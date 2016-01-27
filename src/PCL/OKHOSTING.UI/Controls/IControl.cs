using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// Base interface for all user controls
	/// </summary>
	public interface IControl: IDisposable
	{
		/// <summary>
		/// Friendly programming name (or id) of the control. A simple view should not contain 2 controls with the same name.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets wether the control is visible or not
		/// </summary>
		bool Visible { get; set; }

		/// <summary>
		/// Gets or sets wether the control is enabled or not
		/// </summary>
		bool Enabled { get; set; }

		/// <summary>
		/// Width of the control, in density independent pixels
		/// </summary>
		double? Width { get; set; }

		/// <summary>
		/// Height of the control, in density independent pixels
		/// </summary>
		double? Height { get; set; }

		/// <summary>
		/// Space that this control will set between itself and it's container
		/// </summary>
		Thickness Margin { get; set; }

		/// <summary>
		/// Background color
		/// </summary>
		Color BackgroundColor { get; set; }

		/// <summary>
		/// Border color
		/// </summary>
		Color BorderColor { get; set; }

		/// <summary>
		/// Border width, in density independent pixels (DIP)
		/// </summary>
		Thickness BorderWidth { get; set; }

		/// <summary>
		/// Horizontal alignment of the control with respect to it's container
		/// </summary>
		HorizontalAlignment HorizontalAlignment { get; set; }

		/// <summary>
		/// Vertical alignment of the control with respect to it's container
		/// </summary>
		VerticalAlignment VerticalAlignment { get; set; }

        /// <summary>
        /// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
        /// </summary>
        /// <remarks>
        /// Returns the intended value. This property has no default value.
        /// </remmarks>
        object Tag { get; set; }
    }
}