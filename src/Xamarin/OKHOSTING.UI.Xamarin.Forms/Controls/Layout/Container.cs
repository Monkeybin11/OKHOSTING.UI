using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using View = global::Xamarin.Forms.View;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layout
{
	/// <summary>
	/// Base control for all containers, allows for a background image
	/// </summary>
	public abstract class Container<T> : Control<T>, IContainer where T : View
	{
		private IImage _BackgroundImage;

		public Container()
		{
		}

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
					
					SetRowSpan((global::Xamarin.Forms.Image) value, RowDefinitions.Count);
					SetColumnSpan((global::Xamarin.Forms.Image) value, ColumnDefinitions.Count);

					base.Children.Insert(0, (View) value);
				}
			}
		}

		public new abstract ICollection<IControl> Children
		{
			get;
		}
	}
}