using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OKHOSTING.UI.Net4.Ajax.Controls
{
	public abstract class TextControl : Control, UI.Controls.ITextControl
	{
		public bool Bold
		{
			get;
			set;
		}

		public Color FontColor
		{
			get;
			set;
		}

		public string FontFamily
		{
			get;
			set;
		}

		public double FontSize
		{
			get;
			set;
		}

		public bool Italic
		{
			get;
			set;
		}

		public HorizontalAlignment TextHorizontalAlignment
		{
			get;
			set;
		}

		public Thickness TextPadding
		{
			get;
			set;
		}

		public VerticalAlignment TextVerticalAlignment
		{
			get;
			set;
		}

		public bool Underline
		{
			get;
			set;
		}
	}
}