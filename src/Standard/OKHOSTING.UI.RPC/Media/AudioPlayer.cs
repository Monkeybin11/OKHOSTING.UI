using OKHOSTING.UI.Media;

namespace OKHOSTING.UI.RPC.Media
{
	public class AudioPlayer : OKHOSTING.RPC.Bidireccional.ServerObject, IAudioPlayer
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