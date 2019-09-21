using OKHOSTING.UI.Test;
using System.Windows;

namespace OKHOSTING.UI.Net4.WPF.Test
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.IImage), typeof(Controls.Image));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.IImageButton), typeof(Controls.ImageButton));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.ILabel), typeof(Controls.Label));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.ILabelButton), typeof(Controls.LabelButton));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.IListPicker), typeof(Controls.ListPicker));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.IAutocomplete), typeof(Controls.Autocomplete));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.Layout.IRelativePanel), typeof(Controls.Layout.RelativePanel));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.Layout.IStack), typeof(Controls.Layout.Stack));

			var page = new Page();
			page.App = new UI.App();
			new IndexController() { Page = page }.Start();

			page.Show();
		}
	}
}
