using System.ComponentModel;
using System.Drawing;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using OKHOSTING.UI.Xamarin.Forms.Controls;

[assembly: Xamarin.Forms.ExportRenderer(typeof(BorderEntry), typeof(OKHOSTING.UI.Xamarin.iOS.Renderers.BorderEntryRenderer))]
namespace OKHOSTING.UI.Xamarin.iOS.Renderers
{
	public class BorderEntryRenderer : EntryRenderer
    {
        public BorderEntry ElementV2 => Element as BorderEntry;
        public UITextFieldPadding ControlV2 => Control as UITextFieldPadding;

        protected override UITextField CreateNativeControl()
        {
            var control = new UITextFieldPadding(RectangleF.Empty)
            {
                Padding = ElementV2.Padding,
                BorderStyle = UITextBorderStyle.RoundedRect,
                ClipsToBounds = true, 
            };

            UpdateBackground(control);

            return control;
        }

        protected void UpdateBackground(UITextField control)
        {
            if (control == null) return;
            control.Layer.CornerRadius = ElementV2.CornerRadius;
            control.Layer.BorderWidth = ElementV2.BorderThickness;
            control.Layer.BorderColor = ElementV2.BorderColor.ToCGColor();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == BorderEntry.PaddingProperty.PropertyName)
            {
                UpdatePadding();
            }

            base.OnElementPropertyChanged(sender, e);
        }

        protected void UpdatePadding()
        {
            if (Control == null)
                return;

            ControlV2.Padding = ElementV2.Padding;
        }
    }

    public class UITextFieldPadding : UITextField
    {
        private global::Xamarin.Forms.Thickness _padding = new global::Xamarin.Forms.Thickness(5);

        public global::Xamarin.Forms.Thickness Padding
        {
            get => _padding;
            set
            {
                if (_padding != value)
                {
                    _padding = value;
                    //InvalidateIntrinsicContentSize();
                }
            }
        }

        public UITextFieldPadding()
        {
        }
        public UITextFieldPadding(NSCoder coder) : base(coder)
        {
        }

        public UITextFieldPadding(CGRect rect) : base(rect)
        {
        }

        public override CGRect TextRect(CGRect forBounds)
        {
            var insets = new UIEdgeInsets((float)Padding.Top, (float)Padding.Left, (float)Padding.Bottom, (float)Padding.Right);
            return insets.InsetRect(forBounds);
        }

        public override CGRect PlaceholderRect(CGRect forBounds)
        {
            var insets = new UIEdgeInsets((float)Padding.Top, (float)Padding.Left, (float)Padding.Bottom, (float)Padding.Right);
            return insets.InsetRect(forBounds);
        }

        public override CGRect EditingRect(CGRect forBounds)
        {
            var insets = new UIEdgeInsets((float)Padding.Top, (float)Padding.Left, (float)Padding.Bottom, (float)Padding.Right);
            return insets.InsetRect(forBounds);
        }
    }
}