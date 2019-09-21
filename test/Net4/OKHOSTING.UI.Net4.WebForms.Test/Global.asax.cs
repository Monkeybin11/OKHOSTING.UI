using System;

namespace OKHOSTING.UI.Net4.WebForms.Test
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.IImage), typeof(Controls.Image));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.IImageButton), typeof(Controls.ImageButton));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.ILabel), typeof(Controls.Label));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.ILabelButton), typeof(Controls.LabelButton));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.IListPicker), typeof(Controls.ListPicker));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.IAutocomplete), typeof(Controls.Autocomplete));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.Layout.IRelativePanel), typeof(Controls.Layout.RelativePanel));
			Core.BaitAndSwitch.PlatformSpecificTypes.Add(typeof(UI.Controls.Layout.IStack), typeof(Controls.Layout.Stack));
		}

		protected void Session_Start(object sender, EventArgs e)
		{
			Session["App"] = new App();
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}