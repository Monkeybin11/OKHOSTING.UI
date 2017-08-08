using System;

namespace OKHOSTING.UI.Media
{
	public interface IAudioPlayer
	{
		Uri Source { get; set; }
		void Play();
		void Pause();
		void Stop();
	}
}