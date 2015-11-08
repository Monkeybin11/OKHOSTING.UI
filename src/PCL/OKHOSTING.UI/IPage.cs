using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI
{
	/// <summary>
	/// Represents a "window" that contains a view. In WinForms this is a Form, in ASP.NET a WebForm, in Xamarin Forms it will be a Page
	/// </summary>
	public interface IPage
	{
		/// <summary>
		/// Title for this page
		/// </summary>
		string Title { get; set; }

		/// <summary>
		/// Each window only contains one main view, which can optionally be a container and contain more views
		/// </summary>
		Controls.IControl Content { get; set; }
	}
}