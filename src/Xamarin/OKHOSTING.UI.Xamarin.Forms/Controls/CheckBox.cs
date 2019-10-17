using System;
using System.Drawing;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// It is a control that represents a CheckBox in a Xamarin.Forms.
	/// <para xml:lang="es">Es un control que representa un CheckBox en un Xamarin.Forms</para>
	/// </summary>
	public class CheckBox : global::Xamarin.Forms.Switch, ICheckBox
	{
		/// <summary>
		/// Initializes a new instance of the CheckBox class.
		/// <para xml:lang="es">
		/// Iniciarliza una nueva instancia de la clase CheckBox.
		/// </para>
		/// </summary>
		public CheckBox()
		{
			base.Toggled += CheckBox_Toggled;
		}

		/// <summary>
		/// The identifier dispose.
		/// <para xml:lang="es">
		/// El identificador dispose
		/// </para>
		/// </summary>
		/// <returns>The identifier isposable. dispose.</returns>
		void IDisposable.Dispose()
		{
		}

		#region IInputControl

		/// <summary>
		/// Checks the box toggled.
		/// <para xml:lang="es">
		/// Comprueba si el checkBox esta seleccionado.
		/// </para>
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void CheckBox_Toggled(object sender, global::Xamarin.Forms.ToggledEventArgs e)
		{
			ValueChanged?.Invoke(this, ((IInputControl<bool>)this).Value);
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">
		/// Ocurre cuando el valor del checkbox es cambiado.
		/// </para>
		/// </summary>
		public event EventHandler<bool> ValueChanged;

		/// <summary>
		/// Gets or sets the user input value.
		/// <para xml:lanmg="es">
		/// Obtiene o establece el valor de entrada del usuario.
		/// </para>
		/// </summary>
		bool IInputControl<bool>.Value
		{
			get
			{
				return base.IsToggled;
			}
			set
			{
				base.IsToggled = value;
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
				return Forms.Platform.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = Forms.Platform.Parse(value);
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
		/// Gets or sets the control vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la alineación vertical del control</para>
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
		/// Obtiene o establece un valor de objeto arbitrario que puede ser usado para almacenar información personalizada de este elemento.
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
	}
}