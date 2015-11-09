using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms
{
	public partial class Page : Form, IPage
	{
		public Page()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Platform.Current = new Platform(this);
			Platform.Current.Controller.Start();
		}

		public IControl Content
		{
			get
			{
                if (base.Controls.Count == 0)
                {
                    return null;
                }

                return (IControl) Controls[0];
			}

			set
			{
				Controls.Clear();

				if (value != null)
				{
					Controls.Add((Control) value);
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
	}
}
