using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OKHOSTING.UI.Test
{
    class CssController : Controller
    {

		ILabel lblTitulo;
		ILabel lblTexto;
		ILabelButton lblEnlace;
		IImage imgOne;
		IImage imgTwo;
		IImage imgTree;


		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia una instancia de este objeto.
		/// </para>
		/// </summary>
		/// 

		protected override void OnStart()
		{


            //Create an Grid with specified columns and rows.
            IGrid grid = Core.BaitAndSwitch.Create<IGrid>();
            grid.ColumnCount = 3;
            grid.RowCount = 5;

            lblTitulo = Core.BaitAndSwitch.Create<ILabel>();
            lblTitulo.Text = " Lil Octopus";
			lblTitulo.CssClass = "container";
			lblTitulo.Name = "titulo";
			grid.SetContent(0, 1, lblTitulo);

            lblTexto = Core.BaitAndSwitch.Create<ILabel>();
            lblTexto.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. \n" +
                "Mi eget mauris pharetra et ultrices neque ornare. Cursus eget nunc scelerisque viverra. Pellentesque massa placerat duis ultricies lacus. \n" +
    "Dignissim cras tincidunt lobortis feugiat vivamus at augue. Arcu risus quis varius quam quisque id diam vel quam. Morbi tempus iaculis urna id volutpat lacus laoreet. \n" +
 "Lacus suspendisse faucibus interdum posuere lorem ipsum dolor sit amet. Consectetur adipiscing elit duis tristique. Neque ornare aenean euismod elementum nisi quis. \n" +
 "Pellentesque elit ullamcorper dignissim cras tincidunt lobortis. In hendrerit gravida rutrum quisque non tellus orci ac auctor. Suscipit tellus mauris a diam maecenas sed enim ut. \n";
            lblTexto.Name = "parrafo";
            lblTexto.CssClass = "container";
            grid.SetContent(1, 1, lblTexto);

            imgOne = Core.BaitAndSwitch.Create<IImage>();
            imgOne.LoadFromUrl(new Uri("https://www.tekcrispy.com/wp-content/uploads/2018/05/pulpo-vida-1021x580.jpg"));
            imgOne.Height = 100;
            imgOne.Width = 100;
			imgOne.CssClass = "container";
            grid.SetContent(2, 0, imgOne);

			imgTwo = Core.BaitAndSwitch.Create<IImage>();
			imgTwo.LoadFromUrl(new Uri("https://lithub.com/wp-content/uploads/2019/09/octopus-1.jpg"));
			imgOne.Height = 100;
			imgOne.Width = 100;
			imgTwo.CssClass = "container";
			grid.SetContent(2, 1, imgTwo);

			imgTree = Core.BaitAndSwitch.Create<IImage>();
			imgTree.LoadFromUrl(new Uri("https://octolab.tv/wp-content/uploads/2019/03/octopuses-are-alien-creatures-2-750x500.jpg"));
			imgOne.Height = 100;
			imgOne.Width = 100;
			imgTree.CssClass = "container";
			grid.SetContent(2, 2, imgTree);

			//lblEnlace = Core.BaitAndSwitch.Create<ILabelButton>();
			//lblEnlace.Text = "http://www.pulpopedia.com/";
			//lblEnlace.Click += http://www.pulpopedia.com/;

			IButton btnClose = Core.BaitAndSwitch.Create<IButton>();
            btnClose.Text = "Close";
            btnClose.Name = "btnClose";
            btnClose.CssClass = "container";
            btnClose.Click += btnClose_Click;
			grid.SetContent(3, 1, btnClose);

			Page.Title = "Choose one control to test";
			Page.Content = grid;


			CSS.Style style = new CSS.Style();
			style.Parse(
			@"
             #titulo {
             font-size: 20px; 
			 border:3px inside;
			 color: red;
             }
           
             #parrafo {
             font-size: 16px;
             border: 3px  dashed black ;
			 color: red;
             }


			.alert
			{
				font-weight: bold;
				font-size: 20px;
				color: red;
			}

			.container
			{
				text-align: justify;
				line-height: 100%;
				font-family: Arial;
                color: purple;
				background: #CFF6FF;
            }

			#lblOne
			{
				margin: 20px;
				color: blue;
			}

			#btnClose
			{
				text-align: center;
				height: 30px;
			}
			");

			style.Apply(Page);
		}

		/// <summary>
		/// It is the button click event cmd Color, what it does is change the background color of the stack.
		/// <para xml:lang="es">
		/// Es el evento clic del boton cmdColor, lo que hace es cambiar el color de fondo del stack.
		/// </para>
		/// </summary>
		/// <returns>The set color click.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		/// 

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}

	}
}
