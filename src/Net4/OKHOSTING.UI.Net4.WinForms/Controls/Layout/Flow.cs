using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Net4.WinForms.Controls.Layout
{
	public class Flow : StackBase, IFlow
	{
		public Flow()
		{
			FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
		}
	}
}