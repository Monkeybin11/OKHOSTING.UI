using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WinForms.Controls.Layouts
{
	public class Stack : System.Windows.Forms.FlowLayoutPanel, IStack
	{
		public Stack()
		{

			AutoScroll = true;
			FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			WrapContents = false;

			_Children = new ControlList(base.Controls);
		}

	protected readonly ControlList _Children;

        public IList<IControl> Children
		{
			get
			{
				return _Children;
			}
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
					base.Width = (int)value;
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
					base.Height = (int)value;
				}
			}
		}

		Thickness IControl.Margin
		{
			get
			{
				return App.Current.Parse(base.Margin);
			}
			set
			{
				base.Margin = App.Current.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return App.Current.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = App.Current.Parse(value);
			}
		}

		Color IControl.BorderColor { get; set; }

		Thickness IControl.BorderWidth { get; set; }

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return App.Current.Parse(base.Anchor).Item1;
			}
			set
			{
				base.Anchor = App.Current.ParseAnchor(value, ((IControl)this).VerticalAlignment);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.Current.Parse(base.Anchor).Item2;
			}
			set
			{
				base.Anchor = App.Current.ParseAnchor(((IControl)this).HorizontalAlignment, value);
			}
		}

		#endregion

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			var control = (IControl)this;

			//calculate the 4 points or coordinates of the border
			System.Drawing.Point p1 = base.Bounds.Location; //top left

			System.Drawing.Point p2 = base.Bounds.Location;
			p2.Offset(base.Width, 0); //top right

			System.Drawing.Point p3 = base.Bounds.Location; //bottom left
			p2.Offset(0, base.Height * -1); //top right

			System.Drawing.Point p4 = base.Bounds.Location; //bottom right
			p2.Offset(base.Width, base.Height * -1); //top right

			//draw custom border here

			pevent.Graphics.DrawLine(new System.Drawing.Pen(App.Current.Parse(((IButton)this).BorderColor), (float)((IButton)this).BorderWidth.Left), p4, p1); //left
			pevent.Graphics.DrawLine(new System.Drawing.Pen(App.Current.Parse(((IButton)this).BorderColor), (float)((IButton)this).BorderWidth.Left), p1, p2); //top
			pevent.Graphics.DrawLine(new System.Drawing.Pen(App.Current.Parse(((IButton)this).BorderColor), (float)((IButton)this).BorderWidth.Left), p2, p3); //right
			pevent.Graphics.DrawLine(new System.Drawing.Pen(App.Current.Parse(((IButton)this).BorderColor), (float)((IButton)this).BorderWidth.Left), p3, p4); //bottom

			base.OnPaint(pevent);
		}

	}
}