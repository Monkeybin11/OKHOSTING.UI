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
	public class Autocomplete: TextControl, IAutocomplete, IInputControl<string>
	{
		public string Value
		{
			get
			{
				return (string) Get(nameof(Value));
			}
			set
			{
				Set(nameof(Value), value);
			}
		}

		public event EventHandler<string> ValueChanged
		{
			add
			{
				AddHybridEventHandler(nameof(ValueChanged), value);
			}
			remove
			{
				RemoveHybridEventHandler(nameof(ValueChanged), value);
			}
		}

		/// <summary>
		/// Raises after the user writes something and triggers a search
		/// <para xml:lang="es">
		/// Lo lanza despues de que el usuario escrive algo desencadena una busqueda.
		/// </para>
		/// </summary>
		public event EventHandler<AutocompleteSearchEventArgs> Searching
		{
			add
			{
				AddHybridEventHandler(nameof(Searching), value);
			}
			remove
			{
				RemoveHybridEventHandler(nameof(Searching), value);
			}
		}

		public AutocompleteSearchEventArgs OnSearching(string text)
		{
			return (AutocompleteSearchEventArgs) Invoke(nameof(OnSearching), text);
		}

		public void RaiseValueChanged()
		{
			Invoke(nameof(RaiseValueChanged));
		}
	}
}