using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class LabelButton : Label, ILabelButton
	{
		public LabelButton()
		{
			base.GestureRecognizers.Add(new global::Xamarin.Forms.TapGestureRecognizer
			{
				Command = new global::Xamarin.Forms.Command(() => OnLabelClicked()),
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