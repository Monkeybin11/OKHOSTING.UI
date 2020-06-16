using System;
using System.Drawing;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class UserControl : Control<global::Xamarin.Forms.ContentView>, IUserControl
	{
		public UserControl()
		{
			Content.SizeChanged += UserControl_SizeChanged;
		}

		private void UserControl_SizeChanged(object sender, EventArgs e)
		{
			Resized?.Invoke(this, e);
		}

		public event EventHandler Resized;

		#region IPage

		/// <summary>
		/// App that is running on this page
		/// </summary>
		public App App { get; set; }

		/// <summary>
		/// Title for this page
		/// <para xml:lang="es">
		/// El titulo para esta pagina.
		/// </para>
		/// </summary>
		public string Title
		{
			get;
			set;
		}

		/// <summary>
		/// Each Page only contains one main view, which can optionally be a container and contain more views
		/// <para xml:lang="es">
		/// Cada ventana solo contiene una vista principal, que puede ser opcionalmente un contenedor y contener mas vistas.
		/// </para>
		/// </summary>
		IControl IPage.Content
		{
			get
			{
				return (IControl) Content.Content;
			}
			set
			{
				Content.Content = (global::Xamarin.Forms.View) value;
			}
		}

		/// <summary>
		/// Gets or sets the width of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece el ancho del control.
		/// </para>
		/// </summary>
		double? IPage.Width
		{
			get
			{
				return base.WidthRequest;
			}
		}

		/// <summary>
		/// Gets or sets the height of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece la altura del control.
		/// </para>
		/// </summary>
		double? IPage.Height
		{
			get
			{
				return base.HeightRequest;
			}
		}

		public void InvokeOnMainThread(Action action)
		{
			global::Xamarin.Forms.Device.BeginInvokeOnMainThread(action);
		}

		#endregion
	}
}