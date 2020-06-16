using System;
using System.Linq;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using System.Drawing;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// List picker.
	/// <para xml:lang="es">
	/// Una lista de elementos donde el usuario puede seleccionar un elemento.
	/// </para>
	/// </summary>
	public class ListPicker : Control<global::Xamarin.Forms.Picker>, IListPicker
	{
		/// <summary>
		/// Initializes a new instance of the ListPicker class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase ListPicker.
		/// </para>
		/// </summary>
		public ListPicker()
		{
			Content.SelectedIndexChanged += ListPicker_SelectedIndexChanged;
		}

		/// <summary>
		/// Gets or sets the list of items from which the user can select one.
		/// <para xml:lang="es">
		/// Obtiene o establece la lista de elementos de los que puede seleccionar uno el usuario.
		/// </para>
		/// </summary>
		IList<string> IListPicker.Items
		{
			get
			{
				return Content.Items;
			}
			set
			{
				if (Content.Items.Any())
				{
					Content.Items.Clear();
				}
				
				foreach (string item in value)
				{
					Content.Items.Add(item);
				}
			}
		}

		#region IInputControl

		/// <summary>
		/// Lists the picker selected index changed.
		/// <para xml:lang="es">
		/// Lista de los indices a seleccionar.
		/// </para>
		/// </summary>
		/// <returns>The picker selected index changed.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void ListPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			ValueChanged?.Invoke(this, ((IInputControl<string>) this).Value);
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">
		/// Ocurre cuando se cambia el valor.
		/// </para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// Gets or sets the user impiut value.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor seleccionado por el usuario.
		/// </para>
		/// </summary>
		string IInputControl<string>.Value
		{
			get
			{
				if(Content.SelectedIndex == -1)
				{
					return null;
				}
				else
				{
					return ((IListPicker) this).Items.ToArray()[Content.SelectedIndex];
				}
			}
			set
			{
				int index = ((IListPicker) this).Items.ToList().IndexOf(value);
				Content.SelectedIndex = index;
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
				return Content.FontFamily;
			}
			set
			{
				Content.FontFamily = value;
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
		/// Gets or sets wether Text control bold or no.
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
		/// <para xml:lang="es">
		/// Obtiene o establece si el texto del control esta en italica.
		/// </para>
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
			get;
			set;
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
		/// <para xml:lang="es">Obtiene o establece el espacio entre un borde del control y su texto.</para>
		/// </summary>
		Thickness ITextControl.TextPadding
		{
			get;
			set;
		}

		#endregion

		public int SelectedIndex
		{
			get
			{
				return Content.SelectedIndex;
			}
			set
			{
				Content.SelectedIndex = value;
			}
		}
	}
}