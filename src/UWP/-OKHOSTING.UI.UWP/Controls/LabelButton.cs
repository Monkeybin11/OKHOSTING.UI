using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.UWP.Controls
{
	public class LabelButton : Label, ILabelButton
	{
		public LabelButton()
		{
			base.Tapped += LabelButton_Tapped;
		}

		private void LabelButton_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
		{
			if(Click != null)
			{
				Click(sender, new EventArgs());
			}
		}

		public event EventHandler Click;
	}
}