using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Net4.WinForms.Controls.Layout
{
	public class Flow : System.Windows.Forms.FlowLayoutPanel, IFlow
	{
		public Flow()
		{
			AutoScroll = true;
			FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
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
				return App.Parse(base.Margin);
			}
			set
			{
				base.Margin = App.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return App.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = App.Parse(value);
			}
		}

		Color IControl.BorderColor { get; set; }

		Thickness IControl.BorderWidth { get; set; }

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return App.Parse(base.Anchor).Item1;
			}
			set
			{
				base.Anchor = App.ParseAnchor(value, ((IControl)this).VerticalAlignment);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.Parse(base.Anchor).Item2;
			}
			set
			{
				base.Anchor = App.ParseAnchor(((IControl)this).HorizontalAlignment, value);
			}
		}

		#endregion

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			App.DrawBorders(this, pevent);
			base.OnPaint(pevent);
		}
	}
}