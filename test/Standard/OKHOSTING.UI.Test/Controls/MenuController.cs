using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Test.Controls
{
	public class MenuController: Controller
	{
		ILabel Label;

		protected override void OnStart()
		{
			Label = Core.BaitAndSwitch.Create<ILabel>();
			Label.Text = "Click on a menu item";

			var menu = Core.BaitAndSwitch.Create<IMenu>();
			var stack = Core.BaitAndSwitch.Create<IStack>();

			var home = new MenuItem("Home", menuItem_Click);
			var services= new MenuItem("Services", menuItem_Click);
			var products = new MenuItem("Products", menuItem_Click);
			var aboutus = new MenuItem("About us", menuItem_Click);
			var contact = new MenuItem("Contact us", menuItem_Click);

			home.Children = new List<MenuItem>()
			{
				services,
				products,
				aboutus,
				contact
			};

			var hosting = new MenuItem("Hosting", menuItem_Click);
			var design = new MenuItem("Design", menuItem_Click);
			var development = new MenuItem("Development", menuItem_Click);
			var marketing = new MenuItem("Marketing", menuItem_Click);

			services.Children = new List<MenuItem>()
			{
				hosting,
				design,
				development,
				marketing
			};

			var shared = new MenuItem("Shared hosting", menuItem_Click);
			var dedicated = new MenuItem("Dedicated servers", menuItem_Click);
			var free = new MenuItem("Free hosting", menuItem_Click);

			hosting.Children = new List<MenuItem>()
			{
				shared,
				dedicated,
				free,
			};

			var domains = new MenuItem("domains", menuItem_Click);
			var templates = new MenuItem("Templates", menuItem_Click);

			products.Children = new List<MenuItem>()
			{
				domains,
				templates,
			};

			menu.Items = new List<MenuItem>()
			{
				home,
			};

			stack.Children.Add(Label);
			stack.Children.Add(menu);

			Page.Content = stack;
		}

		private void menuItem_Click(object sender, EventArgs e)
		{
			MenuItem item = (MenuItem) sender;
			Label.Text = $"You clicked: {item.Text}";
		}
	}
}