using System.Collections.Generic;

namespace OKHOSTING.UI.Controls.Layout
{
	/// <summary>
	/// Inspired by UWP and Xamarin.Forms RelativePanel's
	/// </summary>
	public interface IRelativePanel : IControl
	{
		IList<IControl> Children { get; }

		/// <summary>
		/// Adds a control to the panel and positions it using the constraints and references given
		/// </summary>
		/// <param name="control">
		/// Control to add and position to the panel
		/// </param>
		/// <param name="horizontalContraint">
		/// Horizontal constraint to use
		/// </param>
		/// <param name="horizontalReference">
		/// Control that will be used as a reference for the horizontal constriant. 
		/// If value is NULL, then the reference will be the panel itself
		/// </param>
		/// <param name="verticalContraint">
		/// Vertical constraint to use
		/// </param>
		/// <param name="verticalReference">
		/// Control that will be used as a reference for the vertical constriant. 
		/// If value is NULL, then the reference will be the panel itself
		/// </param>
		void Add(IControl control, RelativePanelHorizontalContraint horizontalContraint, IControl horizontalReference, RelativePanelVerticalContraint verticalContraint, IControl verticalReference);
	}

	public enum RelativePanelHorizontalContraint
	{
		/// <summary>
		/// The horizontal center of the control is aligned with the horizontal center of the reference
		/// </summary>
		CenterWith,

		/// <summary>
		/// The left border of the control is aligned with the left border of the reference
		/// </summary>
		LeftWith,

		/// <summary>
		/// The right border of the control is aligned with the right border of the reference
		/// </summary>
		RightWith,

		/// <summary>
		/// The right border of the control is aligned with the left border of the reference
		/// </summary>
		LeftOf,

		/// <summary>
		/// The left border oh the control is aligned with the right border of the reference
		/// </summary>
		RightOf,
	}

	public enum RelativePanelVerticalContraint
	{
		/// <summary>
		/// The vertical center of the control is aligned with the vertical center of the reference
		/// </summary>
		CenterWith,

		/// <summary>
		/// The top border of the control is aligned with the top border of the reference
		/// </summary>
		TopWith,

		/// <summary>
		/// The bottom border of the control is aligned with the bottom border of the reference
		/// </summary>
		BottomWith,

		/// <summary>
		/// The bottom border of the control is aligned with the top border of the reference
		/// </summary>
		AboveOf,

		/// <summary>
		/// The top border oh the control is aligned with the bottom border of the reference
		/// </summary>
		BelowOf,
	}
}