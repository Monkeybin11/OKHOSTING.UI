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
			base.Load += Page_Load;
			InitializeComponent();
		}

		public event EventHandler Loaded;

		private void Page_Load(object sender, EventArgs e)
		{
			if (Loaded != null)
			{
				Loaded(sender, new EventArgs());
			}
		}

		public IControl Content
		{
			get
			{
				return (IControl) Controls[0];
			}

			set
			{
				Controls.Clear();
				Controls.Add((Control) value);
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
