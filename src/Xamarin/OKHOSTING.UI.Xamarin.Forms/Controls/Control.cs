using OKHOSTING.Core;
using System;
using System.Drawing;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class Control<T> : global::Xamarin.Forms.Grid, IControl where T : global::Xamarin.Forms.View
	{
		protected readonly T Content;

		protected readonly global::Xamarin.Forms.BoxView LeftBoder;
		protected readonly global::Xamarin.Forms.BoxView TopBoder;
		protected readonly global::Xamarin.Forms.BoxView RightBoder;
		protected readonly global::Xamarin.Forms.BoxView BottomBoder;

		public Control()
		{
			ColumnDefinitions.Add(new global::Xamarin.Forms.ColumnDefinition() { Width = 0 });
			ColumnDefinitions.Add(new global::Xamarin.Forms.ColumnDefinition());
			ColumnDefinitions.Add(new global::Xamarin.Forms.ColumnDefinition() { Width = 0 });
			
			RowDefinitions.Add(new global::Xamarin.Forms.RowDefinition() { Height = 0 });
			RowDefinitions.Add(new global::Xamarin.Forms.RowDefinition());
			RowDefinitions.Add(new global::Xamarin.Forms.RowDefinition() { Height = 0 });

			LeftBoder = new global::Xamarin.Forms.BoxView() { WidthRequest = 0, HeightRequest = 0 };
			TopBoder = new global::Xamarin.Forms.BoxView() { WidthRequest = 0, HeightRequest = 0 };
			RightBoder = new global::Xamarin.Forms.BoxView() { WidthRequest = 0, HeightRequest = 0 };
			BottomBoder = new global::Xamarin.Forms.BoxView() { WidthRequest = 0, HeightRequest = 0 };

			SetColumn(LeftBoder, 0);
			SetColumn(TopBoder, 1);
			SetColumn(RightBoder, 2);
			SetColumn(BottomBoder, 1);

			SetRow(LeftBoder, 1);
			SetRow(TopBoder, 0);
			SetRow(RightBoder, 1);
			SetRow(BottomBoder, 2);

			SetColumnSpan(TopBoder, 3);
			SetColumnSpan(BottomBoder, 3);

			Content = BaitAndSwitch.Create<T>();

			SetColumn(Content, 1);
			SetRow(Content, 1);
			
			base.Children.Add(Content);
		}

		#region IControl

		/// <summary>
		/// Gets or sets the name of the Control.
		/// <para xml:lang="es">Obtiene o establece el nommbre del control.</para>
		/// </summary>
		string IControl.Name
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the if the control visible.
		/// <para xml:lang="es">Obtiene o establece si el control es visible o no.</para>
		/// </summary>
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

		/// <summary>
		/// Gets or sets the control is enabled or not.
		/// <para xml:lang="es">
		/// Obtiene o establece si el control esta habilitado o no.
		/// </para>
		/// </summary>
		bool IControl.Enabled
		{
			get
			{
				return base.IsEnabled;
			}
			set
			{
				base.IsEnabled = value;
				Content.IsEnabled = value;
			}
		}

		/// <summary>
		/// Gets or sets the width of the control.
		/// <para xml:lang="es">Obtiene o establece el ancho del control.</para>
		/// </summary>
		double? IControl.Width
		{
			get
			{
				return base.WidthRequest;
			}
			set
			{
				if (value.HasValue && value > 0)
				{
					base.WidthRequest = value.Value;
					Content.WidthRequest = value.Value;

					var borderWidth = ((IControl)this).BorderWidth;

					if (borderWidth != null)
					{
						Content.WidthRequest -= borderWidth.Left - borderWidth.Right;
					}

					ColumnDefinitions[1].Width = Content.WidthRequest;

					TopBoder.WidthRequest = value.Value;
					BottomBoder.WidthRequest = value.Value;
				}
				else
				{
					base.WidthRequest = 0;
					Content.WidthRequest = 0;
					ColumnDefinitions[1].Width = 0;

					TopBoder.WidthRequest = 0;
					BottomBoder.WidthRequest = 0;
				}
			}
		}

		/// <summary>
		/// Gets or sets the height of the control.
		/// <para xml:lang="es">Obtiene o establece la altura del control.</para>
		/// </summary>
		double? IControl.Height
		{
			get
			{
				return base.HeightRequest;
			}
			set
			{
				if (value.HasValue && value > 0)
				{
					base.HeightRequest = value.Value;
					Content.HeightRequest = value.Value;

					var borderWidth = ((IControl) this).BorderWidth;

					if (borderWidth != null)
					{
						Content.HeightRequest -= borderWidth.Top - borderWidth.Bottom;
					}

					RowDefinitions[1].Height = Content.HeightRequest;

					LeftBoder.HeightRequest = value.Value - (_BorderWidth?.Top ?? 0 - _BorderWidth?.Bottom?? 0);
					RightBoder.HeightRequest = value.Value - (_BorderWidth?.Top ?? 0 - _BorderWidth?.Bottom ?? 0);
				}
				else
				{
					base.HeightRequest = 0;
					Content.HeightRequest = 0;
					RowDefinitions[1].Height = 0;

					LeftBoder.HeightRequest = 0;
					RightBoder.HeightRequest = 0;
				}
			}
		}

		/// <summary>
		/// Gets or sets the control margin.
		/// <para xml:lang="es">
		/// Obtiene o establece el margen del control.
		/// </para>
		/// </summary>
		Thickness IControl.Margin
		{
			get
			{
				return Forms.Platform.Parse(base.Margin);
			}
			set
			{
				base.Margin = Forms.Platform.Parse(value);
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
				return Forms.Platform.Parse(Content.Margin);
			}
			set
			{
				Content.Margin = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the backgroundcolor of the control.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del control</para>
		/// </summary>
		Color IControl.BackgroundColor
		{
			get
			{
				return Forms.Platform.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = Forms.Platform.Parse(value);
				Content.BackgroundColor = Forms.Platform.Parse(value);
			}
		}

		protected Color _BorderColor;

		/// <summary>
		/// Gets or sets the bordercolor of the control.
		/// <para xml:lang="es">Obtiene o establece el color del borde del control.</para>
		/// </summary>
		Color IControl.BorderColor
		{
			get
			{
				return _BorderColor;
			}
			set
			{
				_BorderColor = value;
				LeftBoder.Color = TopBoder.Color = RightBoder.Color = BottomBoder.Color = value;
			}
		}

		protected Thickness _BorderWidth;
		
		/// <summary>
		/// Gets or sets the borderwidth of the control.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del control.</para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get
			{
				return _BorderWidth;
			}
			set
			{
				_BorderWidth = value;
				
				LeftBoder.WidthRequest = value?.Left ?? 0;
				RightBoder.WidthRequest = value?.Right ?? 0;
				TopBoder.HeightRequest = value?.Top ?? 0;
				BottomBoder.HeightRequest = value?.Bottom ?? 0;

				ColumnDefinitions[0].Width = value?.Left ?? 0;
				ColumnDefinitions[2].Width = value?.Right ?? 0;
				RowDefinitions[0].Height = value?.Top ?? 0;
				RowDefinitions[2].Height = value?.Bottom ?? 0;

			}
		}

		/// <summary>
		/// Gets or sets the horizontal alignment of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineacion horizontal del control.
		/// </para>
		/// </summary>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Forms.Platform.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(Forms.Platform.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets the vertical alignment of the control.
		/// <para xml:lang="es">Obtiene o establevce la alineacion vertical del control.</para>
		/// </summary>
		/// <value>The OKHOSTING . user interface . controls. IC ontrol. vertical alignment.</value>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Forms.Platform.ParseVerticalAlignment(base.VerticalOptions.Alignment);
			}
			set
			{
				base.VerticalOptions = new global::Xamarin.Forms.LayoutOptions(Forms.Platform.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">
		/// Obtiene o establece un objeto de valor arbitrario que puede ser usado para almacenar información personalizada sobre este elemento.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">
		/// Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.
		/// </para>
		/// </remarks>
		object IControl.Tag
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		string IControl.CssClass { get; set; }

		/// <summary>
		/// Control that contains this control, like a grid, or stack
		/// </summary>
		IControl IControl.Parent
		{
			get
			{
				return (IControl) base.Parent;
			}
		}

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}

		public void Dispose()
		{
		}

		#endregion
	}
}