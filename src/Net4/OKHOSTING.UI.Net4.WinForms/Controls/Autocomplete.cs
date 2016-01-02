using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Autocomplete : TextBox, IAutocomplete
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

		#region IInputControl

		private void Autocomplete_TextChanged(object sender, EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, ((IInputControl<string>)this).Value);
			}
		}

		public new event EventHandler<string> ValueChanged;

		string IInputControl<string>.Value
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		#endregion
	}
}