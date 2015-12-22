using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms
{
	public class Page : System.Windows.Forms.Form, IPage
	{
		public Page()
		{
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
					((System.Windows.Forms.Control) value).Dock = System.Windows.Forms.DockStyle.Fill;
					Controls.Add((System.Windows.Forms.Control) value);
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
			Platform.Current.Controller.Resize();
			base.OnResize(e);
		}
	}
}
