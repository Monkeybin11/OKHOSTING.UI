using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Remote.Client.Controls.Layout
{
	/// <summary>
	/// It is a container shaped pile where you can be stacked objects, which we can give you design through its properties
	/// <para xml:lang="es">Es un contenedor en forma de pila, donde puedes ir apilando objetos, al cual le podemos dar diseño por medio de sus propiedades</para>
	/// </summary>
	public class Stack : Control, IStack
	{
		/// <summary>
		/// Initializes a new instance of the OKHOSTING.UI.Remote.Client.Controls.Layout.Stack class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase OKHOSTING.UI.Remote.Client.Controls.Layout.Stack</para>
		/// </summary>
		public Stack()
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