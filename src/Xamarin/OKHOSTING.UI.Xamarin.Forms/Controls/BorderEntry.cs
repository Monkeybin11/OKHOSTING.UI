namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class BorderEntry: global::Xamarin.Forms.Entry
	{
        public static global::Xamarin.Forms.BindableProperty CornerRadiusProperty =
            global::Xamarin.Forms.BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(BorderEntry), 0);

        public static global::Xamarin.Forms.BindableProperty BorderThicknessProperty =
            global::Xamarin.Forms.BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(BorderEntry), 0);

        public static global::Xamarin.Forms.BindableProperty PaddingProperty =
            global::Xamarin.Forms.BindableProperty.Create(nameof(Padding), typeof(global::Xamarin.Forms.Thickness), typeof(BorderEntry), new Thickness(5));

        public static global::Xamarin.Forms.BindableProperty BorderColorProperty =
            global::Xamarin.Forms.BindableProperty.Create(nameof(BorderColor), typeof(global::Xamarin.Forms.Color), typeof(BorderEntry), global::Xamarin.Forms.Color.Transparent);

        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public int BorderThickness
        {
            get => (int)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        public global::Xamarin.Forms.Color BorderColor
        {
            get => (global::Xamarin.Forms.Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        /// <summary>
        /// This property cannot be changed at runtime in iOS.
        /// </summary>
        public global::Xamarin.Forms.Thickness Padding
        {
            get => (global::Xamarin.Forms.Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }
    }
}