using OKHOSTING.UI.Controls;
using System;
using System.Drawing;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// It is a control that represents a button in a Xamarin.Forms.
	/// <para xml:lang="es">Es un control que representa un boton en un Xamarin.Forms</para>
	/// </summary>
	public class Button : global::Xamarin.Forms.Button, IButton
	{
		/// <summary>
		/// Initializes a new instance of the OKHOSTING.UI.Xamarin.Forms.Controls.Button class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase OKHOSTING.UI.Xamarin.Forms.Controls.Button.
		/// </para>
		/// </summary>
		public Button()
		{
			base.Clicked += Button_Clicked;
		}

		/// <summary>
		/// Occurs when clicking the button
		/// <para xml:lang="es">Ocurre al dar clic al boton</para>
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void Button_Clicked(object sender, EventArgs e)
		{
			Click?.Invoke(sender, e);
		}

		/// <summary>
		/// The button click event.
		/// <para xml:lang="es">El evento clic del boton.</para>
		/// </summary>
		public event EventHandler Click;

		/// <summary>
		/// The identifier dispose.
		/// <para xml:lang="es">El identificador Dispose.</para>
		/// </summary>
		/// <returns>The identifier isposable. dispose.</returns>
		void IDisposable.Dispose()
		{
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
			get; set;
		}

		/// <summary>
		/// Gets or sets wether the control is visible or not
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
		/// Gets or sets the width of the IC ontrol..
		/// <para xml:lang="es">Obtiene o establece el ancho del control.</para>
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
		/// Gets or sets the height of the IC ontrol..
		/// <para xml:lang="es">Obtiene o establece la altura del control</para>
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
		/// <para xml:lang="es">Obtiene o establece el margen del control.</para>
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
		/// Space that this control will set between itself and it's own border
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su propio borde
		/// </para>
		/// </summary>
		Thickness IControl.Padding
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the color of the Control background.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del control.</para>
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
		/// Gets or sets the color of the IC ontrol. border.
		/// <para xml:lang="es">Obtiene o establece el color del borde del control.</para>
		/// </summary>
		Color IControl.BorderColor
		{
			get
			{
				return Forms.Platform.Parse(base.BorderColor);
			}
			set
			{
				base.BorderColor = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the width of the IC ontrol. border.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del control.</para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get
			{
				return new Thickness(base.BorderWidth);
			}
			set
			{
				if (value.Top.HasValue)
				{
					base.BorderWidth = value.Top.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the IC ontrol. horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del control.</para>
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
		/// Gets or sets the IC ontrol. vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacio vertical del control</para>
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
		/// Obtiene o establece un valor de objeto arbitraio que se puede usar para almacenar informacion personalizada sobre este elemento
		/// </para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">
		/// Devuelve el valor previsto. Esta propiedad no tiene ningun valor predeterminado.
		/// </para>
		/// </remarks>
		object IControl.Tag
		{
			get; set;
		}

		#endregion

		#region ITextControl

		/// <summary>
		/// Gets or sets IT ext control. font family.
		/// <para xml:lang="es">Obtiene o establece la tipografia del texto del control.</para>
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
		/// Gets or sets the color of the IT ext control. font.
		/// <para xml:lang="es">Obtiene o establece el color del texto del control.</para>
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
		/// Gets or sets wether Text control bold o no.
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
		/// <para xml:lang="es">Obtiene o establece si el texto del control esta en italica.</para>
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
		/// <para xml:lang="es">Obtiene o establece si el texto del control esta subrayado.</para>
		/// </summary>
		bool ITextControl.Underline
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets text control horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la laineacion horizontal del texto del control.</para>
		/// </summary>
		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the text control vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical del texto.</para>
		/// </summary>
		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the controls text padding.
		/// <para xml:lang="es">Obtiene o establece el espacio entre un borde del control y su texto.</para>
		/// </summary>
		Thickness ITextControl.TextPadding
		{
			get;
			set;
		}

		#endregion
	}
}