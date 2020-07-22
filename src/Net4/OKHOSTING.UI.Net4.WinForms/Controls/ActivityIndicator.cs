using OKHOSTING.UI.Controls;
using System;
using System.Drawing;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class ActivityIndicator : System.Windows.Forms.Panel, IActivityIndicator
	{
		bool _IsRunning;

		public ActivityIndicator()
		{
			Visible = false;
		}

		public bool IsRunning 
		{
			get
			{
				return _IsRunning;
			}
			set
			{
				_IsRunning = value;

				if (value)
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				}
				else
				{ 
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				}
			} 
		}
		
		public Color Color 
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
				base.Anchor = Platform.ParseAnchor(value, ((IControl) this).VerticalAlignment);
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
				base.Anchor = Platform.ParseAnchor(((IControl) this).HorizontalAlignment, value);
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
	}
}