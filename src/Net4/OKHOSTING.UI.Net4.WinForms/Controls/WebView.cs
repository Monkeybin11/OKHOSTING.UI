﻿using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class WebView: System.Windows.Forms.WebBrowser, IWebView
	{
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
				base.Anchor = App.ParseAnchor(value, ((IControl) this).VerticalAlignment);
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
				base.Anchor = App.ParseAnchor(((IControl) this).HorizontalAlignment, value);
			}
		}

		#endregion

		public Uri Source
		{
			get
			{
				return base.Url;
			}
			set
			{
				base.Url = value;
			}
		}
	}
}