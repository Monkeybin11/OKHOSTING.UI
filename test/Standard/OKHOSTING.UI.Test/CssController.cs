using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Test
{
	/// <summary>
	/// It represents the main platform where controls are housed.
	/// <para xml:lang="es">
	/// Representa la plataforma principal donde se alojan controles.
	/// </para>
	/// </summary>
	class CssController : Controller
	{
		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">.
		/// Inicia la instancia de este objeto.
		/// </para>
		/// </summary>
		/// 
		protected override void OnStart()
		{
			Page.Title = "Choose one control to test";


			CSS.Style style = new CSS.Style();
			style.Parse(
			@"
			.alert
			{
				font-weight: bold;
				font-size: 20px;
				color: red;
			}

			#label1
			{
				margin: 20px;
				color: blue;
			}
			");

			style.Apply(Page);
		}
    }
}
