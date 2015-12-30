using System;

namespace OKHOSTING.UI.Controls
{
	public interface IImageButton: IImage
	{
		event EventHandler Click;
	}
}