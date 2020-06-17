using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layout
{
	/// <summary>
	/// It represents a container where we can be stacked controls.								
	/// <para xml:lang="es">
	/// Representa un contenedor donde podemos ir apilando controles.
	/// </para>
	/// </summary>
	public class Flow : Background<global::Xamarin.Forms.StackLayout>, IFlow
	{
		/// <summary>
		/// The children controls.
		/// <para xml:lang="es">Lista de los controles hijos del Stack</para>
		/// </summary>
		protected readonly ControlList _Children;

		/// <summary>
		/// Initializes a new instance of the Stack class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase Stack</para>
		/// </summary>
		public Flow()
		{
			_Children = new ControlList(Content.Children);
			Content.Orientation = global::Xamarin.Forms.StackOrientation.Horizontal;
		}

		/// <summary>
		/// Gets the controls IStack children.
		/// <para xml:lang="es">Obtiene la lista de los controles hijos del Stack.</para>
		/// </summary>
		public override ICollection<IControl> Children
		{
			get
			{
				return _Children;
			}
		}

		/// <summary>
		/// The identifier dispose.
		/// <para xml:lang="es">El identificador Dispose.</para>
		/// </summary>
		void IDisposable.Dispose()
		{
		}
	}
}