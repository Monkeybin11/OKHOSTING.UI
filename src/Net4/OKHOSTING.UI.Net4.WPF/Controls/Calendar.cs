using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
    /// <summary>
    /// It is a control that represents a calendar in a Xamarin.Forms.
	/// <para xml:lang="es">
    /// Es un control que representa un calendario en un Xamarin.Forms.
    /// </para>
    /// </summary>
	public class Calendar : System.Windows.Controls.Calendar, ICalendar
	{
        /// <summary>
        /// Initializes a new instance of the Calendar class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase Calendario. 
		/// </para>
        /// </summary>
		public Calendar()
		{
			base.SelectedDatesChanged += Calendar_SelectedDatesChanged;
		}

        /// <summary>
        /// The identifier dispose.
		/// <para xml:lang="es">
		/// El identificador Dispose
		/// </para>
        /// </summary>
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
        /// <param name="sender">Sender</param>
        /// <param name="e">e</param>
        private void Calendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, ((IInputControl<DateTime?>) this).Value);
			}
		}

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
				return base.SelectedDate;
			}
			set
			{
				if (value.HasValue)
				{
					base.SelectedDate = value.Value;
				}
			}
		}

        /// <summary>
        /// Occurs when value changed.
		/// <para xml:lang="es">
		/// Ocurre cuando se cambia la fecha.
		/// </para>
        /// </summary>
		public event EventHandler<DateTime?> ValueChanged;

        #endregion

        #region IControl

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
				return base.Visibility == System.Windows.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					base.Visibility = System.Windows.Visibility.Hidden;
				}
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
				return base.Width;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = value.Value;
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
				return base.Height;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = value.Value;
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
				return Platform.Current.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Current.Parse(value);
			}
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
				return Platform.Current.Parse(((System.Windows.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(Platform.Current.Parse(value));
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
			get
			{
				return Platform.Current.Parse(((System.Windows.Media.SolidColorBrush)base.BorderBrush).Color);
			}
			set
			{
				base.BorderBrush = new System.Windows.Media.SolidColorBrush(Platform.Current.Parse(value));
			}
		}

        /// <summary>
        /// Gets or sets the width of the control border.
		/// <para xml:lang="es">
        /// Obtiene o establece el ancho del borde del control.
        /// </para>
        /// </summary>
		Thickness IControl.BorderWidth
		{
			get
			{
				return Platform.Current.Parse(base.BorderThickness);
			}
			set
			{
				base.BorderThickness = Platform.Current.Parse(value);
			}
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
				return Platform.Current.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = Platform.Current.Parse(value);
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
				return Platform.Current.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = Platform.Current.Parse(value);
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
				return base.FontFamily.Source;
			}
			set
			{
				base.FontFamily = new System.Windows.Media.FontFamily(value);
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
				return Platform.Current.Parse(((System.Windows.Media.SolidColorBrush)base.Foreground).Color);
			}
			set
			{
				base.Foreground = new System.Windows.Media.SolidColorBrush(Platform.Current.Parse(value));
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
				return base.FontWeight == System.Windows.FontWeights.Bold;
			}
			set
			{
				base.FontWeight = System.Windows.FontWeights.Bold;
			}
		}

        /// <summary>
        /// Gets or sets wether text control italic or not.
		/// <para xml:lang="es">
        /// Obtiene o establece si el texto del control esta en italica.
        /// </para>
        /// </summary>
		bool ITextControl.Italic
		{
			get
			{
				return base.FontStyle == System.Windows.FontStyles.Italic;
			}
			set
			{
				base.FontStyle = System.Windows.FontStyles.Italic;
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
			get
			{
				return false;
			}
			set
			{
				throw new NotImplementedException();
			}
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
				return Platform.Current.Parse(base.HorizontalContentAlignment);
			}
			set
			{
				base.HorizontalContentAlignment = Platform.Current.Parse(value);
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
			get
			{
				return Platform.Current.Parse(base.VerticalContentAlignment);
			}
			set
			{
				base.VerticalContentAlignment = Platform.Current.Parse(value);
			}
		}

        /// <summary>
        /// Gets or sets the controls text padding.
		/// <para xml:lang="es">
        /// Obtiene o establece el espacio entre un borde del control y su texto.
        /// </para>
        /// </summary>
		Thickness ITextControl.TextPadding
		{
			get
			{
				return Platform.Current.Parse(base.Padding);
			}
			set
			{
				base.Padding = Platform.Current.Parse(value);
			}
		}

		#endregion
	}
}
