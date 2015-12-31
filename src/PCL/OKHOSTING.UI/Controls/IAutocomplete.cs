using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	public interface IAutocomplete: ITextControl
	{
		/// <summary>
		/// Gets or sets the text that is contained in the textbox
		/// </summary>
		string Text { get; set; }

		/// <summary>
		/// Raises after the user writes something and triggers a search
		/// </summary>
		event EventHandler<AutocompleteSearchEventArgs> Searching;

		/// <summary>
		/// Raises after the value has changed by the user. Chages made in code will not raise this event.
		/// </summary>
		event EventHandler ValueChanged;

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