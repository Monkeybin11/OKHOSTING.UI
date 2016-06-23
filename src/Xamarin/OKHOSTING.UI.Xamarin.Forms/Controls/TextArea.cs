using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// A multiline textbox
	/// <para xml:lang="es">
	/// Un cuadro de texto de multiples lineas.
	/// </para>
	/// </summary>
	public class TextArea : global::Xamarin.Forms.Editor, ITextArea
	{
		/// <summary>
		/// Initializes a new instance of the TextArea class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase TextArea.
		/// </para>
		/// </summary>
		public TextArea()
		{
			base.TextChanged += TextArea_TextChanged;
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
		/// Texts the area text changed.
		/// <para xml:lang="es">
		/// Cambia el texto del cuadro cuando el usuario lo cambia.
		/// </para>
		/// </summary>
		/// <returns>The area text changed.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void TextArea_TextChanged(object sender, global::Xamarin.Forms.TextChangedEventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, ((IInputControl<string>)this).Value);
			}
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">
		/// Ocurre cuando el valor es cambiado.
		/// </para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// Gets or sets the user input value.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor de entrada del usuario.
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

		string IControl.Name
		{
			get; set;
		}

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

		Thickness IControl.Margin
		{
			get; set;
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Current.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = Platform.Current.Parse(value);
			}
		}

		Color IControl.BorderColor
		{
			get;
			set;
		}

		Thickness IControl.BorderWidth
		{
			get;
			set;
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(Platform.Current.Parse(value), false);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Current.ParseVerticalAlignment(base.VerticalOptions.Alignment);
			}
			set
			{
				base.VerticalOptions = new global::Xamarin.Forms.LayoutOptions(Platform.Current.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// </remmarks>
		object IControl.Tag
		{
			get; set;
		}

		#endregion

		#region ITextControl

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

		Color ITextControl.FontColor
		{
			get
			{
				return Platform.Current.Parse(base.TextColor);
			}
			set
			{
				base.TextColor = Platform.Current.Parse(value);
			}
		}

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

		bool ITextControl.Underline
		{
			get;
			set;
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get;
			set;
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get;
			set;
		}

		Thickness ITextControl.TextPadding
		{
			get;
			set;
		}

		#endregion
	}
}