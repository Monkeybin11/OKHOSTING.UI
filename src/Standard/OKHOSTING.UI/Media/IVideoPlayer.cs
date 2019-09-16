using System;

namespace OKHOSTING.UI.Media
{
	public interface IVideoPlayer : Controls.IControl
	{
		string Source { get; set; }
		void Play();
		void Pause();
		void Stop();
	}
}