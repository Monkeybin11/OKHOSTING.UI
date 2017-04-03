using System;
using System.Collections.Specialized;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// It represents a text box control.
	/// <para xml:lang="es">Representa un control de cuadro de texto.</para>
	/// </summary>
	public class TextBox : System.Web.UI.WebControls.TextBox, ITextBox
	{
		#region IInputControl

		/// <summary>
		/// Gets or sets the user imput value.
		/// <para xml:lang="es">Obtiene o establece el valor de entrada del usuario</para>
		/// </summary>
		/// <value>The input value.
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
		/// On the text changed.
		/// <para xml:lang="es">Es el evento enviado al cambiar el texto.</para>
		/// </summary>
		/// <returns>The text changed.
		/// <para xml:lang="es">El texto cambiado.</para>
		/// </returns>
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">Ocurre cuando el valor fue cambiado.</para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// Raises the value changed.
		/// <para xml:lang="es">Cambia el valor.</para>
		/// </summary>
		/// <returns>The value changed.
		/// <para xml:lang="es">El valor cambiado.</para>
		/// </returns>
		protected internal void RaiseValueChanged()
		{
			ValueChanged?.Invoke(this, ((IInputControl<string>)this).Value);
		}

		#endregion

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
		/// <para xml:lang="es">Obtiene o establece la alineación vertical del control</para>
		/// </summary>
		/// <value>The VerticalAlignemnt of the control.
		/// <para xml:lang="es">La alineación vertical del control</para>
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
		/// <para xml:lang="es">Obtiene o establece un valor de objeto arbitrario que puede ser usado para almacenar informacion personalizada de este objeto.</para>
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

		#region ITextControl

		/// <summary>
		/// Gets or sets the FontColor of the control.
		/// <para xml:lang="es">Obtiene o establece el color del texto del control.</para>
		/// </summary>
		/// <value>The FontColor of the control.
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
		/// Gets or sets the FontFamily of the control.
		/// <para xml:lang="es">Obtiene o establece la tipografia del texto del control</para>
		/// </summary>
		/// <value>The FontFamily of the control.
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
		/// Gets or sets the FontSize of the control.
		/// <para xml:lang="es">Obtiene o establece el tamaño del texto del control.</para>
		/// </summary>
		/// <value>The FontSize of the control.
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
		/// Gets or sets the bold text of the control.
		/// <para xml:lang="es">Obtiene o establece el texto en negritas del control.</para>
		/// </summary>
		/// <value>The text bold of the control.
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
		/// Gets or sets the italic text of the control.
		/// <para xml:lang="es">Obtiene o establece el texto en italica del control</para>
		/// </summary>
		/// <value>The italic text of the control.
		/// <para xml:lang="es">El texto en italica del control</para>
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
		/// Gets or sets the UnderLine text of the control.
		/// <para xml:lang="es">Obtiene o establece el texto en subrayado del control</para>
		/// </summary>
		/// <value>The UnderLine text of the control.
		/// <para xml:lang="es">El texto en subrayado del control</para>
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
		/// Gets or sets the TextHorizontalAlignment of the control.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del texto del control</para>
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
				Platform.Current.RemoveCssClassesStartingWith(this, "text-horizontal-alignment");
				Platform.Current.AddCssClass(this, "text-horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the TextVerticalAlignment of the control.
		/// <para xml:lang="es">Obtiene o establece la alineación vertical del control.</para>
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
				Platform.Current.RemoveCssClassesStartingWith(this, "text-vertical-alignment");
				Platform.Current.AddCssClass(this, "text-vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the padding text of the control.
		/// <para xml:lang="es">obtiene o establece el padding del texto del control.</para>
		/// </summary>
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

		/// <summary>
		/// Gets or sets the type of the user input textbox.
		/// <para xml:lang="es">Obtiene o establece el tipo de entrada del usuario al textbox.</para>
		/// </summary>
		/// <value>The type of the user input.</value>
		ITextBoxInputType ITextBox.InputType
		{
			get
			{
				//if not InputType is provided, the InputType back to the text.
				if (base.Attributes["type"] == null)
				{
					return ITextBoxInputType.Text;
				}

				//InputTypes
				switch (base.Attributes["type"])
				{
					case "date":
						return ITextBoxInputType.Date;

					case "datetime":
						return ITextBoxInputType.DateTime;

					case "email":
						return ITextBoxInputType.Email;

					case "number":
						return ITextBoxInputType.Number;

					case "tel":
						return ITextBoxInputType.Telephone;

					case "text":
						return ITextBoxInputType.Text;

					case "time":
						return ITextBoxInputType.Time;

					case "url":
						return ITextBoxInputType.Url;

					default:
						return ITextBoxInputType.Text;
				}
			}
			set
			{
				switch (value)
				{
					case ITextBoxInputType.Date:
					case ITextBoxInputType.DateTime:
						base.Attributes["type"] = "date";
						break;

					case ITextBoxInputType.Email:
						base.Attributes["type"] = "email";
						break;

					case ITextBoxInputType.Number:
						base.Attributes["type"] = "number";
						break;

					case ITextBoxInputType.Telephone:
						base.Attributes["type"] = "tel";
						break;

					case ITextBoxInputType.Text:
						base.Attributes["type"] = "text";
						break;

					case ITextBoxInputType.Time:
						base.Attributes["type"] = "time";
						break;

					case ITextBoxInputType.Url:
						base.Attributes["type"] = "url";
						break;

					default:
						base.Attributes["type"] = "text";
						break;
				}
			}
		}

		#endregion

		/// <summary>
		/// The text that appears when the TextBox is empty (in a lighter color), use it as an alternative to a using a separate label to indicate this TextBox expected input
		/// </summary>
		string ITextBox.Placeholder
		{
			get
			{
				return InnerWatermarkExtender.WatermarkText;
			}
			set
			{
				InnerWatermarkExtender.WatermarkText = value;
			}
		}

		/// <summary>
		/// The font color of the Placeholder text
		/// </summary>
		Color ITextBox.PlaceholderColor
		{
			get;
			set;
		}

		/// <summary>
		/// The inner watermark extender.
		/// <para xml:lang="es">El texto con marca de agua del control.</para>
		/// </summary>
		protected readonly AjaxControlToolkit.TextBoxWatermarkExtender InnerWatermarkExtender;

		/// <summary>
		/// Ons the pre render.
		/// <para xml:lang="es">Ocurre antes de cambiar el valor</para>
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
		protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
		{
			return true;
		}

		/// <summary>
		/// Initializes a new instance of the OKHOSTING.UI.Net4.WebForms.Controls.TextBox class.
		/// <para xml:alng="es">Inicializa una nueva instacia de la clase OKHOSTING.UI.Net4.WebForms.Controls.TextBox</para>
		/// </summary>
		public TextBox()
		{
			//set a default id so we ensure the extender's TargetControlID is set
			base.ID = "TextBox_InnerTextBox_" + Guid.NewGuid().ToString().Replace('-', '_');

			//ajax watermark
			InnerWatermarkExtender = new AjaxControlToolkit.TextBoxWatermarkExtender();
			InnerWatermarkExtender.ID = ID + "_TextBoxWatermarkExtender";
			InnerWatermarkExtender.TargetControlID = ID;
			//InnerWatermarkExtender.WatermarkCssClass = "AutoComplete_Watermark";
			//base.Controls.Add(InnerWatermarkExtender);
		}
	}
}