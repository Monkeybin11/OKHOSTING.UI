using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OKHOSTING.UI.Test
{
    class ContainerTest : Controller
    {
        ILabel lblNumberOne;
        ILabel lblNumberTwo;
        ILabel lblResult;

        ITextBox txtNumberTwo;
        ITextBox txtNumberOne;

        IButton btnClose;
        IButton btnPlus;
        IButton btnSubtraction;
        IButton btnMultiply;
        IButton btnDivide;
        IButton btnClean;
        

        /// <summary>
        /// Start this instance.
        /// <para xml:lang="es">
        /// Inicia una instancia de este objeto.
        /// </para>
        /// </summary>
        /// 

        protected override void OnStart() 
        {
            //Create an RelativePanel container
            IRelativePanel relativePanel = Core.BaitAndSwitch.Create<IRelativePanel>();

            lblResult = Core.BaitAndSwitch.Create<ILabel>();
            lblResult.Text = "Result";
            lblResult.FontSize = 500;
            lblResult.Width = 500;
            lblResult.Name = "lblResult";
            relativePanel.Add(lblResult, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.CenterWith, lblResult);

            lblNumberOne = Core.BaitAndSwitch.Create<ILabel>();
            lblNumberOne.Text = "           Number one";
            relativePanel.Add(lblNumberOne, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, lblResult);

            lblNumberTwo = Core.BaitAndSwitch.Create<ILabel>();
            lblNumberTwo.Text = "           Number Two";
            lblNumberTwo.CssClass = "container";
            relativePanel.Add(lblNumberTwo, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, lblNumberOne);

            txtNumberOne = Core.BaitAndSwitch.Create<ITextBox>();
            txtNumberOne.Value = "";
            txtNumberOne.CssClass = "container";
            txtNumberOne.Width = 50;
            relativePanel.Add(txtNumberOne, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.CenterWith, lblNumberOne);

            txtNumberTwo = Core.BaitAndSwitch.Create<ITextBox>();
            txtNumberTwo.Value = "";
            txtNumberTwo.CssClass = "container";
            txtNumberTwo.Width = 50;
            relativePanel.Add(txtNumberTwo, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, txtNumberOne);


            btnPlus = Core.BaitAndSwitch.Create<IButton>();
            btnPlus.Text = "+";
            btnPlus.CssClass = "container";
            btnPlus.Width = 20;
              btnPlus.Click += btnPlus_Click;
            relativePanel.Add(btnPlus, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.CenterWith, txtNumberOne);

            btnSubtraction = Core.BaitAndSwitch.Create<IButton>();
            btnSubtraction.Text = "-";
            btnSubtraction.CssClass = "container";
            btnSubtraction.Width = 20;
            btnSubtraction.Click += btnSubtraction_Click;
            relativePanel.Add(btnSubtraction, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, btnPlus);


            btnMultiply = Core.BaitAndSwitch.Create<IButton>();
            btnMultiply.Text = "x";
            btnMultiply.CssClass = "container";
            btnMultiply.Width = 20;
            btnMultiply.Click  += btnMultiply_Click;
            relativePanel.Add(btnMultiply, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, btnSubtraction);

            btnDivide = Core.BaitAndSwitch.Create<IButton>();
            btnDivide.Text = "/";
            btnDivide.CssClass = "container";
            btnDivide.Width = 20;
            btnDivide.Click += btnDivide_Click;
            relativePanel.Add(btnDivide, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, btnMultiply);

            btnClose = Core.BaitAndSwitch.Create<IButton>();
            btnClose.Text = "Close";
            btnClose.CssClass = "container";
            btnClose.Width = 50;
            btnClose.Click += btnClose_Click;
            relativePanel.Add(btnClose, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, txtNumberTwo);

            btnClean = Core.BaitAndSwitch.Create<IButton>();
            btnClean.Text = "Clean";
            btnClean.CssClass = "container";
            btnClean.Width = 50;
            btnClean.Click += btnClean_Click;
            relativePanel.Add(btnClean, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, btnClose);

            // Establishes the content and title of the page.
            Page.Title = "Container Test";
            Page.Content = relativePanel;



            CSS.Style style = new CSS.Style();
            style.Parse(
            @"

             
             #lblResult {
             
            text-aling: center;
             font-size:14px;
            color: black;
            background-color: #75CA38;
            }

            ");

            style.Apply(Page);


        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            double res = double.Parse(txtNumberOne.Value) + double.Parse(txtNumberTwo.Value);
            lblResult.Text = res.ToString();
        }

        private void btnSubtraction_Click(object sender, EventArgs e)
        {
            double res = double.Parse(txtNumberOne.Value) - double.Parse(txtNumberTwo.Value);
            lblResult.Text = res.ToString();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            double res = double.Parse(txtNumberOne.Value) * double.Parse(txtNumberTwo.Value);
            lblResult.Text = res.ToString();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            double res = double.Parse(txtNumberOne.Value) / double.Parse(txtNumberTwo.Value);
            lblResult.Text = res.ToString();
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
        /// 

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            string clean = " ";
            lblResult.Text = clean;
            txtNumberOne.Value = clean;
            txtNumberTwo.Value = clean;
        }

    }
}
