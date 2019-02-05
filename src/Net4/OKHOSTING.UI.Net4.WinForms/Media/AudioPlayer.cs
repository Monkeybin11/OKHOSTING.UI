using NAudio.Wave;

namespace OKHOSTING.UI.Net4.WinForms.Media
{
	public class AudioPlayer : UI.Media.IAudioPlayer
	{
		protected IWavePlayer WaveOutDevice;
		protected AudioFileReader AudioFileReader;

		public string Source { get; set; }

		public void Pause()
		{
			WaveOutDevice.Pause();
		}

		public void Play()
		{
			WaveOutDevice = new WaveOut();
			AudioFileReader = new AudioFileReader(Source);

			WaveOutDevice.Init(AudioFileReader);
			WaveOutDevice.Play();
		}

		public void Stop()
		{
			WaveOutDevice.Stop();
			AudioFileReader.Dispose();
			WaveOutDevice.Dispose();
		}
	}
}