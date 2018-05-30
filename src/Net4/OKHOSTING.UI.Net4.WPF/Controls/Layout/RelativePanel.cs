// Author: Morten Nielsen
// Taken from https://github.com/dotMorten/UniversalWPF

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace OKHOSTING.UI.Net4.WPF.Controls.Layout
{
	/// <summary>
	/// Defines an area within which you can position and align child objects in relation
	/// to each other or the parent panel.
	/// </summary>
	/// <remarks>
	/// <para><b>Default position</b></para>
	///	<para>By default, any unconstrained element declared as a child of the RelativePanel is given the entire
	///	available space and positioned at the(0, 0) coordinates(upper left corner) of the panel.So, if you
	/// are positioning a second element relative to an unconstrained element, keep in mind that the second
	/// element might get pushed out of the panel.
	/// </para>
	///<para><b>Conflicting relationships</b></para>
	///	<para>
	///	If you set multiple relationships that target the same edge of an element, you might have conflicting
	/// relationships in your layout as a result.When this happens, the relationships are applied in the
	///	following order of priority:
	///	  •   Panel alignment relationships (AlignTopWithPanel, AlignLeftWithPanel, …) are applied first.
	///	  •   Sibling alignment relationships(AlignTopWith, AlignLeftWith, …) are applied second.
	///	  •   Sibling positional relationships(Above, Below, RightOf, LeftOf) are applied last.
	/// </para>
	/// <para>
	/// The panel-center alignment properties(AlignVerticalCenterWith, AlignHorizontalCenterWithPanel, ...) are
	/// typically used independently of other constraints and are applied if there is no conflict.
	///</para>
	/// <para>
	/// The HorizontalAlignment and VerticalAlignment properties on UI elements are applied after relationship
	/// properties are evaluated and applied. These properties control the placement of the element within the
	/// available size for the element, if the desired size is smaller than the available size.
	/// </para>
	/// </remarks>
	public partial class RelativePanel : Panel, IRelativePanel
	{
		public RelativePanel()
		{
			_Children = new ControlList(base.Children);
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;

        }

		protected readonly ControlList _Children;

		// Dependency property for storing intermediate arrange state on the children
		private static readonly DependencyProperty ArrangeStateProperty =
			DependencyProperty.Register("ArrangeState", typeof(double[]), typeof(StateTrigger), new PropertyMetadata(null));

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
				return App.Parse(base.Margin);
			}
			set
			{
				base.Margin = App.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return App.Parse(((System.Windows.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(App.Parse(value));
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
				return App.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = App.Parse(value);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = App.Parse(value);
			}
		}
		
		#endregion

		/// <summary>
		/// When overridden in a derived class, measures the size in layout required for
		/// child elements and determines a size for the System.Windows.FrameworkElement-derived
		/// class.</summary>
		/// <param name="availableSize">
		/// The available size that this element can give to child elements. Infinity can
		/// be specified as a value to indicate that the element will size to whatever content
		/// is available.
		/// </param>
		/// <returns>
		/// The size that this element determines it needs during layout, based on its calculations
		/// of child element sizes.
		/// </returns>
		protected override Size MeasureOverride(Size availableSize)
		{
			foreach (var child in Children.OfType<FrameworkElement>())
			{
				child.Measure(availableSize);
			}
			return base.MeasureOverride(availableSize);
		}

		/// <summary>
		///  When overridden in a derived class, positions child elements and determines a
		///  size for a System.Windows.FrameworkElement derived class.
		/// </summary>
		/// <param name="finalSize">
		/// The final area within the parent that this element should use to arrange itself
		/// and its children.
		/// </param>
		/// <returns>The actual size used.</returns>
		protected override Size ArrangeOverride(Size finalSize)
		{
			Dictionary<string, UIElement> elements = new Dictionary<string, UIElement>();
			foreach (var child in Children.OfType<FrameworkElement>().Where(c => c.Name != null))
			{
				elements[child.Name] = child;
			}
			//List of margins for each element between the element and panel (left, top, right, bottom)
			List<double[]> arranges = new List<double[]>(Children.Count);
			//First pass aligns all sides that aren't constrained by other elements
			int arrangedCount = 0;
			foreach (var child in Children.OfType<UIElement>())
			{
				//NaN means the arrange value is not constrained yet for that side
				double[] rect = new[] { double.NaN, double.NaN, double.NaN, double.NaN };
				arranges.Add(rect);
				child.SetValue(ArrangeStateProperty, rect);

				//Align with panels always wins, so do these first, or if no constraints are set at all set margin to 0

				//Left side
				if (GetAlignLeftWithPanel(child))
				{
					rect[0] = 0;
				}
				else if (
					child.GetValue(AlignLeftWithProperty) == null &&
					child.GetValue(RightOfProperty) == null &&
					child.GetValue(AlignHorizontalCenterWithProperty) == null &&
					!GetAlignHorizontalCenterWithPanel(child))
				{
					if (GetAlignRightWithPanel(child))
						rect[0] = finalSize.Width - child.DesiredSize.Width;
					else if (child.GetValue(AlignRightWithProperty) == null && child.GetValue(AlignHorizontalCenterWithProperty) == null)
						rect[0] = 0; //default fallback to 0
				}

				//Top side
				if (GetAlignTopWithPanel(child))
				{
					rect[1] = 0;
				}
				else if (
					child.GetValue(AlignTopWithProperty) == null &&
					child.GetValue(BelowProperty) == null &&
					child.GetValue(AlignVerticalCenterWithProperty) == null &&
					!GetAlignVerticalCenterWithPanel(child))
				{
					if (GetAlignBottomWithPanel(child))
						rect[1] = finalSize.Height - child.DesiredSize.Height;
					else if (child.GetValue(AlignBottomWithProperty) == null && child.GetValue(AlignVerticalCenterWithProperty) == null)
						rect[1] = 0; //default fallback to 0
				}

				//Right side
				if (GetAlignRightWithPanel(child))
				{
					rect[2] = 0;
				}
				else if (!double.IsNaN(rect[0]) &&
				 child.GetValue(AlignRightWithProperty) == null &&
				 child.GetValue(LeftOfProperty) == null &&
				 child.GetValue(AlignHorizontalCenterWithProperty) == null &&
				 !GetAlignHorizontalCenterWithPanel(child))
				{
					rect[2] = finalSize.Width - rect[0] - child.DesiredSize.Width;
				}

				//Bottom side
				if (GetAlignBottomWithPanel(child))
					rect[3] = 0;
				else if (!double.IsNaN(rect[1]) &&
					(child.GetValue(AlignBottomWithProperty) == null &&
					child.GetValue(AboveProperty) == null) &&
					child.GetValue(AlignVerticalCenterWithProperty) == null &&
					!GetAlignVerticalCenterWithPanel(child))
				{
					rect[3] = finalSize.Height - rect[1] - child.DesiredSize.Height;
				}

				if (!double.IsNaN(rect[0]) && !double.IsNaN(rect[1]) &&
					!double.IsNaN(rect[2]) && !double.IsNaN(rect[3]))
					arrangedCount++;
			}
			int i = 0;
			//Run iterative layout passes
			while (arrangedCount < Children.Count)
			{
				int lastArrangeCount = arrangedCount;
				i = 0;
				foreach (var child in Children.OfType<UIElement>())
				{
					double[] rect = arranges[i++];

					if (!double.IsNaN(rect[0]) && !double.IsNaN(rect[1]) &&
						!double.IsNaN(rect[2]) && !double.IsNaN(rect[3]))
						continue; //Control is fully arranged

					//Calculate left side
					if (double.IsNaN(rect[0]))
					{
						var alignLeftWith = GetDependencyElement(RelativePanel.AlignLeftWithProperty, child, elements);
						if (alignLeftWith != null)
						{
							double[] r = (double[])alignLeftWith.GetValue(ArrangeStateProperty);
							if (!double.IsNaN(r[0]))
								rect[0] = r[0];
						}
						else
						{
							var rightOf = GetDependencyElement(RelativePanel.RightOfProperty, child, elements);
							if (rightOf != null)
							{
								double[] r = (double[])rightOf.GetValue(ArrangeStateProperty);
								rect[0] = finalSize.Width - r[2];
							}
							else if (!double.IsNaN(rect[2]))
							{
								rect[0] = finalSize.Width - rect[2] - child.DesiredSize.Width;
							}
						}
					}
					//Calculate top side
					if (double.IsNaN(rect[1]))
					{
						var alignTopWith = GetDependencyElement(RelativePanel.AlignTopWithProperty, child, elements);
						if (alignTopWith != null)
						{
							double[] r = (double[])alignTopWith.GetValue(ArrangeStateProperty);
							if (!double.IsNaN(r[1]))
								rect[1] = r[1];
						}
						else
						{
							var below = GetDependencyElement(RelativePanel.BelowProperty, child, elements);
							if (below != null)
							{
								double[] r = (double[])below.GetValue(ArrangeStateProperty);
								rect[1] = finalSize.Height - r[3];
							}
							else if (!double.IsNaN(rect[3]))
							{
								rect[1] = finalSize.Height - rect[3] - child.DesiredSize.Height;
							}
						}
					}
					//Calculate right side
					if (double.IsNaN(rect[2]))
					{
						var alignRightWith = GetDependencyElement(RelativePanel.AlignRightWithProperty, child, elements);
						if (alignRightWith != null)
						{
							double[] r = (double[])alignRightWith.GetValue(ArrangeStateProperty);
							if (!double.IsNaN(r[2]))
							{
								rect[2] = r[2];
								if (double.IsNaN(rect[0]))
								{
									if (child.GetValue(RelativePanel.AlignLeftWithProperty) == null)
									{
										rect[0] = rect[2] + child.DesiredSize.Width;
									}
								}
							}
						}
						else
						{
							var leftOf = GetDependencyElement(RelativePanel.LeftOfProperty, child, elements);
							if (leftOf != null)
							{
								double[] r = (double[])leftOf.GetValue(ArrangeStateProperty);
								rect[2] = finalSize.Width - r[0];
							}
							else if (!double.IsNaN(rect[0]))
							{
								rect[2] = finalSize.Width - rect[0] - child.DesiredSize.Width;
							}
						}
					}
					//Calculate bottom side
					if (double.IsNaN(rect[3]))
					{
						var alignBottomWith = GetDependencyElement(RelativePanel.AlignBottomWithProperty, child, elements);
						if (alignBottomWith != null)
						{
							double[] r = (double[])alignBottomWith.GetValue(ArrangeStateProperty);
							if (!double.IsNaN(r[3]))
							{
								rect[3] = r[3];
								if (double.IsNaN(rect[1]))
								{
									if (child.GetValue(RelativePanel.AlignTopWithProperty) == null)
									{
										rect[1] = rect[3] + child.DesiredSize.Height;
									}
								}
							}
						}
						else
						{
							var above = GetDependencyElement(RelativePanel.AboveProperty, child, elements);
							if (above != null)
							{
								double[] r = (double[])above.GetValue(ArrangeStateProperty);
								rect[3] = finalSize.Height - r[1];
							}
							else if (!double.IsNaN(rect[1]))
							{
								rect[3] = finalSize.Height - rect[1] - child.DesiredSize.Height;
							}
						}
					}
					//Calculate horizontal alignment
					if (double.IsNaN(rect[0]) && double.IsNaN(rect[2]))
					{
						var alignHorizontalCenterWith = GetDependencyElement(RelativePanel.AlignHorizontalCenterWithProperty, child, elements);
						if (alignHorizontalCenterWith != null)
						{
							double[] r = (double[])alignHorizontalCenterWith.GetValue(ArrangeStateProperty);
							if (!double.IsNaN(r[0]) && !double.IsNaN(r[2]))
							{
								rect[0] = r[0] + (finalSize.Width - r[2] - r[0]) * .5 - child.DesiredSize.Width * .5;
								rect[2] = finalSize.Width - rect[0] - child.DesiredSize.Width;
							}
						}
						else
						{
							if (GetAlignHorizontalCenterWithPanel(child))
							{
								var roomToSpare = finalSize.Width - child.DesiredSize.Width;
								rect[0] = roomToSpare * .5;
								rect[2] = roomToSpare * .5;
							}
						}
					}

					//Calculate vertical alignment
					if (double.IsNaN(rect[1]) && double.IsNaN(rect[3]))
					{
						var alignVerticalCenterWith = GetDependencyElement(RelativePanel.AlignVerticalCenterWithProperty, child, elements);
						if (alignVerticalCenterWith != null)
						{
							double[] r = (double[])alignVerticalCenterWith.GetValue(ArrangeStateProperty);
							if (!double.IsNaN(r[1]) && !double.IsNaN(r[3]))
							{
								rect[1] = r[1] + (finalSize.Height - r[3] - r[1]) * .5 - child.DesiredSize.Height * .5;
								rect[3] = finalSize.Height - rect[1] - child.DesiredSize.Height;
							}
						}
						else
						{
							if (GetAlignVerticalCenterWithPanel(child))
							{
								var roomToSpare = finalSize.Height - child.DesiredSize.Height;
								rect[1] = roomToSpare * .5;
								rect[3] = roomToSpare * .5;
							}
						}
					}


					//if panel is now fully arranged, increase the counter
					if (!double.IsNaN(rect[0]) && !double.IsNaN(rect[1]) &&
						!double.IsNaN(rect[2]) && !double.IsNaN(rect[3]))
						arrangedCount++;
				}
				if (lastArrangeCount == arrangedCount)
				{
					//If a layout pass didn't increase number of arranged elements,
					//there must be a circular dependency
					throw new ArgumentException("RelativePanel error: Circular dependency detected. Layout could not complete");
				}
			}

			i = 0;
			//Arrange iterations complete - Apply the results to the child elements
			foreach (var child in Children.OfType<UIElement>())
			{
				double[] rect = arranges[i++];
				//Measure child again with the new calculated available size
				//this helps for instance textblocks to reflow the text wrapping
				//We should probably have done this during the measure step but it would cause a more expensive
				//measure+arrange layout cycle
				child.Arrange(new Rect(rect[0], rect[1], Math.Max(0, finalSize.Width - rect[2] - rect[0]), Math.Max(0, finalSize.Height - rect[3] - rect[1])));
			}
			return base.ArrangeOverride(finalSize);
		}

		//Gets the element that's referred to in the alignment attached properties
		private UIElement GetDependencyElement(DependencyProperty property, DependencyObject child, Dictionary<string, UIElement> elements)
		{
			var dependency = child.GetValue(property);
			if (dependency == null)
				return null;
			if (dependency is string)
			{
				string name = (string)dependency;
				if (!elements.ContainsKey(name))
					throw new ArgumentException(string.Format("RelativePanel error: The name '{0}' does not exist in the current context", name));
				return elements[name];
			}
			if (dependency is UIElement)
			{
				if (Children.Contains((UIElement)dependency))
					return (UIElement)dependency;
				throw new ArgumentException(string.Format("RelativePanel error: Element does not exist in the current context", property.Name));
			}

			throw new ArgumentException("RelativePanel error: Value must be of type UIElement");
		}

		IList<IControl> IRelativePanel.Children
		{
			get
			{
				return _Children;
			}
		}

		void IRelativePanel.Add(IControl control, RelativePanelHorizontalContraint horizontalContraint, RelativePanelVerticalContraint verticalContraint, IControl referenceControl)
		{
			if (control == null)
			{
				throw new ArgumentNullException(nameof(control));
			}

			//no reference is given, so we position the control relative to the this panel
			if (referenceControl == null)
			{
				switch (horizontalContraint)
				{
					case RelativePanelHorizontalContraint.CenterWith:
						SetAlignHorizontalCenterWithPanel((UIElement) control, true);
						break;

					case RelativePanelHorizontalContraint.LeftOf:
						throw new NotImplementedException();

					case RelativePanelHorizontalContraint.LeftWith:
						SetAlignHorizontalCenterWithPanel((UIElement) control, true);
						break;

					case RelativePanelHorizontalContraint.RightOf:
						throw new NotImplementedException();

					case RelativePanelHorizontalContraint.RightWith:
						SetAlignRightWithPanel((UIElement) control, true);
						break;
				}

				switch (verticalContraint)
				{
					case RelativePanelVerticalContraint.AboveOf:
						throw new NotImplementedException();

					case RelativePanelVerticalContraint.BelowOf:
						throw new NotImplementedException();

					case RelativePanelVerticalContraint.BottomWith:
						SetAlignBottomWithPanel((UIElement) control, true);
						break;

					case RelativePanelVerticalContraint.CenterWith:
						SetAlignVerticalCenterWithPanel((UIElement) control, true);
						break;

					case RelativePanelVerticalContraint.TopWith:
						SetAlignTopWithPanel((UIElement) control, true);
						break;
				}
			}
			//a reference control is given, so we position the control relative to referenceControl
			else
			{
				switch (horizontalContraint)
				{
					case RelativePanelHorizontalContraint.CenterWith:
						SetAlignHorizontalCenterWith((UIElement) control, referenceControl);
						break;

					case RelativePanelHorizontalContraint.LeftOf:
						SetLeftOf((UIElement) control, referenceControl);
						break;

					case RelativePanelHorizontalContraint.LeftWith:
						SetAlignLeftWith((UIElement) control, referenceControl);
						break;

					case RelativePanelHorizontalContraint.RightOf:
						SetRightOf((UIElement) control, referenceControl);
						break;

					case RelativePanelHorizontalContraint.RightWith:
						SetAlignRightWith((UIElement) control, referenceControl);
						break;
				}

				switch (verticalContraint)
				{
					case RelativePanelVerticalContraint.AboveOf:
						SetAbove((UIElement) control, referenceControl);
						break;

					case RelativePanelVerticalContraint.BelowOf:
						SetBelow((UIElement) control, referenceControl);
						break;

					case RelativePanelVerticalContraint.BottomWith:
						SetAlignBottomWith((UIElement) control, referenceControl);
						break;

					case RelativePanelVerticalContraint.CenterWith:
						SetAlignVerticalCenterWith((UIElement) control, referenceControl);
						break;

					case RelativePanelVerticalContraint.TopWith:
						SetAlignTopWith((UIElement) control, referenceControl);
						break;
				}
			}

			//finally add to children
			base.Children.Add((UIElement) control);
		}

		void IDisposable.Dispose()
		{
		}

		public class VisualStateUwp : System.Windows.VisualState, System.ComponentModel.ISupportInitialize
		{
			[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
			public class SetterBaseCollection : ObservableCollection<System.Windows.Setter> { }
			private SetterBaseCollection _setters;
			private ObservableCollection<StateTriggerBase> _triggers;

			public VisualStateUwp()
			{
				_setters = new SetterBaseCollection();
				_triggers = new ObservableCollection<StateTriggerBase>();
				_triggers.CollectionChanged += triggers_CollectionChanged;
				_setters.CollectionChanged += _setters_CollectionChanged;
			}

			private void _setters_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
			{
				SetActive(_triggers.Where(t => t.IsTriggerActive).Any());
			}

			private void triggers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
			{
				if (e.NewItems != null)
				{
					foreach (var item in e.NewItems.OfType<StateTriggerBase>())
					{
						item.Owner = this;
					}
				}
				if (e.OldItems != null)
				{
					foreach (var item in e.OldItems.OfType<StateTriggerBase>())
					{
						if (item.Owner == this)
							item.Owner = null;
					}
				}
				SetActive(_triggers.Where(t => t.IsTriggerActive).Any());
			}

			Action afterInit;
			internal void SetActive(bool active)
			{
				if (_isInitializing)
				{
					afterInit = () => SetActive(active);
					return;
				}
				if (Storyboard != null)
				{
					if (active)
						Storyboard.Begin();
					else
						Storyboard.Stop();
				}

				//var storyboard = new System.Windows.Media.Animation.Storyboard();
				foreach (var setter in _setters.OfType<System.Windows.Setter>())
				{
					System.Windows.DependencyProperty property = setter.Property;
					object value = setter.Value; //Why doesn't this  return the actual value???
					string targetName = setter.TargetName;

					//var s = new System.Windows.Media.Animation.DoubleAnimation() { };
					//System.Windows.Media.Animation.Storyboard.SetTargetName(s, setter.TargetName);
					//System.Windows.Media.Animation.Storyboard.SetTargetProperty(s, new System.Windows.PropertyPath(string.Format("({0}.{1})", setter.Property.OwnerType.Name, setter.Property.Name )));
					//s.To = (double)setter.Value;
					//storyboard.Children.Add(s);

					//This isn't really working... need a better way
					//if (System.Windows.Application.Current.MainWindow != null)
					//{
					//	if (System.Windows.Application.Current.MainWindow.IsLoaded)
					//	{
					//		var target = System.Windows.Application.Current.MainWindow.FindName(targetName) as System.Windows.DependencyObject;
					//		if (target != null)
					//			target.SetValue(property, value);
					//	}
					//	else
					//		System.Windows.Application.Current.MainWindow.Loaded += (s, e) =>
					//		{
					//			var target = System.Windows.Application.Current.MainWindow.FindName(targetName) as System.Windows.DependencyObject;
					//			if (target != null)
					//				target.SetValue(property, value);
					//		};
					//}
				}
				//storyboard.Begin()
			}
			private bool _isInitializing;

			void ISupportInitialize.BeginInit()
			{
				_isInitializing = true;
			}

			void ISupportInitialize.EndInit()
			{
				_isInitializing = false;
				afterInit?.Invoke();
			}

			/// <summary>
			/// Gets a collection of Setter objects
			/// </summary>
			/// <returns>A collection of Setter objects. The default is an empty collection.</returns>
			public SetterBaseCollection Setters { get { return _setters; } }

			/// <summary>
			/// Gets a collection of StateTriggerBase objects.
			/// </summary>
			/// <returns>A collection of StateTriggerBase objects. The default is an empty collection.</returns>
			public ObservableCollection<StateTriggerBase> StateTriggers { get { return _triggers; } }
		}

		public abstract class StateTriggerBase : DependencyObject
		{
			private bool _isActive;

			/// <summary>
			/// Initializes a new instance of the StateTriggerBase class.
			/// </summary>
			protected StateTriggerBase() { }

			/// <summary>
			/// Sets the value that indicates whether the state trigger is active.
			/// </summary>
			/// <param name="IsActive">true if the system should apply the trigger; otherwise, false.</param>
			protected void SetActive(bool IsActive)
			{
				_isActive = IsActive;
				if (Owner != null && Owner.Storyboard != null)
				{
					Owner.SetActive(_isActive);
				}
			}

			internal bool IsTriggerActive { get { return _isActive; } }

			internal VisualStateUwp Owner { get; set; }

		}

		public class AdaptiveTrigger : StateTriggerBase
		{


			public double MinWindowHeight
			{
				get { return (double)GetValue(MinWindowHeightProperty); }
				set { SetValue(MinWindowHeightProperty, value); }
			}

			public static readonly DependencyProperty MinWindowHeightProperty =
				DependencyProperty.Register("MinWindowHeight", typeof(double), typeof(AdaptiveTrigger), new PropertyMetadata(0d));

			public double MinWindowWidth
			{
				get { return (double)GetValue(MinWindowWidthProperty); }
				set { SetValue(MinWindowWidthProperty, value); }
			}

			public static readonly DependencyProperty MinWindowWidthProperty =
				DependencyProperty.Register("MinWindowWidth", typeof(double), typeof(AdaptiveTrigger), new PropertyMetadata(0d));


		}

		public class StateTrigger : StateTriggerBase
		{
			/// <summary>
			/// Initializes a new instance of the StateTrigger class.
			/// </summary>
			public StateTrigger() { }

			/// <summary>
			/// Gets or sets a value that indicates whether the trigger should be applied
			/// </summary>
			/// <returns>true if the system should apply the trigger; otherwise, false.</returns>
			public bool IsActive
			{
				get { return (bool)GetValue(IsActiveProperty); }
				set { SetValue(IsActiveProperty, value); }
			}

			/// <summary>Identifies the IsActive dependency property.</summary>
			/// <returns>The identifier for the IsActive dependency property.</returns>
			public static readonly DependencyProperty IsActiveProperty =
				DependencyProperty.Register("IsActive", typeof(bool), typeof(StateTrigger), new PropertyMetadata(false, OnIsActivePropertyChanged));

			private static void OnIsActivePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
			{
				((StateTrigger)d).SetActive((bool)e.NewValue);
			}
		}
	}
}