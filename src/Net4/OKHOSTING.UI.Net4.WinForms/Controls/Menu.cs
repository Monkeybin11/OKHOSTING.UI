using OKHOSTING.UI.Controls;
using System.Drawing;
using System.Collections.Generic;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Menu : System.Windows.Forms.MenuStrip, IMenu
	{
		public Menu()
		{
			base.ItemClicked += Menu_ItemClicked;
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
				base.BackColor = Platform.RemoveAlpha(value);
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
				return (IControl)base.Parent;
			}
		}

		#endregion

		#region ITextControl

		/// <summary>
		/// Private member to store the FontColor
		/// </summary>
		private Color _FontColor;

		Color ITextControl.FontColor
		{
			get
			{
				return _FontColor;
			}
			set
			{
				_FontColor = value;
				base.ForeColor = Platform.RemoveAlpha(value);
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
				base.Font = new Font(value, (float) base.FontHeight);
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
				base.Font = new Font(Font.Name, base.Font.Size, value ? FontStyle.Bold : FontStyle.Regular);
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
				base.Font = new Font(Font.Name, base.Font.Size, value ? FontStyle.Italic : FontStyle.Regular);
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
				base.Font = new Font(Font.Name, base.Font.Size, value ? FontStyle.Underline : FontStyle.Regular);
			}
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get;
			set;
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get;
			set;
		}

		Thickness ITextControl.TextPadding
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

		#endregion

		ICollection<IMenuItem> IMenu.Items { get; set; }

		private void Menu_ItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
		{
			
		}

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			DataBind();
			base.OnPaint(e);
		}

		protected System.Windows.Forms.ToolStripMenuItem Parse(IMenuItem item)
		{
			var nativeItem = new System.Windows.Forms.ToolStripMenuItem(item.Text, null, (sender, e) => item.Click(sender, e));
			nativeItem.Font = Font;
			nativeItem.BackColor = BackColor;
			nativeItem.ForeColor = ForeColor;
			nativeItem.TextAlign = Platform.ParseContentAlignment(((ITextControl)this).TextHorizontalAlignment, ((ITextControl)this).VerticalAlignment);
			
			foreach (var child in item.Children)
			{
				nativeItem.DropDownItems.Add(Parse(child));
			}

			return nativeItem;
		}

		protected void DataBind()
		{
			base.Items.Clear();

			foreach (var item in ((IMenu) this).Items)
			{
				base.Items.Add(Parse(item));
			}
		}
	}
}