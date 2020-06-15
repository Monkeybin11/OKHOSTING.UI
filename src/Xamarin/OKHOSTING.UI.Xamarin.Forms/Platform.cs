using System;
using System.Drawing;

namespace OKHOSTING.UI.Xamarin.Forms
{
	/// <summary>
	/// It is the platform on which the application is displayed.
	/// <para xml:lang="es">
	/// Es la plataforma en la que se mostara la aplicacion.  
	/// </para>
	/// </summary>
	public static class Platform
	{
		//virtual
		/// <summary>
		/// Parse HOSTING.UI.Thickness to a Xamarin.Forms.Thickness.
		/// <para xml:lang="es">
		/// Parsea un Xamarin.Forms.Thickness a un OKHOSTING.UI.Thickness 
		/// </para>
		/// </summary>
		/// <param name="thickness">Thickness.</param>
		public static Thickness Parse(global::Xamarin.Forms.Thickness thickness)
		{
			return new Thickness(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);
		}

		/// <summary>
		/// Parse Xamarin.Forms.Thickness a OKHOSTING.UI.Thickness.
		/// <para xml:lang="es">
		/// Parsea un OKHOSTING.UI.Thickness a un Xamarin.Forms.Thickness.
		/// </para>
		/// </summary>
		/// <param name="thickness">Thickness.</param>
		public static global::Xamarin.Forms.Thickness Parse(Thickness thickness)
		{
			return new global::Xamarin.Forms.Thickness(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);
		}

		/// <summary>
		/// Parse a Xamarin.Forms.Color to a OKHOSTING.UI.Thickness.
		/// <para xml:lang="es">
		/// Parsea un Xamarin.Forms.Color a un OKHOSTING.UI.Thickness.
		/// </para>
		/// </summary>
		/// <param name="color">Color.</param>
		public static Color Parse(global::Xamarin.Forms.Color color)
		{
			return Color.FromArgb((int) color.A, (int) color.R, (int) color.G, (int) color.B);
		}

		/// <summary>
		/// Parse a OKHOSTING.UI.Thickness to a Xamarin.Forms.Color.
		/// <para xml:lang="es">
		/// Parsea un OKHOSTING.UI.Thickness a un Xamarin.Forms.Color.
		/// </para>
		/// </summary>
		/// <returns>The color
		/// <para xml:lang="es">El color.</para>
		/// </returns>
		/// <param name="color">Color.</param>
		public static global::Xamarin.Forms.Color Parse(Color color)
		{
			return global::Xamarin.Forms.Color.FromRgba(color.R, color.G, color.B, color.A);
		}

		/// <summary>
		/// Parse a Xamarin.Forms.LayoutAlignment to a OKHOSTING.UI.HorizontalAlignment.
		/// <para xml:lang="es">
		/// Parsea un Xamarin.Forms.LayoutAlignment a un OKHOSTING.UI.HorizontalAlignment.
		/// </para>
		/// </summary>
		/// <returns>
		/// The horizontal alignment.
		/// <para xml:lang="es">
		/// La alineación horizontal.
		/// </para>
		/// </returns>
		/// <param name="horizontalAlignment">HorizontalAlignment.</param>
		public static HorizontalAlignment Parse(global::Xamarin.Forms.LayoutAlignment horizontalAlignment)
		{
			switch (horizontalAlignment)
			{
				case global::Xamarin.Forms.LayoutAlignment.Start:
					return HorizontalAlignment.Left;

				case global::Xamarin.Forms.LayoutAlignment.Center:
					return HorizontalAlignment.Center;

				case global::Xamarin.Forms.LayoutAlignment.End:
					return HorizontalAlignment.Right;

				case global::Xamarin.Forms.LayoutAlignment.Fill:
					return HorizontalAlignment.Fill;
			}

			return HorizontalAlignment.Left;
		}

		/// <summary>
		/// Parse a OKHOSTING.UI.HorizontalAlignment to a Xamarin.Forms.LayoutAlignment.
		/// <para xml:lang="es">
		/// Parsea un OKHOSTING.UI.HorizontalAlignment a un Xamarin.Forms.LayoutAlignment.
		/// </para>
		/// </summary>
		/// <param name="horizontalAlignment">HorizontalAlignment.</param>
		public static global::Xamarin.Forms.LayoutAlignment Parse(HorizontalAlignment horizontalAlignment)
		{
			switch (horizontalAlignment)
			{
				case HorizontalAlignment.Left:
					return global::Xamarin.Forms.LayoutAlignment.Start;

				case HorizontalAlignment.Center:
					return global::Xamarin.Forms.LayoutAlignment.Center;

				case HorizontalAlignment.Right:
					return global::Xamarin.Forms.LayoutAlignment.End;

				case HorizontalAlignment.Fill:
					return global::Xamarin.Forms.LayoutAlignment.Fill;
			}

			throw new ArgumentOutOfRangeException("horizontalAlignment");
		}

		/// <summary>
		/// Parse a amarin.Forms.LayoutAlignment to a OKHOSTING.UI.HorizontalAlignment.
		/// <para xml:lang="es">
		/// Parsea un Xamarin.Forms.LayoutAlignment a un OKHOSTING.UI.HorizontalAlignment.
		/// </para>
		/// </summary>
		/// <returns>The vertical alignment.
		/// <para xml:lang="es">
		/// La alineación vertical.
		/// </para>
		/// </returns>
		/// <param name="verticalAlignment">Vertical alignment.</param>
		public static VerticalAlignment ParseVerticalAlignment(global::Xamarin.Forms.LayoutAlignment verticalAlignment)
		{
			switch (verticalAlignment)
			{
				case global::Xamarin.Forms.LayoutAlignment.Start:
					return VerticalAlignment.Top;

				case global::Xamarin.Forms.LayoutAlignment.Center:
					return VerticalAlignment.Center;

				case global::Xamarin.Forms.LayoutAlignment.End:
					return VerticalAlignment.Bottom;

				case global::Xamarin.Forms.LayoutAlignment.Fill:
					return VerticalAlignment.Fill;
			}

			return VerticalAlignment.Top;
		}

		/// <summary>
		/// Parse a OKHOSTING.UI.VerticalAlignment to a Xamarin.Forms.LayoutAlignment.
		/// <para xml:lang="es">
		/// Parsea un OKHOSTING.UI.VerticalAlignment a un Xamarin.Forms.LayoutAlignment.
		/// </para>
		/// </summary>
		/// <returns>The vertical alignment.
		/// <para xml:lang="es">La alineacion vertical.</para>
		/// </returns>
		/// <param name="verticalAlignment">VerticalAlignment.</param>
		public static global::Xamarin.Forms.LayoutAlignment Parse(VerticalAlignment verticalAlignment)
		{
			switch (verticalAlignment)
			{
				case VerticalAlignment.Top:
					return global::Xamarin.Forms.LayoutAlignment.Start;

				case VerticalAlignment.Center:
					return global::Xamarin.Forms.LayoutAlignment.Center;

				case VerticalAlignment.Bottom:
					return global::Xamarin.Forms.LayoutAlignment.End;

				case VerticalAlignment.Fill:
					return global::Xamarin.Forms.LayoutAlignment.Fill;
			}

			return global::Xamarin.Forms.LayoutAlignment.Start;
		}

		/// <summary>
		/// Parse a Xamarin.Forms.TextAlignment to a OKHOSTING.UI.VerticalAlignment.
		/// <para xml:lang="es">
		/// Parsea un Xamarin.Forms.TextAlignment a un OKHOSTING.UI.VerticalAlignment.
		/// </para>
		/// </summary>
		/// <returns>The vertical alignment.
		/// <para xml:lang="es">La alineación vertical.</para>
		/// </returns>
		/// <param name="textAlignment">TextAlignment.</param>
		public static VerticalAlignment ParseVerticalTextAlignment(global::Xamarin.Forms.TextAlignment textAlignment)
		{
			switch (textAlignment)
			{
				case global::Xamarin.Forms.TextAlignment.Start:
					return VerticalAlignment.Top;

				case global::Xamarin.Forms.TextAlignment.Center:
					return VerticalAlignment.Center;

				case global::Xamarin.Forms.TextAlignment.End:
					return VerticalAlignment.Bottom;
			}

			return VerticalAlignment.Top;
		}

		/// <summary>
		/// Parse a Xamarin.Forms.TextAlignment to a OKHOSTING.UI.HorizontalAlignment.
		/// <para xml:lang="es">
		/// Parsea un Xamarin.Forms.TextAlignment a un OKHOSTING.UI.HorizontalAlignment.
		/// </summary>
		/// <returns>The horizontal alignment
		/// <para xml:lang="es">
		/// La alineacion horizontal
		/// </para>
		/// </returns>
		/// <param name="textAlignment">Text alignment.</param>
		public static HorizontalAlignment Parse(global::Xamarin.Forms.TextAlignment textAlignment)
		{
			switch (textAlignment)
			{
				case global::Xamarin.Forms.TextAlignment.Start:
					return HorizontalAlignment.Left;

				case global::Xamarin.Forms.TextAlignment.Center:
					return HorizontalAlignment.Center;

				case global::Xamarin.Forms.TextAlignment.End:
					return HorizontalAlignment.Right;
			}

			return HorizontalAlignment.Left;
		}

		/// <summary>
		/// Parse a OKHOSTING.UI.HorizontalAlignment to a Xamarin.Forms.TextAlignment.
		/// <para xml:lang="es">
		/// Parsea un OKHOSTING.UI.HorizontalAlignment a un Xamarin.Forms.TextAlignment.
		/// </summary>
		/// <returns>The text alignment.
		/// <para xml:lang="es">La alineacion del texto.</para>
		/// </returns>
		/// <param name="alignment">alignment.</param>
		public static global::Xamarin.Forms.TextAlignment ParseTextAlignment(HorizontalAlignment alignment)
		{
			switch (alignment)
			{
				case HorizontalAlignment.Left:
					return global::Xamarin.Forms.TextAlignment.Start;

				case HorizontalAlignment.Center:
					return global::Xamarin.Forms.TextAlignment.Center;

				case HorizontalAlignment.Right:
					return global::Xamarin.Forms.TextAlignment.End;

				case HorizontalAlignment.Fill:
					return global::Xamarin.Forms.TextAlignment.Start;
			}

			return global::Xamarin.Forms.TextAlignment.Start;
		}

		/// <summary>
		/// Parse a OKHOSTING.UI.VerticalAlignment to a Xamarin.Forms.TextAlignment.
		/// <para xml:lang="es">
		/// Parsea un OKHOSTING.UI.VerticalAlignment a un Xamarin.Forms.TextAlignment.
		/// </summary>
		/// <returns>The text alignment.</returns>
		/// <param name="alignment">Alignment.</param>
		public static global::Xamarin.Forms.TextAlignment ParseTextAlignment(VerticalAlignment alignment)
		{
			switch (alignment)
			{
				case VerticalAlignment.Center:
					return global::Xamarin.Forms.TextAlignment.Center;

				case VerticalAlignment.Bottom:
					return global::Xamarin.Forms.TextAlignment.End;

				case VerticalAlignment.Fill:
					return global::Xamarin.Forms.TextAlignment.Center;

				case VerticalAlignment.Top:
					return global::Xamarin.Forms.TextAlignment.Start;
			}

			return global::Xamarin.Forms.TextAlignment.Start;
		}

		/// <summary>
		///	 Gets the screen coordinates from top left corner.
		/// </summary>
		/// <returns>The screen coordinates.</returns>
		public static (double X, double Y) GetScreenCoordinates(this global::Xamarin.Forms.VisualElement view)
		{
			// A view's default X- and Y-coordinates are LOCAL with respect to the boundaries of its parent,
			// and NOT with respect to the screen. This method calculates the SCREEN coordinates of a view.
			// The coordinates returned refer to the top left corner of the view.

			// Initialize with the view's "local" coordinates with respect to its parent
			var screenCoordinateX = view.X;
			var screenCoordinateY = view.Y;

			// Get the view's parent (if it has one...)
			if (view.Parent.GetType() != typeof(App))
			{
				var parent = (global::Xamarin.Forms.VisualElement) view.Parent;

				// Loop through all parents
				while (parent != null)
				{
					// Add in the coordinates of the parent with respect to ITS parent
					screenCoordinateX += parent.X;
					screenCoordinateY += parent.Y;

					// If the parent of this parent isn't the app itself, get the parent's parent.
					if (parent.Parent.GetType() == typeof(App))
						parent = null;
					else
						parent = (global::Xamarin.Forms.VisualElement) parent.Parent;
				}
			}

			// Return the final coordinates...which are the global SCREEN coordinates of the view
			return (screenCoordinateX, screenCoordinateY);
		}
	}
}