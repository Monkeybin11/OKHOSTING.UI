using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Autocomplete : TextBox, UI.Controls.IAutocomplete
	{
		public Autocomplete()
		{
			var allowedTypes = new System.Windows.Forms.AutoCompleteStringCollection();
			allowedTypes.AddRange(yourArrayOfSuggestions);
			AutoCompleteCustomSource = allowedTypes;
			AutoCompleteMode = AutoCompleteMode.Suggest;
			AutoCompleteSource = AutoCompleteSource.CustomSource;

			Searching+=
		}

		public event EventHandler<AutocompleteSearchEventArgs> Searching;

		public AutocompleteSearchEventArgs OnSearching(string text)
		{
			var e = new AutocompleteSearchEventArgs(text);

			if (Searching != null)
			{
                Searching(this, e);
			}

			return e;
		}
	}
}