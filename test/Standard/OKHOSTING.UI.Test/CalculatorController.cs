using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OKHOSTING.UI.Test
{
    class CalculatorController : Controller
    {
        ILabel lblResu;
        ITextBox txtNum1;
        ITextBox txtNum2;
        IButton cmdPlus;
        IButton cmdSubtract;
        IButton cmdMultiply;
        IButton cmdDivide;
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

            //Create the button cmdPlus with specific text with the event also click and adds it to the stack.
            cmdPlus = Core.BaitAndSwitch.Create<IButton>();
            cmdPlus.Text = "+";
            cmdPlus.Click += CmdPlus_Click;
            stack.Children.Add(cmdPlus);

            //Create the button cmdSubtract with specific text with the event also click and adds it to the stack.
            cmdSubtract = Core.BaitAndSwitch.Create<IButton>();
            cmdSubtract.Text = "-";
            cmdSubtract.Click += CmdSubtract_Click;
            stack.Children.Add(cmdSubtract);

            //Create the button cmdMultiply with specific text with the event also click and adds it to the stack.
            cmdMultiply = Core.BaitAndSwitch.Create<IButton>();
            cmdMultiply.Text = "*";
            cmdMultiply.Click += CmdMultiply_Click;
            stack.Children.Add(cmdMultiply);

            //Create the button cmdDivide with specific text with the event also click and adds it to the stack.
            cmdDivide = Core.BaitAndSwitch.Create<IButton>();
            cmdDivide.Text = "/";
            cmdDivide.Click += CmdDivide_Click;
            stack.Children.Add(cmdDivide);

            // Creates the Button cmdClose with text specific, with the event also click and adds it to the stack.
            cmdClose = Core.BaitAndSwitch.Create<IButton>();
            cmdClose.Text = "Close";
            cmdClose.Click += CmdClose_Click;
            stack.Children.Add(cmdClose);

            // Establishes the content and title of the page.
            Page.Title = "Calculator";
            Page.Content = stack;

        }

        private void CmdPlus_Click(object sender, EventArgs e)
        {
            double res = double.Parse(txtNum1.Value) + double.Parse(txtNum2.Value);
            lblResu.Text = res.ToString();
        }

        private void CmdSubtract_Click(object sender, EventArgs e)
        {
            double res = double.Parse(txtNum1.Value) - double.Parse(txtNum2.Value);
            lblResu.Text = res.ToString();
        }

        private void CmdMultiply_Click(object sender, EventArgs e)
        {
            double res = double.Parse(txtNum1.Value) * double.Parse(txtNum2.Value);
            lblResu.Text = res.ToString();
        }

        private void CmdDivide_Click(object sender, EventArgs e)
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
