/// <summary>
/// Taken from https://blog.xamarin.com/background-audio-streaming-with-xamarin-android/
/// </summary>

using Android.App;
using Android.Content;
using Android.Media;
using Android.Net;
using Android.Net.Wifi;
using Android.OS;
using Android.Support.V4.App;
using System;

namespace OKHOSTING.UI.Xamarin.Android.Media
{
	[Service]
	[IntentFilter(new[] { ActionPlay, ActionPause, ActionStop, ActionSource })]
	public class StreamingBackgroundService : Service, AudioManager.IOnAudioFocusChangeListener
	{
		//Actions
		public const string ActionPlay = "OKHOSTING.Streaming.Xamarin.Android.action.PLAY";
		public const string ActionPause = "OKHOSTING.Streaming.Xamarin.Android.action.PAUSE";
		public const string ActionStop = "OKHOSTING.Streaming.Xamarin.Android.action.STOP";
		public const string ActionSource = "OKHOSTING.Streaming.Xamarin.Android.action.SOURCE";

		private System.Uri Source { get; set; }

		private MediaPlayer player;
		private AudioManager audioManager;
		private WifiManager wifiManager;
		private WifiManager.WifiLock wifiLock;
		private bool paused;

		private const int NotificationId = 100;

		/// <summary>
		/// On create simply detect some of our managers
		/// </summary>
		public override void OnCreate()
		{
			base.OnCreate();
			//Find our audio and notificaton managers
			audioManager = (AudioManager) GetSystemService(AudioService);
			wifiManager = (WifiManager) GetSystemService(WifiService);
		}

		/// <summary>
		/// Don't do anything on bind
		/// </summary>
		/// <param name="intent"></param>
		/// <returns></returns>
		public override IBinder OnBind(Intent intent)
		{
			return null;
		}

		public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			switch (intent.Action)
			{
				case ActionPlay: Play(); break;
				case ActionStop: Stop(); break;
				case ActionPause: Pause(); break;

				case ActionSource:
					Source = new System.Uri(intent.GetStringExtra("source"));
					break;
			}

			//Set sticky as we are a long running operation
			return StartCommandResult.Sticky;
		}

		private void IntializePlayer()
		{
			player = new MediaPlayer();

			//Tell our player to sream music
			player.SetAudioStreamType(Stream.Music);

			//Wake mode will be partial to keep the CPU still running under lock screen
			player.SetWakeMode(ApplicationContext, WakeLockFlags.Partial);

			//When we have prepared the song start playback
			player.Prepared += (sender, args) => player.Start();

			//When we have reached the end of the song stop ourselves, however you could signal next track here.
			player.Completion += (sender, args) => Stop();

			player.Error += (sender, args) =>
			{
				//playback error
				Console.WriteLine("Error in playback resetting: " + args.What);
				Stop();//this will clean up and reset properly.
			};
		}

		private async void Play()
		{
			if (paused && player != null)
			{
				paused = false;
				//We are simply paused so just start again
				player.Start();
				StartForeground();

				return;
			}

			if (player == null)
			{
				IntializePlayer();
			}

			if (player.IsPlaying)
				return;

			await player.SetDataSourceAsync(ApplicationContext, global::Android.Net.Uri.Parse(Source.ToString()));
				
			var focusResult = audioManager.RequestAudioFocus(this, Stream.Music, AudioFocus.Gain);

			if (focusResult != AudioFocusRequest.Granted)
			{
				//could not get audio focus
				Console.WriteLine("Could not get audio focus");
			}
				
			player.Prepare();
			AquireWifiLock();
			StartForeground();
		}

		private void Pause()
		{
			if (player == null)
				return;

			if(player.IsPlaying)
				player.Pause();

			StopForeground(true);
			paused = true;
		}

		private void Stop()
		{
			if (player == null)
				return;

			if(player.IsPlaying)
				player.Stop();

			player.Reset();
			paused = false;
			StopForeground(true);
			ReleaseWifiLock();
		}

		/// <summary>
		/// Lock the wifi so we can still stream under lock screen
		/// </summary>
		private void AquireWifiLock()
		{
			if (wifiLock == null)
			{
				wifiLock = wifiManager.CreateWifiLock(WifiMode.Full, "xamarin_wifi_lock");
			} 

			wifiLock.Acquire();
		}

		/// <summary>
		/// This will release the wifi lock if it is no longer needed
		/// </summary>
		private void ReleaseWifiLock()
		{
			if (wifiLock == null)
				return;

			wifiLock.Release();
			wifiLock = null;
		}

		/// <summary>
		/// Properly cleanup of your player by releasing resources
		/// </summary>
		public override void OnDestroy()
		{
			base.OnDestroy();
			if (player != null)
			{
				player.Release();
				player = null;
			}
		}

		/// <summary>
		/// For a good user experience we should account for when audio focus has changed.
		/// There is only 1 audio output there may be several media services trying to use it so
		/// we should act correctly based on this.  "duck" to be quiet and when we gain go full.
		/// All applications are encouraged to follow this, but are not enforced.
		/// </summary>
		/// <param name="focusChange"></param>
		public void OnAudioFocusChange(AudioFocus focusChange)
		{
			switch (focusChange)
			{
				case AudioFocus.Gain:
					if (player == null)
						IntializePlayer();

					if (!player.IsPlaying)
					{
						player.Start();
						paused = false;
					}
					
					player.SetVolume(1.0f, 1.0f);//Turn it up!
					break;
				case AudioFocus.Loss:
					//We have lost focus stop!
					Stop();
					break;
				case AudioFocus.LossTransient:
					//We have lost focus for a short time, but likely to resume so pause
					Pause();
					break;
				case AudioFocus.LossTransientCanDuck:
					//We have lost focus but should till play at a muted 10% volume
					if(player.IsPlaying)
						player.SetVolume(.1f, .1f);//turn it down!
					break;

			}
		}

		/// <summary>
		/// When we start on the foreground we will present a notification to the user
		/// When they press the notification it will take them to the main page so they can control the music
		/// </summary>
		private void StartForeground()
		{
			if (ReturnTo == null)
			{
				return;
			}

			var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, ReturnTo), 0);

			NotificationCompat.Builder builder = new NotificationCompat.Builder(this);
			builder.SetTicker("Señal Global");
			builder.SetContentTitle("Señal Global");
			builder.SetContentText("Estas escuchando Señal Global");
			builder.SetContentIntent(pendingIntent);
			builder.SetOngoing(true);
			builder.SetCategory(Notification.CategoryService);
			builder.SetSmallIcon(Resource.Drawable.icon);

			StartForeground(NotificationId, builder.Build());
		}


		/// <summary>
		/// The type of activity where control must be returned when clicking on the 
		/// "notification icon" once the audio playing begins. Must be a subclass of Activity
		/// </summary>
		public static Type ReturnTo { get; set; }
	}
}