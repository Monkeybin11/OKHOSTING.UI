using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class MenuItem : global::Xamarin.Forms.MenuItem, IMenuItem
	{
		public event EventHandler Click;

		public MenuItem()
		{
			base.Clicked += MenuItem_Clicked;
		}

		public MenuItem(string text): this()
		{
			Text = text;
		}

		public MenuItem(string text, EventHandler onClick) : this(text)
		{
			Click += onClick;
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">
		/// Obtiene o establece un objeto de valor arbitrario que se puede usar para almacenar informacion personalizada sobre este elemento.
		/// </para>
		/// </summary>
		public object Tag { get; set; }

		public ICollection<IMenuItem> Children
		{
			get;
			protected set;
		}

		public override string ToString()
		{
			return Text ?? base.ToString();
		}

		private void MenuItem_Clicked(object sender, EventArgs e)
		{
			Click?.Invoke(sender, e);
		}
	}
}
