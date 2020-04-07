using System;
using System.Windows.Forms;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WinForms
{
	public class Page : Form, IPage
	{
		public Page()
		{
			Container = new Panel();
			Container.Dock = DockStyle.Fill;
			Container.AutoScroll = true;
			Controls.Add(Container);
			BackColor = System.Drawing.Color.White;
		}

		/// <summary>
		/// Raised when the page is resized
		/// </summary>
		public event EventHandler Resized;

		/// <summary>
		/// App that is running on this page
		/// </summary>
		public App App { get; set; }

		private readonly new Panel Container;

		public IControl Content
		{
			get
			{
				if (Container.Controls.Count == 0)
				{
					return null;
				}

				return (IControl) Container.Controls[0];
			}
			set
			{
				Container.Controls.Clear();

				if (value != null)
				{
					//((System.Windows.Forms.Control) value).Dock = System.Windows.Forms.DockStyle.Fill;
					Container.Controls.Add((Control) value);
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
				return Width - 30;
			}
		}

		double? IPage.Height
		{
			get
			{
				return Height - 30;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			Resized?.Invoke(this, null);
		}

		public void InvokeOnMainThread(Action action)
		{
			BeginInvoke(action);
		}
	}
}