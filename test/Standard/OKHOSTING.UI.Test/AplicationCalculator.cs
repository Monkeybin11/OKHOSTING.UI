using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Test
{
    /// <summary>
	/// It represents the main platform where controls are housed.
	/// <para xml:lang="es">
	/// Representa la plataforma principal donde se alojan controles.
	/// </para>
	/// </summary>
    /// 
    public class AplicationCalculator : Controller
    {
        // Declare an button
        IButton btnAdd;
        IButton btnSubtract;
        IButton btnMultiply;
        IButton btnDivide;
        IButton btnExit;
        // Declare an label
        ILabel lb1;
        ILabel lb2;
        ILabel lbResult;
        // Declare an texbox
        ITextBox txtn1;
        ITextBox txtn2;


        /// <summary>
        /// Start this instance.
        /// <para xml:lang="es">.
        /// Inicia la instancia de este objeto.
        /// </para>
        /// </summary>
        /// 

        protected override void OnStart()
        {
            IGrid grid = Core.BaitAndSwitch.Create<IGrid>();
            grid.ColumnCount = 3;
            grid.RowCount = 5;

            lb1 = Core.BaitAndSwitch.Create<ILabel>();
            lb1.Text = "enter the first number";
            grid.SetContent(0, 0, lb1);


            lb2 = Core.BaitAndSwitch.Create<ILabel>();
            lb2.Text = "enter the second number";
            grid.SetContent(1, 0, lb2);

            txtn1 = Core.BaitAndSwitch.Create<ITextBox>();
            txtn1.Value = "";
            grid.SetContent(0, 1, txtn1);

            txtn2 = Core.BaitAndSwitch.Create<ITextBox>();
            txtn2.Value = "";
            grid.SetContent(1, 1, txtn2);

            lbResult = Core.BaitAndSwitch.Create<ILabel>();
            lbResult.Text = "";
            grid.SetContent(2, 1, lbResult);

            btnAdd = Core.BaitAndSwitch.Create<IButton>();
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            grid.SetContent(0, 2, btnAdd);

            btnSubtract = Core.BaitAndSwitch.Create<IButton>();
            btnSubtract.Text = "Subtract";
            btnSubtract.Click += btnSubtract_Click;
            grid.SetContent(1, 2, btnSubtract);

            btnMultiply = Core.BaitAndSwitch.Create<IButton>();
            btnMultiply.Text = "Multiply";
            btnMultiply.Click += btnMultiply_Click;
            grid.SetContent(2, 2, btnMultiply);

            btnDivide = Core.BaitAndSwitch.Create<IButton>();
            btnDivide.Text = "Divide";
            btnDivide.Click += btnDivide_Click;
            grid.SetContent(3, 2, btnDivide);


            btnExit = Core.BaitAndSwitch.Create<IButton>();
            btnExit.Text = "Exit";
            btnExit.Click += btnExit_Click;
            grid.SetContent(4, 2, btnExit);

            Page.Content = grid;
            
        }
        /// <summary>
        /// It is the click event of the button cmd Change, showing a label with the date of the Calendar.
        /// <para xml:lang="es">
        /// Es el evento clic del boton cmdChange, que muestra un label con la fecha del Calendar.
        /// </para>
        /// </summary>
        /// <returns>The change click.</returns>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        /// 


        private void btnAdd_Click(object sender, EventArgs e) {

            double sumar = double.Parse(txtn1.Value) + double.Parse(txtn2.Value);
            lbResult.Text = sumar.ToString();
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {

            double restar = double.Parse(txtn1.Value) - double.Parse(txtn2.Value);
            lbResult.Text = restar.ToString();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            double multiplicar = double.Parse(txtn1.Value) * double.Parse(txtn2.Value);
            lbResult.Text = multiplicar.ToString();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {

            double dividir = double.Parse(txtn1.Value) / double.Parse(txtn2.Value);
            lbResult.Text = dividir.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}
