using OKHOSTING.UI.Controls;
using System.Collections.Generic;

namespace OKHOSTING.UI.Remote.Controls
{
	/// <summary>
	/// A calendar for date selection..
	/// <para xml:lang="es">Un calendario para seleccion de fechas.</para>
	/// </summary>
	public  class Container : Control, IContainer
	{
		public IList<IControl> Children { get; } = new List<IControl>();

		public override void Dispose()
		{
			if (Children != null)
			{
				foreach(var c in Children)
				{
					c.Dispose();
				}
			}
		}
	}
}