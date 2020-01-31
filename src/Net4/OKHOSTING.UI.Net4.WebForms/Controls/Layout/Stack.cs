using System.Drawing;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Net4.WebForms.Controls.Layout
{
	/// <summary>
	/// It is a container shaped pile where you can be stacked objects, which we can give you design through its properties
	/// <para xml:lang="es">Es un contenedor en forma de pila, donde puedes ir apilando objetos, al cual le podemos dar diseño por medio de sus propiedades</para>
	/// </summary>
	public class Stack : System.Web.UI.WebControls.Panel, IStack
	{
		/// <summary>
		/// Initializes a new instance of the OKHOSTING.UI.Net4.WebForms.Controls.Layout.Stack class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase OKHOSTING.UI.Net4.WebForms.Controls.Layout.Stack</para>
		/// </summary>
		public Stack()
		{
			Children = new ControlList(this);
		}

		#region IControl

		/// <summary>
		/// Gets or sets the name of the control..
		/// <para xml:lang="es">Obtiene o establece el nombre del control</para>
		/// </summary>
		/// <value>The name of the control.
		/// <para xml:lang="es">El nombre del IControl</para>
		/// </value>
		string IControl.Name
		{
			get
			{
				return base.ID;
			}
			set
			{
				base.ID = value;
			}
		}

		/// <summary>
		/// Gets or sets the color of the control. background.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del Stack</para>
		/// </summary>
		/// <value>The color of the control. background.
		/// <para xml:lang="es">El color del IControl.</para>
		/// </value>
		Color IControl.BackgroundColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		/// <summary>
		/// Gets or sets the color of the control. border.
		/// <para xml:lang="es">Obtiene o establece el color del borde del IControl</para>
		/// </summary>
		/// <value>The color of the control. border.
		/// <para xml:lang="es">El color del IControl</para>
		/// </value>
		Color IControl.BorderColor
		{
			get
			{
				return base.BorderColor;
			}
			set
			{
				base.BorderColor = value;
			}
		}

		/// <summary>
		/// Gets or sets the width of the control.
		/// <para xml:lang="es">Obtiene o establece el ancho del IControl</para>
		/// </summary>
		/// <value>The width of the control.
		/// <para xml:lang="es">El ancho del IControl</para>
		/// </value>
		double? IControl.Width
		{
			get
			{
				if (base.Width.IsEmpty)
				{
					return null;
				}

				return base.Width.Value;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					base.Width = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		/// <summary>
		/// Gets or sets the height of the control.
		/// <para xml:lang="es">Obtiene o establece el alto del IControl</para>
		/// </summary>
		/// <value>The height of the control.
		/// <para xml:lang="es">El valor del IControl.</para>
		/// </value>
		double? IControl.Height
		{
			get
			{
				if (base.Height.IsEmpty)
				{
					return null;
				}

				return base.Height.Value;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					base.Height = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		/// <summary>
		/// Space that this control will set between itself and it's container
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su contenedor.
		/// </para>
		/// </summary>
		Thickness IControl.Margin
		{
			get
			{
				return this.GetMargin();
			}
			set
			{
				this.SetMargin(value);
			}
		}

		/// <summary>
		/// Space that this control will set between itself and it's own border
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su propio borde
		/// </para>
		/// </summary>
		Thickness IControl.Padding
		{
			get
			{
				return this.GetPadding();
			}
			set
			{
				this.SetPadding(value);
			}
		}

		/// <summary>
		/// Gets or sets the width of the control. border.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del IControl.</para>
		/// </summary>
		/// <value>The width of the control. border.
		/// <para xml:lang="es">El ancho del borde del IControl</para>
		/// </value>
		Thickness IControl.BorderWidth
		{
			get
			{
				return this.GetBorderWidth();
			}
			set
			{
				this.SetBorderWidth(value);
			}
		}

		/// <summary>
		/// Gets or sets the control. horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del IControl</para>
		/// </summary>
		/// <value>The control. horizontal alignment.
		/// <para xml:lang="es">La alineacion horizontal del IControl.</para>
		/// </value>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("horizontal-alignment")).SingleOrDefault();

				//if not horizontal alignment is provided, the alignment back to the left.
				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return HorizontalAlignment.Left;
				}

				//verify the horizontal alignment provided.
				if (cssClass.EndsWith("left"))
				{
					return HorizontalAlignment.Left;
				}
				else if (cssClass.EndsWith("right"))
				{
					return HorizontalAlignment.Right;
				}
				else if (cssClass.EndsWith("center"))
				{
					return HorizontalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return HorizontalAlignment.Fill;
				}
				else
				{
					return HorizontalAlignment.Left;
				}
			}
			set
			{
				this.RemoveCssClassesStartingWith("horizontal-alignment");
				this.AddCssClass("horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the control. vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical</para>
		/// </summary>
		/// <value>The control. vertical alignment.
		/// <para xml:lang="es">La alineacion vertical del IControl.</para>
		/// </value>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("vertical-alignment")).SingleOrDefault();

				//if not vertical alignment is provided, the alignment back to the top.
				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return VerticalAlignment.Top;
				}

				//verify the vertical alignment provided.
				if (cssClass.EndsWith("top"))
				{
					return VerticalAlignment.Top;
				}
				else if (cssClass.EndsWith("bottom"))
				{
					return VerticalAlignment.Bottom;
				}
				else if (cssClass.EndsWith("center"))
				{
					return VerticalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return VerticalAlignment.Fill;
				}
				else
				{
					return VerticalAlignment.Top;
				}
			}
			set
			{
				this.RemoveCssClassesStartingWith("vertical-alignment");
				this.AddCssClass("vertical-alignment-" + value.ToString().ToLower());
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

		/// <summary>
		/// Control that contains this control, like a grid, or stack
		/// </summary>
		IControl IControl.Parent
		{
			get
			{
				return (IControl)base.Parent;
			}
		}

		#endregion

		/// <summary>
		/// The list of all the child controls
		/// <para xml:lang="es">La lista de todos los controles hijos</para>
		/// </summary>
		public readonly ControlList Children;

		ICollection<IControl> IContainer.Children
		{
			get
			{
				return Children;
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
			private readonly Stack Container;

			/// <summary>
			/// Initializes a new instance of the OKHOSTING.UI.Net4.WebForms.Controls.Layout.Stack.ControlList class.
			/// <para xml:lang="es">Inicializa una nueva instancia de la clase OKHOSTING.UI.Net4.WebForms.Controls.Layout.Stack.ControlList</para>
			/// </summary>
			/// <param name="container">Container stack.
			/// <para xml:lang="es">Pila de contenedores</para>
			/// </param>
			public ControlList(Stack container)
			{
				Container = container;
			}

			/// <summary>
			/// Gets or sets the OKHOSTING.UI.Net4.WebForms.Controls.Layout.Stack.ControlList at the specified index.
			/// <para xml:lang="es">Obtiene o establece la lista de controles en el indice especificado.</para>
			/// </summary>
			/// <param name="index">Index.</param>
			public IControl this[int index]
			{
				get
				{
					return (IControl) Container.Controls[index * 2];
				}
				set
				{
					Container.Controls.RemoveAt(index * 2);
					Container.Controls.AddAt(index * 2, (System.Web.UI.Control) value);
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
					return Container.Controls.Count / 2;
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
				Container.Controls.Add((System.Web.UI.Control) item);
				Container.Controls.Add(new System.Web.UI.LiteralControl("<br />"));
			}

			/// <summary>
			/// Clear this instance.
			/// <para xml:lang="es">Limpia esta instancia</para>
			/// </summary>
			public void Clear()
			{
				Container.Controls.Clear();
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
				return Container.Controls.Contains((System.Web.UI.Control) item);
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
				for (int i = 0; i < Container.Controls.Count; i += 2)
				{
					array[i] = (IControl) Container.Controls[i];
				}
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
				foreach (var control in Container.Controls)
				{
					if (control is System.Web.UI.LiteralControl && ((System.Web.UI.LiteralControl) control).Text == "<br />")
					{
						continue;
					}

					yield return (IControl) control;
				}
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
				return Container.Controls.IndexOf((System.Web.UI.Control) item) / 2;
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
				Container.Controls.AddAt(index * 2, (System.Web.UI.Control) item);
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
				if (Contains(item))
				{
					int index = Container.Controls.IndexOf((System.Web.UI.Control) item);

					Container.Controls.RemoveAt(index);
					Container.Controls.RemoveAt(index);  //remove <br />

					return true;
				}
				else
				{
					return false;
				}
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
				Container.Controls.RemoveAt(index);
				Container.Controls.RemoveAt(index);  //remove <br />
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