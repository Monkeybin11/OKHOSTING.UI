using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.Net4.WPF.Controls;
using OKHOSTING.UI.Net4.WPF.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WPF
{
	/// <summary>
	/// Interaction logic for Page.xaml
	/// </summary>
	public partial class Page : System.Windows.Window, IPage
	{
		public Page()
		{
			InitializeComponent();
			Controller.CurrentPage = this;
			Controller.CurrentController.Start();

			System.Windows.Application.Current.MainWindow.SizeChanged += MainWindow_SizeChanged;
        }

		private void MainWindow_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			//todo:resise and make responsive here??
			Controller.CurrentController.Start();
		}

		public new IControl Content
		{
			get
			{
				return (IControl) base.Content;
			}
			set
			{
				base.Content = value;
			}
		}

		public T Create<T>() where T : class, IControl
		{
			if (typeof(T) == typeof(IButton))
			{
				return new Button() as T;
			}

			if (typeof(T) == typeof(ILabel))
			{
				return new Label() as T;
			}

			if (typeof(T) == typeof(ITextBox))
			{
				return new TextBox() as T;
			}

			if (typeof(T) == typeof(IPasswordTextBox))
			{
				return new PasswordTextBox() as T;
			}

			if (typeof(T) == typeof(IGrid))
			{
				return new Grid() as T;
			}

			throw new NotSupportedException();
		}
		
		public static Color Parse(System.Windows.Media.Color color)
		{
			return new Color(color.A, color.R, color.G, color.B);
		}

		public static System.Windows.Media.Color Parse(Color color)
		{
			return System.Windows.Media.Color.FromArgb((byte) color.Alpha, (byte) color.Red, (byte) color.Green, (byte) color.Blue);
		}
	}
}
