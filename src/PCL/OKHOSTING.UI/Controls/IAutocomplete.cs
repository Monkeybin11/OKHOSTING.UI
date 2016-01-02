using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	public interface IAutocomplete: ITextControl, IInputControl<string>
	{
		/// <summary>
		/// Raises after the user writes something and triggers a search
		/// </summary>
		event EventHandler<AutocompleteSearchEventArgs> Searching;

		AutocompleteSearchEventArgs OnSearching(string text);
	}

	public class AutocompleteSearchEventArgs
	{
		public AutocompleteSearchEventArgs(string text)
		{
			Text = text;
		}

		public readonly string Text;

		/// <summary>
		/// You shoukd stablish this with your own code
		/// </summary>
		public IEnumerable<string> SearchResult
		{
			get; set;
		}
	}
}