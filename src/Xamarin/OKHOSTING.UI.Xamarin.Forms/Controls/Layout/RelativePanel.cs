using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using View = global::Xamarin.Forms.View;
using Constraint = global::Xamarin.Forms.Constraint;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layout
{
	/// <summary>
	/// Inspired by UWP and Xamarin.Forms RelativePanel's
	/// <para xml:lang="es">
	/// Un RelativePanel inspirado por WPF y Xamarin.Forms
	/// </para>
	/// </summary>
	public class RelativePanel : Background<global::Xamarin.Forms.RelativeLayout>, IRelativePanel
	{
		private readonly ControlList _Children;

		/// <summary>
		/// Initializes a new instance of the RelativePanel class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase RelativePanel</para>
		/// </summary>
		public RelativePanel()
		{
			_Children = new ControlList(Content.Children);
		}

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
		public override ICollection<IControl> Children
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
			Content.Children.Add((View) control, horizontalXamarinConstraint, verticalXamarinConstraint, null, null);
		}

		#endregion
	}
}