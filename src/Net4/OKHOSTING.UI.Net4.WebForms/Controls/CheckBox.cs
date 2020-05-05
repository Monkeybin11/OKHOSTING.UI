using System;
using System.Drawing;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// It is a control that represents a checkbox
	/// <para xml:lang="es">Es un control que representa un checkbox</para>
	/// </summary>
	public class CheckBox : System.Web.UI.WebControls.CheckBox, ICheckBox, IInputControl
	{
		#region IControl

		/// <summary>
		/// Gets or sets the name of the checkbox
		/// <para xml:lang="es">Obtiene o establece el nombre del checkbox</para>
		/// </summary>
		/// <value>The name of the checkbox.
		/// <para xml:lang="es">El nombre del checkbox</para>
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
		/// Gets or sets the background of the checkbox
		/// <para xml:lang="es">Obtiene o establece el color de fondo del checkbox</para>
		/// </summary>
		/// <value>The background of the checkbox.
		/// <para xml:lang="es">El color de fondo del checkbox</para>
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
		/// Gets or sets the BorderColor of the checkbox
		/// <para xml:lang="es">Obtiene o establece el color del borde del checkbox</para>
		/// </summary>
		/// <value>The BorderColor of the checkbox.
		/// <para xml:lang="es">El color del borde del checkbox.</para>
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
		/// Gets or sets the width of the checkbox.
		/// <para xml:lang="es">Obtiene o establece el ancho del checkbox</para>
		/// </summary>
		/// <value>The width of the checkbox.
		/// <para xml:lang="es">El ancho del checkbox.</para>
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
		/// Gets or sets the height the checkbox.
		/// <para xml:lang="es">Obtiene o establece la altura del checkbox</para>
		/// </summary>
		/// <value>The height of the ckeckbox.
		/// <para xml:lang="es">La altura del checkbox</para>
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
		/// Gets or sets the horizontalalignment of the checkbox.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del checkbox</para> 
		/// </summary>
		/// <value>The horizontalalignment of the checkbox.</value>
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

				//Verify the horizontal alignment provided.
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
		/// Gets or sets the verticalalignment of the checkbox.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical del checkbox</para>
		/// </summary>
		/// <value>The verticalalignment of the checkbox.</value>
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

				//Verify the vertical alignment provided.
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
		/// <para xml:lang="es">Obtiene o establece un valor de objeto arbitrario que puede ser usado para almacenar informacion personalizada sobre este elemento</para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">
		/// Regresa el valor previsto. Esta propiedad no tiene ningun valor predeterminado.
		/// </para>
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
				return (IControl) base.Parent;
			}
		}

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}

		#endregion

		#region IInputControl

		bool IInputControl.HandlePostBack()
		{
			string postedValue = Page?.Request.Form[ID];
			bool value = postedValue == "on";

			if (value != ((ICheckBox) this).Value)
			{
				((ICheckBox) this).Value = value;
				return true;
			}
			else
			{
				return false;
			}
		}

		void IInputControl.RaiseValueChanged()
		{
			ValueChanged?.Invoke(this, ((ICheckBox) this).Value);
		}

		#endregion

		/// <summary>
		/// Gets or sets the input value of the checkbox
		/// <para xml:lang="es">Obtiene o establece el valor de entrada del checkbox</para>
		/// </summary>
		/// <value>The value of the checkbox.
		/// <para xml:lang="es">El valor del checkbox</para>
		/// </value>
		bool IInputControl<bool>.Value
		{
			get
			{
				return base.Checked;
			}
			set
			{
				base.Checked = value;
			}
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">Se produce cuando cambia el valor</para>
		/// </summary>
		public event EventHandler<bool> ValueChanged;

		/// <summary>
		/// Does nothing since we manage state ourselves
		/// </summary>
		protected override bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
		{
			return true;
		}

		/// <summary>
		/// Ons the pre render.
		/// </summary>
		/// <returns>The pre render.</returns>
		/// <param name="e">E.</param>
		protected override void OnPreRender(EventArgs e)
		{
			AutoPostBack = ValueChanged != null;
			base.OnPreRender(e);
		}
	}
}