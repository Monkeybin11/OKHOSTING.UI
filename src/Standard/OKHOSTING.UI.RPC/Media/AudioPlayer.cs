using OKHOSTING.UI.Media;
using System;

namespace OKHOSTING.UI.RPC.Media
{
	public class AudioPlayer: IAudioPlayer
	{
		public string Source { get; set; }
		public void Play() { }
		public void Pause() { }
		public void Stop() { }
	}
}