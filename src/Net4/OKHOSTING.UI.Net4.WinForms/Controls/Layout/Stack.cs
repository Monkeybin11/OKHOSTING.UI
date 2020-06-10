using System;
using System.Collections.Generic;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Net4.WinForms.Controls.Layout
{
	public class Stack : System.Windows.Forms.FlowLayoutPanel, IStack
	{
		private readonly ControlList _Children;
		
		public Stack()
		{

			AutoScroll = true;
			AutoSize = true;
			FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			WrapContents = false;

			_Children = new ControlList(base.Controls);

			SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
		}

		ICollection<IControl> IContainer.Children
		{
			get
			{
				return _Children;
			}
		}

		IImage IContainer.BackgroundImage
		{
			get;
			set;
		}

		#region IControl

		double? IControl.Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = (int) value;
				}
			}
		}

		double? IControl.Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = (int) value;
				}
			}
		}

		Thickness IControl.Margin
		{
			get
			{
				return Platform.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Parse(value);
			}
		}

		Thickness IControl.Padding
		{
			get
			{
				return Platform.Parse(base.Padding);
			}
			set
			{
				base.Padding = Platform.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = Platform.Parse(value);
			}
		}

		Color IControl.BorderColor { get; set; }

		Thickness IControl.BorderWidth { get; set; }

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Parse(base.Anchor).Item1;
			}
			set
			{
				base.Anchor = Platform.ParseAnchor(value, ((IControl)this).VerticalAlignment);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Parse(base.Anchor).Item2;
			}
			set
			{
				base.Anchor = Platform.ParseAnchor(((IControl)this).HorizontalAlignment, value);
			}
		}

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		string IControl.CssClass { get; set; }

		/// <summary>
		/// Control that contains this control, like a grid, or stack
		/// </summary>
		IControl IControl.Parent
		{
			get
			{
				return (IControl) base.Parent;
			}
		}

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}

		#endregion

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			Platform.DrawBackgroundImage(this, e);
			Platform.DrawBorders(this, e);
			base.OnPaint(e);
		}
	}
}