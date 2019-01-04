using OKHOSTING.UI.Media;
using System;

namespace OKHOSTING.UI.Remote.Media
{
	public class AudioPlayer: IAudioPlayer
	{
		public Uri Source { get; set; }
		public void Play() { }
		public void Pause() { }
		public void Stop() { }
	}
}