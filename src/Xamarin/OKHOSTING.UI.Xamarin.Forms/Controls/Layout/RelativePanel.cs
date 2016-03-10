using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System.Collections.Generic;
using View = global::Xamarin.Forms.View;
using Constraint = global::Xamarin.Forms.Constraint;
using Xamarin.Forms;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layout
{
	public class RelativePanel : global::Xamarin.Forms.RelativeLayout, IRelativePanel
	{
		public RelativePanel()
		{
			_Children = new ControlList(base.Children);
		}

		protected readonly ControlList _Children;

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

		#region IDisposable

		void IDisposable.Dispose()
		{
		}

		#endregion

		#region IRelativePanel

		IList<IControl> IRelativePanel.Children
		{
			get
			{
				return _Children;
			}
		}
		
		void IRelativePanel.Add(IControl control, RelativePanelHorizontalContraint horizontalContraint, IControl horizontalReference, RelativePanelVerticalContraint verticalContraint, IControl verticalReference)
		{
			if (control == null)
			{
				throw new ArgumentNullException(nameof(control));
			}

			Constraint horizontalXamarinConstraint = null;
			Constraint verticalXamarinConstraint = null;

			//horizontal constraint

			if (horizontalReference == null)
			{
				switch (horizontalContraint)
				{
					case RelativePanelHorizontalContraint.CenterWith:
						horizontalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.X + (parent.Width / 2) - (control.Width.Value / 2); });
						break;

					case RelativePanelHorizontalContraint.LeftOf:
						horizontalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.X - control.Width.Value; });
						break;

					case RelativePanelHorizontalContraint.LeftWith:
						horizontalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.X; });
						break;

					case RelativePanelHorizontalContraint.RightOf:
						horizontalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.X + control.Width.Value; });
						break;

					case RelativePanelHorizontalContraint.RightWith:
						horizontalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.X + parent.Width - control.Width.Value; });
						break;
				}
			}
			else
			{
				switch (horizontalContraint)
				{
					case RelativePanelHorizontalContraint.CenterWith:
						horizontalXamarinConstraint = Constraint.RelativeToView((View) horizontalReference, (parent, reference) => { return reference.X + (reference.Width / 2) - (control.Width.Value / 2); });
						break;

					case RelativePanelHorizontalContraint.LeftOf:
						horizontalXamarinConstraint = Constraint.RelativeToView((View) horizontalReference, (parent, reference) => { return reference.X - ((IControl) reference).Margin.Left.Value - control.Width.Value; });
						break;
						
					case RelativePanelHorizontalContraint.LeftWith:
						horizontalXamarinConstraint = Constraint.RelativeToView((View) horizontalReference, (parent, reference) => { return reference.X; });
						break;

					case RelativePanelHorizontalContraint.RightOf:
						horizontalXamarinConstraint = Constraint.RelativeToView((View) horizontalReference, (parent, reference) => { return reference.X + reference.Width; });
						break;

					case RelativePanelHorizontalContraint.RightWith:
						horizontalXamarinConstraint = Constraint.RelativeToView((View) horizontalReference, (parent, reference) => { return reference.X + reference.Width - control.Width.Value; });
						break;
				}
			}

			//vertical constraint

			if (verticalReference == null)
			{
				switch (verticalContraint)
				{
					case RelativePanelVerticalContraint.AboveOf:
						verticalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.Y - control.Height.Value; });
						break;

					case RelativePanelVerticalContraint.BelowOf:
						verticalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.Y + parent.Height; });
						break;

					case RelativePanelVerticalContraint.BottomWith:
						verticalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.Y + parent.Height - control.Height.Value; });
						break;

					case RelativePanelVerticalContraint.CenterWith:
						verticalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.Y + (parent.Height / 2) - (control.Height.Value / 2); });
						break;

					case RelativePanelVerticalContraint.TopWith:
						verticalXamarinConstraint = Constraint.RelativeToParent((parent) => { return parent.Y; });
						break;
				}
			}
			else
			{
				switch (verticalContraint)
				{
					case RelativePanelVerticalContraint.AboveOf:
						verticalXamarinConstraint = Constraint.RelativeToView((View) verticalReference, (parent, reference) => { return reference.Y - control.Height.Value; });
						break;

					case RelativePanelVerticalContraint.BelowOf:
						verticalXamarinConstraint = Constraint.RelativeToView((View) verticalReference, (parent, reference) => { return reference.Y + reference.Height + control.Height.Value; });
						break;

					case RelativePanelVerticalContraint.BottomWith:
						verticalXamarinConstraint = Constraint.RelativeToView((View) verticalReference, (parent, reference) => { return reference.Y + reference.Height; });
						break;

					case RelativePanelVerticalContraint.CenterWith:
						verticalXamarinConstraint = Constraint.RelativeToView((View) verticalReference, (parent, reference) => { return reference.Y + (reference.Height / 2) - (control.Height.Value / 2); });
						break;

					case RelativePanelVerticalContraint.TopWith:
						verticalXamarinConstraint = Constraint.RelativeToView((View) verticalReference, (parent, reference) => { return reference.Y; });
						break;
				}
			}

			//finally add to children using the constraints
			base.Children.Add((View) control, horizontalXamarinConstraint, verticalXamarinConstraint, null, null);
		}

		#endregion
	}
}