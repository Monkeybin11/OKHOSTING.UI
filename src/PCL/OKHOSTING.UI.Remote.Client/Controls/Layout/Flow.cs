using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Remote.Client.Controls.Layout
{
	/// <summary>
	/// A flow layout puts all its children controls one right next to the other, in a sequential way,
	/// in the same order as they appear in the collection
	/// </summary>
	public class Flow : Control, IFlow
	{
		/// <summary>
		/// Initializes a new instance of the OKHOSTING.UI.Remote.Client.Controls.Layout.Stack class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase OKHOSTING.UI.Remote.Client.Controls.Layout.Stack</para>
		/// </summary>
		public Flow()
		{
			Children = new List<IControl>();
		}

		/// <summary>
		/// The list of all the child controls
		/// <para xml:lang="es">La lista de todos los controles hijos</para>
		/// </summary>
		public IList<IControl> Children { get; }
	}
}