using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// It is a control that represents a button.
	/// <para xml:lang="es">Es un control que representa un boton</para>
	/// </summary>
	public class Button : System.Web.UI.WebControls.Button, IButton
	{
		/// <summary>
		/// Occurs when click.
		/// <para xml:lang="es">Ocurre cuando hay un evento clic de un boton.</para>
		/// </summary>
		public new event EventHandler Click;

		/// <summary>
		/// Raises the click.
		/// <para xml:lang="es">Es el evento que proboca el clic</para>
		/// </summary>
		/// <returns>The click.
		/// <para xml:lang="es">El clic.</para>
		/// </returns>
		protected internal virtual void Raise_Click()
		{
			if (Click != null)
			{
				Click(this, new EventArgs());
			}
		}

		#region IControl

		/// <summary>
		/// Gets or sets the name of the IC ontrol.
		/// <para xml:lang="es">Obtiene o establece el nombre del control</para>
		/// </summary>
		/// <value>The name of the IC ontrol.
		/// <para xml:lang="es">El nombre del control.</para>
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
		/// Gets or sets the color of the IC ontrol. background.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del control.</para>
		/// </summary>
		/// <value>The color of the IC ontrol. background.
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
		/// Gets or sets the color of the IC ontrol. border.
		/// <para xml:lang="es">Obtiene o establece el color del borde del control.</para>
		/// </summary>
		/// <value>The color of the IC ontrol. border.
		/// <para xml:lang="es">El color del borde del control.</para>
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
		/// Gets or sets the width of the IC ontrol..
		/// <para xml:lang="es">Obtiene o establece el ancho del control.</para>
		/// </summary>
		/// <value>The width of the IC ontrol.
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
		/// Gets or sets the height of the IC ontrol..
		/// <para xml:lang="es">Obtiene o establece la altura del control</para>
		/// </summary>
		/// <value>The height of the IC ontrol.
		/// <para xml:lang="es">La altura del control.</para>
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
		/// Gets or sets the IC ontrol. margin.
		/// <para xml:lang="es">Obtiene o establece el margen del control.</para>
		/// </summary>
		/// <value>The IC ontrol. margin.
		/// <para xml:lang="es">El margen del control.</para>
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
		/// Gets or sets the width of the IC ontrol. border.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del control.</para>
		/// </summary>
		/// <value>The width of the IC ontrol. border.</value>
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
		/// Gets or sets the IC ontrol. horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del control.</para>
		/// </summary>
		/// <value>The IC ontrol. horizontal alignment.
		/// <para xml:lang="es">La alineacion horizontal del control.</para>
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
		/// Gets or sets the IC ontrol. vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacio vertical del control</para>
		/// </summary>
		/// <value>The IC ontrol. vertical alignment.
		/// <para xml:lang="es">La laineacion vertical del control.</para>
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
		/// <para xml:lang="es">Obtiene o establece un valor de objeto arbitraio que se puede usar para almacenar informacion personalizada sobre este elemento</para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">Devuelve el valor previsto. Esta propiedad no tiene ningun valor predeterminado.</para>
		/// </remmarks>
		object IControl.Tag
		{
			get; set;
		}

		#endregion

		#region ITextControl

		/// <summary>
		/// Gets or sets the color of the IT ext control. font.
		/// <para xml:lang="es">Obtiene o establece el color del texto del control.</para>
		/// </summary>
		/// <value>The color of the IT ext control. font.
		/// <para xml:lang="es">El color del texto del control.</para>
		/// </value>
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
		/// Gets or sets IT ext control. font family.
		/// <para xml:lang="es">Obtiene o establece la tipografia del texto del control.</para>
		/// </summary>
		/// <value>IT ext control. font family.
		/// <para xml:lang="es">La tipografia del texto del control.</para>
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
		/// Gets or sets the size of the IT ext control. font.
		/// <para xml:lang="es">Obtiene o establece el tamaño del texto del control.</para>
		/// </summary>
		/// <value>The size of the IT ext control. font.
		/// <para xml:lang="es">El tamaño del texto del control.</para>
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
		/// Gets or sets IT ext control. bold.
		/// <para xml:lang="es">Obtiene o establece si existe texto en negritas en el control</para>
		/// </summary>
		/// <value>IT ext control. bold.
		/// <para xml:lang="es">El texto en negritas del control.</para>
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
		/// Gets or sets IT ext control. italic.
		/// <para xml:lang="es">Obtiene o establece si el control contiene texto en italica.</para>
		/// </summary>
		/// <value>IT ext control. italic.
		/// <para xml:lang="es">El texto del control en italica.</para>
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
		/// Gets or sets IT ext control. underline.
		/// <para xml:lang="es">Obtiene o establece si el control contiene texto subrrayado.</para>
		/// </summary>
		/// <value>IT ext control. underline.
		/// <para xml:lang="es">El texto subrayado del control</para>
		/// </value>
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
		/// Gets or sets IT ext control. text horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del texto</para>
		/// </summary>
		/// <value>IT ext control. text horizontal alignment.
		/// <para xml:lang="es">La alineacion horizontal del texto</para>
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
		/// Gets or sets IT ext control. text vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical del texto</para>
		/// </summary>
		/// <value>IT ext control. text vertical alignment.
		/// <para xml:lang="es">La alineacion vertical del texto.</para>
		/// </value>
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
		/// Gets or sets IT ext control. text padding.
		/// <para xml:lang="es">Obtiene o establece el padding en el texto del control</para>
		/// </summary>
		/// <value>IT ext control. text padding.
		/// <para xml:lang="es">El padding del texto del control.</para>
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
	}
}