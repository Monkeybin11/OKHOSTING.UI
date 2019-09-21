using System;
using Foundation;
using AVFoundation;
using OKHOSTING.UI.Media;

namespace OKHOSTING.UI.Xamarin.iOS.Media
{
	public class AudioPlayer: IAudioPlayer
	{
		StreamingPlayback Playback;
		string PlayingURI = null;
		public bool IsPlaying = false;

		public AudioPlayer()
		{ 
			Playback = new StreamingPlayback ();

			NSError error;
			var session = AVAudioSession.SharedInstance();
			session.SetCategory (AVAudioSessionCategory.Playback, AVAudioSessionCategoryOptions.DefaultToSpeaker);
			session.OverrideOutputAudioPort (AVAudioSessionPortOverride.Speaker, out error);
		}

		public void Play ()
		{
			IsPlaying = true;

			if (PlayingURI != Source || Playback == null)
			{
				if (Playback != null)
				{
					Playback.Dispose();
				}

				Playback = new StreamingPlayback ();

				NSError error;
				var session = AVAudioSession.SharedInstance ();
				session.SetCategory (AVAudioSessionCategory.Playback, AVAudioSessionCategoryOptions.DefaultToSpeaker);
				session.OverrideOutputAudioPort (AVAudioSessionPortOverride.Speaker, out error);

				Playback.Play (new Uri(Source));
				PlayingURI = Source;
			}
			else if(PlayingURI == Source)
			{
				Playback.Play ();
			}
		}

		public void Pause ()
		{
			Playback.Pause ();
			IsPlaying = false;
		}

		public void Stop ()
		{
			Playback.Stop ();
			Playback = null;
			IsPlaying = false;
		}

		public string Source 
		{
			get;
			set;
		}
	}
}