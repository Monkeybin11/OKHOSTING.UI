using System.Collections.Generic;

namespace OKHOSTING.UI.Controls.Layout
{
	/// <summary>
	/// Inspired by UWP RelativePanel
	/// </summary>
	public interface IRelativePanel : IControl
	{
		IList<IControl> Children { get; }

		void SetAbove(IControl control, IControl relative);
		void SetBelow(IControl control, IControl relative);
		void SetLeftOf(IControl control, IControl relative);
		void SetRightOf(IControl control, IControl relative);

		void SetAlignBottomWith(IControl control, IControl relative);
		void SetAlignBottomWithPanel(IControl control);
		void SetAlignHorizontalCenterWith(IControl control, IControl relative);
		void SetAlignHorizontalCenterWithPanel(IControl control);
		void SetAlignLeftWith(IControl control, IControl relative);
		void SetAlignLeftWithPanel(IControl control);
		void SetAlignRightWith(IControl control, IControl relative);
		void SetAlignRightWithPanel(IControl control);
		void SetAlignTopWith(IControl control, IControl relative);
		void SetAlignTopWithPanel(IControl control);
		void SetAlignVerticalCenterWith(IControl control, IControl relative);
		void SetAlignVerticalCenterWithPanel(IControl control);
	}
}