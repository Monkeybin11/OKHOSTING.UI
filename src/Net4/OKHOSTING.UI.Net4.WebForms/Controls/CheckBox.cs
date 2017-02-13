using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// It is a control that represents a checkbox
	/// <para xml:lang="es">Es un control que representa un checkbox</para>
	/// </summary>
	public class CheckBox : System.Web.UI.WebControls.CheckBox, ICheckBox
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
				return Platform.Current.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = Platform.Current.Parse(value);
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
				return Platform.Current.Parse(base.BorderColor);
			}
			set
			{
				base.BorderColor = Platform.Current.Parse(value);
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
		/// Gets or sets the margin of the checkbox
		/// <para xml:lang="es">Obtiene o establece el margen del checkbox</para>
		/// </summary>
		/// <value>The margin of the checkbox.
		/// <para xml:lang="es">El margen del checkbox.</para>
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
		/// Gets or sets the BorderWidth of the checkbox.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del checkbox</para>
		/// </summary>
		/// <value>The BorderWidth of the checkbox.
		/// <para xml:lang="es">El ancho del borde del checkbox </para>
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
				Platform.Current.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				Platform.Current.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
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
				Platform.Current.RemoveCssClassesStartingWith(this, "vertical-alignment");
				Platform.Current.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
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

		#endregion

		#region ITextControl

		/// <summary>
		/// Gets or sets the fontcolor of the Checkbox
		/// <para xml:lang="es">Obtiene o establece el color de la fuente del checkbox</para>
		/// </summary>
		/// <value>The fontcolor of the checkbox.</value>
		Color ITextControl.FontColor
		{
			get
			{
				return Platform.Current.Parse(base.ForeColor);
			}
			set
			{
				base.ForeColor = Platform.Current.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets of the FontFamily of the checkbox.
		/// <para xml:lang="es">Obtiene o establece la tipografia del texto del checkbox</para>
		/// </summary>
		/// <value>The FontFamily of the checkbox.
		/// <para xml:lang="es">La tipografia del texto del checkbox</para>
		/// </value>
		string ITextControl.FontFamily
		{
			get
			{
				return base.Font.Name;
			}
			set
			{
				base.Font.Name = value;
			}
		}

		/// <summary>
		/// Gets or sets the FontSize of checkbox.
		/// <para xml:lang="es">Obtiene o establece el tamaño del texto del checkbox</para>
		/// </summary>
		/// <value>The fontsize of the checkbox.
		/// <para xml:lang="es">El tamaño del texto del checkbox</para>
		/// </value>
		double ITextControl.FontSize
		{
			get
			{
				return base.Font.Size.Unit.Value;
			}
			set
			{
				base.Font.Size = new System.Web.UI.WebControls.FontUnit(value, System.Web.UI.WebControls.UnitType.Pixel);
			}
		}

		/// <summary>
		/// Gets or sets the text checkbox bold.
		/// <para xml:lang="es">Obtiene  establece el texto en negritas del checkbox</para>
		/// </summary>
		/// <value>The checkbox text in bold.
		/// <para xml:lang="es">El texto en negritas del checkbox</para>
		/// </value>
		bool ITextControl.Bold
		{
			get
			{
				return base.Font.Bold;
			}
			set
			{
				base.Font.Bold = value;
			}
		}

		/// <summary>
		/// Gets or sets text checkbox italic.
		/// <para xml:lamg="es">Obtiene o establece el texto en italica del checkbox</para> 
		/// </summary>
		/// <value>Text checkbox italic.
		/// <para xml:lang="es">El texto enitalica del checkbox</para>
		/// </value>
		bool ITextControl.Italic
		{
			get
			{
				return base.Font.Italic;
			}
			set
			{
				base.Font.Italic = value;
			}
		}

		/// <summary>
		/// Gets or sets text underline of the checkbox.
		/// <para xml:lang="es">Obtiene o establece el texto subrayado del checkbox</para>
		/// </summary>
		/// <value>The text underline of the checkbox.</value>
		bool ITextControl.Underline
		{
			get
			{
				return base.Font.Underline;
			}
			set
			{
				base.Font.Underline = value;
			}
		}

		/// <summary>
		/// Gets or sets text ckeckbox. text horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del texto del checkbox</para>
		/// </summary>
		/// <value>Text checkbox. text horizontal alignment.
		/// <para xml:lang="es">La alineacion horizontal del texto del checkbox.</para>
		/// </value>
		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{

			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("text-horizontal-alignment")).SingleOrDefault();

				//if not text horizontal alignment is provided, the alignment back to the left.
				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return HorizontalAlignment.Left;
				}

				//Verify the text horizontal alignment provided.
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
				Platform.Current.RemoveCssClassesStartingWith(this, "text-horizontal-alignment");
				Platform.Current.AddCssClass(this, "text-horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the TextVerticalAlignment of the checkbox.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical del texto del checkbox</para>
		/// </summary>
		/// <value>The TextVerticalAlingnment of the checkbox.</value>
		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("text-vertical-alignment")).SingleOrDefault();

				//if not text vertical alignment is provided, the alignment back to the top.
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
				Platform.Current.RemoveCssClassesStartingWith(this, "text-vertical-alignment");
				Platform.Current.AddCssClass(this, "text-vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the padding in the text checkbox.
		/// <para xml:lang="es">Obtiene o establece el padding del texto del checkbox.</para>
		/// </summary>
		/// <value>The padding in the text checkbox.
		/// <para xml:lang="es">El padding del texto del checkbox</para>
		/// </value>
		Thickness ITextControl.TextPadding
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["padding-left"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["padding-top"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["padding-right"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["padding-bottom"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["padding-left"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["padding-top"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["padding-right"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["padding-bottom"] = string.Format("{0}px", value.Bottom);
			}
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
		/// Raises the value changed.
		/// <para xml:lang="es">Pone el valor cambiado</para>
		/// </summary>
		/// <returns>The value changed.
		/// <para xml:lang="es">El valor cambiado.</para>
		/// </returns>
		protected internal void RaiseValueChanged()
		{
			ValueChanged?.Invoke(this, ((IInputControl<bool>)this).Value);
		}

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