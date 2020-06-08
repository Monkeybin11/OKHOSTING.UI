using System.Collections.Generic;

namespace OKHOSTING.UI.Controls.Layout
{
	/// <summary>
	/// A calendar for date selection..
	/// <para xml:lang="es">Un calendario para seleccion de fechas.</para>
	/// </summary>
	public interface IContainer : IControl
	{
		/// <summary>
		/// /List of child controls contained on this container
		/// </summary>
		ICollection<IControl> Children { get; }

		/// <summary>
		/// Optional image to be placed as the background of this container
		/// </summary>
		IImage BackgroundImage { get; set; }
	}
}