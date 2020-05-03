using Android.Content;

namespace OKHOSTING.UI.Xamarin.Android.Media
{
	public class OpenFile : UI.Media.IOpenFile
	{
		public void Open(string fullPath)
		{
			var intent = new Intent();
			var mime = Core.MimeTypes.GetMimeType(fullPath);

			intent.SetAction(Intent.ActionView);
			intent.SetDataAndType(global::Android.Net.Uri.Parse(fullPath), mime);
			intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

			global::Android.App.Application.Context.StartActivity(intent);
		}
	}
}