using OKHOSTING.UI.Controls;
using System;
using System.Collections;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
    public class Autocomplete : WpfAutoCompleteControls.Editors.AutoCompleteTextBox, IAutocomplete, WpfAutoCompleteControls.Editors.ISuggestionProvider
    {
        public Autocomplete()
        {
            //base.OnApplyTemplate();
            base.Provider = this;
        }

        public IEnumerable GetSuggestions(string filter)
        {
            var e = this.OnSearching(filter);

            return e.SearchResult;
        }

        #region ITextControl

        /// <summary>
		/// Private member to store the FontColor
		/// </summary>
		private Color _FontColor;

        Color ITextControl.FontColor
        {
            get
            {
                return _FontColor;
            }
            set
            {
                _FontColor = value;
                base.Foreground = new System.Windows.Media.SolidColorBrush(Platform.Parse(value));
            }
        }

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

        HorizontalAlignment ITextControl.TextHorizontalAlignment
        {
            get
            {
                return Platform.Parse(base.HorizontalContentAlignment);
            }
            set
            {
                base.HorizontalContentAlignment = Platform.Parse(value);
            }
        }

        VerticalAlignment ITextControl.TextVerticalAlignment
        {
            get
            {
                return Platform.Parse(base.VerticalContentAlignment);
            }
            set
            {
                base.VerticalContentAlignment = Platform.Parse(value);
            }
        }

        Thickness ITextControl.TextPadding
        {
            get
            {
                return Platform.Parse(base.Padding);
            }
            set
            {
                base.Padding = Platform.Parse(value);
            }
        }

        #endregion

        #region IInputControl

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

        public event EventHandler<string> ValueChanged;

        #endregion

        #region IControl

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

        Color IControl.BackgroundColor
        {
            get
            {
                return Platform.Parse(((System.Windows.Media.SolidColorBrush)base.Background).Color);
            }
            set
            {
                base.Background = new System.Windows.Media.SolidColorBrush(Platform.Parse(value));
            }
        }

        Color IControl.BorderColor
        {
            get
            {
                return Platform.Parse(((System.Windows.Media.SolidColorBrush)base.BorderBrush).Color);
            }
            set
            {
                base.BorderBrush = new System.Windows.Media.SolidColorBrush(Platform.Parse(value));
            }
        }

        Thickness IControl.BorderWidth
        {
            get
            {
                return Platform.Parse(base.BorderThickness);
            }
            set
            {
                base.BorderThickness = Platform.Parse(value);
            }
        }

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

        Thickness IControl.Margin
        {
            get
            {
                return Platform.Parse(base.Margin);
            }
            set
            {
                base.Margin = Platform.Parse(value);
            }
        }

        HorizontalAlignment IControl.HorizontalAlignment
        {
            get
            {
                return Platform.Parse(base.HorizontalAlignment);
            }
            set
            {
                base.HorizontalAlignment = Platform.Parse(value);
            }
        }

        VerticalAlignment IControl.VerticalAlignment
        {
            get
            {
                return Platform.Parse(base.VerticalAlignment);
            }
            set
            {
                base.VerticalAlignment = Platform.Parse(value);
            }
        }

        #endregion

        public event EventHandler<AutocompleteSearchEventArgs> Searching;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public AutocompleteSearchEventArgs OnSearching(string text)
        {
            var e = new AutocompleteSearchEventArgs(text);

            Searching?.Invoke(this, e);

            return e;
        }

        private void Autocomplete_TextChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, ((IInputControl<string>)this).Value);
        }

    }
}
