using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// It contains the events of Autocomplete.
	/// <para xml:lang="es">
	/// Contiene los evetos de un Autocomplete.
	/// </para>
	/// </summary>
	public interface IAutocomplete: ITextControl, IInputControl<string>
	{
		/// <summary>
		/// Raises after the user writes something and triggers a search
		/// <para xml:lang="es">
		/// Lo lanza despues de que el usuario escrive algo desencadena una busqueda.
		/// </para>
		/// </summary>
		event EventHandler<AutocompleteSearchEventArgs> Searching;

		AutocompleteSearchEventArgs OnSearching(string text);
	}

	/// <summary>
	/// Autocomplete search event arguments.
	/// <para xml:lang="es">
	/// Argumentos del evento buscar del Autocomplete. 
	/// </para>
	/// </summary>
	public class AutocompleteSearchEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the AutocompleteSearchEventArgs class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase AutocompleteSearchEventArgs.
		/// </para>
		/// </summary>
		/// <param name="text">Text.</param>
		public AutocompleteSearchEventArgs(string text)
		{
			Text = text;
		}

		/// <summary>
		/// The text.
		/// <para xml:lang="es">El texto.</para>
		/// </summary>
		public readonly string Text;

		/// <summary>
		/// You shoukd stablish this with your own code.
		/// <para xml:lang="es">
		/// Deve establecer esto con su propio código.
		/// </para>
		/// </summary>
		public IEnumerable<string> SearchResult
		{
			get; set;
		}
	}
}