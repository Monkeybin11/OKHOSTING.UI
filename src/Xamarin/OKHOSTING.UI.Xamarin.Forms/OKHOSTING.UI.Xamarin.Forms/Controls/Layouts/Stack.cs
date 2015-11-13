﻿using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layouts
{
	public class Stack : global::Xamarin.Forms.StackLayout, IStack
	{
		public Stack()
		{
			_Children = new ControlList(base.Children);
		}

		public string Name
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public IPage Page
        {
            get
            {
                return (IPage) App.Current.MainPage;
            }
        }

		public bool Visible
		{
			get
			{
				return base.IsVisible;
			}
			set
			{
				base.IsVisible = value;
			}
		}

		protected readonly ControlList _Children;

		IList<IControl> IStack.Children
		{
			get
			{
				return _Children;
			}
		}

		public void Dispose()
		{
		}
	}
}