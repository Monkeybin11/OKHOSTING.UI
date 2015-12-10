using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Net4.WinForms.Controls;
using OKHOSTING.UI.Net4.WinForms.Controls;

namespace OKHOSTING.UI.Net4.WinForms
{
	public partial class Page : System.Windows.Forms.Form, IPage
	{
		public Page()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Controller.CurrentPage = this;
			Controller.CurrentController.Start();
		}

		public IControl Content
		{
			get
			{
				if (base.Controls.Count == 0)
				{
					return null;
				}

				return (IControl)Controls[0];
			}

			set
			{
				Controls.Clear();

				if (value != null)
				{
					Controls.Add((System.Windows.Forms.Control)value);
				}
			}
		}

		public string Title
		{
			get
			{
				return base.Text;
			}

			set
			{
				base.Text = value;
			}
		}

		double IPage.Width
		{
			get
			{
				return base.Width;
			}
		}

		double IPage.Height
		{
			get
			{
				return base.Height;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			//make responsive
			Controller.CurrentController.Resize();

			base.OnResize(e);
		}
	}
}
