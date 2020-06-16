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
	public class ProgressBar : Control<global::Xamarin.Forms.ProgressBar>, IProgressBar
	{
		public double Value
		{
			get
			{
				return Content.Progress;
			}
			set
			{
				Content.Progress = value;
			}
		}
	}
}