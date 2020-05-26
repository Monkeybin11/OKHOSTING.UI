using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OKHOSTING.UI.Console.Controls
{
	public class Button : Terminal.Gui.Button, IButton
	{
		public Button(): base(0, 0, null)
		{ }

		public string FontFamily { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Color FontColor { get => base.ColorScheme.Normal; set => throw new NotImplementedException(); }
		public double FontSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Bold { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Italic { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Underline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public HorizontalAlignment TextHorizontalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public VerticalAlignment TextVerticalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Thickness TextPadding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Enabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Thickness Padding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Color BackgroundColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Color BorderColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Thickness BorderWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public object Tag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string CssClass { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		double? IControl.Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		double? IControl.Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		Thickness IControl.Margin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		HorizontalAlignment IControl.HorizontalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		VerticalAlignment IControl.VerticalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		IControl IControl.Parent => throw new NotImplementedException();

		string IButton.Text { get => base.Text.ToString(); set => base.Text = NStack.ustring.Make(value); }

		public event EventHandler Click;

		public object Clone()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}