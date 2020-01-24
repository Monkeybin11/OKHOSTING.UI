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
			grid.RowCount = 1;

			//ILabel lblTitle = Core.BaitAndSwitch.Create<ILabel>();
			//lblTitle.Text = "This is a test of Grid Make Responsive";
			//lblTitle.FontSize = 30;
			//lblTitle.FontColor = Color.Red;
			//lblTitle.Bold = true;
			//lblTitle.Width = 500;
			//grid.SetContent(0, 0, lblTitle);

			//ILabel lblSubTitle = Core.BaitAndSwitch.Create<ILabel>();
			//lblSubTitle.Text = "Each controller is in a different cell";
			//lblSubTitle.FontSize = 25;
			//lblSubTitle.FontColor = Color.Blue;
			//lblSubTitle.Bold = true;
			//grid.SetContent(1, 0, lblSubTitle);

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

			int w = Convert.ToInt32(grid.Width);
			grid.MakeResponsive(w);

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
