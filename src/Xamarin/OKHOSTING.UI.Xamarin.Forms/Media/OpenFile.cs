using OKHOSTING.UI.Media;
using global::Xamarin.Essentials;

namespace OKHOSTING.UI.Xamarin.Forms.Media
{
	public class OpenFile : IOpenFile
	{
		public async void Open(string fullPath)
		{
			await Launcher.OpenAsync(new OpenFileRequest
			{
				File = new ReadOnlyFile(fullPath)
			});
		}
	}
}