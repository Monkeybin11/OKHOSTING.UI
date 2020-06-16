using OKHOSTING.UI.Controls;
using System;
using System.Drawing;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	/// <summary>
	/// A single line textbox
	/// <para xml:lang="es">
	/// Un cuadro de texto de una sola linea.
	/// </para>
	/// </summary>
	public class Slider : Control<global::Xamarin.Forms.Slider>, ISlider
	{
		public double Minimum { get => Content.Minimum; set => Content.Minimum = value; }
		public double Maximum { get => Content.Maximum; set => Content.Maximum = value; }
		public double Value { get => Content.Value; set => Content.Value = value; }

		/// <summary>
		/// Initializes a new instance of the TextBox class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clase TextBox.
		/// </para>
		/// </summary>
		public Slider()
		{
			Content.ValueChanged += Slider_ValueChanged;
		}

		private void Slider_ValueChanged(object sender, global::Xamarin.Forms.ValueChangedEventArgs e)
		{
			ValueChanged?.Invoke(sender, e.NewValue);
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">
		/// Ocurre cuando el valor del textbox es cambiado.
		/// </para>
		/// </summary>
		public event EventHandler<double> ValueChanged;
	}
}