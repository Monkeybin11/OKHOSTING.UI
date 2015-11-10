using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class Button : global::Xamarin.Forms.Button, IButton
	{
		public Button()
		{
			base.Clicked += Button_Clicked;
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			if (Click != null)
			{
				Click(sender, e);
			}
		}

		public string Name
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public IPage Page
		{
			get
			{
				return (IPage) App.Current.MainPage;
			}
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

		public event EventHandler Click;

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}