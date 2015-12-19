namespace OKHOSTING.UI.Controls.Styles
{
	/// <summary>
	/// Represents a style that can be applied to multiple IControls
	/// </summary>
	public class ControlStyle
	{
		/// <summary>
		/// Name of the style
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets wether the control is visible or not
		/// </summary>
		public bool Visible { get; set; }

		/// <summary>
		/// Width of the control, in density independent pixels
		/// </summary>
		public double? Width { get; set; }

		/// <summary>
		/// Height of the control, in density independent pixels
		/// </summary>
		public double? Height { get; set; }

		/// <summary>
		/// Space that this control will set between itself and it's container
		/// </summary>
		public Thickness Margin { get; set; }

		/// <summary>
		/// Background color
		/// </summary>
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// Border color
		/// </summary>
		public Color BorderColor { get; set; }

		/// <summary>
		/// Border width, in density independent pixels (DIP)
		/// </summary>
		public Thickness BorderWidth { get; set; }

		/// <summary>
		/// Horizontal alignment of the control with respect to it's container
		/// </summary>
		public HorizontalAlignment HorizontalAlignment { get; set; }

		/// <summary>
		/// Vertical alignment of the control with respect to it's container
		/// </summary>
		public VerticalAlignment VerticalAlignment { get; set; }

		/// <summary>
		/// Applies this style tho the provided IControl
		/// </summary>
		public virtual void ApplyTo(IControl control)
		{
			control.Visible = this.Visible;
			control.Width = this.Width;
			control.Height = this.Height;
			control.Margin = this.Margin;
			control.BackgroundColor = this.BackgroundColor;
			control.BorderColor = this.BorderColor;
			control.BorderWidth = this.BorderWidth;
			control.HorizontalAlignment = this.HorizontalAlignment;
			control.VerticalAlignment = this.VerticalAlignment;
		}
	}
}