namespace OKHOSTING.UI.Media
{
	/// <summary>
	/// Represents a class that can play audio in the local device
	/// </summary>
	public interface IAudioPlayer
	{
		/// <summary>
		/// Source of the audio
		/// </summary>
		string Source { get; set; }

		void Play();
		void Pause();
		void Stop();
	}
}