using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Net4.WPF.Controls.Layout
{
	/// <summary>
	/// It is a container shaped pile where you can be stacked objects, which we can give you design through its properties
	/// <para xml:lang="es">Es un contenedor en forma de pila, donde puedes ir apilando objetos, al cual le podemos dar diseño por medio de sus propiedades</para>
	/// </summary>
	public class Stack : RelativePanel, IStack
	{
		/// <summary>
		/// Initializes a new instance of the OKHOSTING.UI.Net4.Ajax.Controls.Layout.Stack class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase OKHOSTING.UI.Net4.Ajax.Controls.Layout.Stack</para>
		/// </summary>
		public Stack()
		{
			Controls = new ControlList(this);
			InnerGrid = Core.BaitAndSwitch.Create<IGrid>();
			InnerGrid.ColumnCount = 1;
			InnerGrid.RowCount = 1;

			base.Children.Add((System.Windows.UIElement)InnerGrid);

			HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
			VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
			Width = Double.NaN;
			Height = Double.NaN;

		}

		#region IControl

		/// <summary>
		/// Gets or sets the color of the IC ontrol. background.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del Stack</para>
		/// </summary>
		/// <value>The color of the IC ontrol. background.
		/// <para xml:lang="es">El color del IControl.</para>
		/// </value>
		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Parse(((System.Windows.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(Platform.Parse(value));
			}
		}

		/// <summary>
		/// Gets or sets the color of the IC ontrol. border.
		/// <para xml:lang="es">Obtiene o establece el color del borde del IControl</para>
		/// </summary>
		/// <value>The color of the IC ontrol. border.
		/// <para xml:lang="es">El color del IControl</para>
		/// </value>
		Color IControl.BorderColor
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the width of the IC ontrol.
		/// <para xml:lang="es">Obtiene o establece el ancho del IControl</para>
		/// </summary>
		/// <value>The width of the IC ontrol.
		/// <para xml:lang="es">El ancho del IControl</para>
		/// </value>
		double? IControl.Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = value.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the height of the IC ontrol.
		/// <para xml:lang="es">Obtiene o establece el alto del IControl</para>
		/// </summary>
		/// <value>The height of the IC ontrol.
		/// <para xml:lang="es">El valor del IControl.</para>
		/// </value>
		double? IControl.Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = value.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the IC ontrol. margin.
		/// <para xml:lang="es">Obtiene o establece el Margen del IControl</para>
		/// </summary>
		/// <value>The IC ontrol. margin.
		/// <para xml:lang="es">El margen del IControl</para>
		/// </value>
		Thickness IControl.Margin
		{
			get
			{
				return Platform.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the width of the IC ontrol. border.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del IControl.</para>
		/// </summary>
		/// <value>The width of the IC ontrol. border.
		/// <para xml:lang="es">El ancho del borde del IControl</para>
		/// </value>
		Thickness IControl.BorderWidth
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the IC ontrol. horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del IControl</para>
		/// </summary>
		/// <value>The IC ontrol. horizontal alignment.
		/// <para xml:lang="es">La alineacion horizontal del IControl.</para>
		/// </value>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the IC ontrol. vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical</para>
		/// </summary>
		/// <value>The IC ontrol. vertical alignment.
		/// <para xml:lang="es">La alineacion vertical del IControl.</para>
		/// </value>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element.
		/// <para xml:lang="es">Obtiene o establece un valor de objeto arbitrario que se puede utilizar para almacenar información personalizada sobre este elemento.</para> 
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">Devuelve el valor previsto. Esta propiedad no tiene ningún valor predeterminado.</para>
		/// </remmarks>
		object IControl.Tag
		{
			get; set;
		}

		#endregion

		/// <summary>
		/// The actual grid that contains all controls in a "stacky" way
		/// <para xml:lang="es">El grid actual que contiene todos los controles de una manera apilada.</para>
		/// </summary>
		public readonly IGrid InnerGrid;

		/// <summary>
		/// The list of all the child controls
		/// <para xml:lang="es">La lista de todos los controles hijos</para>
		/// </summary>
		public readonly ControlList Controls;

		IList<IControl> IContainer.Children
		{
			get
			{
				return Controls;
			}
		}

		/// <summary>
		/// Control list.
		/// <para xml:lang="es">Lista de controles</para>
		/// </summary>
		public class ControlList : IList<IControl>
		{
			/// <summary>
			/// The container stack.
			/// <para xml:lang="es">El contenido del Stack</para>
			/// </summary>
			private readonly Stack ContainerStack;

			/// <summary>
			/// Initializes a new instance of the OKHOSTING.UI.Net4.Ajax.Controls.Layout.Stack.ControlList class.
			/// <para xml:lang="es">Inicializa una nueva instancia de la clase OKHOSTING.UI.Net4.Ajax.Controls.Layout.Stack.ControlList</para>
			/// </summary>
			/// <param name="containerStack">Container stack.
			/// <para xml:lang="es">Pila de contenedores</para>
			/// </param>
			public ControlList(Stack containerStack)
			{
				ContainerStack = containerStack;
			}

			/// <summary>
			/// Gets or sets the OKHOSTING.UI.Net4.Ajax.Controls.Layout.Stack.ControlList at the specified index.
			/// <para xml:lang="es">Obtiene o establece la lista de controles en el indice especificado.</para>
			/// </summary>
			/// <param name="index">Index.</param>
			public IControl this[int index]
			{
				get
				{
					return (IControl)ContainerStack.InnerGrid.GetContent(index, 0);
				}
				set
				{
				}
			}

			/// <summary>
			/// Gets the count of rows in the container.
			/// <para xml:lang="es">Obtiene el conteo de filas en el contenedor</para>
			/// </summary>
			/// <value>The count.
			/// <para xml:lang="es">El conteo.</para>
			/// </value>
			public int Count
			{
				get
				{
					return ContainerStack.InnerGrid.RowCount;
				}
			}

			/// <summary>
			/// Gets the is read only.
			/// <para xml:lang="es">Obtiene un valor que determina si es de solo lectura.</para>
			/// </summary>
			public bool IsReadOnly
			{
				get
				{
					return false;
				}
			}

			/// <summary>
			/// Add the specified item.
			/// <para xml:lang="es">Agrega el control especificado al contenedor.</para>
			/// </summary>
			/// <param name="item">Item.
			/// <para xml:lang="es">El control.</para>
			/// </param>
			public void Add(IControl item)
			{
				ContainerStack.InnerGrid.SetContent(ContainerStack.InnerGrid.RowCount, 0, item);
				ContainerStack.InnerGrid.RowCount++;
				
				//((IGrid) ContainerStack.InnerGrid).SetContent(((IGrid)ContainerStack.InnerGrid).RowCount + 1, 0, item);
			}

			/// <summary>
			/// Clear this instance.
			/// <para xml:lang="es">Limpia esta instancia</para>
			/// </summary>
			public void Clear()
			{
				ContainerStack.InnerGrid.RowCount = 0;
			}

			/// <summary>
			/// Contains the specified item.
			/// <para xml:lang="es">Valida si el contenedor contiene el control especificado.</para>
			/// </summary>
			/// <param name="item">Item.
			/// <para xml:lang="es">El control.</para>
			/// </param>
			public bool Contains(IControl item)
			{

				return false;
			}

			/// <summary>
			/// Copies to.
			/// <para xml:lang="es">Copia el arreglo de controles en el index del arreglo especificado</para>
			/// </summary>
			/// <param name="array">Array.
			/// <para xml:lang="es">El arreglo</para>
			/// </param>
			/// <param name="arrayIndex">Array index.
			/// <para xml:lang="es">Indice del arreglo.</para>
			/// </param>
			public void CopyTo(IControl[] array, int arrayIndex)
			{
				//for (int i = 0; i < ContainerStack.InnerGrid.RowCount; i++)
				//{
	//				int row 
				//	System.Windows.UIElement row = ContainerStack.InnerGrid.Children[i];

				//	if (row != null)
				//	{
				//		array[i] = (IControl) row;
				//	}
				//}
			}

			/// <summary>
			/// Gets a collection of objects representing the child controls for a specified control in the User interface.
			/// <para xml:lang="es">Obtiene una coleccion de objetos que representan los controles hijos para un control especificado en la interfaz de ususario</para>
			/// </summary>
			/// <returns>The enumerator.
			/// <para xml:lang="es">La enumeracion.</para>
			/// </returns>
			public IEnumerator<IControl> GetEnumerator()
			{
				IEnumerator<IControl> list = null;
				return list;
			}

			/// <summary>
			/// Determines the index of a specific item in the current instance.
			/// </summary>
			/// <returns>Determina el indice de un control especifico en la instancia actual</returns>
			/// <param name="item">Item.
			/// <para xml:lang="es">El control especificado.</para>
			/// </param>
			public int IndexOf(IControl item)
			{
				for (int i = 0; i < ContainerStack.InnerGrid.RowCount; i++)
				{
					IControl row = ContainerStack.InnerGrid.GetContent(ContainerStack.InnerGrid.RowCount, 0);

					if (row != null && row == item)
					{
						return i;
					}
				}
				return -1;
			}

			/// <summary>
			/// Insert the specified index and item.
			/// <para xml:lang="es">Inserta el control especificado en el indice especificado.</para>
			/// </summary>
			/// <param name="index">Index.
			/// <para xml:lang="es">El indice especificado</para>
			/// </param>
			/// <param name="item">Item.
			/// <para xml:lang="es">El control especificado.</para>
			/// </param>
			public void Insert(int index, IControl item)
			{
				ContainerStack.InnerGrid.SetContent(index, 0, item);
			}

			/// <summary>
			/// Remove the specified item.
			/// <para xml:lang="es">Quita la primera aparicion del control especificado en el contenedor actual.</para>
			/// </summary>
			/// <param name="item">Item.
			/// <para xml:lang="es">El control especificado</para>
			/// </param>
			public bool Remove(IControl item)
			{
				//foreach (System.Windows.UIElement row in ContainerStack.InnerGrid.Children)
				//{
				//	if (row.Equals((System.Windows.UIElement)item))
				//	{
				//		ContainerStack.InnerGrid.Children.Remove(row);
				//		return true;
				//	}
				//}

				return false;
			}

			/// <summary>
			/// Removes a child control that is located at the specified index of the current container.
			/// <para xml:lang="es">Quita un control hijo que se encuentra en el indice especificado del contenedor actual.</para>
			/// </summary>
			/// <param name="index">Index.
			/// <para xml:lang="es">El indice especificado.</para>
			/// </param>
			public void RemoveAt(int index)
			{
				ContainerStack.InnerGrid.RowCount = ContainerStack.InnerGrid.RowCount - index;
			}

			/// <summary>
			/// Gets the enumerator of the controls natives content in the content.
			/// <para xml:lang="es">Obtiene la coleccion de los controles nativos contenidos en el contenedor</para>
			/// </summary>
			/// <returns>The collections.
			/// <para xml:lang="es">La colección.</para>
			/// </returns>
			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}
	}
}