using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OKHOSTING.UI.Test.Misc
{
    class CurrencyConversionController : Controller
    {
        IStack stack = Core.BaitAndSwitch.Create<IStack>();

        ILabel lblResult;
        ITextBox txtPesoMx;
        IListPicker lstCurrencyConversion;
        IButton btnConvert;
        IButton cmdClose;

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

            //Label titule
            ILabel lblTitulo = Core.BaitAndSwitch.Create<ILabel>();
            lblTitulo.Text = "Convert of peso mexicano.";
            lblTitulo.Width = 50;
            //stack.Children.Add(lblTitulo);
            grid.SetContent(0, 0, lblTitulo);

            //Label1
            ILabel lbllabel1 = Core.BaitAndSwitch.Create<ILabel>();
            lbllabel1.Text = "Peso Mx.";
            lbllabel1.Width = 30;
            //stack.Children.Add(lbllabel1);
            grid.SetContent(1, 0, lbllabel1);

            //TextBos for write number of pesos mexicanos
            txtPesoMx = Core.BaitAndSwitch.Create<ITextBox>();
            txtPesoMx.BorderColor = Color.FromArgb(255, 255, 0, 0);
            txtPesoMx.BorderWidth = new Thickness(1, 2, 3, 4);
            //stack.Children.Add(txtPesoMx);
            grid.SetContent(1, 1, txtPesoMx);

            //Label for show the result
            lblResult = Core.BaitAndSwitch.Create<ILabel>();
            lblResult.Text = " ";
            lblResult.Width = 40;
            //stack.Children.Add(lblResult);
            grid.SetContent(1, 2, lblResult);

            //ListPicker of currency type
            lstCurrencyConversion = Core.BaitAndSwitch.Create<IListPicker>();
            lstCurrencyConversion.Items = new string[] { "Dolar US", "Euro", "Sol Peruano" };
            //stack.Children.Add(lstCurrencyConversion);
            grid.SetContent(2, 0, lstCurrencyConversion);

            //Button for claculate the currency type
            btnConvert = Core.BaitAndSwitch.Create<IButton>();
            btnConvert.Text = "Convert";
            btnConvert.Click += btnConvert_Click;
            //stack.Children.Add(btnConvert);
            grid.SetContent(2, 1, btnConvert);

            // Creates the Button cmdClose with text specific, with the event also click and adds it to the stack.
            cmdClose = Core.BaitAndSwitch.Create<IButton>();
            cmdClose.Text = "Close";
            cmdClose.Click += CmdClose_Click;
            //stack.Children.Add(cmdClose);
            grid.SetContent(3, 0, cmdClose);

            // Establishes the content and title of the page.
            Page.Title = "Test label";
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

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double result = 0.0;

            if(lstCurrencyConversion.Value == "Dolar US")
            {
                result = double.Parse(txtPesoMx.Value) / 18.95;
                lblResult.Text = result.ToString();
            }
            else if (lstCurrencyConversion.Value == "Euro")
            {
                result = double.Parse(txtPesoMx.Value) / 18.95;
                lblResult.Text = result.ToString();
            }
            else if (lstCurrencyConversion.Value == "Sol Peruano")
            {
                result = double.Parse(txtPesoMx.Value) / 5.75;
                lblResult.Text = result.ToString();
            }
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }

}

