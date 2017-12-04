using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls
{
	public class Autocomplete : TextBox, IAutocomplete
	{
		public Autocomplete()
		{
            base.AutoCompleteCustomSource = Datos();
            base.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            base.AutoCompleteSource = AutoCompleteSource.CustomSource;

			base.TextChanged += Autocomplete_TextChanged;
			//Searching+=
		}

        public static AutoCompleteStringCollection Datos()
        {
            var array = new[] { "Pedro", "Donaciana", "Muñoz", "Mata", "Lozano" };

            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();

            foreach(string dato in array)
            {
                datos.Add(dato);
            }

            return datos;
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
			ValueChanged?.Invoke(this, ((IInputControl<string>)this).Value);
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