using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class ListPicker : System.Windows.Forms.ComboBox, IListPicker
	{
        public ListPicker()
        {
            base.SelectedIndexChanged += ListPicker_SelectedIndexChanged;
        }

        private void ListPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItemChanged != null)
            {
                SelectedItemChanged(sender, e);
            }
        }

        IEnumerable<string> IListPicker.DataSource
		{
			get
			{
				return (IEnumerable<string>) base.DataSource;
			}
			set
			{
				base.DataSource = value;
			}
		}

		string IListPicker.SelectedItem
		{
			get
			{
				return (string) base.SelectedValue;
			}
			set
			{
				base.SelectedValue = value;
			}
		}

        public event EventHandler SelectedItemChanged;

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
				return Platform.Current.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Current.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Current.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = Platform.Current.Parse(value);
			}
		}

		Color IControl.BorderColor { get; set; }

		Thickness IControl.BorderWidth { get; set; }

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.Anchor).Item1;
			}
			set
			{
				base.Anchor = Platform.Current.ParseAnchor(value, ((IControl)this).VerticalAlignment);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.Anchor).Item2;
			}
			set
			{
				base.Anchor = Platform.Current.ParseAnchor(((IControl)this).HorizontalAlignment, value);
			}
		}

		#endregion

		#region ITextControl

		Color ITextControl.FontColor
		{
			get
			{
				return Platform.Current.Parse(base.ForeColor);
			}
			set
			{
				base.ForeColor = Platform.Current.Parse(value);
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
			get
			{
				return HorizontalAlignment.Left;
			}
			set
			{
				//do nothing since dis control doe snot dupport text elignment
			}
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				return VerticalAlignment.Top;
			}
			set
			{
				//do nothing since dis control doe snot dupport text elignment
			}
		}

		Thickness ITextControl.TextPadding
		{
			get
			{
				return Platform.Current.Parse(base.Padding);
			}
			set
			{
				base.Padding = Platform.Current.Parse(value);
			}
		}

        #endregion

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
		{
			Platform.Current.DrawBorders(this, pevent);
			base.OnPaint(pevent);
		}
	}
}