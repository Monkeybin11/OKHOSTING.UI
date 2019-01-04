using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Remote.Controls
{
	public class VideoPlayer : Control, IVideoPlayer
	{
		public Uri Source { get; set; }
		public void Play() { }
		public void Pause() { }
		public void Stop() { }
	}
}