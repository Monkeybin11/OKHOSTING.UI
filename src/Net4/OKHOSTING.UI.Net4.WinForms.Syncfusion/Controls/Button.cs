using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Net4.WinForms.Syncfusion.Controls
{
	public class Button : global::Syncfusion.Windows.Forms.ButtonAdv, IButton
	{
		public string FontFamily
		{
			get
			{
				return base.Font.FontFamily.Name;
			}
			set
			{
				base.Font = new Font(value, (float) FontSize);
			}
		}
		public Color FontColor
		{
			get
			{
				return base.ForeColor;
			}
			set 
			{
				base.ForeColor = value;
			}
		}

		public double FontSize
		{
			get
			{
				return base.Font.Size;
			}
			set
			{
				base.Font = new Font(FontFamily, (float) value);
			}
		}

		public bool Bold
		{
			get
			{
				return base.Font.Bold;
			}
			set
			{
				base.Font = new Font(FontFamily, (float) FontSize, FontStyle.Bold);
			}
		}

		public bool Italic { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Underline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public HorizontalAlignment TextHorizontalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public VerticalAlignment TextVerticalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Thickness TextPadding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Color BackgroundColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Color BorderColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Thickness BorderWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public HorizontalAlignment HorizontalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public VerticalAlignment VerticalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string CssClass { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		double? IControl.Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		double? IControl.Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		Thickness IControl.Margin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		Thickness IControl.Padding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		IControl IControl.Parent => throw new NotImplementedException();

		public object Clone()
		{
			throw new NotImplementedException();
		}

		protected FontStyle GetFontStyle()
		{
			FontStyle result = FontStyle.Regular;

			if (Bold || Italic || Underline)
			{
				if (Bold)
				{
					result = FontStyle.Bold;
				}

				if (Italic)
				{
					result = FontStyle.Italic;
				}

				if (Underline)
				{
					result = FontStyle.Underline;
				}
			}
			else
			{
				result = FontStyle.Regular;
			}

			return result;
		}

	}
}