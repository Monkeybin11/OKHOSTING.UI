using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// It represents a text box that masks the input visibly.
	/// <para xml:lang="es">Representa un cuadro de texto que visiblemente enmascara la entrada.</para>
	/// </summary>
	public class PasswordTextBox : System.Web.UI.WebControls.TextBox, IPasswordTextBox
	{
		/// <summary>
		/// Initializes a new instance of the PasswordTextBox class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase PasswordTextBox.</para>
		/// </summary>
		public PasswordTextBox()
		{
			base.TextMode = System.Web.UI.WebControls.TextBoxMode.Password;
		}

		#region IControl

		/// <summary>
		/// Gets or sets the name of the control.
		/// <para xml:lang="es">Obtiene o establece el nombre del control</para>
		/// </summary>
		/// <value>The name of the control.
		/// <para xml:lang="es">El nombre del control</para>
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
		/// Gets or sets the background of the control.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del control</para>
		/// </summary>
		/// <value>The background of the hiperlink.
		/// <para xml:lang="es">El color de fondo del control.</para>
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
		/// Gets or sets the BorderColor of the control.
		/// <para xml:lang="es">Obtiene o establece el color del borde del control</para>
		/// </summary>
		/// <value>The BorderColor of the control.
		/// <para xml:lang="es">El color del borde del control</para>
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
		/// Gets or Sets the width of the control.
		/// <para xml:lang="es">Obtiene o establece el ancho del control</para>
		/// </summary>
		/// <value>The width of the control.
		/// <para xml:lang="es">El ancho del control</para>
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
		/// Gets or sets the Height of the control
		/// <para xml:lang="es">Obtiene o establece la altura del control</para>
		/// </summary>
		/// <value>The height of the control.
		/// <para xml:lang="es">La altura del control</para>
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
		/// Gets or sets the margin of the control.
		/// <para xml:lang="es">Obtien o establece el margen del control</para>
		/// </summary>
		/// <value>The margin of the control.
		/// <para xml:lang="es">El margen del control</para>
		/// </value>
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
		/// Gets or sets the BorderWidth of the control.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del control.</para>
		/// </summary>
		/// <value>The BorderWidth of the control.
		/// <para xml:lang="es">El ancho del borde del control.</para>
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
		/// Gets or sets the HorizontalAlignment of the control.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del control.</para>
		/// </summary>
		/// <value>The HorizontalAlignment of the control.
		/// <para xml:lang="es">La alineacion horizontal del control</para>
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
				Platform.Current.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				Platform.Current.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the VerticalAlignment of the control.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical del control</para>
		/// </summary>
		/// <value>The VerticalAlignemnt of the control.
		/// <para xml:lang="es">La alineacion vertical del control</para>
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
				Platform.Current.RemoveCssClassesStartingWith(this, "vertical-alignment");
				Platform.Current.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">Obtiene o establece un objeto con valor arbitrario que puede ser usado para almacenar informacion personalizada de este elemento.</para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.</para>
		/// </remmarks>
		object IControl.Tag
		{
			get; set;
		}

		#region IInputControl

		/// <summary>
		/// Gets or sets the input control value.
		/// <para xml:lang="es">Obtiene o establece el valor de entrada del control.</para>
		/// </summary>
		/// <value>The imput value.
		/// <para xml:lang="es">El valor de entrada.</para>
		/// </value>
		string IInputControl<string>.Value
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">Ocurre cuando el valor es cambiado.</para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// Raises the value changed.
		/// <para xml:lang="es">Cambia el valor.</para>
		/// </summary>
		/// <returns>The value changed.
		/// <para xml:lang="es">El valor cambiado</para>
		/// </returns>
		protected internal void RaiseValueChanged()
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, ((IInputControl<string>)this).Value);
			}
		}

		#endregion


		#endregion

		/// <summary>
		/// Ons the pre render.
		/// <para xml:lang="es">Ocurre antes de hacer el cambio.</para>
		/// </summary>
		/// <returns>The pre render.</returns>
		/// <param name="e">E.</param>
		protected override void OnPreRender(EventArgs e)
		{
			AutoPostBack = ValueChanged != null;
			base.OnPreRender(e);
		}

		/// <summary>
		/// Does nothing since we manage state ourselves
		/// </summary>
		protected override bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
		{
			return true;
		}
	}
}