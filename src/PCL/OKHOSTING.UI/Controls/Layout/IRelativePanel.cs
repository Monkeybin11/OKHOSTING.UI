using System.Collections.Generic;

namespace OKHOSTING.UI.Controls.Layout
{
	/// <summary>
	/// Inspired by UWP RelativePanel
	/// </summary>
	public interface IRelativePanel : IControl
	{
		IList<IControl> Children { get; }

		IControl GetAbove(IControl control);
		IControl GetBelow(IControl control);
		IControl GetLeftOf(IControl control);
		IControl GetRightOf(IControl control);

		IControl GetAlignBottomWith(IControl control);
		IControl GetAlignHorizontalCenterWith(IControl control);
		IControl GetAlignLeftWith(IControl control);
		IControl GetAlignRightWith(IControl control);
		IControl GetAlignTopWith(IControl control);
		IControl GetAlignVerticalCenterWith(IControl control);

		bool GetAlignBottomWithPanel(IControl control);
		bool GetAlignHorizontalCenterWithPanel(IControl control);
		bool GetAlignLeftWithPanel(IControl control);
		bool GetAlignRightWithPanel(IControl control);
		bool GetAlignTopWithPanel(IControl control);
		bool GetAlignVerticalCenterWithPanel(IControl control);

		void SetAbove(IControl control, IControl relative);
		void SetBelow(IControl control, IControl relative);
		void SetLeftOf(IControl control, IControl relative);
		void SetRightOf(IControl control, IControl relative);

		void SetAlignBottomWith(IControl control, IControl relative);
		void SetAlignBottomWithPanel(IControl control, bool value);
		void SetAlignHorizontalCenterWith(IControl control, IControl relative);
		void SetAlignHorizontalCenterWithPanel(IControl control, bool value);
		void SetAlignLeftWith(IControl control, IControl relative);
		void SetAlignLeftWithPanel(IControl control, bool value);
		void SetAlignRightWith(IControl control, IControl relative);
		void SetAlignRightWithPanel(IControl control, bool value);
		void SetAlignTopWith(IControl control, IControl relative);
		void SetAlignTopWithPanel(IControl control, bool value);
		void SetAlignVerticalCenterWith(IControl control, IControl relative);
		void SetAlignVerticalCenterWithPanel(IControl control, bool value);
	}
}