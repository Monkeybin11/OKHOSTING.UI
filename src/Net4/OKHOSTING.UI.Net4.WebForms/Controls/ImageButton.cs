using System;
using System.Linq;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>It represents a button with a background image
	/// <para xml:lang="es">Representa un boton con una imagen de fondo</para>
	/// </summary>
	public class ImageButton : System.Web.UI.WebControls.ImageButton, IImageButton, IWebClickableControl
	{
		#region IControl

		/// <summary>
		/// Gets or sets the name of the control.
		/// <para xml:lang="es">Obtiene o establece el nombre del control</para>
		/// </summary>
		/// <value>The name of the control.
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
		/// Gets or sets the BackgroundColor of the control.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del control.</para>
		/// </summary>
		/// <value>The BackgroundColor of the control.
		/// <para xml:lang="es">El color de fondo del control.</para>
		/// </value>
		Color IControl.BackgroundColor
		{
			get
			{
				return App.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = App.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the BorderColor of the control.
		/// <para xml:lang="es">Obtiene o establece el color del borde del control.</para>
		/// </summary>
		/// <value>The BorderColor of the control.
		/// <para xml:lang="es">El color del borde del control.</para>
		/// </value>
		Color IControl.BorderColor
		{
			get
			{
				return App.Parse(base.BorderColor);
			}
			set
			{
				base.BorderColor = App.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the Width of the control.
		/// <para xml:lang="es">Obtiene o establece el ancho del control.</para>
		/// </summary>
		/// <value>The width of the control.
		/// <para xml:lang="es">El ancho del control.</para>
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
		/// Gets or sets the Height of the control.
		/// <para xml:lang="es">Obtiene o establece la altura del control.</para>
		/// </summary>
		/// <value>The height of the control.
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
		/// Gets or sets the Margin of the control.
		/// <para xml:lang="es">Obtiene o establece el margen del control.</para>
		/// </summary>
		/// <value>The margin of the control.
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
		/// <value>The HorizontalAlign of the control.
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
				App.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				App.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the VerticalAlignment of the control.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical del control</para>
		/// </summary>
		/// <value>The VerticalAlignment of the control.
		/// <para xml:lang="es">La alineación vertical del control.</para>
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
				App.RemoveCssClassesStartingWith(this, "vertical-alignment");
				App.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">Obtiene o establece un valor de objeto arbitrario que se puede usar para almacenar información personalizada sobre este elemento.</para>
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
		/// Occurs when click.
		/// <para xml:lang="es">Se produce este evento al hacer clic en el control.</para>
		/// </summary>
		public new event EventHandler Click;

		void IWebClickableControl.RaiseClick()
		{
			string postedValue = Page.Request.Form[ID + ".x"];

			//is this an image button?
			if (postedValue != null)
			{
				Click?.Invoke(this, new EventArgs());
			}
		}

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
		public void LoadFromUrl(System.Uri url)
		{
			base.ImageUrl = url?.ToString();
		}
	}
}
