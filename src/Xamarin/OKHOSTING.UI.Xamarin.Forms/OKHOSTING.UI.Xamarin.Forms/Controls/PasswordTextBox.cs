using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class PasswordTextBox : global::Xamarin.Forms.Entry, IPasswordTextBox
	{
		public PasswordTextBox()
		{
			base.IsPassword = true;
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