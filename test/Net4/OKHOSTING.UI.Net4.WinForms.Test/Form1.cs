using OKHOSTING.UI.Test;
using System;

namespace OKHOSTING.UI.Net4.WinForms.Test
{
	public partial class Form1 : Page
	{
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (App == null)
			{
				App = new App();
			}

			if (App.State.Count == 0)
			{
				try
				{
					Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.IImage), typeof(Controls.Image));
					Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.IImageButton), typeof(Controls.ImageButton));
					Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.ILabel), typeof(Controls.Label));
					Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.ILabelButton), typeof(Controls.LabelButton));
					Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.IListPicker), typeof(Controls.ListPicker));
					Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.IAutocomplete), typeof(Controls.Autocomplete));

					App.MainPage = this;
					var index = new IndexController();
					index.Page = this;
					index.Start();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			}
		}
	}
}
