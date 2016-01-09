using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class LabelButton : Label, ILabelButton
	{
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			Platform.Current.DrawBorders(this, pevent);
			base.OnPaint(pevent);
		}
	}
}