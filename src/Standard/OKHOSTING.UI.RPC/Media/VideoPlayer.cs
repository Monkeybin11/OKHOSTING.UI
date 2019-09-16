using OKHOSTING.UI.Media;
using OKHOSTING.UI.RPC.Controls;

namespace OKHOSTING.UI.RPC.Media
{
	public class VideoPlayer : Control, IVideoPlayer
	{
		public string Source
		{
			get
			{
				return (string) Get(nameof(Source));
			}
			set
			{
				Set(nameof(Source), value);
			}
		}

		public void Play()
		{
			Invoke(nameof(Play));
		}

		public void Pause()
		{
			Invoke(nameof(Pause));
		}

		public void Stop()
		{
			Invoke(nameof(Stop));
		}
	}
}