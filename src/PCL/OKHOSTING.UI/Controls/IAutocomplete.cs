using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	public interface IAutocomplete: ITextBox
	{
		event EventHandler<AutocompleteSearchEventArgs> Searching;

		void OnSearching();
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