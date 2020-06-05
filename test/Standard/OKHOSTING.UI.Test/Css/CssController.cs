using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;

namespace OKHOSTING.UI.Test.Css
{
	public class CssController : Controller
	{
		

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia una instancia de este objeto.
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			//Create an Grid with specified columns and rows.
			IGrid grid = Core.BaitAndSwitch.Create<IGrid>();
			grid.ColumnCount = 3;
			grid.RowCount = 5;
			grid.Name = "grid";
			grid.Width = Page.Width;
			grid.Height = Page.Height;

			ILabel lblTitle;
			ILabel lblText1;
			ILabel lblText2;
			IImage imgOne;
			IImage imgTwo;
			IImage imgTree;
			IListPicker lstp;

			lblTitle = Core.BaitAndSwitch.Create<ILabel>();
			lblTitle.Text = "Lil Octopus";
			lblTitle.Name = "Title";
			lblTitle.CssClass = "marginpadding";
			grid.SetContent(0, 0, lblTitle);

			ILabel lblsubtitle = Core.BaitAndSwitch.Create<ILabel>();
			lblsubtitle.Text = "Subtitulo";
			lblsubtitle.Name = "LblSubtitle";
			grid.SetContent(0, 1, lblsubtitle);

			lblText1 = Core.BaitAndSwitch.Create<ILabel>();
			lblText1.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. \n" +
				"Mi eget mauris pharetra et ultrices neque ornare. Cursus eget nunc scelerisque viverra. Pellentesque massa placerat duis ultricies lacus. \n" +
				"Dignissim cras tincidunt lobortis feugiat vivamus at augue. Arcu risus quis varius quam quisque id diam vel quam. Morbi tempus iaculis urna id volutpat lacus laoreet. \n" +
				"Lacus suspendisse faucibus interdum posuere lorem ipsum dolor sit amet. Consectetur adipiscing elit duis tristique. Neque ornare aenean euismod elementum nisi quis. \n" +
				"Pellentesque elit ullamcorper dignissim cras tincidunt lobortis. In hendrerit gravida rutrum quisque non tellus orci ac auctor. Suscipit tellus mauris a diam maecenas sed enim ut. \n";
			lblText1.Name = "Text1";
			lblText1.CssClass = "fontandcolor";
			grid.SetContent(0, 2, lblText1);

			ITextBox TxtNombre = Core.BaitAndSwitch.Create<ITextBox>();
			TxtNombre.Value = "Nombre";
			TxtNombre.Name = "TxtNombre";
			grid.SetContent(1, 0, TxtNombre);

			imgOne = Core.BaitAndSwitch.Create<IImage>();
			imgOne.LoadFromUrl(new Uri("https://www.tekcrispy.com/wp-content/uploads/2018/05/pulpo-vida-1021x580.jpg"));
			imgOne.Name = "ImgOne";
			grid.SetContent(1, 1, imgOne);
			
			imgTwo = Core.BaitAndSwitch.Create<IImage>();
			imgTwo.LoadFromUrl(new Uri("https://lithub.com/wp-content/uploads/2019/09/octopus-1.jpg"));
			imgTwo.Name = "Imgtwo";
			grid.SetContent(1, 2, imgTwo);

			imgTree = Core.BaitAndSwitch.Create<IImage>();
			imgTree.LoadFromUrl(new Uri("https://octolab.tv/wp-content/uploads/2019/03/octopuses-are-alien-creatures-2-750x500.jpg"));
			imgTree.Name = "ImgTree";
			grid.SetContent(2, 0, imgTree);

			lblText2 = Core.BaitAndSwitch.Create<ILabel>();
			lblText2.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. \n" +
				"Mi eget mauris pharetra et ultrices neque ornare. Cursus eget nunc scelerisque viverra. Pellentesque massa placerat duis ultricies lacus.";
			lblText2.Name = "Text2";
			lblText2.CssClass = "fontandcolor marginpadding";
			grid.SetContent(2, 1, lblText2);

			lstp = Core.BaitAndSwitch.Create<IListPicker>();
			lstp.Items = new string[] { "Arial", "Verdana", "Times new roman", "Helvetica" };
			//lstp.BackgroundColor = ConsoleColor.Red;
			lstp.Name = "LPTest";
			grid.SetContent(2, 2, lstp);

			IButton btnClose = Core.BaitAndSwitch.Create<IButton>();
			btnClose.Text = "Close";
			btnClose.Name = "btnClose";
			btnClose.Click += btnClose_Click;
			grid.SetContent(3, 0, btnClose);

			ITimeOfDayPicker CTime = Core.BaitAndSwitch.Create<ITimeOfDayPicker>();
			CTime.Name = "Calendar";
			grid.SetContent(3, 1, CTime);

			ITextArea txtArea = Core.BaitAndSwitch.Create<ITextArea>();
			txtArea.Value = "Apellido";
			txtArea.Name = "txtApellido";
			grid.SetContent(3, 2, txtArea);

			ILabel LblA = Core.BaitAndSwitch.Create<ILabel>();
			LblA.Name = "A";
			LblA.Text = "lblA";
			grid.SetContent(4, 0, LblA);

			ILabelButton LblB = Core.BaitAndSwitch.Create<ILabelButton>();
			LblB.Text = "B";
			LblB.Name = "lblB";
			grid.SetContent(4, 1, LblB);

			ITextBox txtA = Core.BaitAndSwitch.Create<ITextBox>();
			txtA.Name = "txtA";
			txtA.Value = "txtA";
			grid.SetContent(4, 2, txtA);

			Page.Title = "CSS is now multiplatform";
			Page.Content = grid;

			CSS.Style style = new CSS.Style();
			style.Parse(
			@"

			#grid
			{ 
				display: grid;
				grid-template-areas: 
				""ImgTwo . LblSubtitle""
				""Text1 . ImgTree""
				""Text2 LPTest Nombre""
				""btnClose txtApellido lblA""
				""footer lblB txtA"";
				grid-template-rows: 80px 500px 10px 100px 250px;
				grid-template-columns: 20px 100px 30px;
				/* grid-template: 80px 500px 10px 100px 250px/20px 100px 15px; */
				grid-row-gap: 10px;
				grid-column-gap: 10px;
			}   
			
			/* Stack the layout on small devices/viewports. */
			@media all and (max-width: 675px) 
			{
				#pageHeader 
				{ 
					/* grid-template-areas: 
					""header""
					""article""
					""ads""
					""nav""
					""footer""; */
					/* grid-template-rows: 80px 1fr 70px 1fr 70px; */
					/* grid-template-columns: 1fr; */
				}

				div2
				{ 
					/* grid-template-areas: 
					""header""
					""article""
					""ads""
					""nav""
					""footer""; */
					/* grid-template-rows: 80px 1fr 70px 1fr 70px; */
					/* grid-template-columns: 1fr; */
				}
			}

			header, footer, article, nav, div 
			{
				padding: 1.2em;
				background: gold;
			}
			
			ListPicker 
			{
				color: white;
				background: green;
				height: 20px;
				width: 20px;
			}

			#title 
			{
				font-size: 20px; 
				border: 2px solid blue;
				color: red;
				text-align: center;
				vertical-align: bottom;
			 }
		   
			#text1 
			{
				font-size: 16px;
				border: 1px solid black;
				color: yellow;
				text-align: right;
			}
			
			#text2
			{
				font-size: 14px;
				border: 2px solid #336699;
				color: orange;
				background-color: #AABBCC;
				text-align: justify;
			}

			.fontandcolor
			{
				font-family: Arial;
				color: purple;
			}

			.marginpadding
			{
				margin: 15px;
				padding: 30px;
			}

			image, imageButton
			{
				width: 100px;
				height: 100px;
			}
			
			#btnClose
			{
				text-align: center;
				height: 50px;
				font-family: Verdana;
			}");

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