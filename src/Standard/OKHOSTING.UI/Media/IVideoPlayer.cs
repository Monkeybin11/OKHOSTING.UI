using System;

namespace OKHOSTING.UI.Media
{
	public interface IVideoPlayer : IControl
	{
		string Source { get; set; }
		void Play();
		void Pause();
		void Stop();
	}
}