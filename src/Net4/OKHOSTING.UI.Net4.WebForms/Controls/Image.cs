using System;
using System.Drawing;
using System.Linq;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// It represents an image to which we can give you design through its properties.
	/// <para xml:lang="es">Representa una imagen a la cual le podemos dar diseño por medio de sus propiedades.</para>
	/// </summary>
	public class Image : System.Web.UI.WebControls.Image, IImage
	{
		#region IControl

		/// <summary>
		/// Gets or sets the name of the Image.
		/// <para xml:lang="es">Obtiene o establece el nombre de la imagen</para>
		/// </summary>
		/// <value>The name of the Image.
		/// <para xml:lang="es">El nombre de la imagen.</para>
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
		/// Gets or sets the BackgroundColor of the Image.
		/// <para xml:lang="es">Obtiene o establece el color de fondo de la imagen.</para>
		/// </summary>
		/// <value>The BackgroundColor of the Image.
		/// <para xml:lang="es">El color de fondo de la imagen.</para>
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
		/// Gets or sets of the BorderColor of the Image.
		/// <para xml:lang="es">Obtiene o establece el color del borde de la imagen.</para>
		/// </summary>
		/// <value>The BorderColor of the Image.
		/// <para xml:lang="es">El color del borde de la imagen.</para>
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
		/// Gets or sets the Width the Imagen.
		/// <para xml:lang="es">Obtien o establece el ancho de la imagen.</para>
		/// </summary>
		/// <value>The width of the Image.
		/// <para xml:lang="es">El ancho de la imagen.</para>
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
		/// Gets or sets the Height the Image.
		/// <para xml:lang="es">Obtiene o establece la altura de la imagen.</para>
		/// </summary>
		/// <value>The height of the Image.
		/// <para xml:lang="es">La altura de la imagen.</para>
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
		/// Gets or sets the Margin the Image.
		/// <para xml:lang="es">Obtiene o establece el margen de la imagen.</para>
		/// </summary>
		/// <value>The Margin of the Image.
		/// <para xml:lang="es">El margen de la imagen.</para>
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
		/// Gets or sets of the BorderWidht of the Image.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde de la imagen.</para>
		/// </summary>
		/// <value>The BorderWidth of the Image.
		/// <para xml:lang="es">El ancho del borde de la imagen.</para>
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
		/// Gets or sets the HorizontalAlignment of the Image.
		/// <para xml:lang="es">Obtiene o establece la alineacion horixontal de la imagen</para>
		/// </summary>
		/// <value>The HorizontalAlignment of the Image.
		/// <para xml:lang="es">La alineacion horizontal de la imagen.</para>
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
				Platform.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				Platform.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the VerticalAlignment of the Image.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical de la imagen</para>
		/// </summary>
		/// <value>The VerticalAlignment of the image.
		/// <para xml:lang="es">La alineación vertical de la imagen.</para>
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
				Platform.RemoveCssClassesStartingWith(this, "vertical-alignment");
				Platform.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">Obtiene o establece un valor de objeto arbitrario que puede ser usado para almacenar informacion personalizada sobre este elemento.</para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.</para>
		/// </remmarks>
		object IControl.Tag
		{
			get; set;
		}

		#endregion

		/// <summary>
		/// Loads from file.
		/// <para xml:lang="es">Carga la imagen del control desde una ruta de archivo.</para>
		/// </summary>
		/// <returns>The from file.
		/// <para xml:lang="es">El archivo.</para>
		/// </returns>
		/// <param name="filePath">File path.
		/// <para xml:lang="es">La ruta del archivo.</para>
		/// </param>
		public void LoadFromFile(string filePath)
		{
			if (!File.Exists(filePath))
			{
				throw new ArgumentOutOfRangeException("filePath", "The file does not exist");
			}

			using (var stream = File.OpenRead(filePath))
			{
				LoadFromStream(stream);
			}
		}

		public void LoadFromStream(Stream stream)
		{
			BinaryReader br = new BinaryReader(stream);
			byte[] bytes = br.ReadBytes((int) stream.Length);
			string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
			ImageUrl = "data:image/png;base64," + base64String;
		}

		/// <summary>
		/// Loads from URL.
		/// <para xml:lang="es">Carga la imagen desde una direccion de internet.</para>
		/// </summary>
		/// <returns>The from URL.
		/// <para xml:lang="es">La url de la imagen</para>
		/// </returns>
		/// <param name="url">URL.</param>
		public void LoadFromUrl(Uri url)
		{
			base.ImageUrl = url?.ToString();
		}

		/// <summary>
		/// Load a image from an array of bytes
		/// <para xml:lang="es">
		/// Carga una imagen desde un arreglo de bytes
		/// </para>
		/// </summary>
		public void LoadFromBytes(byte[] bytes)
		{
			LoadFromStream(new MemoryStream(bytes));
		}
	}
}
