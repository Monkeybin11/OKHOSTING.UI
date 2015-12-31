using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Mac.Controls
{
	public class LabelButton : Label, ILabelButton
	{
		public LabelButton()
		{
			base.GestureRecognizers.Add(new global::Xamarin.Mac.TapGestureRecognizer
			{
				Command = new global::Xamarin.Mac.Command(() => OnLabelClicked()),
			});
		}

		private void OnLabelClicked()
		{
			if (Click != null)
			{
				Click(this, new EventArgs());
			}
		}

		public event EventHandler Click;
	}
}