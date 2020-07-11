using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZXing;

namespace OKHOSTING.UI.Net4.WPF.Test
{
	/// <summary>
	/// Lógica de interacción para Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
            string name = "este etxto me inspira";
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            var result = writer.Write(name);
            string path = System.IO.Path.Combine(Core.DefaultPaths.Base, "qr.jpg");
            var barcodeBitmap = new Bitmap(result);

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }

        }

		private void ButtonAdv_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
