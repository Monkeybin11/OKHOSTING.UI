﻿using OKHOSTING.UI;
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
			base.Start();

			CurrentPage.Title = "Escritorio";

			IAutocomplete automcomplete = CurrentPage.Create<IAutocomplete>();
			automcomplete.Searching += Automcomplete_Searching;

			ILabel label = CurrentPage.Create<ILabel>();
			label.Text = "hola amigo!";

			IStack stack = CurrentPage.Create<IStack>();
			stack.Children.Add(label);
			stack.Children.Add(automcomplete);

			CurrentPage.Content = stack;
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