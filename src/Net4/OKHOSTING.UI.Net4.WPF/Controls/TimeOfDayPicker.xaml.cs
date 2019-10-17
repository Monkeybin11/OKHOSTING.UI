using OKHOSTING.UI.Controls;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	/// <summary>
	/// Taken from http://jobijoy.blogspot.com/2007/10/time-picker-user-control.html
	/// </summary>
	public partial class TimeOfDayPicker : System.Windows.Controls.UserControl, ITimeOfDayPicker
	{
		public TimeOfDayPicker()
		{
			InitializeComponent();
		}

		public TimeSpan? Value
		{
			get { return (TimeSpan) GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register
		(
			"Value", 
			typeof(TimeSpan), 
			typeof(TimeOfDayPicker),
			new UIPropertyMetadata(DateTime.Now.TimeOfDay, new PropertyChangedCallback(OnValueChanged))
		);

		private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			TimeOfDayPicker control = obj as TimeOfDayPicker;

			control.Hours = ((TimeSpan) e.NewValue).Hours;
			control.Minutes = ((TimeSpan) e.NewValue).Minutes;
			control.Seconds = ((TimeSpan) e.NewValue).Seconds;

			control.ValueChanged?.Invoke(control, (TimeSpan) e.NewValue);
		}

		public int Hours
		{
			get { return (int) GetValue(HoursProperty); }
			set { SetValue(HoursProperty, value); }
		}

		public static readonly DependencyProperty HoursProperty = DependencyProperty.Register
		(
			"Hours", 
			typeof(int), 
			typeof(TimeOfDayPicker),
			new UIPropertyMetadata(0, new PropertyChangedCallback(OnTimeChanged))
		);

		public int Minutes
		{
			get { return (int) GetValue(MinutesProperty); }
			set { SetValue(MinutesProperty, value); }
		}

		public static readonly DependencyProperty MinutesProperty = DependencyProperty.Register
		(
			"Minutes", 
			typeof(int), 
			typeof(TimeOfDayPicker),
			new UIPropertyMetadata(0, new PropertyChangedCallback(OnTimeChanged))
		);

		public int Seconds
		{
			get { return (int) GetValue(SecondsProperty); }
			set { SetValue(SecondsProperty, value); }
		}

		public static readonly DependencyProperty SecondsProperty = DependencyProperty.Register
		(
			"Seconds", 
			typeof(int), 
			typeof(TimeOfDayPicker),
			new UIPropertyMetadata(0, new PropertyChangedCallback(OnTimeChanged))
		);

		private static void OnTimeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			TimeOfDayPicker control = obj as TimeOfDayPicker;
			control.Value = new TimeSpan(control.Hours, control.Minutes, control.Seconds);
		}

		private void Down(object sender, KeyEventArgs args)
		{
			switch (((Grid) sender).Name)
			{
				case "sec":
					if (args.Key == Key.Up)
						this.Seconds++;

					if (args.Key == Key.Down)
						this.Seconds--;
					break;

				case "min":
					if (args.Key == Key.Up)
						this.Minutes++;
					if (args.Key == Key.Down)
						this.Minutes--;
					break;

				case "hour":
					if (args.Key == Key.Up)
						this.Hours++;

					if (args.Key == Key.Down)
						this.Hours--;

					break;
			}
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

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

		/// <summary>
		/// Space that this control will set between its content and its border
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre su contenido y su borde
		/// </para>
		/// </summary>
		Thickness IControl.Padding
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

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		string IControl.CssClass { get; set; }

		#endregion

		#region ITextControl

		string ITextControl.FontFamily
		{
			get
			{
				return base.FontFamily.Source;
			}
			set
			{
				base.FontFamily = mmTxt.FontFamily = sep1.FontFamily = ddTxt.FontFamily = sep2.FontFamily = yyTxt.FontFamily = new System.Windows.Media.FontFamily(value);
			}
		}

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
				base.Foreground = mmTxt.Foreground = sep1.Foreground = ddTxt.Foreground = sep2.Foreground = yyTxt.Foreground = new System.Windows.Media.SolidColorBrush(Platform.Parse(value));
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
				base.FontWeight = mmTxt.FontWeight = sep1.FontWeight = ddTxt.FontWeight = sep2.FontWeight = yyTxt.FontWeight = FontWeights.Bold;
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
				base.FontStyle = mmTxt.FontStyle = sep1.FontStyle = ddTxt.FontStyle = sep2.FontStyle = yyTxt.FontStyle = FontStyles.Italic;
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
				base.HorizontalContentAlignment = mmTxt.HorizontalAlignment = sep1.HorizontalAlignment = ddTxt.HorizontalAlignment = sep2.HorizontalAlignment = yyTxt.HorizontalAlignment = Platform.Parse(value);
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
				base.VerticalContentAlignment = mmTxt.VerticalAlignment = sep1.VerticalAlignment = ddTxt.VerticalAlignment = sep2.VerticalAlignment = yyTxt.VerticalAlignment = Platform.Parse(value);
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

		public event EventHandler<TimeSpan?> ValueChanged;
	}
}