using System;
using System.Drawing;
using System.Collections.Generic;
using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using View = global::Xamarin.Forms.View;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layout
{
	/// <summary>
	/// Base control for all containers, allows for a background image
	/// </summary>
	public abstract class Background<T> : global::Xamarin.Forms.Grid, IContainer where T : View
	{
		private IImage _BackgroundImage;
		protected readonly T Content;

		public Background()
		{
			Content = BaitAndSwitch.Create<T>();

			SetRow(Content, 0);
			SetColumn(Content, 0);
			
			//make only 1 cell and put the content there
			base.ColumnDefinitions.Add(new global::Xamarin.Forms.ColumnDefinition());
			base.RowDefinitions.Add(new global::Xamarin.Forms.RowDefinition());
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
				if (value.HasValue)
				{
					base.WidthRequest = value.Value;
					Content.WidthRequest = value.Value;
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
				if (value.HasValue)
				{
					base.HeightRequest = value.Value;
					Content.HeightRequest = value.Value;
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
				return Forms.Platform.Parse(base.Padding);
			}
			set
			{
				base.Padding = Forms.Platform.Parse(value);
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

		/// <summary>
		/// Gets or sets the bordercolor of the control.
		/// <para xml:lang="es">Obtiene o establece el color del borde del control.</para>
		/// </summary>
		Color IControl.BorderColor
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the borderwidth of the control.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del control.</para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get; set;
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

		#endregion

		IImage IContainer.BackgroundImage
		{
			get
			{
				return _BackgroundImage;
			}
			set
			{
				_BackgroundImage = value;

				if (value != null)
				{
					//remove old background
					if (_BackgroundImage != null & base.Children.Contains((View) _BackgroundImage))
					{
						base.Children.Remove((View) _BackgroundImage);
					}

					((global::Xamarin.Forms.Image) value).Aspect = global::Xamarin.Forms.Aspect.AspectFill;
					((global::Xamarin.Forms.Image) value).HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(global::Xamarin.Forms.LayoutAlignment.Fill, true);
					((global::Xamarin.Forms.Image) value).VerticalOptions = new global::Xamarin.Forms.LayoutOptions(global::Xamarin.Forms.LayoutAlignment.Fill, true);
					
					SetRow((global::Xamarin.Forms.Image) value, 0);
					SetColumn((global::Xamarin.Forms.Image) value, 0);
					
					SetRowSpan((global::Xamarin.Forms.Image) value, 1);
					SetColumnSpan((global::Xamarin.Forms.Image) value, 1);

					base.Children.Insert(0, (View) value);
				}
			}
		}

		public new abstract ICollection<IControl> Children
		{
			get;
		}

		public virtual void Dispose()
		{
		}
	}
}