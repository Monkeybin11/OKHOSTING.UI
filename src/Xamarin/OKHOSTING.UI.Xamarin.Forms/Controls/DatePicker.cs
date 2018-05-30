using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// It is a control that represents a calendar in a Xamarin.Forms.
	/// <para xml:lang="es">Es un control que representa un calendario en un Xamarin.Forms</para>
	/// </summary>
	public class DatePicker : global::Xamarin.Forms.DatePicker, IDatePicker
	{
		/// <summary>
		/// Initializes a new instance of the Calendar class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase Calendario. 
		/// </para>
		/// </summary>
		public DatePicker()
		{
			base.DateSelected += Picker_DateSelected;
		}

		/// <summary>
		/// The identifier dispose.
		/// <para xml:lang="es">
		/// El identificador Dispose
		/// </para>
		/// </summary>
		/// <returns>The identifier isposable. dispose.</returns>
		void IDisposable.Dispose()
		{
		}

		#region IInputControl

		/// <summary>
		/// Calendars the date selected.
		/// <para xml:lang="es">
		/// Fecha de seleccion del calendario
		/// </para>
		/// </summary>
		/// <returns>The date selected.
		/// <para xml:lang="es">La fecha seleccionada</para>
		/// </returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void Picker_DateSelected(object sender, global::Xamarin.Forms.DateChangedEventArgs e)
		{
			ValueChanged?.Invoke(this, ((IInputControl<DateTime?>)this).Value);
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">
		/// Ocurre cuando se cambia la fecha.
		///  </para>
		/// </summary>
		public event EventHandler<DateTime?> ValueChanged;

		/// <summary>
		/// Gets or sets the value of user input.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor de entrada del usuario.
		/// </para>
		/// </summary>
		DateTime? IInputControl<DateTime?>.Value
		{
			get
			{
				return base.Date;
			}
			set
			{
				if (value.HasValue)
				{
					base.Date = value.Value;
				}
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
		/// Gets or sets the height of the control.
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
			get; set;
		}

		/// <summary>
		/// Gets or sets the color of the Control background.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del control.</para>
		/// </summary>
		Color IControl.BackgroundColor
		{
			get
			{
				return App.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = App.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the color of the control border.
		/// <para xml:lang="es">Obtiene o establece el color del borde del control.</para>
		/// </summary>
		Color IControl.BorderColor
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the width of the control border.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del control.</para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the control horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la alineación horizontal del control.</para>
		/// </summary>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return App.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(App.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets the control vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la alineación vertical del control</para>
		/// </summary>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.ParseVerticalAlignment(base.VerticalOptions.Alignment);
			}
			set
			{
				base.VerticalOptions = new global::Xamarin.Forms.LayoutOptions(App.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">
		/// Obtiene o establece un valor de objeto arbitrario que puede ser usado para almacenar informacion personalizada sobre este elemento.
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

		#endregion

		#region ITextControl

		/// <summary>
		/// Gets or sets text control font family.
		/// <para xml:lang="es">Obtiene o establece la tipografia del texto del control.</para>
		/// </summary>
		string ITextControl.FontFamily
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the color of the text control font.
		/// <para xml:lang="es">Obtiene o establece el color del texto del control.</para>
		/// </summary>
		Color ITextControl.FontColor
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets wether Text control bold or no.
		/// <para xml:lang="es">
		/// Obtiene o establece si el texto del control esta en negritas o no.
		/// </para>
		/// </summary>
		bool ITextControl.Bold
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets wether text control italic or not.
		/// <para xml:lang="es">Obtiene o establece si el texto del control esta en italica.</para>
		/// </summary>
		bool ITextControl.Italic
		{
			get;
			set;
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

		/// <summary>
		/// Gets or sets the size of the control font.
		/// <para xml:lang="es">
		/// Obtiene o establece el tamaño del texto del control.
		/// </para>
		/// </summary>
		double ITextControl.FontSize
		{
			get;
			set;
		}

		#endregion
	}
}