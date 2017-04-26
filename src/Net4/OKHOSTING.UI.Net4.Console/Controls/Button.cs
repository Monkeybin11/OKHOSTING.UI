using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.Console.Controls
{
	/// <summary>
	/// It is a control that represents a button.
	/// <para xml:lang="es">Es un control que representa un boton</para>
	/// </summary>
	public class Button : ConsoleFramework.Controls.Button, IButton
	{
		public Button()
		{
			base.OnClick += Button_OnClick;
		}

		private void Button_OnClick(object sender, ConsoleFramework.Events.RoutedEventArgs e)
		{
			Click?.Invoke(sender, e);
		}

		/// <summary>
		/// Occurs when click.
		/// <para xml:lang="es">Ocurre cuando hay un evento clic de un boton.</para>
		/// </summary>
		public event EventHandler Click;

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		#region IControl

		/// <summary>
		/// Gets or sets the color of the IC ontrol. background.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del control.</para>
		/// </summary>
		/// <value>The color of the IC ontrol. background.
		/// <para xml:lang="es">El color de fondo del control.</para>
		/// </value>
		Color IControl.BackgroundColor
		{
			get;
			set;
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
			get;
			set;
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
				if (!base.Width.HasValue)
				{
					return null;
				}

				return base.Width.Value;
			}
			set
			{
				base.Width = (int?) value;
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
				if (!base.Height.HasValue)
				{
					return null;
				}

				return base.Height.Value;
			}
			set
			{
				base.Height = (int?) value;
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
				return Platform.Current.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Current.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the width of the IC ontrol. border.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del control.</para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get;
			set;
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
				return Platform.Current.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = Platform.Current.Parse(value);
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
				return Platform.Current.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = Platform.Current.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">Obtiene o establece un valor de objeto arbitraio que se puede usar para almacenar informacion personalizada sobre este elemento</para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">Devuelve el valor previsto. Esta propiedad no tiene ningun valor predeterminado.</para>
		/// </remarks>
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
			get;
			set;
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
			get;
			set;
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
			get;
			set;
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
			get;
			set;
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
			get;
			set;
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
			get;
			set;
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
			get;
			set;
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
			get;
			set;
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
			get;
			set;
		}

		public string Text
		{
			get
			{
				return base.Caption;
			}
			set
			{
				base.Caption = value;
			}
		}

		public bool Visible
		{
			get
			{
				return base.Visibility == ConsoleFramework.Controls.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = ConsoleFramework.Controls.Visibility.Collapsed;
				}
				else
				{
					base.Visibility = ConsoleFramework.Controls.Visibility.Visible;
				}
			}
		}

		public bool Enabled
		{
			get
			{
				return !base.Disabled;
			}
			set
			{
				base.Disabled = !value;
			}
		}

		#endregion
	}
}