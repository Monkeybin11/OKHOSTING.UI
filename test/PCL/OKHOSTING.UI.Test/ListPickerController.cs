using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	public class ListPickerController : Controller
	{
        IStack stack = Platform.Current.CreateControl<IStack>();
        IListPicker lstColor;

        public override void Start()
		{
			base.Start();

			ILabel lblLabel = Platform.Current.CreateControl<ILabel>();
			lblLabel.Text = "This is a label";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

            IListPicker lstFont = Platform.Current.CreateControl<IListPicker>();
            lstFont.Items = new string[] { "Arial", "Verdana", "Times new roman", "Helvetica" };
            lstFont.ValueChanged += (object sender, string e) => lblLabel.FontFamily = lstFont.Value;
            stack.Children.Add(lstFont);

            lstColor = Platform.Current.CreateControl<IListPicker>();
            lstColor.Items = new string[] { "Red", "Green", "Blue" };
			stack.Children.Add(lstColor);

            IButton cmdColor = Platform.Current.CreateControl<IButton>();
            cmdColor.Text = "Set Color";
            cmdColor.Click += CmdSetColor_Click;
            stack.Children.Add(cmdColor);

            IButton cmdClose = Platform.Current.CreateControl<IButton>();
            cmdClose.Text = "Close";
            cmdClose.Click += CmdClose_Click;
            stack.Children.Add(cmdClose);

            Platform.Current.Page.Title = "Test label";
			Platform.Current.Page.Content = stack;
		}

        private void CmdSetColor_Click(object sender, EventArgs e)
        {
            if(lstColor.Value == "Red")
            {
                stack.BackgroundColor = new Color(1,255,0,0);
            }
            else if (lstColor.Value == "Green")
            {
                stack.BackgroundColor = new Color(1, 0, 255, 0);
            }
            else if (lstColor.Value == "Blue")
            {
                stack.BackgroundColor = new Color(1, 0, 0, 255);
            }
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}