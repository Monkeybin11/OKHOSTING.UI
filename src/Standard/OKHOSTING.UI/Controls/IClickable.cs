using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A clickable control
	/// <para xml:lang="es">
	/// Un control clickeable
	/// </para>
	/// </summary>
	public interface IClickable : IControl
	{
		/// <summary>
		/// Raised after the user clicks on a control
		/// </summary>
		event EventHandler Click;
	}
}