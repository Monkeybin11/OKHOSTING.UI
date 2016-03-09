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
		protected readonly Dictionary<IControl, ControlConstraints> _ChildrenConstraints = new Dictionary<IControl, ControlConstraints>();

		protected override void OnAdded(View view)
		{
			base.OnAdded(view);

			if(!_ChildrenConstraints.ContainsKey((IControl) view))
			{ 
				_ChildrenConstraints.Add((IControl) view, new ControlConstraints());
			}
		}

		protected override void OnRemoved(View view)
		{
			base.OnRemoved(view);

			_ChildrenConstraints[(IControl) view].X = null;
			_ChildrenConstraints[(IControl) view].Y = null;
		}

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

		void IRelativePanel.SetAbove(IControl control, IControl relative)
		{
			_ChildrenConstraints[control].Y = Constraint.RelativeToView((View) relative, (parent, view) => { return view.Y - ((IControl) view).Margin.Top.Value - control.Height.Value - control.Margin.Bottom.Value; });
		}

		void IRelativePanel.SetBelow(IControl control, IControl relative)
		{
			_ChildrenConstraints[control].Y = Constraint.RelativeToView((View) relative, (parent, view) => { return view.Y + view.Height + ((IControl) view).Margin.Bottom.Value + control.Margin.Top.Value; });
		}

		void IRelativePanel.SetLeftOf(IControl control, IControl relative)
		{
			_ChildrenConstraints[control].X = Constraint.RelativeToView((View) relative, (parent, view) => { return view.X - ((IControl) view).Margin.Left.Value - control.Width.Value - control.Margin.Right.Value; });
		}

		void IRelativePanel.SetRightOf(IControl control, IControl relative)
		{
			_ChildrenConstraints[control].X = Constraint.RelativeToView((View) relative, (parent, view) => { return view.X + view.Width + ((IControl) view).Margin.Right.Value + control.Margin.Left.Value; });
		}

		void IRelativePanel.SetAlignBottomWith(IControl control, IControl relative)
		{
			_ChildrenConstraints[control].Y = Constraint.RelativeToView((View) relative, (parent, view) => { return view.Y + view.Width + control.Margin.Top.Value; });
		}

		void IRelativePanel.SetAlignBottomWithPanel(IControl control)
		{
			_ChildrenConstraints[control].Y = Constraint.RelativeToParent((parent) => { return parent.Y + parent.Height - control.Margin.Bottom.Value; });
		}

		void IRelativePanel.SetAlignHorizontalCenterWith(IControl control, IControl relative)
		{
			_ChildrenConstraints[control].X = Constraint.RelativeToView((View) relative, (parent, view) => { return view.X + (view.Width / 2); });
		}

		void IRelativePanel.SetAlignHorizontalCenterWithPanel(IControl control)
		{
			base.Children.Add
			(
				(View) control,
				null,
				Constraint.RelativeToParent((parent) => { return parent.X + (parent.Width / 2); }),
				null,
				null
			);
		}

		void IRelativePanel.SetAlignLeftWith(IControl control, IControl relative)
		{
			base.Children.Add
			(
				(View) control,
				Constraint.RelativeToView((View) relative, (parent, view) => { return view.X; }),
				null,
				null,
				null
			);
		}

		void IRelativePanel.SetAlignLeftWithPanel(IControl control)
		{
			base.Children.Add
			(
				(View) control,
				Constraint.RelativeToParent((parent) => { return parent.X; }),
				null,
				null,
				null
			);
		}

		void IRelativePanel.SetAlignRightWith(IControl control, IControl relative)
		{
			base.Children.Add
			(
				(View) control,
				Constraint.RelativeToView((View) relative, (parent, view) => { return view.X + view.Width - control.Width.Value; }),
				null,
				null,
				null
			);
		}

		void IRelativePanel.SetAlignRightWithPanel(IControl control)
		{
			base.Children.Add
			(
				(View) control,
				Constraint.RelativeToParent((parent) => { return parent.X + parent.Width - control.Width.Value; }),
				null,
				null,
				null
			);
		}

		void IRelativePanel.SetAlignTopWith(IControl control, IControl relative)
		{
			base.Children.Add
			(
				(View) control,
				null,
				Constraint.RelativeToView((View) relative, (parent, view) => { return view.Y + control.Margin.Top.Value; }),
				null,
				null
			);
		}

		void IRelativePanel.SetAlignTopWithPanel(IControl control)
		{
			throw new NotImplementedException();
		}

		void IRelativePanel.SetAlignVerticalCenterWith(IControl control, IControl relative)
		{
			throw new NotImplementedException();
		}

		void IRelativePanel.SetAlignVerticalCenterWithPanel(IControl control)
		{
			throw new NotImplementedException();
		}

		protected class ControlConstraints
		{
			public Constraint X { get; set; }
			public Constraint Y { get; set; }
		}

		#endregion
	}
}