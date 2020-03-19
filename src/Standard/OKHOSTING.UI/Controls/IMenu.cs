using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A tree-menu control for navigation or similar purposes
	/// </summary>
	public interface IMenu : ITextControl
	{
		ICollection<IMenuItem> Items { get; set; }
	}
}