using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Test
{
	public class DashboardController : Controller
	{
		public override void Start()
		{
			ILabel label = CurrentPage.Create<ILabel>();
			label.Text = "hola amigo!";

			CurrentPage.Title = "Escritorio";
			CurrentPage.Content = label;

			IAutocomplete automcomplete = CurrentPage.Create<IAutocomplete>();
			automcomplete.Searching += Automcomplete_Searching;
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