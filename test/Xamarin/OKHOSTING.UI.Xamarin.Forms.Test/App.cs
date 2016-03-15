using System;
using Un4seen.Bass;

namespace OKHOSTING.UI.Xamarin.Forms.Test
{
	public class App : global::Xamarin.Forms.Application
	{
		public App ()
		{
			// init BASS using the default output device 
			if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
			{
				// create a stream channel from a file 
				int channel = Bass.BASS_StreamCreateURL("http://148.202.165.1:8000/;stream/1", 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);
				Bass.BASS_ChannelPlay(channel, false);

				// free the stream
				Bass.BASS_StreamFree(channel);
				// free BASS
				Bass.BASS_Free();
			}

			//Platform.Current.Page = new Page();
			//MainPage = (global::Xamarin.Forms.Page) Platform.Current.Page;
			//new OKHOSTING.UI.Test.IndexController().Start();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}