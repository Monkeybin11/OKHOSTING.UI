using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class Label : global::Xamarin.Forms.Label, ILabel
	{
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