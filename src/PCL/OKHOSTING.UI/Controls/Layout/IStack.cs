using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Controls.Layout
{
	/// <summary>
	/// It represents a container where we can be stacked controls.								
	/// <para xml:lang="es">
	/// Representa un contenedor donde podemos ir apilando controles.
	/// </para>
	/// </summary>
	public interface IStack: IControl
	{
		IList<IControl> Children { get; }
	}
}