using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System.IO;
using OKHOSTING.UI.Forms;

namespace OKHOSTING.UI.Test.Misc
{
	/// <summary>
	/// It represents a form to store content.
	/// <para xml:lang="es">Representa un formulario para almacenar contenido.</para>
	/// </summary>
	public class FormController : Controller
	{
		// Declare an Form
		Form Form;

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia una instancia del objeto Form
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			// Inicialize an new instance of the class Form
			IUserControl userControl = Core.BaitAndSwitch.Create<IUserControl>();
			userControl.App = Page.App;

			Form = new Form(userControl);

			// Inicialize an new intsance of the class IntegerField, with Name, Value and text especific and adds it to the Form
			IntegerField intField = new IntegerField(Form);
			intField.Name = "id";
			intField.Value = 5;
			intField.CaptionControl.Text = "id";
			intField.Required = true;
			intField.Container = Form;
			Form.Fields.Add(intField);

			// Inicialize an new intsance of the class StringField, with Name, Value and text especific and adds it to the Form
			StringField stringField = new StringField(Form);
			stringField.Name = "name";
			stringField.Value = "";
			stringField.CaptionControl.Text = "name";
			stringField.Required = true;
			stringField.Container = Form;
			Form.Fields.Add(stringField);

			// Establishes the number of columns of the Form and the position of the captions.
			Form.RepeatColumns = 4;
			Form.LabelPosition = CaptionPosition.Left;

			// Creates the Button cmdSave with text specific, with the event also click.
			IButton cmdSave = Core.BaitAndSwitch.Create<IButton>();
			cmdSave.Text = "Save";
			cmdSave.Click += CmdSave_Click;

			// Create a new Stack.
			IStack stack = Core.BaitAndSwitch.Create<IStack>();
			// Adds the content of the Form and the button cmdSave it to the stack
			Form.Start();
			stack.Children.Add(Form.Page.Content);
			stack.Children.Add(cmdSave);

			// Establishes the content and title of the page
			Page.Title = "Form";
			Page.Content = stack;
		}

		/// <summary>
		/// Cmds the save click.
		/// <para xml:lang="es">
		/// Es el evento clic del boton cmdSave, lo que hace es guardar en variables los valores 
		/// de los campos agregados al form y cierra el objeto.
		/// </para>
		/// </summary>
		/// <returns>The save click.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void CmdSave_Click(object sender, EventArgs e)
		{
			var id = Form["id"].Value;
			var name = Form["name"].Value;

			Finish();
		}
	}
}