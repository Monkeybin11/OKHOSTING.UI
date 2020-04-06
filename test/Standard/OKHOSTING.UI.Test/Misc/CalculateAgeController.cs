using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Test.Misc
{
    /// <summary>
    /// It represents the main platform where controls are housed.
    /// <para xml:lang="es">
    /// Representa la plataforma principal donde se alojan controles.
    /// </para>
    /// </summary>
    /// 
    class CalculateAgeController : Controller
    {
        ITextBox txtdate1;
        ITextBox txtdate2;

        ILabel lbdatebirth;
        ILabel lbcurrentdate;
        ILabel lboutcome;

        IButton btnCalculate;
        IButton btnexit;

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

            txtdate1 = Core.BaitAndSwitch.Create<ITextBox>();
            txtdate1.Value = "";
            grid.SetContent(1, 0, txtdate1);

            txtdate2 = Core.BaitAndSwitch.Create<ITextBox>();
            txtdate2.Value = "";
            grid.SetContent(3, 0, txtdate2);

            lbdatebirth = Core.BaitAndSwitch.Create<ILabel>();
            lbdatebirth.Text = "year of birth";
            grid.SetContent(0, 0, lbdatebirth);

            lbcurrentdate = Core.BaitAndSwitch.Create<ILabel>();
            lbcurrentdate.Text = "current year";
            grid.SetContent(2, 0, lbcurrentdate);

            lboutcome = Core.BaitAndSwitch.Create<ILabel>();
            lboutcome.Text = "";
            grid.SetContent(4, 0, lboutcome);

            btnCalculate = Core.BaitAndSwitch.Create<IButton>();
            btnCalculate.Text = "Calculate";
            btnCalculate.Click += btnCalcular_Click;
            grid.SetContent(0, 2, btnCalculate);

            btnexit = Core.BaitAndSwitch.Create<IButton>();
   
            btnexit.Text = "Exit";
            btnexit.Click += btnSalir_Click;
            grid.SetContent(1, 2, btnexit);

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
            int calcular = int.Parse(txtdate1.Value) - int.Parse(txtdate2.Value);
            lboutcome.Text = calcular.ToString();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}