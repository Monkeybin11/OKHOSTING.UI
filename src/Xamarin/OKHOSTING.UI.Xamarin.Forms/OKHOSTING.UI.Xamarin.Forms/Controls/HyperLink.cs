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
			global::Xamarin.Forms.Device.OpenUri(Uri);
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

		public Uri Uri
		{
			get
			{
				return new Uri(base.Text);
			}
			set
			{
				base.Text = value.ToString();
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