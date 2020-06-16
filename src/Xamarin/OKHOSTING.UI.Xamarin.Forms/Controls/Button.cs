using OKHOSTING.UI.Controls;
using System;
using System.Drawing;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// It is a control that represents a button in a Xamarin.Forms.
	/// <para xml:lang="es">Es un control que representa un boton en un Xamarin.Forms</para>
	/// </summary>
	public class Button : Control<global::Xamarin.Forms.Button>, IButton
	{
		/// <summary>
		/// Initializes a new instance of the OKHOSTING.UI.Xamarin.Forms.Controls.Button class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase OKHOSTING.UI.Xamarin.Forms.Controls.Button.
		/// </para>
		/// </summary>
		public Button()
		{
			Content.Clicked += Button_Clicked;
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

		#region ITextControl

		/// <summary>
		/// Gets or sets IT ext control. font family.
		/// <para xml:lang="es">Obtiene o establece la tipografia del texto del control.</para>
		/// </summary>
		string ITextControl.FontFamily
		{
			get
			{
				return Content.FontFamily;
			}
			set
			{
				Content.FontFamily = value;
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
				return Forms.Platform.Parse(Content.TextColor);
			}
			set
			{
				Content.TextColor = Forms.Platform.Parse(value);
			}
		}

		double ITextControl.FontSize
		{
			get
			{
				return Content.FontSize;
			}
			set
			{
				Content.FontSize = value;
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
				return Content.FontAttributes.HasFlag(global::Xamarin.Forms.FontAttributes.Bold);
			}
			set
			{
				Content.FontAttributes = global::Xamarin.Forms.FontAttributes.Bold;
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
				return Content.FontAttributes.HasFlag(global::Xamarin.Forms.FontAttributes.Italic);
			}
			set
			{
				Content.FontAttributes = global::Xamarin.Forms.FontAttributes.Italic;
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

		string IButton.Text
		{
			get
			{
				return Content.Text;
			}
			set
			{
				Content.Text = value;
			}
		}
	}
}