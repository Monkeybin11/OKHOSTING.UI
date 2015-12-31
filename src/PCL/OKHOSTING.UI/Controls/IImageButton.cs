using System;

namespace OKHOSTING.UI.Controls
{
	public interface IImageButton: IImage
	{
		/// <summary>
		/// Raises after the user clicked on the image
		/// </summary>
		event EventHandler Click;
	}
}