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
    public class AplicacionPrueba : Controller
    {
        // Declare an button
        IButton btnsumar;
        IButton btnrestar;
        IButton btnmultiplicar;
        IButton btndividir;
        IButton btnsalir;
        // Declare an label
        ILabel lb1;
        ILabel lb2;
        ILabel lbResultado;
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
            lb1.Text = "ingrese el primer numero";
            grid.SetContent(0, 0, lb1);


            lb2 = Core.BaitAndSwitch.Create<ILabel>();
            lb2.Text = "ingrese el segundo numero";
            grid.SetContent(1, 0, lb2);

            txtn1 = Core.BaitAndSwitch.Create<ITextBox>();
            txtn1.Value = "";
            grid.SetContent(0, 1, txtn1);

            txtn2 = Core.BaitAndSwitch.Create<ITextBox>();
            txtn2.Value = "";
            grid.SetContent(1, 1, txtn2);

            lbResultado = Core.BaitAndSwitch.Create<ILabel>();
            lbResultado.Text = "";
            grid.SetContent(2, 1, lbResultado);

            btnsumar = Core.BaitAndSwitch.Create<IButton>();
            btnsumar.Text = "Sumar";
            btnsumar.Click += btnSumar_Click;
            grid.SetContent(0, 2, btnsumar);

            btnrestar = Core.BaitAndSwitch.Create<IButton>();
            btnrestar.Text = "Restar";
            btnrestar.Click += btnRestar_Click;
            grid.SetContent(1, 2, btnrestar);

            btnmultiplicar = Core.BaitAndSwitch.Create<IButton>();
            btnmultiplicar.Text = "Multiplicar";
            btnmultiplicar.Click += btnMultiplicar_Click;
            grid.SetContent(2, 2, btnmultiplicar);

            btndividir = Core.BaitAndSwitch.Create<IButton>();
            btndividir.Text = "Dividir";
            btndividir.Click += btnDividir_Click;
            grid.SetContent(3, 2, btndividir);


            btnsalir = Core.BaitAndSwitch.Create<IButton>();
            btnsalir.Text = "Salir";
            btnsalir.Click += btnSalir_Click;
            grid.SetContent(4, 2, btnsalir);

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


        private void btnSumar_Click(object sender, EventArgs e) {

            double sumar = double.Parse(txtn1.Value) + double.Parse(txtn2.Value);
            lbResultado.Text = sumar.ToString();
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {

            double restar = double.Parse(txtn1.Value) - double.Parse(txtn2.Value);
            lbResultado.Text = restar.ToString();
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            double multiplicar = double.Parse(txtn1.Value) * double.Parse(txtn2.Value);
            lbResultado.Text = multiplicar.ToString();
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {

            double dividir = double.Parse(txtn1.Value) / double.Parse(txtn2.Value);
            lbResultado.Text = dividir.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}
