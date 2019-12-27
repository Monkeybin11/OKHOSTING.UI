using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms
{
	public class Page : System.Windows.Forms.Form, IPage
	{
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

		public event EventHandler Resized;

		protected override void OnResize(EventArgs e)
		{
			Resized?.Invoke(this, null);
		}
	}
}