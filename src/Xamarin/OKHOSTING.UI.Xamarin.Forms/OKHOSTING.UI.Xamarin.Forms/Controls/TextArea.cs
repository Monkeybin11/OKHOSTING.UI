using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class TextArea : global::Xamarin.Forms.Editor, ITextArea
	{
		public TextArea()
		{
		}

		public string Name
		{
			get; set;
		}

		public bool Visible
		{
			get
			{
				return base.IsVisible;
			}
			set
			{
				base.IsVisible = value;
			}
		}

		public void Dispose()
		{
		}
	}
}