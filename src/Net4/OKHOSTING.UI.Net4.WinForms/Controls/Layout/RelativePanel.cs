using System;
using System.Drawing;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using NativeControl = System.Windows.Forms.Control;

namespace OKHOSTING.UI.Net4.WinForms.Controls.Layout
{
	public class RelativePanel : System.Windows.Forms.Panel, IRelativePanel
	{
		public RelativePanel()
		{
			//AutoScroll = true;
			_Children = new ControlList(base.Controls);
			//base.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			//| System.Windows.Forms.AnchorStyles.Left)
			//| System.Windows.Forms.AnchorStyles.Right)));
		}

		protected readonly ControlList _Children;

		ICollection<IControl> IContainer.Children
		{
			get
			{
				return _Children;
			}
		}

		void IRelativePanel.Add(IControl control, RelativePanelHorizontalContraint horizontalContraint, RelativePanelVerticalContraint verticalContraint, IControl referenceControl)
		{
			if (control == null)
			{
				throw new ArgumentNullException(nameof(control));
			}

			//if no reference control is provided, then use this panel as reference
			if (referenceControl == null)
			{
				referenceControl = this;
			}

			NativeControl nativeControl = (NativeControl) control;
			NativeControl nativeReference = (NativeControl) referenceControl;
			Point location = new Point();
			
			switch (horizontalContraint)
			{
				case RelativePanelHorizontalContraint.CenterWith:
					location.X = nativeReference.Location.X + (nativeReference.Width / 2) - (nativeControl.Width / 2);
					break;

				case RelativePanelHorizontalContraint.LeftOf:
					location.X = nativeReference.Location.X - nativeControl.Width;
					break;

				case RelativePanelHorizontalContraint.LeftWith:
					location.X = nativeReference.Location.X;
					break;

				case RelativePanelHorizontalContraint.RightOf:
					location.X = nativeReference.Location.X + nativeReference.Width + nativeControl.Width;
					break;

				case RelativePanelHorizontalContraint.RightWith:
					location.X = nativeReference.Location.X + nativeReference.Width;
					break;
			}

			//vertical constraint

			switch (verticalContraint)
			{
				case RelativePanelVerticalContraint.AboveOf:
					location.Y = nativeReference.Location.Y - nativeControl.Height;
					break;

				case RelativePanelVerticalContraint.BelowOf:
					location.Y = nativeReference.Location.Y + nativeReference.Height;
					break;

				case RelativePanelVerticalContraint.BottomWith:
					location.Y = nativeReference.Location.Y + nativeReference.Height - nativeControl.Height;
					break;

				case RelativePanelVerticalContraint.CenterWith:
					location.Y = nativeReference.Location.Y + (nativeReference.Height / 2) - (nativeControl.Height / 2);
					break;

				case RelativePanelVerticalContraint.TopWith:
					location.Y = nativeReference.Location.Y;
					break;
			}

			((NativeControl)control).Location = location;
			base.Controls.Add((NativeControl) control);
		}

		protected bool arranged = false;

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			//invert child index of controls so they are shown in the order which they where added
			if (!arranged)
			{
				foreach (NativeControl control in base.Controls)
				{
					control.BringToFront();
				}

				arranged = true;
			}

			Platform.DrawBorders(this, pevent);
			base.OnPaint(pevent);

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
				return Platform.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Parse(value);
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
				base.BackColor = value;
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

		#endregion
	}
}