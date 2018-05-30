using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class DatePicker : System.Windows.Forms.DateTimePicker, IDatePicker
	{
		public DatePicker()
		{
			base.ValueChanged += Calendar_ValueChanged;
		}

		#region IInputControl

		private void Calendar_ValueChanged(object sender, EventArgs e)
		{
			ValueChanged?.Invoke(this, ((IInputControl<DateTime?>)this).Value);
		}

		DateTime? IInputControl<DateTime?>.Value
		{
			get
			{
				return base.Value;
			}
			set
			{
				if (value.HasValue)
				{
					if(value.Value < base.MinDate)
					{
						base.Value = Value;
					}
					else
					{
						base.Value = value.Value;
					}
				}
			}
		}

		public new event EventHandler<DateTime?> ValueChanged;

		#endregion
	
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

		#region ITextControl

		Color ITextControl.FontColor
		{
			get
			{
				return App.Parse(base.ForeColor);
			}
			set
			{
				base.ForeColor = App.Parse(value);
			}
		}

		string ITextControl.FontFamily
		{
			get
			{
				return base.Font.FontFamily.Name;
			}
			set
			{
				base.Font = new System.Drawing.Font(value, (float)base.FontHeight);
			}
		}

		double ITextControl.FontSize
		{
			get
			{
				return base.FontHeight;
			}
			set
			{
				base.FontHeight = (int)value;
			}
		}

		bool ITextControl.Bold
		{
			get
			{
				return base.Font.Bold;
			}
			set
			{
				base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
			}
		}

		bool ITextControl.Italic
		{
			get
			{
				return base.Font.Italic;
			}
			set
			{
				base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular);
			}
		}

		bool ITextControl.Underline
		{
			get
			{
				return base.Font.Underline;
			}

			set
			{
				base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value ? System.Drawing.FontStyle.Underline : System.Drawing.FontStyle.Regular);
			}
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get; set;
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get; set;
		}

		Thickness ITextControl.TextPadding
		{
			get
			{
				return App.Parse(base.Padding);
			}
			set
			{
				base.Padding = App.Parse(value);
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