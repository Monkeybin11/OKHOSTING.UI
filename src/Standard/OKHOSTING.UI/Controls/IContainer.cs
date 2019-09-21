using System.Collections.Generic;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A calendar for date selection..
	/// <para xml:lang="es">Un calendario para seleccion de fechas.</para>
	/// </summary>
	public interface IContainer : IControl
	{
		ICollection<IControl> Children { get; }
	}
}