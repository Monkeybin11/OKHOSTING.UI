using System;
using System.Linq;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class Autocomplete : global::Xamarin.Forms.StackLayout, IAutocomplete
	{
		public Autocomplete()
		{
			GoSearchButton = Controller.CurrentPage.Create<IButton>();
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
			SearchText = Controller.CurrentPage.Create<ITextBox>();
			SearchButton = Controller.CurrentPage.Create<IButton>();
			SearchButton.Text = "Search";
			SearchButton.Click += SearchButton_Click;
			SearchStack = Controller.CurrentPage.Create<IStack>();
			SearchStack.Children.Add(SearchText);
			SearchStack.Children.Add(SearchButton);

			SearchPage = new Page();
			SearchPage.Content = SearchStack;

			((Page) Controller.CurrentPage).Navigation.PushAsync(SearchPage);
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			OnSearching();
		}

		public string Text
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

		public string Name
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public bool Visible

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

		public void Dispose()
		{
		}

		public void OnSearching()
		{
			if (Searching == null)
			{
				return;
			}

			AutocompleteSearchEventArgs e = new AutocompleteSearchEventArgs(SearchText.Text);
			Searching(this, e);

			if (e.SearchResult == null)
			{
				return;
			}

			ResultView = new global::Xamarin.Forms.ListView();
			ResultView.ItemsSource = e.SearchResult;
			ResultView.ItemSelected += ListView_ItemSelected;

			ResultPage = new global::Xamarin.Forms.ContentPage();
			ResultPage.Content = ResultView;

			((Page) Controller.CurrentPage).Navigation.PushAsync(ResultPage);
		}

		private void ListView_ItemSelected(object sender, global::Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			SearchText.Text = e.SelectedItem.ToString();

			//close result page
			((Page) Controller.CurrentPage).Navigation.PopAsync();

			//close search page and get back to original page
			((Page) Controller.CurrentPage).Navigation.PopAsync();
		}
	}
}