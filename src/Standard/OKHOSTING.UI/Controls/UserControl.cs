using System;
using System.Linq;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// An IPage that is also a IControl, allowing you to add it as a control, but then assign a controller to it and let it work.
	/// The controller will believe this is the main Page and will work as espected, inside the UserControl.
	/// </summary>
	public class UserControl: IPage, IControl
	{
		/// <summary>
		/// The actual control that will contain the IPage.Content
		/// </summary>
		public readonly IFlow Container;

		public UserControl(App app)
		{
			if (app == null)
			{
				throw new ArgumentNullException(nameof(app));
			}

			App = app;
			Container = App.Create<IFlow>();
		}

		#region IPage

		/// <summary>
		/// Raised when the page is resized
		/// </summary>
		public event EventHandler Resized;

		/// <summary>
		/// App that is calling the controller
		/// </summary>
		public App App { get; set; }

		/// <summary>
		/// Title for this page
		/// <para xml:lang="es">
		/// El titulo para esta pagina.
		/// </para>
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Width of the page, in density independent pixels
		/// <para xml:lang="es">
		/// Anchura de la pagina, en la dencidad de pixeles independientes.
		/// </para>
		/// </summary>
		public double Width
		{
			get
			{
				return Container.Width ?? 0;
			}
		}

		/// <summary>
		/// Height of the page, in density independent pixels
		/// <para xml:lang="es">
		/// Altura de la página, en la densidad de pixeles independientes.
		/// </para>
		/// </summary>
		public double Height
		{
			get
			{
				return Container.Height ?? 0;
			}
		}

		/// <summary>
		/// Each Page only contains one main view, which can optionally be a container and contain more views
		/// <para xml:lang="es">
		/// Cada ventana solo contiene una vista principal, que puede ser opcionalmente un contenedor y contener mas vistas.
		/// </para>
		/// </summary>
		public IControl Content
		{
			get
			{
				return Container.Children.FirstOrDefault();
			}
			set
			{
				Container.Children.Clear();

				if (value != null)
				{
					Container.Children.Add(value);
				}
			}
		}

		#endregion

		#region IControl

		/// <summary>
		/// Friendly programming name (or id) of the control. A simple view should not contain 2 controls with the same name.
		/// <para xml:lang="es">
		/// Nombre (o Id) de programacion amigable del control. Una simple vista no puede contener dos controles con el mismo nombre.
		/// </para>
		/// </summary>
		public string Name
		{
			get
			{
				return Container.Name;
			}
			set
			{
				Container.Name = value;
			}
		}

		/// <summary>
		/// Gets or sets wether the control is visible or not
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es visible o no.
		/// </para>
		/// </summary>
		public bool Visible
		{
			get
			{
				return Container.Visible;
			}
			set
			{
				Container.Visible = value;
			}
		}

		/// <summary>
		/// Gets or sets wether the control is enabled or not
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es habilitado o no.
		/// </para>
		/// </summary>
		public bool Enabled
		{
			get
			{
				return Container.Enabled;
			}
			set
			{
				Container.Enabled = value;
			}
		}

		/// <summary>
		/// Space that this control will set between itself and it's container
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su contenedor.
		/// </para>
		/// </summary>
		public Thickness Margin
		{
			get
			{
				return Container.Margin;
			}
			set
			{
				Container.Margin = value;
			}
		}

		/// <summary>
		/// Background color
		/// <para xml:lang="es">
		/// Color de fondo.
		/// </para>
		/// </summary>
		public Color BackgroundColor
		{
			get
			{
				return Container.BackgroundColor;
			}
			set
			{
				Container.BackgroundColor = value;
			}
		}

		/// <summary>
		/// Border color
		/// <para xml:lang="es">
		/// Color del borde.
		/// </para>
		/// </summary>
		public Color BorderColor
		{
			get
			{
				return Container.BorderColor;
			}
			set
			{
				Container.BorderColor = value;
			}
		}

		/// <summary>
		/// Border width, in density independent pixels (DIP)
		/// <para xml:lang="es">
		/// Ancho del borde, en dencidad de pixeles independientes (DIP)
		/// </para>
		/// </summary>
		public Thickness BorderWidth
		{
			get
			{
				return Container.BorderWidth;
			}
			set
			{
				Container.BorderWidth = value;
			}
		}

		/// <summary>
		/// Horizontal alignment of the control with respect to it's container.
		/// <para xml:lang="es">
		/// Alineacion horizontal del control con respecto a su contenedor.
		/// </para>
		/// </summary>
		public HorizontalAlignment HorizontalAlignment
		{
			get
			{
				return Container.HorizontalAlignment;
			}
			set
			{
				Container.HorizontalAlignment = value;
			}
		}

		/// <summary>
		/// Vertical alignment of the control with respect to it's container
		/// <para xml:lang="es">
		/// Alineacion vertical del control con respecto a su contenedor.
		/// </para>
		/// </summary>
		public VerticalAlignment VerticalAlignment
		{
			get
			{
				return Container.VerticalAlignment;
			}
			set
			{
				Container.VerticalAlignment = value;
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">
		/// Obtiene o establece un objeto de valor arbitrario que se puede usar para almacenar informacion personalizada sobre este elemento.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">
		/// Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.
		/// </para>
		/// </remarks>
		public object Tag
		{
			get
			{
				return Container.Tag;
			}
			set
			{
				Container.Tag = value;
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
				return Container.Width;
			}
			set
			{
				Container.Width = value;
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
				return Container.Height;
			}
			set
			{
				Container.Height = value;
			}
		}

		public void Dispose()
		{
			Container.Dispose();
		}
		
		#endregion
	}
}