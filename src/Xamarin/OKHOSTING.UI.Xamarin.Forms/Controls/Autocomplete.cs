using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class Autocomplete : global::Xamarin.Forms.StackLayout, IAutocomplete
	{
		public Autocomplete()
		{
			GoSearchButton = Platform.Current.Create<IButton>();
			GoSearchButton.Click += GoSearchButton_Click;
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
			OnSearching(SearchText.Value);
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
			ResultView.ItemSelected += ResultView_ItemSelected;

			ResultPage = new global::Xamarin.Forms.ContentPage();
			ResultPage.Content = ResultView;

			((Page) Platform.Current.Page).Navigation.PushAsync(ResultPage);

			return e;
		}

		private void ResultView_ItemSelected(object sender, global::Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			SearchText.Value = e.SelectedItem.ToString();

			if (SearchText.Value != GoSearchButton.Text)
			{
				GoSearchButton.Text = e.SelectedItem.ToString();
				OnValueChanged();
			}

			//close result page
			((Page) Platform.Current.Page).Navigation.PopAsync();

			//close search page and get back to original page
			((Page) Platform.Current.Page).Navigation.PopAsync();
		}

		#region IInputControl

		private void OnValueChanged()
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, ((IInputControl<string>) this).Value);
			}
		}

		public event EventHandler<string> ValueChanged;

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

		void IDisposable.Dispose()
		{
		}
	}
}