using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms.Controls.Layouts
{
	public class Grid : System.Windows.Forms.TableLayoutPanel, OKHOSTING.UI.Controls.Layouts.IGrid
	{
		public IPage Page
		{
			get
			{
				return (Page) base.FindForm();
			}
		}

		public IControl GetContent(int row, int column)
		{
			foreach (System.Windows.Forms.Control control in Controls)
			{
				if (base.GetColumn(control) == column && base.GetRow(control) == row)
				{
					return (IControl) control;
				}
			}

			return null;
		}

		public void SetContent(int row, int column, IControl content)
		{
			base.Controls.Add((System.Windows.Forms.Control) content, column, row);
		}
	}
}