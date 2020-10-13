using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System.Collections.Generic;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// A calendar for date selection..
	/// <para xml:lang="es">Un calendario para seleccion de fechas.</para>
	/// </summary>
	public class Container : Control, IContainer
	{
		public ICollection<IControl> Children
		{
			get; protected set;
		}
		public IImage BackgroundImage
		{
			get 
			{
				return (IImage) base.Get(nameof(BackgroundImage));
			}
			set 
			{
				base.Set(nameof(BackgroundImage), value);
			}
		}

		public override void Init()
		{
			base.Init();

			Children = new OKHOSTING.RPC.Bidireccional.ServerCollection<IControl>()
			{
				Server = Server,
			};
		}

		public override void Dispose()
		{
			Invoke(nameof(Dispose));

			if (Children != null)
			{
				foreach (var c in Children)
				{
					c.Dispose();
				}
			}
		}
	}
}