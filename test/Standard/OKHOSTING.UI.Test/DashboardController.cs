using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Test
{
	public class DashboardController : Controller
	{
		protected override void OnStart()
		{
			Page.Title = "Escritorio";

			IAutocomplete automcomplete = Core.BaitAndSwitch.Create<IAutocomplete>();
			automcomplete.Searching += Automcomplete_Searching;

			ILabel label = Core.BaitAndSwitch.Create<ILabel>();
			label.Text = "hola amigo!";

			IStack stack = Core.BaitAndSwitch.Create<IStack>();
			stack.Children.Add(label);
			stack.Children.Add(automcomplete);

			Page.Content = stack;
		}

		private void Automcomplete_Searching(object sender, AutocompleteSearchEventArgs e)
		{
			Random r = new Random();
			List<string> items = new List<string>();

			for (int i = 0; i < r.Next(100); i++)
			{
				items.Add(e.Text + i.ToString());
			}

			e.SearchResult = items;
		}
	}
}