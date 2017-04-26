using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Remote.Client.Controls.Layout
{
	/// <summary>
	/// A board where you can store objects, which you can give design through its properties.
	/// <para xml:lang="es">
	/// Un tablero donde se pueden almacenar objetos, al cual le podemos dar diseño por medio de sus propiedades.
	/// </para>
	/// </summary>
	public class RelativePanel: Control, IRelativePanel
	{
		/// <summary>
		/// Initializes a new instance of the RelativePanel class.
		/// <para xml:lang="es">Inicilaiza una nueva instancia de la clase RelativePanel</para>
		/// </summary>
		public RelativePanel()
		{
			Children = new List<IControl>();
		}

		/// <summary>
		/// The list of all the child controls
		/// <para xml:lang="es">La lista de todos los controles hijos</para>
		/// </summary>
		public IList<IControl> Children { get; }

		public void Add(IControl control, RelativePanelHorizontalContraint horizontalContraint, RelativePanelVerticalContraint verticalContraint, IControl referenceControl)
		{
		}
	}
}