using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NativeControl = System.Web.UI.Control;

namespace OKHOSTING.UI.Net4.Ajax.Controls.Layout
{
	/// <summary>
	/// A board where you can store objects, which you can give design through its properties.
	/// <para xml:lang="es">
	/// Un tablero donde se pueden almacenar objetos, al cual le podemos dar diseño por medio de sus propiedades.
	/// </para>
	/// </summary>
	public class RelativePanel: System.Web.UI.WebControls.Panel, IRelativePanel
	{
		protected readonly ControlList _Children;
		protected readonly List<string> ClientScripts = new List<string>();

		/// <summary>
		/// Initializes a new instance of the RelativePanel class.
		/// <para xml:lang="es">Inicilaiza una nueva instancia de la clase RelativePanel</para>
		/// </summary>
		public RelativePanel()
		{
			_Children = new ControlList(this);
		}

		/// <summary>
		/// Gets the children controls of the current panel.
		/// <para xml:lang="es">Obtiene los controles hijos del panel actual</para>
		/// </summary>
		/// <value>The children.
		/// <para xml:lang="es">Los controles hijos</para>
		/// </value>
		IList<IControl> IRelativePanel.Children
		{
			get
			{
				return _Children;
			}
		}

		/// <summary>
		/// Adds the specified control, specifying its horizontal and vertical position and a control reference.
		/// <para xml:lang="es">Agrega el control especificado, especificando su posicion horizontal y vertical y un control de referencia</para>
		/// </summary>
		/// <param name="control">Control.
		/// <para xml:lang="es">El control a agregar.</para>
		/// </param>
		/// <param name="horizontalContraint">Horizontal contraint.
		/// <para xml:lang="es">Referencia horizontal donde se colocara el control.</para>
		/// </param>
		/// <param name="verticalContraint">Vertical contraint.
		/// <para xml:lang="es">Referencia vertical donde se colocara el control.</para>
		/// </param>
		/// <param name="referenceControl">Reference control.
		/// <para xml:lang="es">Control de referencia.</para>
		/// </param>
		void IRelativePanel.Add(IControl control, RelativePanelHorizontalContraint horizontalContraint, RelativePanelVerticalContraint verticalContraint, IControl referenceControl)
		{
			if (control == null)
			{
				throw new ArgumentNullException(nameof(control));
			}

			//if no reference control is provided, then use this panel as reference
			if (referenceControl == null)
			{
				referenceControl = this;
			}

			base.Controls.Add((NativeControl) control);

			//the anchors at the current control
			string myHorizontalAnchor = "center";
			string myVerticalAnchor = "center";

			//the anchors at the reference control
			string atHorizontalAnchor = "center";
			string atVerticalAnchor = "center";

			//the reference control's id
			string of = ((NativeControl)referenceControl).ClientID;

			//horizontal constraint

			switch (horizontalContraint)
			{
				case RelativePanelHorizontalContraint.CenterWith:
					myHorizontalAnchor = "center";
					atHorizontalAnchor = "center";
					break;

				case RelativePanelHorizontalContraint.LeftOf:
					myHorizontalAnchor = "right";
					atHorizontalAnchor = "left";
					break;

				case RelativePanelHorizontalContraint.LeftWith:
					myHorizontalAnchor = "left";
					atHorizontalAnchor = "left";
					break;

				case RelativePanelHorizontalContraint.RightOf:
					myHorizontalAnchor = "left";
					atHorizontalAnchor = "right";
					break;

				case RelativePanelHorizontalContraint.RightWith:
					myHorizontalAnchor = "right";
					atHorizontalAnchor = "right";
					break;
			}

			//vertical constraint

			switch (verticalContraint)
			{
				case RelativePanelVerticalContraint.AboveOf:
					myVerticalAnchor = "bottom";
					atVerticalAnchor = "top";
					break;

				case RelativePanelVerticalContraint.BelowOf:
					myVerticalAnchor = "top";
					atVerticalAnchor = "bottom";
					break;

				case RelativePanelVerticalContraint.BottomWith:
					myVerticalAnchor = "bottom";
					atVerticalAnchor = "bottom";
					break;

				case RelativePanelVerticalContraint.CenterWith:
					myVerticalAnchor = "center";
					atVerticalAnchor = "center";
					break;

				case RelativePanelVerticalContraint.TopWith:
					myVerticalAnchor = "top";
					atVerticalAnchor = "top";
					break;
			}

			string positionJS = string.Format
			(
				@"
				$('#{0}').position
				(
					{{
						my: '{1} {2}',
						at: '{3} {4}',
						of: '#{5}'
					}}
				);", 
				((NativeControl) control).ClientID, myHorizontalAnchor, myVerticalAnchor, atHorizontalAnchor, atVerticalAnchor, ((NativeControl) referenceControl).ClientID
			);

			ClientScripts.Add(positionJS);
		}

		/// <summary>
		/// Raises the pre render event.
		/// <para xml:lang="es"></para>
		/// </summary>
		/// <param name="e">E.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			string positionJS = string.Format
			(
				@"
				<script type='text/javascript'>
					$(document).ready
					(
						function()
						{{
							{0}
						}}
					);
				</script>"
			, string.Join(Environment.NewLine, ClientScripts)
			);

			((System.Web.UI.Page) Platform.Current.Page).ClientScript.RegisterStartupScript(this.GetType(), "position_" + base.ClientID, positionJS);
		}

		#region IControl

		/// <summary>
		/// Gets or sets the name.
		/// <para xml:lang="es">Obtiene o establece el nombre del control.</para>
		/// </summary>
		/// <value>The name.
		/// <para xml:lang="es">El nombre.</para>
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
		/// Gets or sets the color of the background of the panel.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del panel.</para>
		/// </summary>
		/// <value>The color of the background.
		/// <para xml:lang="es">El color de fondo.</para>
		/// </value>
		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Current.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = Platform.Current.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the color of the border of the panel.
		/// <para xml:lang="es">Obtiene o establece el color del borde del panel.</para>
		/// </summary>
		/// <value>The color of the border.
		/// <para xml:lang="es">El color del borde.</para>
		/// </value>
		Color IControl.BorderColor
		{
			get
			{
				return Platform.Current.Parse(base.BorderColor);
			}
			set
			{
				base.BorderColor = Platform.Current.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the width of the panel.
		/// <para xml:lang="es">Obtiene o establece el ancho del panel.</para>
		/// </summary>
		/// <value>The width.
		/// <para xml:lang="es">El ancho.</para>
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
		/// Gets or sets the height of the panel.
		/// <para xml:lang="es">Obtiene o establece la altura del panel.</para>
		/// </summary>
		/// <value>The height.
		/// <para xml:lang="es">La altura.</para>
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
		/// Gets or sets the margin toward the left, top, right and bottom of the panel.
		/// <para xml:lang="es">Obtiene o establece el margen hacia la izquiera, arriba, derecha y abajo del panel.</para>
		/// </summary>
		/// <value>The margin.</value>
		Thickness IControl.Margin
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["margin-left"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["margin-top"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["margin-right"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["margin-bottom"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["margin-left"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["margin-top"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["margin-right"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["margin-bottom"] = string.Format("{0}px", value.Bottom);
			}
		}

		/// <summary>
		/// Gets or sets the width of the border of the panel.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del panel.</para>
		/// </summary>
		/// <value>The width of the border.
		/// <para xml:lang="es">El ancho del borde.</para>
		/// </value>
		Thickness IControl.BorderWidth
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["border-left-width"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["border-top-width"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["border-right-width"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["border-bottom-width"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["border-left-width"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["border-top-width"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["border-right-width"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["border-bottom-width"] = string.Format("{0}px", value.Bottom);
			}
		}

		/// <summary>
		/// Gets or sets the horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal.</para>
		/// </summary>
		/// <value>The horizontal alignment.
		/// <para xml:lang="es">La alineacion horizontal.</para>
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
				Platform.Current.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				Platform.Current.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical.</para>
		/// </summary>
		/// <value>The vertical alignment.
		/// <para xml:lang="es">La alineacion vertical.</para>
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
				Platform.Current.RemoveCssClassesStartingWith(this, "vertical-alignment");
				Platform.Current.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
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
		/// It is used to find out information controls containing the panel.
		/// <para xml:lang="es">Se usa para saber la informacion de los controles que contiene el panel.</para>
		/// </summary>
		public class ControlList : IList<IControl>
		{
			private readonly RelativePanel ContainerPanel;

			/// <summary>
			/// Initializes a new instance of the "OKHOSTING.UI.Net4.Ajax.Controls.Layout.RelativePanel+ControlList" class.
			/// <para xml:lang="es">Inicializa una nueva instancia de la clase "OKHOSTING.UI.Net4.Ajax.Controls.Layout.RelativePanel+ControlList" class.</para>
			/// </summary>
			/// <param name="containerPanel">Container panel.</param>
			public ControlList(RelativePanel containerPanel)
			{
				ContainerPanel = containerPanel;
			}

			/// <summary>
			/// Gets or sets the existing control at the specified index.
			/// specified index.
			/// <para xml:lang="es">Obtiene o establece el control existente en el indice especificado.</para>
			/// </summary>
			/// <param name="index">Index.
			/// <para xml:lang="es">El indice.</para>
			/// </param>
			public IControl this[int index]
			{
				get
				{
					return (IControl) ContainerPanel.Controls[index];
				}
				set
				{
					ContainerPanel.Controls.RemoveAt(index);
					ContainerPanel.Controls.AddAt(index, (NativeControl) value);
				}
			}

			/// <summary>
			/// Gets the number of controls containing the current panel.
			/// <para xml:lang="es">Obtiene el numero de controles que contiene el panel actual.</para>
			/// </summary>
			/// <value>The count.
			/// <para xml:lang="es">La cuenta</para>
			/// </value>
			public int Count
			{
				get
				{
					return ContainerPanel.Controls.Count;
				}
			}

			/// <summary>
			/// Gets a value indicating whether this instance is read only.
			/// <para xml:lang="es">Obtiene un valor que indica si esta instanci es de solo lectura.</para>
			/// </summary>
			/// <value>true if this instance is read only; otherwise, false.
			/// <para xml:lang="es">Verdadero si es de solo lectura; de lo contrario, falso</para>
			/// </value>
			public bool IsReadOnly
			{
				get
				{
					return false;
				}
			}

			/// <Docs>The item to add to the current collection.
			/// <para xml:lang="es">El control a agregar al panel actual.</para>
			/// </Docs>
			/// <para>Adds an item to the current collection.
			/// <para xml:lang="es">Agrega un elemento al panel actual.</para>
			/// </para>
			/// <remarks>To be added.
			/// <para xml:lang="es">Para ser agregado.</para>
			/// </remarks>
			/// <summary>
			/// Add the specified item.
			/// <para xml:lang="es">Agrega el control especificado al panel.</para>
			/// </summary>
			/// <param name="item">Item.
			/// <para xml:lang="es">El control.</para>
			/// </param>
			public void Add(IControl item)
			{
				ContainerPanel.Controls.Add((NativeControl) item);
			}

			/// <summary>
			/// Clear this instance.
			/// <para xml:lang="es">Limpia esta instancia.</para>
			/// </summary>
			public void Clear()
			{
				ContainerPanel.Controls.Clear();
			}

			/// <Docs>The object to locate in the current collection.
			/// <para xml:lang="es">El objeto a localizar en el panel actual.</para>
			/// </Docs>
			/// <para>Determines whether the current collection contains a specific value.
			/// <para xml:lang="es">Determina si el panel actual contiene un valor especifico.</para>
			/// </para>
			/// <summary>
			/// Contains the specified item.
			/// <para xml:lang="es">Verificamos si contiene el control especificado.</para>
			/// </summary>
			/// <param name="item">Item.</param>
			public bool Contains(IControl item)
			{
				return ContainerPanel.Controls.Contains((NativeControl) item);
			}

			/// <summary>
			/// Copy the controls specified array, specifying index of the array.
			/// <para xml:lang="es">Copia los controles al arreglo especificado, especificandole el indice del arreglo.</para>
			/// </summary>
			/// <param name="array">Array.
			/// <para xml:lang="es">El arreglo.</para>
			/// </param>
			/// <param name="arrayIndex">Array index.
			/// <para xml:lang="es">El indice del arreglo.</para>
			/// </param>
			public void CopyTo(IControl[] array, int arrayIndex)
			{
				for (int i = 0; i < ContainerPanel.Controls.Count; i++)
				{
					array[i] = (IControl) ContainerPanel.Controls[i];
				}
			}

			/// <summary>
			/// Gets the enumerator.
			/// <para xml:lang="es">Obtiene la enumeracion de los controles nativos contenidos en el panel.</para>
			/// </summary>
			/// <returns>The enumerator.
			/// <para xml:lang="es">La enumeracion.</para>
			/// </returns>
			public IEnumerator<IControl> GetEnumerator()
			{
				foreach (NativeControl control in ContainerPanel.Controls)
				{
					yield return (IControl) control;
				}
			}

			/// <summary>
			/// Determines the index of a specific item in the current instance.
			/// <para xml:lang="es">Determina el indice de un control especificado en el panel actual.</para>
			/// </summary>
			/// <returns>The index of the specified control.
			/// <para xml:lang="es">El indice del control especificado.</para>
			/// </returns>
			/// <param name="item">Item.
			/// <para xml:lang="es">El control.</para>
			/// </param>
			public int IndexOf(IControl item)
			{
				return ContainerPanel.Controls.IndexOf((NativeControl) item);
			}

			/// <summary>
			/// Insert the specified control in the specified index.
			/// <para xml:lang="es">
			/// Inserta el control especificado en el indice especificado.
			/// </para>
			/// </summary>
			/// <param name="index">Index.
			/// <para xml:lang="es">El indice.</para>
			/// </param>
			/// <param name="item">Item.
			/// <para xml:lang="es">El control.</para>
			/// </param>
			public void Insert(int index, IControl item)
			{
				ContainerPanel.Controls.AddAt(index, (NativeControl) item);
			}

			/// <summary>
			/// Removes the first occurrence of an item from the current collection.
			/// <para xml:lang="es">Quita la primer aparicion de un elemento en el panel actual.</para>
			/// </summary>
			/// <param name="item">Item.
			/// <para xml:lang="es">El control.</para>
			/// </param>
			public bool Remove(IControl item)
			{
				if (Contains(item))
				{
					ContainerPanel.Controls.Remove((NativeControl)item);
					return true;
				}
				else
				{
					return false;
				}
			}

			/// <summary>
			/// Remove a children control, at the specified index location, from the current panel.
			/// <para xml:lang="es">
			/// Elimina un control hijo, en el indice especificado del panel actual.
			/// </para>
			/// </summary>
			/// <param name="index">Index.</param>
			public void RemoveAt(int index)
			{
				ContainerPanel.Controls.RemoveAt(index);
			}

			/// <summary>
			/// Gets the enumerator of the controls natives content in the panel.
			/// <para xml:lang="es">Obtiene la enumeracion de los controles nativos contenidos en el panel.</para>
			/// </summary>
			/// <returns>The enumerator.
			/// <para xml:lang="es">El enumerador</para>
			/// </returns>
			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}
	}
}