﻿using System;
using System.Drawing;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// Its a control that represents a HiperLink
	/// <para xml:lang="es">Es un control que representa un hiperlink</para>
	/// </summary>
	public class HyperLink : System.Web.UI.WebControls.HyperLink, IHyperLink
	{
		#region IControl

		/// <summary>
		/// Gets or sets the name of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece el nombre del hiperlink</para>
		/// </summary>
		/// <value>The name of the HiperLink.
		/// <para xml:lang="es">El nombre del hiperlink</para>
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
		/// Gets or sets the background of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del hiperlink</para>
		/// </summary>
		/// <value>The background of the hiperlink.
		/// <para xml:lang="es">El color de fondo del hiperlink</para>
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
		/// Gets or sets the BorderColor of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece el color del borde del hiperlink</para>
		/// </summary>
		/// <value>The BorderColor of the HiperLink.
		/// <para xml:lang="es">El color del borde del hiperlink</para>
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
		/// Gets or Sets the width of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece el ancho del hiperlink</para>
		/// </summary>
		/// <value>The width of the HiperLink.
		/// <para xml:lang="es">El ancho del hiperlink</para>
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
		/// Gets or sets the Height of the HiperLink
		/// <para xml:lang="es">Obtiene o establece la altura del hiperlink</para>
		/// </summary>
		/// <value>The height of the HiperLink.
		/// <para xml:lang="es">La altura del hiperlink</para>
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
		/// Gets or sets the HorizontalAlignment of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del hiperlink.</para>
		/// </summary>
		/// <value>The HorizontalAlignment of the HiperLink.
		/// <para xml:lang="es">La alineacion horizontal del hiperlink</para>
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
				this.RemoveCssClassesStartingWith("horizontal-alignment");
				this.AddCssClass("horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the VerticalAlignment of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical del hiperlink</para>
		/// </summary>
		/// <value>The VerticalAlignemnt of the HiperLink.
		/// <para xml:lang="es">La alineacion vertical del hiperlink</para>
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
				this.RemoveCssClassesStartingWith("vertical-alignment");
				this.AddCssClass("vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">Obtiene o establece un valor de objeto arbitrario que se puede usar para almacenar informacion personalizada sobre este elemento</para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:alng="es">Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.</para>
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

		#endregion

		#region ITextControl

		/// <summary>
		/// Gets or sets the FontColor of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece el color del texto del iperlink.</para>
		/// </summary>
		/// <value>The FontColor of the HiperLink.
		/// <para xml:lang="es">El color del texto del hiperlink.</para>
		/// </value>
		Color ITextControl.FontColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		/// <summary>
		/// Gets or sets the FontFamily of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece la tipografia del texto del hiperlink</para>
		/// </summary>
		/// <value>The FontFamily of the HiperLink.
		/// <para xml:lang="es">La tipografia del texto del hiperlink.</para>
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
		/// Gets or sets the FontSize of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece el tamaño del texto del hiperlink.</para>
		/// </summary>
		/// <value>The FontSize of the HiperLink.
		/// <para xml:lang="es">El tamaño del texto del hiperlink.</para>
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
		/// Gets or sets the bold text of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece el texto en negritas del hiperlink.</para>
		/// </summary>
		/// <value>The text bold of the HiperLink.
		/// <para xml:lang="es">El texto en negritas del hiperlink.</para>
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
		/// Gets or sets the italic text of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece el texto en italica del hiperlink</para>
		/// </summary>
		/// <value>The italic text of the HiperLink.
		/// <para xml:lang="es">El texto en italica del hiperlink</para>
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
		/// Gets or sets the UnderLine text of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece el texto en subrayado del hiperlink</para>
		/// </summary>
		/// <value>The UnderLine text of the HiperLink.
		/// <para xml:lang="es">El texto en subrayado del hiperlink</para>
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
		/// Gets or sets the TextHorizontalAlignment of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del texto del hiperlink</para>
		/// </summary>
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
				this.RemoveCssClassesStartingWith("text-horizontal-alignment");
				this.AddCssClass("text-horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the TextVerticalAlignment of the HiperLink.
		/// <para xml:lang="es">Obtiene o establece la alineación vertical del hiperlink.</para>
		/// </summary>
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
				this.RemoveCssClassesStartingWith("text-vertical-alignment");
				this.AddCssClass("text-vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the padding text of the HiperLink.
		/// <para xml:lang="es">obtiene o establece el padding del texto del hiperlink.</para>
		/// </summary>
		Thickness ITextControl.TextPadding
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["padding-left"].Replace("px", null), out left)) thickness.Left = left;
				if (double.TryParse(base.Style["padding-top"].Replace("px", null), out top)) thickness.Top = top;
				if (double.TryParse(base.Style["padding-right"].Replace("px", null), out right)) thickness.Right = right;
				if (double.TryParse(base.Style["padding-bottom"].Replace("px", null), out bottom)) thickness.Bottom = bottom;

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
		/// Gets or sets the address that will reference the hyperlink.
		/// <para xml:lang="es">Obtiene o establece la direccion a la que hara referencia el hiperlink.</para>
		/// </summary>
		public Uri Uri
		{
			get
			{
				return new Uri(base.NavigateUrl);
			}
			set
			{
				base.NavigateUrl = value.ToString();
			}
		}
	}
}