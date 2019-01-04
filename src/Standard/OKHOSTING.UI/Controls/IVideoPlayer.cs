using System;

namespace OKHOSTING.UI.Controls
{
	public interface IVideoPlayer : IControl
	{
		Uri Source { get; set; }
		void Play();
		void Pause();
		void Stop();
	}
}