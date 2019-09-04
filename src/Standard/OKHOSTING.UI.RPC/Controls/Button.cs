using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// It contains the events of Button.
	/// <para xml:lang="es">
	/// Contiene los eventos del Button.
	/// </para>
	/// </summary>
	public class Button: TextControl, IButton
	{
		public string Text
		{
			get
			{
				return (string) Get(nameof(Text));
			}
			set
			{
				Set(nameof(Text), value);
			}
		}

		private event EventHandler _Click;

		/// <summary>
		/// Raises after the user clicked on the button
		/// <para xml:lang="es">
		/// Se lanza despues de que el usuario ha hecho clic en el botón.
		/// </para>
		/// </summary>
		public event EventHandler Click
		{
			add
			{
				_Click += value;
			}
			remove
			{
				_Click -= value;
			}
		}

		public void OnClick(EventArgs e)
		{
			_Click?.Invoke(this, e);
		}

		public override void Init()
		{
			Init<IButton>();
		}
	}
}