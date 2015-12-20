using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class Autocomplete : global::Xamarin.Forms.StackLayout, IAutocomplete
	{
		public Autocomplete()
		{
			GoSearchButton = Platform.Current.Create<IButton>();
			GoSearchButton.Click += GoSearchButton_Click;
		}

		event EventHandler<AutocompleteSearchEventArgs> IAutocomplete.Searching
		{
			add
			{
				throw new NotImplementedException();
			}

			remove
			{
				throw new NotImplementedException();
			}
		}

		public event EventHandler<AutocompleteSearchEventArgs> Searching;

		protected IButton GoSearchButton;
		protected ITextBox SearchText;
		protected IButton SearchButton;
		protected IStack SearchStack;
		protected Page SearchPage;

		protected global::Xamarin.Forms.ListView ResultView;
		protected global::Xamarin.Forms.ContentPage ResultPage;

		private void GoSearchButton_Click(object sender, EventArgs e)
		{
			SearchText = Platform.Current.Create<ITextBox>();
			SearchButton = Platform.Current.Create<IButton>();
			SearchButton.Text = "Search";
			SearchButton.Click += SearchButton_Click;
			SearchStack = Platform.Current.Create<IStack>();
			SearchStack.Children.Add(SearchText);
			SearchStack.Children.Add(SearchButton);

			SearchPage = new Page();
			SearchPage.Content = SearchStack;

			((Page) Platform.Current.Page).Navigation.PushAsync(SearchPage);
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			OnSearching(SearchText.Text);
		}

		string IAutocomplete.Text
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

		public AutocompleteSearchEventArgs OnSearching(string text)
		{
			AutocompleteSearchEventArgs e = new AutocompleteSearchEventArgs(text);

			if (Searching != null)
			{
				Searching(this, e);
			}

			ResultView = new global::Xamarin.Forms.ListView();
			ResultView.ItemsSource = e.SearchResult;
			ResultView.ItemSelected += ListView_ItemSelected;

			ResultPage = new global::Xamarin.Forms.ContentPage();
			ResultPage.Content = ResultView;

			((Page) Platform.Current.Page).Navigation.PushAsync(ResultPage);

			return e;
		}

		private void ListView_ItemSelected(object sender, global::Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			SearchText.Text = e.SelectedItem.ToString();

			//close result page
			((Page) Platform.Current.Page).Navigation.PopAsync();

			//close search page and get back to original page
			((Page) Platform.Current.Page).Navigation.PopAsync();
		}



		void IDisposable.Dispose()
		{
		}

		AutocompleteSearchEventArgs IAutocomplete.OnSearching(string text)
		{
			throw new NotImplementedException();
		}

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
			get; set;
		}

		Thickness IControl.BorderWidth
		{
			get; set;
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

		#endregion

		#region ITextControl

		string ITextControl.FontFamily
		{
			get; set;
		}

		Color ITextControl.FontColor
		{
			get; set;
		}

		bool ITextControl.Bold
		{
			get; set;
		}

		bool ITextControl.Italic
		{
			get; set;
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

		double ITextControl.FontSize
		{
			get;
			set;
		}

		#endregion
	}
}