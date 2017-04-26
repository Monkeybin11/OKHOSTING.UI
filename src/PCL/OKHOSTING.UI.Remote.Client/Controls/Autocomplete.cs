using OKHOSTING.UI.Controls;
using System;
using System.Linq;

namespace OKHOSTING.UI.Remote.Client.Controls
{
	/// <summary>
	/// Represents a control that is autocomplete.
	/// <para xml:lang="es">Representa un control que es autocomplete.</para>
	/// </summary>
	public class Autocomplete : TextBox, IAutocomplete
	{
		public event EventHandler<AutocompleteSearchEventArgs> Searching;

		public AutocompleteSearchEventArgs OnSearching(string text)
		{
			var e = new AutocompleteSearchEventArgs(text);
			
			Searching?.Invoke(this, e);

			return e;
		}
	}
}