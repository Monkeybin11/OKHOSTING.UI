using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System.Collections.Generic;
using View = global::Xamarin.Forms.View;
using Constraint = global::Xamarin.Forms.Constraint;
using Xamarin.Forms;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layout
{
	/// <summary>
	/// Inspired by UWP and Xamarin.Forms RelativePanel's
	/// <para xml:lang="es">
	/// Un RelativePanel inspirado por WPF y Xamarin.Forms
	/// </para>
	/// </summary>
	public class RelativePanel : global::Xamarin.Forms.RelativeLayout, IRelativePanel
	{
		/// <summary>
		/// Initializes a new instance of the RelativePanel class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase RelativePanel</para>
		/// </summary>
		public RelativePanel()
		{
			_Children = new ControlList(base.Children);
		}

		/// <summary>
		/// The children.
		/// <para xml:lang="es">Lista de los controles hijos.</para>
		/// </summary>
		protected readonly ControlList _Children;

		#region IControl

		/// <summary>
		/// Gets or sets the name of the control.
		/// <para xml:lang="es">Obtiene o establece el nombre del control.</para>
		/// </summary>
		string IControl.Name
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets wether Control is visible or not.
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
		/// Gets or sets wether Control is enabled or not.
		/// <para xml:lang="es">Obtiene o establece si el control es habilitado o no.</para>
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
		/// Gets or sets the width of the Control.
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
				}
			}
		}

		/// <summary>
		/// Gets or sets the height of the Control.
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
				}
			}
		}

		/// <summary>
		/// Gets or sets the margin Control.
		/// <para xml:lang="es">Obtiene o establece el margen del control.</para>
		/// </summary>
		Thickness IControl.Margin
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the backgroundcolor of the Control.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del control.</para>
		/// </summary>
		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the bordercolor of the Control.
		/// <para xml:lang="es">Obtiene o establece el color del borde del control.</para>
		/// </summary>
		Color IControl.BorderColor
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the borderwidth of the Control.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del control.</para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the horizontal alignment of the Control.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del control.</para>
		/// </summary>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(Platform.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets the vertical alignment of the Control.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical.</para>
		/// </summary>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.ParseVerticalAlignment(base.VerticalOptions.Alignment);
			}
			set
			{
				base.VerticalOptions = new global::Xamarin.Forms.LayoutOptions(Platform.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">
		/// Obtiene o establece un objeto de valor arbitrario que puede ser usado para almacenar informacion personalizada sobre este elemento.
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

		#endregion

		#region IDisposable
		/// <summary>
		/// Dispose.
		/// <para xml:lang="es">Libera la memoria.</para>
		/// </summary>
		/// <returns>The identifier dispose.
		/// <para xml:lang="es">El identificador dispose.</para>
		/// </returns>
		void IDisposable.Dispose()
		{
		}

		#endregion

		#region IRelativePanel
		/// <summary>
		/// Gets the controls RelativePanel children.
		/// <para xml:lang="es">Obtiene los controles hijos del RelativePanel.</para>
		/// </summary>
		IList<IControl> IRelativePanel.Children
		{
			get
			{
				return _Children;
			}
		}

		/// <summary>
		/// Adds the specified control to RelativePanel with vertical and horizontal alignment specified for the specified reference control.
		/// <para xml:lang="es">
		/// Agrega el control especificado al RelativePanel con la alineacion vertical y horizontal especificadas con respecto al control de referencia especificado.
		/// </para>
		/// </summary>
		/// <returns>The control Relative panel add.
		/// <para xml:lang="es">El control agregado al RelativePanel.</para>
		/// </returns>
		/// <param name="control">Control.
		/// <para xml:lang="es">El control a agregar al control.</para>
		/// </param>
		/// <param name="horizontalContraint">Horizontal contraint.
		/// <para xml:lang="es">Restriccion de la alineacion horizontal para el control.</para>
		/// </param>
		/// <param name="verticalContraint">Vertical contraint.
		/// <para xml:lang="es">Restricciona de la alineacion vertical para el control.</para>
		/// </param>
		/// <param name="referenceControl">Reference control.
		/// <para xml:lang="es">Control de referencia.</para>
		/// </param>
		void IRelativePanel.Add(IControl control, RelativePanelHorizontalContraint horizontalContraint, RelativePanelVerticalContraint verticalContraint, IControl referenceControl)
		{
			if (control == null)
			{
				throw new ArgumentNullException(nameof(control));
			}

			if (control.Margin == null)
			{
				control.Margin = new Thickness(0);
			}

			if (((IRelativePanel) this).Margin == null)
			{
				((IRelativePanel) this).Margin = new Thickness(0);
			}

			Thickness myMargin = ((IRelativePanel) this).Margin;
			Constraint horizontalXamarinConstraint = null;
			Constraint verticalXamarinConstraint = null;

			//no reference is given, so we position the control relative to the this panel

			if (referenceControl == null)
			{
				switch (horizontalContraint)
				{
					case RelativePanelHorizontalContraint.CenterWith:
						horizontalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.X + (parent.Width / 2) - (control.Width.Value / 2); });
						break;

					case RelativePanelHorizontalContraint.LeftOf:
						horizontalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.X - control.Width.Value - control.Margin.Right.Value - myMargin.Left.Value; });
						break;

					case RelativePanelHorizontalContraint.LeftWith:
						horizontalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.X + control.Margin.Left.Value; });
						break;

					case RelativePanelHorizontalContraint.RightOf:
						horizontalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.X + parent.Width + control.Margin.Left.Value + myMargin.Right.Value; });
						break;

					case RelativePanelHorizontalContraint.RightWith:
						horizontalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.X + parent.Width - control.Width.Value - control.Margin.Right.Value; });
						break;
				}

				switch (verticalContraint)
				{
					case RelativePanelVerticalContraint.AboveOf:
						verticalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.Y - control.Height.Value - control.Margin.Bottom.Value - myMargin.Top.Value; });
						break;

					case RelativePanelVerticalContraint.BelowOf:
						verticalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.Y + parent.Height + control.Margin.Top.Value + myMargin.Bottom.Value; });
						break;

					case RelativePanelVerticalContraint.BottomWith:
						verticalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.Y + parent.Height - control.Height.Value - control.Margin.Bottom.Value; });
						break;

					case RelativePanelVerticalContraint.CenterWith:
						verticalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.Y + (parent.Height / 2) - (control.Height.Value / 2); });
						break;

					case RelativePanelVerticalContraint.TopWith:
						verticalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.Y + control.Margin.Top.Value; });
						break;
				}
			}
			//a reference control is given, so we position the control relative to referenceControl
			else
			{
				switch (horizontalContraint)
				{
					case RelativePanelHorizontalContraint.CenterWith:
						horizontalXamarinConstraint = Constraint.RelativeToView((View) referenceControl, (parent, reference) => { return reference.X + (reference.Width / 2) - (control.Width.Value / 2); });
						break;

					case RelativePanelHorizontalContraint.LeftOf:
						horizontalXamarinConstraint = Constraint.RelativeToView((View) referenceControl, (parent, reference) => { return reference.X - control.Width.Value - control.Margin.Right.Value - ((IControl) reference).Margin.Left.Value; });
						break;
						
					case RelativePanelHorizontalContraint.LeftWith:
						horizontalXamarinConstraint = Constraint.RelativeToView((View) referenceControl, (parent, reference) => { return reference.X + control.Margin.Left.Value; });
						break;

					case RelativePanelHorizontalContraint.RightOf:
						horizontalXamarinConstraint = Constraint.RelativeToView((View) referenceControl, (parent, reference) => { return reference.X + reference.Width + control.Margin.Left.Value + ((IControl) reference).Margin.Right.Value; });
						break;

					case RelativePanelHorizontalContraint.RightWith:
						horizontalXamarinConstraint = Constraint.RelativeToView((View) referenceControl, (parent, reference) => { return reference.X + reference.Width - control.Width.Value - control.Margin.Right.Value; });
						break;
				}

				switch (verticalContraint)
				{
					case RelativePanelVerticalContraint.AboveOf:
						verticalXamarinConstraint = Constraint.RelativeToView((View) referenceControl, (parent, reference) => { return reference.Y - control.Height.Value - control.Margin.Bottom.Value - ((IControl) reference).Margin.Top.Value; });
						break;

					case RelativePanelVerticalContraint.BelowOf:
						verticalXamarinConstraint = Constraint.RelativeToView((View) referenceControl, (parent, reference) => { return reference.Y + reference.Height + control.Margin.Top.Value + ((IControl) reference).Margin.Bottom.Value; });
						break;

					case RelativePanelVerticalContraint.BottomWith:
						verticalXamarinConstraint = Constraint.RelativeToView((View) referenceControl, (parent, reference) => { return reference.Y + reference.Height - control.Margin.Bottom.Value; });
						break;

					case RelativePanelVerticalContraint.CenterWith:
						verticalXamarinConstraint = Constraint.RelativeToView((View) referenceControl, (parent, reference) => { return reference.Y + (reference.Height / 2) - (control.Height.Value / 2); });
						break;

					case RelativePanelVerticalContraint.TopWith:
						verticalXamarinConstraint = Constraint.RelativeToView((View) referenceControl, (parent, reference) => { return reference.Y + control.Margin.Top.Value; });
						break;
				}
			}

			//finally add to children using the constraints
			base.Children.Add((View) control, horizontalXamarinConstraint, verticalXamarinConstraint, null, null);
		}

		#endregion
	}
}