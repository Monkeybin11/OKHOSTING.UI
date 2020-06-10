using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKHOSTING.UI.Net4.WinForms.Test
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			this.Controls.Add(new TranspCtrl());
		}
	}
}
