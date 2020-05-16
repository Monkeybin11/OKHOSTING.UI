using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.UI.Builders.Editors;
using OKHOSTING.UI.Builders.Forms;
using OKHOSTING.Core;

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

		ILabel lblMessage;

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia una instancia del objeto Form
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			// Inicialize an new intsance of the class IntegerField, with Name, Value and text especific and adds it to the Form
			Field intField = new Field();
			intField.Name = "id";
			intField.Editor = new IntegerEditor();
			intField.Editor.Value = 5;
			intField.Caption = BaitAndSwitch.Create<ILabel>();
			intField.Caption.Text = "id";
			intField.Editor.Required = true;
			intField.Container = Form;

			// Inicialize an new intsance of the class StringField, with Name, Value and text especific and adds it to the Form
			Field stringField = new Field();
			stringField.Editor = new TextBoxEditor<string>();
			stringField.Name = "name";
			stringField.Editor.Value = "";
			stringField.Caption = BaitAndSwitch.Create<ILabel>();
			stringField.Caption.Text = "name";
			stringField.Editor.Required = true;
			stringField.Container = Form;

			// Establishes the number of columns of the Form and the position of the captions.
			Form = new Form(new[] { intField, stringField }, 4, CaptionPosition.Left);

			// Creates the Button cmdSave with text specific, with the event also click.
			IButton cmdSave = BaitAndSwitch.Create<IButton>();
			cmdSave.Text = "Save";
			cmdSave.Click += CmdSave_Click;

			IButton cmdExit = BaitAndSwitch.Create<IButton>();
			cmdExit.Text = "Exit";
			cmdExit.Click += cmdExit_Click;

			lblMessage = BaitAndSwitch.Create<ILabel>();

			// Create a new Stack.
			IStack stack = BaitAndSwitch.Create<IStack>();
			stack.Children.Add(Form.Control);
			stack.Children.Add(cmdSave);
			stack.Children.Add(lblMessage);
			stack.Children.Add(cmdExit);

			// Establishes the content and title of the page
			Page.Title = "Form";
			Page.Content = stack;
		}

		private void cmdExit_Click(object sender, EventArgs e)
		{
			Finish();
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
			var id = Form["id"].Editor.Value;
			var name = Form["name"].Editor.Value;
			lblMessage.Text = $"id:{id} Value:{name}";
		}
	}
}