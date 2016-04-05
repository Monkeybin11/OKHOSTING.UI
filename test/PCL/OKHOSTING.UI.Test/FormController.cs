using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System.IO;
using OKHOSTING.UI.Controls.Forms;

namespace OKHOSTING.UI.Test
{
	public class FormController : Controller
	{
        Form Form;

        public override void Start()
		{
			base.Start();

            Form = new Form();

            IntegerField intField = new IntegerField();
            intField.Name = "id";
            intField.Value = 5;
            intField.CaptionControl.Text = "id";
            intField.Required = true;
            intField.Container = Form;

            Form.Fields.Add(intField);

            StringField stringField = new StringField();
            stringField.Name = "name";
            stringField.Value = "";
            stringField.CaptionControl.Text = "name";
            stringField.Required = true;
            stringField.Container = Form;

            Form.Fields.Add(stringField);

            Form.RepeatColumns = 4;
            Form.LabelPosition = CaptionPosition.Left;
            Form.DataBind();

            IButton cmdSave = Platform.Current.Create<IButton>();
            cmdSave.Text = "Save";
            cmdSave.Click += CmdSave_Click;

            IStack stack = Platform.Current.Create<IStack>();

            stack.Children.Add(Form.Content);
            stack.Children.Add(cmdSave);

            Platform.Current.Page.Title = "Form";
			Platform.Current.Page.Content = stack;
		}

        private void CmdSave_Click(object sender, EventArgs e)
        {
            var id = Form["id"].Value;
            var name = Form["name"].Value;

            Finish();
        }
    }
}