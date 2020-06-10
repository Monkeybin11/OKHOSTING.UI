using System;
using System.Linq;
using System.Windows.Forms;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Autocomplete : ListPicker, IAutocomplete
	{
		public Autocomplete()
		{
			//base.AutoCompleteCustomSource = LoadAutoComplete();
			AutoCompleteMode = AutoCompleteMode.Suggest;
			AutoCompleteSource = AutoCompleteSource.CustomSource;
			TextChanged += Autocomplete_TextChanged;
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}

		protected AutoCompleteStringCollection LoadAutoComplete()
		{
			AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();

			var e = OnSearching(((IInputControl<string>) this).Value);

			if (e.SearchResult == null)
			{
				return stringCollection;
			}

			foreach (string d in e.SearchResult)
			{
				stringCollection.Add(d);
			}

			return stringCollection;
		}

		public event EventHandler<AutocompleteSearchEventArgs> Searching;

		public AutocompleteSearchEventArgs OnSearching(string text)
		{
			var e = new AutocompleteSearchEventArgs(text);

			Searching?.Invoke(this, e);

			return e;
		}

		#region IInputControl

		private void Autocomplete_TextChanged(object sender, EventArgs e)
		{
			ValueChanged?.Invoke(this, ((IInputControl<string>) this).Value);

			if (!string.IsNullOrWhiteSpace(base.Text) && base.Text.Length > 2)
			{
				base.AutoCompleteCustomSource = LoadAutoComplete();
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