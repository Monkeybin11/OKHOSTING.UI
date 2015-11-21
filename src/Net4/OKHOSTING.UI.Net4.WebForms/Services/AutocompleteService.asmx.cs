using OKHOSTING.UI.Net4.WebForms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace OKHOSTING.UI.Net4.WebForms.Services
{
	/// <summary>
	/// Service that returns a list of DataObjects when performing searchs on AutoComplete ajax controls
	/// </summary>
	[WebService(Namespace = "https://okhosting.com/Services/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.Web.Script.Services.ScriptService]
	public class AutocompleteService : WebService
	{
		/// <summary>
		/// String that will be considered as a "Show All" filter
		/// </summary>
		public const string ShowAllText = "***";

		/// <summary>
		/// Performs a searchs on an Autocomplete control
		/// </summary>
		/// <param name="prefixText">String that defines the search criteria</param>
		/// <param name="count">Max number of results to return</param>
		/// <param name="contextKey">UniqueId of the Autocomplete that isn invoking this method</param>
		/// <returns>A array of strings containing the result of Searching event</returns>
		[WebMethod(EnableSession = true)]
		public string[] Search(string prefixText, int count, string contextKey)
		{
			//set default count, if no count is defined
			if (count == 0) count = 20;

			Autocomplete autocomplete = (Autocomplete) OKHOSTING.UI.Session.Current[contextKey];
			var e = autocomplete.OnSearching(prefixText);

			return e.SearchResult.ToArray();
        }
	}
}
