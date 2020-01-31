using OKHOSTING.UI.Controls;
using System;
using System.Drawing;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// A single line textbox
	/// <para xml:lang="es">
	/// Un cuadro de texto de una sola linea.
	/// </para>
	/// </summary>
	public class TextBox : global::Xamarin.Forms.Entry, ITextBox
	{
		/// <summary>
		/// Initializes a new instance of the TextBox class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase TextBox.
		/// </para>
		/// </summary>
		public TextBox()
		{
			base.TextChanged += TextBox_TextChanged;
		}

		/// <summary>
		/// The identifier dispose.
		/// <para xml:lang="es">
		/// El identificador dispose.
		/// </para>
		/// </summary>
		/// <returns>The identifier isposable. dispose.</returns>
		void IDisposable.Dispose()
		{
		}

		#region IInputControl

		/// <summary>
		/// Texts the box text changed.
		/// <para xml:lang="es">
		/// Cambia el texto del textbox y lanza el evento ValueChanged.
		/// </para>
		/// </summary>
		/// <returns>The box text changed.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void TextBox_TextChanged(object sender, global::Xamarin.Forms.TextChangedEventArgs e)
		{
			//apply maxlenght
			if (!string.IsNullOrEmpty(e.NewTextValue))
			{
				if (((ITextBox) this).MaxLength > 0 && e.NewTextValue.Length > ((ITextBox) this).MaxLength)
				{
					base.Text = e.NewTextValue.Substring(0, ((ITextBox) this).MaxLength);
					return; //exit and do not raise ValueChanged event
				}
			}

			ValueChanged?.Invoke(this, ((IInputControl<string>)this).Value);
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">
		/// Ocurre cuando el valor del textbox es cambiado.
		/// </para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// Gets or sets the user input value.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor de la entrada del usuario.
		/// </para>
		/// </summary>
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

		#endregion

		#region IControl

		/// <summary>
		/// Gets or sets the name of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece el nombre del control.
		/// </para>
		/// </summary>
		string IControl.Name
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets wether the control is visible or not.
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es visible o no.
		/// </para>
		/// </summary>
		bool IControl.Visible
		{
			get
			{
				return base.IsVisible;
			}
			set
			{
				base.IsVisible = value;
			}
		}

		/// <summary>
		/// Gets or sets wether the control is enabled or not
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es habilitado o no.
		/// </para>
		/// </summary>
		bool IControl.Enabled
		{
			get
			{
				return base.IsEnabled;
			}
			set
			{
				base.IsEnabled = value;
			}
		}

		/// <summary>
		/// Gets or sets the width of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece el ancho del control.
		/// </para>
		/// </summary>
		double? IControl.Width
		{
			get
			{
				return base.WidthRequest;
			}
			set
			{
				if (value.HasValue)
				{
					base.WidthRequest = value.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the height of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece la altura del control.
		/// </para>
		/// </summary>
		double? IControl.Height
		{
			get
			{
				return base.HeightRequest;
			}
			set
			{
				if (value.HasValue)
				{
					base.HeightRequest = value.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the control margin.
		/// <para xml:lang="es">
		/// Obtiene o establece el margen del control.
		/// </para>
		/// </summary>
		Thickness IControl.Margin
		{
			get
			{
				return Forms.Platform.Parse(base.Margin);
			}
			set
			{
				base.Margin = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Space that this control will set between its content and its border
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre su contenido y su borde
		/// </para>
		/// </summary>
		Thickness IControl.Padding
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the color of the Control background.
		/// <para xml:lang="es">
		/// Obtiene o establece el color de fondo del control.
		/// </para>
		/// </summary>
		Color IControl.BackgroundColor
		{
			get
			{
				return Forms.Platform.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the color of the control border.
		/// <para xml:lang="es">
		/// Obtiene o establece el color del borde del control.
		/// </para>
		/// </summary>
		Color IControl.BorderColor
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the width of the control border.
		/// <para xml:lang="es">
		/// Obtiene o establece el ancho del borde del control.
		/// </para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the control horizontal alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineación horizontal del control.
		/// </para>
		/// </summary>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Forms.Platform.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(Forms.Platform.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets the control vertical alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineación vertical del control.
		/// </para>
		/// </summary>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Forms.Platform.ParseVerticalAlignment(base.VerticalOptions.Alignment);
			}
			set
			{
				base.VerticalOptions = new global::Xamarin.Forms.LayoutOptions(Forms.Platform.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">
		/// Obtiene o establece un valor de objeto arbitrario que puede ser usado para almacenar informacion personalizada de este elemento.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">
		/// Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.
		/// </para>
		/// </remarks>
		object IControl.Tag
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		string IControl.CssClass { get; set; }

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

		#region ITextControl

		/// <summary>
		/// Gets or sets text control font family.
		/// <para xml:lang="es">
		/// Obtiene o establece la tipografia del texto del control.
		/// </para>
		/// </summary>
		string ITextControl.FontFamily
		{
			get
			{
				return base.FontFamily;
			}
			set
			{
				base.FontFamily = value;
			}
		}

		/// <summary>
		/// Gets or sets the color of the text control font.
		/// <para xml:lang="es">
		/// Obtiene o establece el color del texto del control.
		/// </para>
		/// </summary>
		Color ITextControl.FontColor
		{
			get
			{
				return Forms.Platform.Parse(base.TextColor);
			}
			set
			{
				base.TextColor = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets wether Text control bold or no.
		/// <para xml:lang="es">
		/// Obtiene o establece si el texto del control esta en negritas o no.
		/// </para>
		/// </summary>
		bool ITextControl.Bold
		{
			get
			{
				return base.FontAttributes.HasFlag(global::Xamarin.Forms.FontAttributes.Bold);
			}
			set
			{
				base.FontAttributes = global::Xamarin.Forms.FontAttributes.Bold;
			}
		}

		/// <summary>
		/// Gets or sets wether text control italic or not.
		/// <para xml:lang="es">
		/// Obtiene o establece si el texto del control esta en italica o no.
		/// </para>
		/// </summary>
		bool ITextControl.Italic
		{
			get
			{
				return base.FontAttributes.HasFlag(global::Xamarin.Forms.FontAttributes.Italic);
			}
			set
			{
				base.FontAttributes = global::Xamarin.Forms.FontAttributes.Italic;
			}
		}

		/// <summary>
		/// Gets or sets wether text control underline or not.
		/// <para xml:lang="es">
		/// Obtiene o establece si el texto del control esta subrayado.
		/// </para>
		/// </summary>	
		bool ITextControl.Underline
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets text control horizontal alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la laineacion horizontal del texto del control.
		/// </para>
		/// </summary>
		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get
			{
				return Forms.Platform.Parse(base.HorizontalTextAlignment);
			}
			set
			{
				base.HorizontalTextAlignment = Forms.Platform.ParseTextAlignment(value);
			}
		}

		/// <summary>
		/// Gets or sets the text control vertical alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineacion vertical del texto.
		/// </para>
		/// </summary>
		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the controls text padding.
		/// <para xml:lang="es">
		/// Obtiene o establece el espacio entre un borde del control y su texto.
		/// </para>
		/// </summary>
		Thickness ITextControl.TextPadding
		{
			get;
			set;
		}

		#endregion

		/// <summary>
		/// Gets or sets the type of the user Text box input.
		/// <para xml:lang="es">
		/// Obtiene o establece el tipo de entrada del texto del textbox.
		/// </para>
		/// </summary>
		ITextBoxInputType ITextBox.InputType
		{
			get
			{
				if (base.Keyboard == global::Xamarin.Forms.Keyboard.Email) return ITextBoxInputType.Email;
				if (base.Keyboard == global::Xamarin.Forms.Keyboard.Numeric) return ITextBoxInputType.Number;
				if (base.Keyboard == global::Xamarin.Forms.Keyboard.Telephone) return ITextBoxInputType.Telephone;
				if (base.Keyboard == global::Xamarin.Forms.Keyboard.Text) return ITextBoxInputType.Text;
				if (base.Keyboard == global::Xamarin.Forms.Keyboard.Url) return ITextBoxInputType.Url;

				return ITextBoxInputType.Text;
			}
			set
			{
				switch (value)
				{
					case ITextBoxInputType.Date:
					case ITextBoxInputType.DateTime:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Default;
						break;

					case ITextBoxInputType.Email:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Email;
						break;

					case ITextBoxInputType.Number:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Numeric;
						break;

					case ITextBoxInputType.Telephone:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Telephone;
						break;

					case ITextBoxInputType.Text:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Text;
						break;

					case ITextBoxInputType.Time:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Default;
						break;

					case ITextBoxInputType.Url:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Url;
						break;

					default:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Default;
						break;
				}
			}
		}

		/// <summary>
		/// Gets or sets the length of the Text box max.
		/// <para xml:lang="es">
		/// Obtiene o establece la longitud maxima del textbox.
		/// </para>
		/// </summary>
		int ITextBox.MaxLength
		{
			get;
			set;
		}

		/// <summary>
		/// The font color of the Placeholder text
		/// </summary>
		Color ITextBox.PlaceholderColor
		{
			get
			{
				return Forms.Platform.Parse(base.PlaceholderColor);
			}
			set
			{
				base.PlaceholderColor = Forms.Platform.Parse(value);
			}
		}
	}
}