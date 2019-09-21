using OKHOSTING.UI.Controls;
using System;
using System.Drawing;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class LabelButton : Label, ILabelButton
	{
		public LabelButton()
		{
			base.MouseUp += LabelButton_MouseUp;
		}

		private void LabelButton_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Click?.Invoke(this, e);
		}

		public event EventHandler Click;
	}
}