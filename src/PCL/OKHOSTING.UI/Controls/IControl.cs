using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// Base interface for all user controls
	/// </summary>
	public interface IControl: IDisposable
	{
		/// <summary>
		/// Friendly name (or id) of the control. A simple view should not contain 2 controls with the same name.
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
		double Width { get; set; }

		/// <summary>
		/// Height of the control, in density independent pixels
		/// </summary>
		double Height { get; set; }

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
	}
}