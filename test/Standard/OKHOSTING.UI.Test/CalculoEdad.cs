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
    class CalculoEdad : Controller
    {
        ITextBox txtfecha1;
        ITextBox txtfecha2;

        ILabel lbfechaNac;
        ILabel lbfechaActual;
        ILabel lbresultado;

        IButton btnCalcular;
        IButton btnsalir;

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

            txtfecha1 = Core.BaitAndSwitch.Create<ITextBox>();
            txtfecha1.Value = "";
            grid.SetContent(1, 0, txtfecha1);

            txtfecha2 = Core.BaitAndSwitch.Create<ITextBox>();
            txtfecha2.Value = "";
            grid.SetContent(3, 0, txtfecha2);

            lbfechaNac = Core.BaitAndSwitch.Create<ILabel>();
            lbfechaNac.Text = "Año de Nacimiento";
            grid.SetContent(0, 0, lbfechaNac);

            lbfechaActual = Core.BaitAndSwitch.Create<ILabel>();
            lbfechaActual.Text = "Año Actual";
            grid.SetContent(2, 0, lbfechaActual);

            lbresultado = Core.BaitAndSwitch.Create<ILabel>();
            lbresultado.Text = "";
            grid.SetContent(4, 0, lbresultado);

            btnCalcular = Core.BaitAndSwitch.Create<IButton>();
            btnCalcular.Text = "Calcular";
            btnCalcular.Click += btnCalcular_Click;
            grid.SetContent(0, 2, btnCalcular);

            btnsalir = Core.BaitAndSwitch.Create<IButton>();
   
            btnsalir.Text = "Salir";
            btnsalir.Click += btnSalir_Click;
            grid.SetContent(1, 2, btnsalir);

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
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int calcular = int.Parse(txtfecha1.Value) - int.Parse(txtfecha2.Value);
            lbresultado.Text = calcular.ToString();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}