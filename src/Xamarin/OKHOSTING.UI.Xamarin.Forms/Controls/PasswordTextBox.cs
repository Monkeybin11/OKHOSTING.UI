using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// Password text box.
	/// <para xml:lang="es">
	/// Es un cuadro de texto que visiblemente enmascara la entrada del usuario.
	/// </para>
	/// </summary>
	public class PasswordTextBox : Control<global::Xamarin.Forms.Entry>, IPasswordTextBox
	{
		/// <summary>
		/// Initializes a new instance of the PasswordTextBox class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase PasswordTextBox. 
		/// </para>
		/// </summary>
		public PasswordTextBox()
		{
			Content.IsPassword = true;
			Content.TextChanged += PasswordTextBox_TextChanged;
		}

		#region IInputControl

		/// <summary>
		/// Passwords the text box text changed.
		/// <para xml:lang="es">
		/// Cambia el texto del textbox
		/// </para>
		/// </summary>
		/// <returns>The text box text changed.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void PasswordTextBox_TextChanged(object sender, global::Xamarin.Forms.TextChangedEventArgs e)
		{
			ValueChanged?.Invoke(this, Content.Text);
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">
		/// Ocurre cuando el valor del textbox es cambiado.
		/// </para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// Gets or sets the user Input value.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor de netrada del usuario.
		/// </para>
		/// </summary>
		string IInputControl<string>.Value
		{
			get
			{
				return Content.Text;
			}
			set
			{
				Content.Text = value;
			}
		}

		#endregion
	}
}