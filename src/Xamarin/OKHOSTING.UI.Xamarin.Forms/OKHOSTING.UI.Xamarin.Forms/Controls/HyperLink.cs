using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class HyperLink : global::Xamarin.Forms.Button, IHyperLink
	{
		public HyperLink()
		{
			base.Clicked += HyperLink_Clicked;
		}

		private void HyperLink_Clicked(object sender, EventArgs e)
		{
			
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

		public Uri Uri
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