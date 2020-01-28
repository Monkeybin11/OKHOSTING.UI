using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
    public class GridMakeResponsive :  Controller
    {
        /// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia una instancia de este objeto
		/// </para>
		/// </summary>
        protected override void OnStart()
        {
			ResponsiveGrid grid = new ResponsiveGrid();

			grid.Layouts[500] = Core.BaitAndSwitch.Create<IGrid>();
			grid.Layouts[900] = Core.BaitAndSwitch.Create<IGrid>();
			grid.Layouts[2000] = Core.BaitAndSwitch.Create<IGrid>();


			grid.Layouts[500].ColumnCount = 3;
			grid.Layouts[500].RowCount = 20;

			grid.Layouts[900].ColumnCount = 5;
			grid.Layouts[900].RowCount = 15;

			grid.Layouts[2000].ColumnCount =  13;
			grid.Layouts[2000].RowCount = 6;

			ILabel lblOne = Core.BaitAndSwitch.Create<ILabel>();
			lblOne.Text = "Label One";
			lblOne.FontSize = 20;
			lblOne.Width = 100;
			grid.SetContent(0, 0, lblOne);

			ITextBox txtOne = Core.BaitAndSwitch.Create<ITextBox>();
			txtOne.Placeholder = "Text One";
			txtOne.FontSize = 20;
			grid.SetContent(1, 0, txtOne);

			ILabel lblTwo = Core.BaitAndSwitch.Create<ILabel>();
			lblTwo.Text = "Label Two";
			lblTwo.FontSize = 20;
			lblTwo.Width = 100;
			grid.Layouts[500].SetContent(0, 1, lblTwo);
			grid.Layouts[900].SetContent(0, 1, lblTwo);
			grid.Layouts[2000].SetContent(0, 1, lblTwo);

			ITextBox txtTwo = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwo.Placeholder = "Text Two";
			txtTwo.FontSize = 20;
			grid.Layouts[500].SetContent(0, 2, txtTwo);
			grid.Layouts[900].SetContent(0, 2, txtTwo);
			grid.Layouts[2000].SetContent(0, 2, txtTwo);

			ILabel lblThree = Core.BaitAndSwitch.Create<ILabel>();
			lblThree.Text = "Label Three";
			lblThree.FontSize = 20;
			lblThree.Width = 100;
			grid.Layouts[500].SetContent(1, 1, lblThree);
			grid.Layouts[900].SetContent(0, 3, lblThree);
			grid.Layouts[2000].SetContent(0, 3, lblThree);

			ITextBox txtThree = Core.BaitAndSwitch.Create<ITextBox>();
			txtThree.Placeholder = "Text Three";
			txtThree.FontSize = 20;
			grid.Layouts[500].SetContent(1, 2, txtThree);
			grid.Layouts[900].SetContent(0, 4, txtThree);
			grid.Layouts[2000].SetContent(0, 4, txtThree);

			ILabel lblFour = Core.BaitAndSwitch.Create<ILabel>();
			lblFour.Text = "Label Four";
			lblFour.FontSize = 20;
			lblFour.Width = 100;
			grid.Layouts[500].SetContent(2, 1, lblFour);
			grid.Layouts[900].SetContent(1, 1, lblFour);
			grid.Layouts[2000].SetContent(0, 5, lblFour);

			ITextBox txtFour = Core.BaitAndSwitch.Create<ITextBox>();
			txtFour.Placeholder = "Text Four";
			txtFour.FontSize = 20;
			grid.Layouts[500].SetContent(2, 2, txtFour);
			grid.Layouts[900].SetContent(1, 2, txtFour);
			grid.Layouts[2000].SetContent(0, 6, txtFour);

			ILabel lblFive = Core.BaitAndSwitch.Create<ILabel>();
			lblFive.Text = "Label Five";
			lblFive.FontSize = 20;
			lblFive.Width = 100;
			grid.Layouts[500].SetContent(3, 1, lblFive);
			grid.Layouts[900].SetContent(1, 3, lblFive);
			grid.Layouts[2000].SetContent(0, 7, lblFive);

			ITextBox txtFive = Core.BaitAndSwitch.Create<ITextBox>();
			txtFive.Placeholder = "Text Five";
			txtFive.FontSize = 20;
			grid.Layouts[500].SetContent(3, 2, txtFive);
			grid.Layouts[900].SetContent(1, 4, txtFive);
			grid.Layouts[2000].SetContent(0, 8, txtFive);

			ILabel lblSix = Core.BaitAndSwitch.Create<ILabel>();
			lblSix.Text = "Label Six";
			lblSix.FontSize = 20;
			lblSix.Width = 100;
			grid.Layouts[500].SetContent(4, 1, lblSix);
			grid.Layouts[900].SetContent(2, 1, lblSix);
			grid.Layouts[2000].SetContent(0, 9, lblSix);

			ITextBox txtSix = Core.BaitAndSwitch.Create<ITextBox>();
			txtSix.Placeholder = "Text Six";
			txtSix.FontSize = 20;
			grid.Layouts[500].SetContent(4, 2, txtSix);
			grid.Layouts[900].SetContent(2, 2, txtSix);
			grid.Layouts[2000].SetContent(0, 10, txtSix);

			ILabel lblSeven = Core.BaitAndSwitch.Create<ILabel>();
			lblSeven.Text = "Label Seven";
			lblSeven.FontSize = 20;
			lblSeven.Width = 100;
			grid.Layouts[500].SetContent(5, 1, lblSeven);
			grid.Layouts[900].SetContent(2, 3, lblSeven);
			grid.Layouts[2000].SetContent(0, 11, lblSeven);

			ITextBox txtSeven = Core.BaitAndSwitch.Create<ITextBox>();
			txtSeven.Placeholder = "Text Seven";
			txtSeven.FontSize = 20;
			grid.Layouts[500].SetContent(5, 2, txtSeven);
			grid.Layouts[900].SetContent(2, 4, txtSeven);
			grid.Layouts[2000].SetContent(0, 12, txtSeven);

			ILabel lblEigth = Core.BaitAndSwitch.Create<ILabel>();
			lblEigth.Text = "Label Eigth";
			lblEigth.FontSize = 20;
			lblEigth.Width = 100;
			grid.Layouts[500].SetContent(6, 1, lblEigth);
			grid.Layouts[900].SetContent(3, 1, lblEigth);
			grid.Layouts[2000].SetContent(1, 1, lblEigth);

			ITextBox txtEigth = Core.BaitAndSwitch.Create<ITextBox>();
			txtEigth.Placeholder = "Text Eigth";
			txtEigth.FontSize = 20;
			grid.Layouts[500].SetContent(6, 2, txtEigth);
			grid.Layouts[900].SetContent(3, 2, txtEigth);
			grid.Layouts[2000].SetContent(1, 2, txtEigth);

			ILabel lblNine = Core.BaitAndSwitch.Create<ILabel>();
			lblNine.Text = "Label Nine";
			lblNine.FontSize = 20;
			lblNine.Width = 100;
			grid.Layouts[500].SetContent(7, 1, lblNine);
			grid.Layouts[900].SetContent(3, 3, lblNine);
			grid.Layouts[2000].SetContent(1, 3, lblNine);

			ITextBox txtNine = Core.BaitAndSwitch.Create<ITextBox>();
			txtNine.Placeholder = "Text Nine";
			txtNine.FontSize = 20;
			grid.Layouts[500].SetContent(7, 2, txtNine);
			grid.Layouts[900].SetContent(3, 4, txtNine);
			grid.Layouts[2000].SetContent(1, 4, txtNine);

			ILabel lblTen = Core.BaitAndSwitch.Create<ILabel>();
			lblTen.Text = "Label Ten";
			lblTen.FontSize = 20;
			lblTen.Width = 100;
			grid.Layouts[500].SetContent(8, 1, lblTen);
			grid.Layouts[900].SetContent(4, 1, lblTen);
			grid.Layouts[2000].SetContent(1, 5, lblTen);

			ITextBox txtTen = Core.BaitAndSwitch.Create<ITextBox>();
			txtTen.Placeholder = "Text Ten";
			txtTen.FontSize = 20;
			grid.Layouts[500].SetContent(8, 2, txtTen);
			grid.Layouts[900].SetContent(4, 2, txtTen);
			grid.Layouts[2000].SetContent(1, 6, txtTen);

			ILabel lblEleven = Core.BaitAndSwitch.Create<ILabel>();
			lblEleven.Text = "Label Eleven";
			lblEleven.FontSize = 20;
			lblEleven.Width = 100;
			grid.Layouts[500].SetContent(9, 1, lblEleven);
			grid.Layouts[900].SetContent(4, 3, lblEleven);
			grid.Layouts[2000].SetContent(1, 7, lblEleven);

			ITextBox txtEleven = Core.BaitAndSwitch.Create<ITextBox>();
			txtEleven.Placeholder = "Text Eleven";
			txtEleven.FontSize = 20;
			grid.Layouts[500].SetContent(9, 2, txtEleven);
			grid.Layouts[900].SetContent(4, 4, txtEleven);
			grid.Layouts[2000].SetContent(1, 8, txtEleven);

			ILabel lblTwelve = Core.BaitAndSwitch.Create<ILabel>();
			lblTwelve.Text = "Label Twelve";
			lblTwelve.FontSize = 20;
			lblTwelve.Width = 100;
			grid.Layouts[500].SetContent(10, 1, lblTwelve);
			grid.Layouts[900].SetContent(5, 1, lblTwelve);
			grid.Layouts[2000].SetContent(1, 9, lblTwelve);

			ITextBox txtTwelve = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwelve.Placeholder = "Text Twelve";
			txtTwelve.FontSize = 20;
			grid.Layouts[500].SetContent(10, 2, txtTwelve);
			grid.Layouts[900].SetContent(5, 2, txtTwelve);
			grid.Layouts[2000].SetContent(1, 10, txtTwelve);

			ILabel lblThirteen = Core.BaitAndSwitch.Create<ILabel>();
			lblThirteen.Text = "Label Thirteen";
			lblThirteen.FontSize = 20;
			lblThirteen.Width = 100;
			grid.Layouts[500].SetContent(11, 1, lblThirteen);
			grid.Layouts[900].SetContent(5, 3, lblThirteen);
			grid.Layouts[2000].SetContent(1, 11, lblThirteen);

			ITextBox txtThirteen = Core.BaitAndSwitch.Create<ITextBox>();
			txtThirteen.Placeholder = "Text Thirteen";
			txtThirteen.FontSize = 20;
			grid.Layouts[500].SetContent(11, 2, txtThirteen);
			grid.Layouts[900].SetContent(5, 4, txtThirteen);
			grid.Layouts[2000].SetContent(1, 12, txtThirteen);

			ILabel lblFourteen = Core.BaitAndSwitch.Create<ILabel>();
			lblFourteen.Text = "Label Fourteen";
			lblFourteen.FontSize = 20;
			lblFourteen.Width = 100;
			grid.Layouts[500].SetContent(12, 1, lblFourteen);
			grid.Layouts[900].SetContent(6, 1, lblFourteen);
			grid.Layouts[2000].SetContent(2, 1, lblFourteen);

			ITextBox txtFourteen = Core.BaitAndSwitch.Create<ITextBox>();
			txtFourteen.Placeholder = "Text Fourteen";
			txtFourteen.FontSize = 20;
			grid.Layouts[500].SetContent(12, 2, txtFourteen);
			grid.Layouts[900].SetContent(6, 2, txtFourteen);
			grid.Layouts[2000].SetContent(2, 2, txtFourteen);

			ILabel lblFiveteen = Core.BaitAndSwitch.Create<ILabel>();
			lblFiveteen.Text = "Label Fiveteen";
			lblFiveteen.FontSize = 20;
			lblFiveteen.Width = 100;
			grid.Layouts[500].SetContent(13, 1, lblFiveteen);
			grid.Layouts[900].SetContent(6, 3, lblFiveteen);
			grid.Layouts[2000].SetContent(2, 3, lblFiveteen);

			ITextBox txtFiveteen = Core.BaitAndSwitch.Create<ITextBox>();
			txtFiveteen.Placeholder = "Text Fiveteen";
			txtFiveteen.FontSize = 20;
			grid.Layouts[500].SetContent(13, 2, txtFiveteen);
			grid.Layouts[900].SetContent(6, 4, txtFiveteen);
			grid.Layouts[2000].SetContent(2, 4, txtFiveteen);

			ILabel lblSixteen = Core.BaitAndSwitch.Create<ILabel>();
			lblSixteen.Text = "Label Sixteen";
			lblSixteen.FontSize = 20;
			lblSixteen.Width = 100;
			grid.Layouts[500].SetContent(14, 1, lblSixteen);
			grid.Layouts[900].SetContent(7, 1, lblSixteen);
			grid.Layouts[2000].SetContent(2, 5, lblSixteen);

			ITextBox txtSixteen = Core.BaitAndSwitch.Create<ITextBox>();
			txtSixteen.Placeholder = "Text Sixteen";
			txtSixteen.FontSize = 20;
			grid.Layouts[500].SetContent(14, 2, txtSixteen);
			grid.Layouts[900].SetContent(7, 2, txtSixteen);
			grid.Layouts[2000].SetContent(2, 6, txtSixteen);

			ILabel lblSeventeen = Core.BaitAndSwitch.Create<ILabel>();
			lblSeventeen.Text = "Label Seventeen";
			lblSeventeen.FontSize = 20;
			lblSeventeen.Width = 100;
			grid.Layouts[500].SetContent(15, 1, lblSeventeen);
			grid.Layouts[900].SetContent(7, 3, lblSeventeen);
			grid.Layouts[2000].SetContent(2, 7, lblSeventeen);

			ITextBox txtSeventeen = Core.BaitAndSwitch.Create<ITextBox>();
			txtSeventeen.Placeholder = "Text Seventeen";
			txtSeventeen.FontSize = 20;
			grid.Layouts[500].SetContent(15, 2, txtSeventeen);
			grid.Layouts[900].SetContent(7, 4, txtSeventeen);
			grid.Layouts[2000].SetContent(2, 8, txtSeventeen);

			ILabel lblEigtheen = Core.BaitAndSwitch.Create<ILabel>();
			lblEigtheen.Text = "Label Eigteen";
			lblEigtheen.FontSize = 20;
			lblEigtheen.Width = 100;
			grid.Layouts[500].SetContent(16, 1, lblEigtheen);
			grid.Layouts[900].SetContent(8, 1, lblEigtheen);
			grid.Layouts[2000].SetContent(2, 9, lblEigtheen);

			ITextBox txtEigtheen = Core.BaitAndSwitch.Create<ITextBox>();
			txtEigtheen.Placeholder = "Text Eigtheen";
			txtEigtheen.FontSize = 20;
			grid.Layouts[500].SetContent(16, 2, txtEigtheen);
			grid.Layouts[900].SetContent(8, 2, txtEigtheen);
			grid.Layouts[2000].SetContent(2, 10, txtEigtheen);

			ILabel lblNineteen = Core.BaitAndSwitch.Create<ILabel>();
			lblNineteen.Text = "Label Nineteen";
			lblNineteen.FontSize = 20;
			lblNineteen.Width = 100;
			grid.Layouts[500].SetContent(17, 1, lblNineteen);
			grid.Layouts[900].SetContent(8, 3, lblNineteen);
			grid.Layouts[2000].SetContent(2, 11, lblNineteen);

			ITextBox txtNineteen = Core.BaitAndSwitch.Create<ITextBox>();
			txtNineteen.Placeholder = "Text Nineteen";
			txtNineteen.FontSize = 20;
			grid.Layouts[500].SetContent(17, 2, txtNineteen);
			grid.Layouts[900].SetContent(8, 4, txtNineteen);
			grid.Layouts[2000].SetContent(2, 12, txtNineteen);

			ILabel lblTwenty = Core.BaitAndSwitch.Create<ILabel>();
			lblTwenty.Text = "Label Twenty";
			lblTwenty.FontSize = 20;
			lblTwenty.Width = 100;
			grid.Layouts[500].SetContent(18, 1, lblTwenty);
			grid.Layouts[900].SetContent(9, 1, lblTwenty);
			grid.Layouts[2000].SetContent(3, 1, lblTwenty);

			ITextBox txtTwenty = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwenty.Placeholder = "Text Twenty";
			txtTwenty.FontSize = 20;
			grid.Layouts[500].SetContent(18, 2, txtTwenty);
			grid.Layouts[900].SetContent(9, 2, txtTwenty);
			grid.Layouts[2000].SetContent(3, 2, txtTwenty);

			ILabel lblTwentyOne = Core.BaitAndSwitch.Create<ILabel>();
			lblTwentyOne.Text = "Label TwentyOne";
			lblTwentyOne.FontSize = 20;
			lblTwentyOne.Width = 100;
			grid.Layouts[500].SetContent(19, 1, lblTwentyOne);
			grid.Layouts[900].SetContent(10, 3, lblTwentyOne);
			grid.Layouts[2000].SetContent(3, 3, lblTwentyOne);

			ITextBox txtTwentyOne = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwentyOne.Placeholder = "Text TwentyOne";
			txtTwentyOne.FontSize = 20;
			grid.Layouts[500].SetContent(19, 2, txtTwentyOne);
			grid.Layouts[900].SetContent(10, 4, txtTwentyOne);
			grid.Layouts[2000].SetContent(3, 4, txtTwentyOne);

			
			//grid.InsertRow(0, 2);
			//grid.InsertColumn(2, 4);

			//grid.ChangeColumn(2, 4);
			//grid.ChangeRow(0, 2);

			//int cw = Convert.ToInt32(Page.Width);
			//grid.MakeResponsive(cw);

			Page.Content = grid.GetGrid(Page.Width.Value);
		}

		public override void Refresh()
		{
			base.Refresh();
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
	}
}
