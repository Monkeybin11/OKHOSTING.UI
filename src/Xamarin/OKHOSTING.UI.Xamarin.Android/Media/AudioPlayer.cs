using Android.Content;
using OKHOSTING.UI.Media;

namespace OKHOSTING.UI.Xamarin.Android.Media
{
	/// <summary>
	/// REQUIRES WAKELOCK PERMISSION
	/// </summary>
	public class AudioPlayer : IAudioPlayer
	{
		protected string _Source;

		public string Source
		{
			get
			{
				return _Source;
			}
			set
			{
				_Source = value;

				Intent intent = new Intent(StreamingBackgroundService.ActionSource);
				intent.PutExtra("source", value);
				global::Android.App.Application.Context.StartService(intent);
			}
		}

		public void Pause()
		{
			Intent intent = new Intent(StreamingBackgroundService.ActionPause);
			global::Android.App.Application.Context.StartService(intent);
		}

		public void Play()
		{
			Intent intent = new Intent(StreamingBackgroundService.ActionPlay);
			global::Android.App.Application.Context.StartService(intent);
		}

		public void Stop()
		{
			Intent intent = new Intent(StreamingBackgroundService.ActionStop);
			global::Android.App.Application.Context.StartService(intent);
		}
	}
}