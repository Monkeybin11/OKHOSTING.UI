using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Autocomplete : TextBox, UI.Controls.IAutocomplete
	{
		public Autocomplete()
		{
			//var allowedTypes = new System.Windows.Forms.AutoCompleteStringCollection();
			//allowedTypes.AddRange(yourArrayOfSuggestions);
			//AutoCompleteCustomSource = allowedTypes;
			//AutoCompleteMode = AutoCompleteMode.Suggest;
			//AutoCompleteSource = AutoCompleteSource.CustomSource;

			base.TextChanged += Autocomplete_TextChanged;
			//Searching+=
		}

		private void Autocomplete_TextChanged(object sender, EventArgs e)
		{
			if(ValueChanged != null)
			{
				ValueChanged(this, new EventArgs());
			}
		}

		public event EventHandler<AutocompleteSearchEventArgs> Searching;
		public event EventHandler ValueChanged;

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