using System;
using System.Drawing;
using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// Represents a control that is autocomplete in a Xamarin.Forms.
	/// <para xml:lang="es">Representa un control que es autocomplete en Xamarin.Forms.</para>
	/// </summary>
	public class Autocomplete : Control<global::Xamarin.Forms.StackLayout>, IAutocomplete
	{
		/// <summary>
		/// Initializes a new instance of the Autocomplete class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase Autocomplete.</para>
		/// </summary>
		public Autocomplete()
		{
			GoSearchButton = BaitAndSwitch.Create<IButton>();
			GoSearchButton.Click += GoSearchButton_Click;
		}

		/// <summary>
		/// Occurs when searching.
		/// <para xml:lang="es">
		/// Es el evento que ocurre cuando se da clic en buscar.
		/// </para>
		/// </summary>
		public event EventHandler<AutocompleteSearchEventArgs> Searching;

		/// <summary>
		/// The go search button.
		/// <para xml:lang="es">El boton que nos envia a la busqueda</para>
		/// </summary>
		protected IButton GoSearchButton;

		/// <summary>
		/// The search text.
		/// <para xml:lang="es">El texto a buscar.</para>
		/// </summary>
		protected ITextBox SearchText;
		
		/// <summary>
		/// The search button.
		/// <para xml:lang="es">El boton de busqueda</para>
		/// </summary>
		protected IButton SearchButton;
		
		/// <summary>
		/// The search stack.
		/// <para xml:lang="es">El stack donde se buscara.</para>
		/// </summary>
		protected IStack SearchStack;
		
		/// <summary>
		/// The search page.
		/// <para xml:lang="es">La pagina para buscar.</para>
		/// </summary>
		protected Page SearchPage;

		/// <summary>
		/// The result view.
		/// <para xml:lang="es">La vista resultante al buscar.</para>
		/// </summary>
		protected global::Xamarin.Forms.ListView ResultView;

		/// <summary>
		/// The result page.
		/// <para xml:lang="es">La pagina resultante al buscar.</para>
		/// </summary>
		protected global::Xamarin.Forms.ContentPage ResultPage;

		/// <summary>
		/// Gos the search button click.
		/// <para xml:lang="es">El clic del boton que nos envia a la parte donde buscamos.</para>
		/// </summary>
		/// <returns>The search button click.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void GoSearchButton_Click(object sender, EventArgs e)
		{
			SearchText = BaitAndSwitch.Create<ITextBox>();
			SearchButton = BaitAndSwitch.Create<IButton>();
			SearchButton.Text = "Search";
			SearchButton.Click += SearchButton_Click;
			SearchStack = BaitAndSwitch.Create<IStack>();
			SearchStack.Children.Add(SearchText);
			SearchStack.Children.Add(SearchButton);

			SearchPage = new Page();
			SearchPage.Content = SearchStack;

			global::Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(SearchPage);
		}

		/// <summary>
		/// Searchs the button click.
		/// <para xml:lang="es">El clic del boton que realiza la busqueda.</para>
		/// </summary>
		/// <returns>The button click.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void SearchButton_Click(object sender, EventArgs e)
		{
			OnSearching(SearchText.Value);
		}

		/// <summary>
		/// Ons the searching.
		/// <para xml:lang="es">
		/// El argumento de la busqueda paraseleccionar un elemento del Autocomplete.
		/// </para>
		/// </summary>
		/// <returns>The searching.</returns>
		/// <param name="text">Text.</param>
		public AutocompleteSearchEventArgs OnSearching(string text)
		{
			AutocompleteSearchEventArgs e = new AutocompleteSearchEventArgs(text);

			Searching?.Invoke(this, e);

			ResultView = new global::Xamarin.Forms.ListView();
			ResultView.ItemsSource = e.SearchResult;
			ResultView.ItemSelected += ResultView_ItemSelected;

			ResultPage = new global::Xamarin.Forms.ContentPage();
			ResultPage.Content = ResultView;

			global::Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(SearchPage);

			return e;
		}

		/// <summary>
		/// Results the view item selected.
		/// <para xml:lang="es">Resultado del elemento seleccionado.</para>
		/// </summary>
		/// <returns>The view item selected.
		/// <para xml:lang="es">El elemento seleccionado.</para>
		/// </returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void ResultView_ItemSelected(object sender, global::Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			SearchText.Value = e.SelectedItem.ToString();

			if (SearchText.Value != GoSearchButton.Text)
			{
				GoSearchButton.Text = e.SelectedItem.ToString();
				OnValueChanged();
			}

			//close result page
			global::Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();

			//close search page and get back to original page
			global::Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
		}

		#region IInputControl

		/// <summary>
		/// Ons the value changed.
		/// <para xml:lang="es">Cambia el valor</para>
		/// </summary>
		/// <returns>The value changed.
		/// <para xml:lang="es">El valor cambiado.</para>
		/// </returns>
		private void OnValueChanged()
		{
			ValueChanged?.Invoke(this, ((IInputControl<string>)this).Value);
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">Ocurre cuando el valor es cambiado.</para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// Gets or sets the user input value.
		/// <para xml:lang="es">Obtiene o establece el valor de la entrada del usuario.</para>
		/// </summary>
		string IInputControl<string>.Value
		{
			get
			{
				return GoSearchButton.Text; 
			}
			set
			{
				GoSearchButton.Text = value;
			}
		}

		#endregion

		#region ITextControl

		/// <summary>
		/// Gets or sets IT ext control. font family.
		/// <para xml:alng="es">Obtiene o establece la tipografia del texto del control.</para>
		/// </summary>
		string ITextControl.FontFamily
		{
			get 
			{
				return SearchText.FontFamily;
			} 
			set
			{
				SearchText.FontFamily = value;
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
				return SearchText.FontColor;
			}
			set
			{
				SearchText.FontColor = value;
			}
		}

		/// <summary>
		/// Gets or sets IT ext control. bold.
		/// <para xml:lang="es">Obtiene o establece la existencia del texto del control en negritas</para>
		/// </summary>
		bool ITextControl.Bold
		{
			get
			{
				return SearchText.Bold;
			}
			set
			{
				SearchText.Bold = value;
			}
		}

		/// <summary>
		/// Gets or sets IT ext control. italic.
		/// <para xml:lang="es">Obtiene o establece la existencia de texto en italica.</para>
		/// </summary>
		bool ITextControl.Italic
		{
			get
			{
				return SearchText.Italic;
			}
			set
			{
				SearchText.Italic = value;
			}
		}

		/// <summary>
		/// Gets or sets IT ext control. underline.
		/// <para xml:lang="es">Obtiene o establece el texto subrayado en el control.</para>
		/// </summary>
		bool ITextControl.Underline
		{
			get
			{
				return SearchText.Underline;
			}
			set
			{
				SearchText.Underline = value;
			}
		}

		/// <summary>
		/// Gets or sets IT ext control. text horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la laineacion horizontal del texto del control.</para>
		/// </summary>
		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get
			{
				return SearchText.TextHorizontalAlignment;
			}
			set
			{
				SearchText.TextHorizontalAlignment = value;
			}
		}

		/// <summary>
		/// Gets or sets IT ext control. text vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la laineacion vertical del texto del control.</para>
		/// </summary>
		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				return SearchText.TextVerticalAlignment;
			}
			set
			{
				SearchText.TextVerticalAlignment = value;
			}
		}

		/// <summary>
		/// Gets or sets IT ext control text padding.
		/// <para xml:lang="es">Obtiene o establece la existencia de padding del texto del control</para>
		/// </summary>
		Thickness ITextControl.TextPadding
		{
			get
			{
				return SearchText.TextPadding;
			}
			set
			{
				SearchText.TextPadding = value;
			}
		}

		/// <summary>
		/// Gets or sets the size of the IT ext control. font.
		/// <para xml:lang="es">Obtiene o establece el tamaño del texto del control</para>
		/// </summary>
		double ITextControl.FontSize
		{
			get
			{
				return SearchText.FontSize;
			}
			set
			{
				SearchText.FontSize = value;
			}
		}

		#endregion

		/// <summary>
		/// The identifier dispose.
		/// <para xml:lang="es">El identificador Dispose</para>
		/// </summary>
		void IDisposable.Dispose()
		{
		}
	}
}