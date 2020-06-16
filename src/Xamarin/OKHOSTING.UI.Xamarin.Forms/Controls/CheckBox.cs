using System;
using System.Drawing;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// It is a control that represents a CheckBox in a Xamarin.Forms.
	/// <para xml:lang="es">Es un control que representa un CheckBox en un Xamarin.Forms</para>
	/// </summary>
	public class CheckBox : Control<global::Xamarin.Forms.Switch>, ICheckBox
	{
		/// <summary>
		/// Initializes a new instance of the CheckBox class.
		/// <para xml:lang="es">
		/// Iniciarliza una nueva instancia de la clase CheckBox.
		/// </para>
		/// </summary>
		public CheckBox()
		{
			Content.Toggled += CheckBox_Toggled;
		}

		#region IInputControl

		/// <summary>
		/// Checks the box toggled.
		/// <para xml:lang="es">
		/// Comprueba si el checkBox esta seleccionado.
		/// </para>
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void CheckBox_Toggled(object sender, global::Xamarin.Forms.ToggledEventArgs e)
		{
			ValueChanged?.Invoke(this, ((IInputControl<bool>) this).Value);
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">
		/// Ocurre cuando el valor del checkbox es cambiado.
		/// </para>
		/// </summary>
		public event EventHandler<bool> ValueChanged;

		/// <summary>
		/// Gets or sets the user input value.
		/// <para xml:lanmg="es">
		/// Obtiene o establece el valor de entrada del usuario.
		/// </para>
		/// </summary>
		bool IInputControl<bool>.Value
		{
			get
			{
				return Content.IsToggled;
			}
			set
			{
				Content.IsToggled = value;
			}
		}

		#endregion
	}
}