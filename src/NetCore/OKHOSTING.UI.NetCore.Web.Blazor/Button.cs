using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.NetCore.Web.Blazor
{
	class Button : Radzen.Blazor.RadzenButton, IButton
	{
		public string FontFamily
		{
			get 
			{
				return base.CurrentStyle["font-family"];
			}
			set 
			{
				base.CurrentStyle["font-family"] = value;
			}
		}

		public Color FontColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public double FontSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Bold { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Italic { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Underline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public HorizontalAlignment TextHorizontalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public VerticalAlignment TextVerticalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Thickness TextPadding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Enabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public double? Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public double? Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Thickness Margin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Thickness Padding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Color BackgroundColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Color BorderColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Thickness BorderWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public HorizontalAlignment HorizontalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public VerticalAlignment VerticalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public object Tag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string CssClass { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public IControl Parent => throw new NotImplementedException();

		event EventHandler IClickable.Click
		{
			add
			{
				throw new NotImplementedException();
			}

			remove
			{
				throw new NotImplementedException();
			}
		}

		public object Clone()
		{
			throw new NotImplementedException();
		}

		public bool Focus()
		{
			throw new NotImplementedException();
		}
	}
}