/// <summary>
/// Taken from https://blog.xamarin.com/background-audio-streaming-with-xamarin-android/
/// </summary>

using Android.App;
using Android.Content;
using Android.Media;

namespace OKHOSTING.UI.Xamarin.Android.Media
{
	/// <summary>
	/// This is a simple intent receiver that is used to stop playback
	/// when audio become noisy, such as the user unplugged headphones
	/// </summary>
	[BroadcastReceiver]
	[IntentFilter(new []{AudioManager.ActionAudioBecomingNoisy})]
	public class MusicBroadcastReceiver: BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			if (intent.Action == AudioManager.ActionAudioBecomingNoisy)
			{
				//signal the service to stop!
				var stopIntent = new Intent(StreamingBackgroundService.ActionStop);
				context.StartService(stopIntent);
			}
		}
	}
}