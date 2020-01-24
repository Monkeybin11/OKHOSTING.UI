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
			IGrid grid = Core.BaitAndSwitch.Create<IGrid>();
			grid.ColumnCount = 20;
			grid.RowCount = 3;

			//Row 0---------------------------------------------
			ILabel lblOne = Core.BaitAndSwitch.Create<ILabel>();
			lblOne.Text = "Label One";
			lblOne.FontSize = 20;
			lblOne.Width = 100;
			grid.SetContent(0, 0, lblOne);

			ITextBox txtOne = Core.BaitAndSwitch.Create<ITextBox>();
			txtOne.Placeholder = "Text One";
			txtOne.FontSize = 20;
			grid.SetContent(0, 1, txtOne);

			ILabel lblTwo = Core.BaitAndSwitch.Create<ILabel>();
			lblTwo.Text = "Label Two";
			lblTwo.FontSize = 20;
			lblTwo.Width = 100;
			grid.SetContent(0, 2, lblTwo);

			ITextBox txtTwo = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwo.Placeholder = "Text Two";
			txtTwo.FontSize = 20;
			grid.SetContent(0, 3, txtTwo);

			ILabel lblThree = Core.BaitAndSwitch.Create<ILabel>();
			lblThree.Text = "Label Three";
			lblThree.FontSize = 20;
			lblThree.Width = 100;
			grid.SetContent(0, 4, lblThree);

			ITextBox txtThree = Core.BaitAndSwitch.Create<ITextBox>();
			txtThree.Placeholder = "Text Three";
			txtThree.FontSize = 20;
			grid.SetContent(0, 5, txtThree);

			ILabel lblFour = Core.BaitAndSwitch.Create<ILabel>();
			lblFour.Text = "Label Four";
			lblFour.FontSize = 20;
			lblFour.Width = 100;
			grid.SetContent(0, 6, lblFour);

			ITextBox txtFour = Core.BaitAndSwitch.Create<ITextBox>();
			txtFour.Placeholder = "Text Four";
			txtFour.FontSize = 20;
			grid.SetContent(0, 7, txtFour);

			ILabel lblFive = Core.BaitAndSwitch.Create<ILabel>();
			lblFive.Text = "Label Five";
			lblFive.FontSize = 20;
			lblFive.Width = 100;
			grid.SetContent(0, 8, lblFive);

			ITextBox txtFive = Core.BaitAndSwitch.Create<ITextBox>();
			txtFive.Placeholder = "Text Five";
			txtFive.FontSize = 20;
			grid.SetContent(0, 9, txtFive);

			ILabel lblSix = Core.BaitAndSwitch.Create<ILabel>();
			lblSix.Text = "Label Six";
			lblSix.FontSize = 20;
			lblSix.Width = 100;
			grid.SetContent(0, 10, lblSix);

			ITextBox txtSix = Core.BaitAndSwitch.Create<ITextBox>();
			txtSix.Placeholder = "Text Six";
			txtSix.FontSize = 20;
			grid.SetContent(0, 11, txtSix);

			ILabel lblSeven = Core.BaitAndSwitch.Create<ILabel>();
			lblSeven.Text = "Label Seven";
			lblSeven.FontSize = 20;
			lblSeven.Width = 100;
			grid.SetContent(0, 12, lblSeven);

			ITextBox txtSeven = Core.BaitAndSwitch.Create<ITextBox>();
			txtSeven.Placeholder = "Text Seven";
			txtSeven.FontSize = 20;
			grid.SetContent(0, 13, txtSeven);

			ILabel lblEigth = Core.BaitAndSwitch.Create<ILabel>();
			lblEigth.Text = "Label Eigth";
			lblEigth.FontSize = 20;
			lblEigth.Width = 100;
			grid.SetContent(0, 14, lblEigth);

			ITextBox txtEigth = Core.BaitAndSwitch.Create<ITextBox>();
			txtEigth.Placeholder = "Text Eigth";
			txtEigth.FontSize = 20;
			grid.SetContent(0, 15, txtEigth);

			ILabel lblNine = Core.BaitAndSwitch.Create<ILabel>();
			lblNine.Text = "Label Nine";
			lblNine.FontSize = 20;
			lblNine.Width = 100;
			grid.SetContent(0, 16, lblNine);

			ITextBox txtNine = Core.BaitAndSwitch.Create<ITextBox>();
			txtNine.Placeholder = "Text Nine";
			txtNine.FontSize = 20;
			grid.SetContent(0, 17, txtNine);

			ILabel lblTen = Core.BaitAndSwitch.Create<ILabel>();
			lblTen.Text = "Label Ten";
			lblTen.FontSize = 20;
			lblTen.Width = 100;
			grid.SetContent(0, 18, lblTen);

			ITextBox txtTen = Core.BaitAndSwitch.Create<ITextBox>();
			txtTen.Placeholder = "Text Ten";
			txtTen.FontSize = 20;
			grid.SetContent(0, 19, txtTen);

			//Row 1---------------------------------------------
			ILabel lblEleven = Core.BaitAndSwitch.Create<ILabel>();
			lblEleven.Text = "Label Eleven";
			lblEleven.FontSize = 20;
			lblEleven.Width = 100;
			grid.SetContent(1, 0, lblEleven);

			ITextBox txtEleven = Core.BaitAndSwitch.Create<ITextBox>();
			txtEleven.Placeholder = "Text Eleven";
			txtEleven.FontSize = 20;
			grid.SetContent(1, 1, txtEleven);

			ILabel lblTwelve = Core.BaitAndSwitch.Create<ILabel>();
			lblTwelve.Text = "Label Twelve";
			lblTwelve.FontSize = 20;
			lblTwelve.Width = 100;
			grid.SetContent(1, 2, lblTwelve);

			ITextBox txtTwelve = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwelve.Placeholder = "Text Twelve";
			txtTwelve.FontSize = 20;
			grid.SetContent(1, 3, txtTwelve);

			ILabel lblThirteen = Core.BaitAndSwitch.Create<ILabel>();
			lblThirteen.Text = "Label Thirteen";
			lblThirteen.FontSize = 20;
			lblThirteen.Width = 100;
			grid.SetContent(1, 4, lblThirteen);

			ITextBox txtThirteen = Core.BaitAndSwitch.Create<ITextBox>();
			txtThirteen.Placeholder = "Text Thirteen";
			txtThirteen.FontSize = 20;
			grid.SetContent(1, 5, txtThirteen);

			ILabel lblFourteen = Core.BaitAndSwitch.Create<ILabel>();
			lblFourteen.Text = "Label Fourteen";
			lblFourteen.FontSize = 20;
			lblFourteen.Width = 100;
			grid.SetContent(1, 6, lblFourteen);

			ITextBox txtFourteen = Core.BaitAndSwitch.Create<ITextBox>();
			txtFourteen.Placeholder = "Text Fourteen";
			txtFourteen.FontSize = 20;
			grid.SetContent(1, 7, txtFourteen);

			ILabel lblFiveteen = Core.BaitAndSwitch.Create<ILabel>();
			lblFiveteen.Text = "Label Fiveteen";
			lblFiveteen.FontSize = 20;
			lblFiveteen.Width = 100;
			grid.SetContent(1, 8, lblFiveteen);

			ITextBox txtFiveteen = Core.BaitAndSwitch.Create<ITextBox>();
			txtFiveteen.Placeholder = "Text Fiveteen";
			txtFiveteen.FontSize = 20;
			grid.SetContent(1, 9, txtFiveteen);

			ILabel lblSixteen = Core.BaitAndSwitch.Create<ILabel>();
			lblSixteen.Text = "Label Sixteen";
			lblSixteen.FontSize = 20;
			lblSixteen.Width = 100;
			grid.SetContent(1, 10, lblSixteen);

			ITextBox txtSixteen = Core.BaitAndSwitch.Create<ITextBox>();
			txtSixteen.Placeholder = "Text Sixteen";
			txtSixteen.FontSize = 20;
			grid.SetContent(1, 11, txtSixteen);

			ILabel lblSeventeen = Core.BaitAndSwitch.Create<ILabel>();
			lblSeventeen.Text = "Label Seventeen";
			lblSeventeen.FontSize = 20;
			lblSeventeen.Width = 100;
			grid.SetContent(1, 12, lblSeventeen);

			ITextBox txtSeventeen = Core.BaitAndSwitch.Create<ITextBox>();
			txtSeventeen.Placeholder = "Text Seventeen";
			txtSeventeen.FontSize = 20;
			grid.SetContent(1, 13, txtSeventeen);

			ILabel lblEigtheen = Core.BaitAndSwitch.Create<ILabel>();
			lblEigtheen.Text = "Label Eigteen";
			lblEigtheen.FontSize = 20;
			lblEigtheen.Width = 100;
			grid.SetContent(1, 14, lblEigtheen);

			ITextBox txtEigtheen = Core.BaitAndSwitch.Create<ITextBox>();
			txtEigtheen.Placeholder = "Text Eigtheen";
			txtEigtheen.FontSize = 20;
			grid.SetContent(1, 15, txtEigtheen);

			ILabel lblNineteen = Core.BaitAndSwitch.Create<ILabel>();
			lblNineteen.Text = "Label Nineteen";
			lblNineteen.FontSize = 20;
			lblNineteen.Width = 100;
			grid.SetContent(1, 16, lblNineteen);

			ITextBox txtNineteen = Core.BaitAndSwitch.Create<ITextBox>();
			txtNineteen.Placeholder = "Text Nineteen";
			txtNineteen.FontSize = 20;
			grid.SetContent(1, 17, txtNineteen);

			ILabel lblTwenty = Core.BaitAndSwitch.Create<ILabel>();
			lblTwenty.Text = "Label Twenty";
			lblTwenty.FontSize = 20;
			lblTwenty.Width = 100;
			grid.SetContent(1, 18, lblTwenty);

			ITextBox txtTwenty = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwenty.Placeholder = "Text Twenty";
			txtTwenty.FontSize = 20;
			grid.SetContent(1, 19, txtTwenty);

			//Row 2---------------------------------------------
			ILabel lblTwentyOne = Core.BaitAndSwitch.Create<ILabel>();
			lblTwentyOne.Text = "Label TwentyOne";
			lblTwentyOne.FontSize = 20;
			lblTwentyOne.Width = 100;
			grid.SetContent(2, 0, lblTwentyOne);

			ITextBox txtTwentyOne = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwentyOne.Placeholder = "Text TwentyOne";
			txtTwentyOne.FontSize = 20;
			grid.SetContent(2, 1, txtTwentyOne);

			ILabel lblTwentyTwo = Core.BaitAndSwitch.Create<ILabel>();
			lblTwentyTwo.Text = "Label TwentyTwo";
			lblTwentyTwo.FontSize = 20;
			lblTwentyTwo.Width = 100;
			grid.SetContent(2, 2, lblTwentyTwo);

			ITextBox txtTwentyTwo = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwentyTwo.Placeholder = "Text TwentyTwo";
			txtTwentyTwo.FontSize = 20;
			grid.SetContent(2, 3, txtTwentyTwo);

			ILabel lblTwentyThree = Core.BaitAndSwitch.Create<ILabel>();
			lblTwentyThree.Text = "Label TwentyThree";
			lblTwentyThree.FontSize = 20;
			lblTwentyThree.Width = 100;
			grid.SetContent(2, 4, lblTwentyThree);

			ITextBox txtTwentyThree = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwentyThree.Placeholder = "Text TwentyThree";
			txtTwentyThree.FontSize = 20;
			grid.SetContent(2, 5, txtTwentyThree);

			ILabel lblTwentyFour = Core.BaitAndSwitch.Create<ILabel>();
			lblTwentyFour.Text = "Label TwentyFour";
			lblTwentyFour.FontSize = 20;
			lblFourteen.Width = 100;
			grid.SetContent(2, 6, lblTwentyFour);

			ITextBox txtTwentyFour = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwentyFour.Placeholder = "Text TwentyFour";
			txtTwentyFour.FontSize = 20;
			grid.SetContent(2, 7, txtTwentyFour);

			ILabel lblTwentyFive = Core.BaitAndSwitch.Create<ILabel>();
			lblTwentyFive.Text = "Label TwentyFive";
			lblTwentyFive.FontSize = 20;
			lblTwentyFive.Width = 100;
			grid.SetContent(2, 8, lblTwentyFive);

			ITextBox txtTwentyFive = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwentyFive.Placeholder = "Text TwentyFive";
			txtTwentyFive.FontSize = 20;
			grid.SetContent(2, 9, txtTwentyFive);

			ILabel lblTwentySix = Core.BaitAndSwitch.Create<ILabel>();
			lblTwentySix.Text = "Label TwentySix";
			lblTwentySix.FontSize = 20;
			lblTwentySix.Width = 100;
			grid.SetContent(2, 10, lblTwentySix);

			ITextBox txtTwentySix = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwentySix.Placeholder = "Text TwentySix";
			txtTwentySix.FontSize = 20;
			grid.SetContent(2, 11, txtTwentySix);

			ILabel lblTwentySeven = Core.BaitAndSwitch.Create<ILabel>();
			lblTwentySeven.Text = "Label TwentySeven";
			lblTwentySeven.FontSize = 20;
			lblTwentySeven.Width = 100;
			grid.SetContent(2, 12, lblTwentySeven);

			ITextBox txtTwentySeven = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwentySeven.Placeholder = "Text TwentySeven";
			txtTwentySeven.FontSize = 20;
			grid.SetContent(2, 13, txtTwentySeven);

			ILabel lblTwentyEigth = Core.BaitAndSwitch.Create<ILabel>();
			lblTwentyEigth.Text = "Label TwentyEigth";
			lblTwentyEigth.FontSize = 20;
			lblTwentyEigth.Width = 100;
			grid.SetContent(2, 14, lblTwentyEigth);

			ITextBox txtTwentyEigth = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwentyEigth.Placeholder = "Text TwentyEigth";
			txtTwentyEigth.FontSize = 20;
			grid.SetContent(2, 15, txtTwentyEigth);

			ILabel lblTwentyNine = Core.BaitAndSwitch.Create<ILabel>();
			lblTwentyNine.Text = "Label TwentyNine";
			lblTwentyNine.FontSize = 20;
			lblTwentyNine.Width = 100;
			grid.SetContent(2, 16, lblTwentyNine);

			ITextBox txtTwentyNine = Core.BaitAndSwitch.Create<ITextBox>();
			txtTwentyNine.Placeholder = "Text TwentyNine";
			txtTwentyNine.FontSize = 20;
			grid.SetContent(2, 17, txtTwentyNine);

			ILabel lblThirty = Core.BaitAndSwitch.Create<ILabel>();
			lblThirty.Text = "Label Thirty";
			lblThirty.FontSize = 20;
			lblThirty.Width = 100;
			grid.SetContent(2, 18, lblThirty);

			ITextBox txtThirty = Core.BaitAndSwitch.Create<ITextBox>();
			txtThirty.Placeholder = "Text Thirty";
			txtThirty.FontSize = 20;
			grid.SetContent(2, 19, txtThirty);

			//grid.ChangeColumn(0, 2);
			//grid.ChangeRow(0, 2);

			//int cw = Convert.ToInt32(Page.Width);
			//grid.MakeResponsive(cw);

			Page.Content = grid;
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
