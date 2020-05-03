using OKHOSTING.Core;
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
			Label = BaitAndSwitch.Create<ILabel>();
			Label.Text = "Click on a menu item";

			var menu = BaitAndSwitch.Create<IMenu>();
			var stack = BaitAndSwitch.Create<IStack>();

			var home = BaitAndSwitch.Create<IMenuItem>("Home");
			var services= BaitAndSwitch.Create<IMenuItem>("Services");
			var products = BaitAndSwitch.Create<IMenuItem>("Products");
			var aboutus = BaitAndSwitch.Create<IMenuItem>("About us");
			var contact = BaitAndSwitch.Create<IMenuItem>("Contact us");

			home.Children.Add(services);
			home.Children.Add(products);
			home.Children.Add(aboutus);
			home.Children.Add(contact);

			var hosting = BaitAndSwitch.Create<IMenuItem>("Hosting");
			var design = BaitAndSwitch.Create<IMenuItem>("Design");
			var development = BaitAndSwitch.Create<IMenuItem>("Development");
			var marketing = BaitAndSwitch.Create<IMenuItem>("Marketing");

			services.Children.Add(hosting);
			services.Children.Add(design);
			services.Children.Add(development);
			services.Children.Add(marketing);

			var shared = BaitAndSwitch.Create<IMenuItem>("Shared hosting");
			var dedicated = BaitAndSwitch.Create<IMenuItem>("Dedicated servers");
			var free = BaitAndSwitch.Create<IMenuItem>("Free hosting");

			hosting.Children.Add(shared);
			hosting.Children.Add(dedicated);
			hosting.Children.Add(free);

			var domains = BaitAndSwitch.Create<IMenuItem>("domains");
			var templates = BaitAndSwitch.Create<IMenuItem>("Templates");

			products.Children.Add(domains);
			products.Children.Add(templates);

			menu.Items.Add(home);

			home.Click += menuItem_Click;
			services.Click += menuItem_Click;
			products.Click += menuItem_Click;
			aboutus.Click += menuItem_Click;
			contact.Click += menuItem_Click;

			hosting.Click += menuItem_Click;
			design.Click += menuItem_Click;
			development.Click += menuItem_Click;
			marketing.Click += menuItem_Click;

			shared.Click += menuItem_Click;
			dedicated.Click += menuItem_Click;
			free.Click += menuItem_Click;

			domains.Click += menuItem_Click;
			templates.Click += menuItem_Click;

			stack.Children.Add(Label);
			stack.Children.Add(menu);

			Page.Content = stack;
		}

		private void menuItem_Click(object sender, EventArgs e)
		{
			IMenuItem item = (IMenuItem) sender;
			Label.Text = $"You clicked: {item.Text}";
		}
	}
}