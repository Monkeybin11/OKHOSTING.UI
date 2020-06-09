using System;
using System.Drawing;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Net4.WPF.Controls.Layout
{
	/// <summary>
	/// It is a container shaped pile where you can be stacked objects, which we can give you design through its properties
	/// <para xml:lang="es">Es un contenedor en forma de pila, donde puedes ir apilando objetos, al cual le podemos dar diseño por medio de sus propiedades</para>
	/// </summary>
	public class Stack : System.Windows.Controls.StackPanel, IStack
	{
		private readonly ControlList _Children;

		/// <summary>
		/// Initializes a new instance of the OKHOSTING.UI.Net4.Ajax.Controls.Layout.Stack class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase OKHOSTING.UI.Net4.Ajax.Controls.Layout.Stack</para>
		/// </summary>
		public Stack()
		{
			_Children = new ControlList(base.Children);
			base.Orientation = System.Windows.Controls.Orientation.Vertical;
		}

		#region IControl

		/// <summary>
		/// Gets or sets wether the control is visible or not
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es visible o no.
		/// </para>
		/// </summary>
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

		/// <summary>
		/// Gets or sets wether the control is enabled or not
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es habilitado o no.
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
			}
		}

		/// <summary>
		/// Width of the control, in density independent pixels
		/// <para xml:lang="es">
		/// Ancho del control, en dencidad de pixeles independientes.
		/// </para>
		/// </summary>
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

		/// <summary>
		/// Height of the control, in density independent pixels.
		/// <para xml:lang="es">
		/// Altura del control, en dencididad de pixeles independiente
		/// </para>
		/// </summary>
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

		/// <summary>
		/// Space that this control will set between itself and it's container
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su contenedor.
		/// </para>
		/// </summary>
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
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the background color
		/// <para xml:lang="es">
		/// Obtiene o establece el color de fondo del control.
		/// </para>
		/// </summary>
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

		/// <summary>
		/// Gets or sets the border color
		/// <para xml:lang="es">
		/// Obtiene o establece el color del borde del control.
		/// </para>
		/// </summary>
		Color IControl.BorderColor
		{
			get; set;
		}

		/// <summary>
		/// Border width, in density independent pixels (DIP)
		/// <para xml:lang="es">
		/// Ancho del borde, en dencidad de pixeles independientes (DIP)
		/// </para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get; set;
		}

		/// <summary>
		/// Horizontal alignment of the control with respect to it's container.
		/// <para xml:lang="es">
		/// Alineación horizontal del control con respecto a su contenedor.
		/// </para>
		/// </summary>
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

		/// <summary>
		/// Vertical alignment of the control with respect to it's container
		/// <para xml:lang="es">
		/// Alineacion vertical del control con respecto a su contenedor.
		/// </para>
		/// </summary>
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

		/// <summary>
		/// Gets the controls IStack children.
		/// <para xml:lang="es">
		/// Obtiene la lista de los controles hijos del Stack.
		/// </para>
		/// </summary>
		ICollection<IControl> IContainer.Children
		{
			get
			{
				return _Children;
			}
		}

		IImage IContainer.BackgroundImage
		{
			get;
			set;
		}

		/// <summary>
		/// The identifier dispose.
		/// <para xml:lang="es">
		/// El identificador Dispose.
		/// </para>
		/// </summary>
		void IDisposable.Dispose()
		{
		}

		protected override void OnRender(System.Windows.Media.DrawingContext dc)
		{
			Platform.SetBackgroundImage(this);
			base.OnRender(dc);
		}
	}
}