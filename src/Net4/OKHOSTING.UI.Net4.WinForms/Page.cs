using System;
using System.Windows.Forms;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms
{
	public class Page : Form, IPage
	{
		/// <summary>
		/// Raised when the page is resized
		/// </summary>
		public event EventHandler Resized;

		/// <summary>
		/// App that is running on this page
		/// </summary>
		public App App { get; set; }

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
					//((System.Windows.Forms.Control) value).Dock = System.Windows.Forms.DockStyle.Fill;
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

		double? IPage.Width
		{
			get
			{
				return Width;
			}
		}

		double? IPage.Height
		{
			get
			{
				return Height;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			Resized?.Invoke(this, null);
		}
	}
}