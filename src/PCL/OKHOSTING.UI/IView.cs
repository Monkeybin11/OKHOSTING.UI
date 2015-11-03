using System;
using System.Collections.Generic;

namespace OKHOSTING.UI
{
	public interface IView
	{
		bool Visible
		{
			get; set;
		}

		/// <summary>
		/// Page that contains this view (directly or as a through another container view)
		/// </summary>
		IPage Page
		{
			get; set;
		}

        //public abstract void Update();


		event EventHandler Click;
		event EventHandler DoubleClick;
		event EventHandler Changed;
	}
}