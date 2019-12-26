using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OKHOSTING.UI.Test
{
    class CalculadoraController : Controller
    {
        ILabel lblResu;
        ITextBox txtNum1;
        ITextBox txtNum2;
        IButton cmdSumar;
        IButton cmdRestar;
        IButton cmdMultiplicar;
        IButton cmdDividir;
        IButton cmdClose;

        /// <summary>
        /// Start this instance.
        /// <para xml:lang="es">
        /// Inicia una instancia de este objeto.
        /// </para>
        /// </summary>
        protected override void OnStart()
        {
            //Create an Stack
            IStack stack = Core.BaitAndSwitch.Create<IStack>();

            //Create an Label with text and height specific and adds it to the Stack.
            lblResu = Core.BaitAndSwitch.Create<ILabel>();
            lblResu.Text = "Result";
            lblResu.Height = 30;
            stack.Children.Add(lblResu);

            //Create an TextBox and adds it to the Stack
            txtNum1 = Core.BaitAndSwitch.Create<ITextBox>();
            txtNum1.BorderColor = Color.FromArgb(255, 255, 0, 0);
            txtNum1.BorderWidth = new Thickness(1, 2, 3, 4);
            txtNum1.Placeholder = "Enter some number..";
            txtNum1.PlaceholderColor = Color.FromArgb(255, 100, 100, 100);
            stack.Children.Add(txtNum1);

            //Create an TextBox and adds it to the Stack
            txtNum2 = Core.BaitAndSwitch.Create<ITextBox>();
            txtNum2.BorderColor = Color.FromArgb(255, 255, 0, 0);
            txtNum2.BorderWidth = new Thickness(1, 2, 3, 4);
            txtNum2.Placeholder = "Enter some number..";
            txtNum2.PlaceholderColor = Color.FromArgb(255, 100, 100, 100);
            stack.Children.Add(txtNum2);

            //Create the button cmdSumar with specific text with the event also click and adds it to the stack.
            cmdSumar = Core.BaitAndSwitch.Create<IButton>();
            cmdSumar.Text = "Sumar";
            cmdSumar.Click += CmdSumar_Click;
            stack.Children.Add(cmdSumar);

            //Create the button cmdRestar with specific text with the event also click and adds it to the stack.
            cmdRestar = Core.BaitAndSwitch.Create<IButton>();
            cmdRestar.Text = "Restar";
            cmdRestar.Click += CmdRestar_Click;
            stack.Children.Add(cmdRestar);

            //Create the button cmdMultiplar with specific text with the event also click and adds it to the stack.
            cmdMultiplicar = Core.BaitAndSwitch.Create<IButton>();
            cmdMultiplicar.Text = "Multiplicar";
            cmdMultiplicar.Click += CmdMultiplicar_Click;
            stack.Children.Add(cmdMultiplicar);

            //Create the button cmdDividir with specific text with the event also click and adds it to the stack.
            cmdDividir = Core.BaitAndSwitch.Create<IButton>();
            cmdDividir.Text = "Dividir";
            cmdDividir.Click += CmdDividir_Click;
            stack.Children.Add(cmdDividir);

            // Creates the Button cmdClose with text specific, with the event also click and adds it to the stack.
            cmdClose = Core.BaitAndSwitch.Create<IButton>();
            cmdClose.Text = "Close";
            cmdClose.Click += CmdClose_Click;
            stack.Children.Add(cmdClose);

            // Establishes the content and title of the page.
            Page.Title = "Test Calculadora";
            Page.Content = stack;

        }

        private void CmdSumar_Click(object sender, EventArgs e)
        {
            double res = double.Parse(txtNum1.Value) + double.Parse(txtNum2.Value);
            lblResu.Text = res.ToString();
        }

        private void CmdRestar_Click(object sender, EventArgs e)
        {
            double res = double.Parse(txtNum1.Value) - double.Parse(txtNum2.Value);
            lblResu.Text = res.ToString();
        }

        private void CmdMultiplicar_Click(object sender, EventArgs e)
        {
            double res = double.Parse(txtNum1.Value) * double.Parse(txtNum2.Value);
            lblResu.Text = res.ToString();
        }

        private void CmdDividir_Click(object sender, EventArgs e)
        {
            double res = double.Parse(txtNum1.Value) / double.Parse(txtNum2.Value);
            lblResu.Text = res.ToString();
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}
