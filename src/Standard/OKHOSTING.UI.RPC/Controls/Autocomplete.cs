using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// It contains the events of Autocomplete control.
	/// <para xml:lang="es">
	/// Contiene los evetos de un control Autocomplete.
	/// </para>
	/// </summary>
	public class Autocomplete: TextControl, IAutocomplete, IInputControl
	{
		public string Value { get; set; }

		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// Raises after the user writes something and triggers a search
		/// <para xml:lang="es">
		/// Lo lanza despues de que el usuario escrive algo desencadena una busqueda.
		/// </para>
		/// </summary>
		public event EventHandler<AutocompleteSearchEventArgs> Searching;
	
		public AutocompleteSearchEventArgs OnSearching(string text)
		{
			return (AutocompleteSearchEventArgs) base.Invoke(nameof(OnSearching), new[] { text });
		}

		public void RaiseValueChanged()
		{
			ValueChanged?.Invoke(this, ((IAutocomplete)this).Value);
		}
	}
}