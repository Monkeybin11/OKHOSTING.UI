using Foundation;
using UIKit;

namespace OKHOSTING.UI.Xamarin.iOS.Media
{
	public class OpenFile : UI.Media.IOpenFile
	{
		public void Open(string fullPath)
		{
			var PreviewController = UIDocumentInteractionController.FromUrl(NSUrl.FromFilename(fullPath));
			PreviewController.Delegate = new UIDocumentInteractionControllerDelegateClass(UIApplication.SharedApplication.KeyWindow.RootViewController);
			PreviewController.PresentPreview(true);
		}

		public class UIDocumentInteractionControllerDelegateClass : UIDocumentInteractionControllerDelegate
		{
			UIViewController ownerVC;

			public UIDocumentInteractionControllerDelegateClass(UIViewController vc)
			{
				ownerVC = vc;
			}

			public override UIViewController ViewControllerForPreview(UIDocumentInteractionController controller)
			{
				return ownerVC;
			}

			public override UIView ViewForPreview(UIDocumentInteractionController controller)
			{
				return ownerVC.View;
			}
		}
	}
}