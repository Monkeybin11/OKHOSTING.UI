using System;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Controls
{
	/// <summary>
	/// It represents the main platform where controls are housed.
	/// <para xml:lang="es">
	/// Representa la plataforma principal donde se alojan controles.
	/// </para>
	/// </summary>
	public class IndexController: Controller 
	{
		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">.
		/// Inicia la instancia de este objeto.
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			IStack stack = Core.BaitAndSwitch.Create<IStack>();

			ILabelButton lblAutocomplete = Core.BaitAndSwitch.Create<ILabelButton>();
			lblAutocomplete.BackgroundColor = Color.FromArgb(150, 100, 250, 80);
			lblAutocomplete.Text = "Autocomplete";
			lblAutocomplete.Click += (object sender, EventArgs e) => new AutocompleteController() { Page = Page }.Start();
			stack.Children.Add(lblAutocomplete);

			ILabelButton lblLabel = Core.BaitAndSwitch.Create<ILabelButton>();
			lblLabel.Text = "Label";
			lblLabel.Click += (object sender, EventArgs e) => new LabelController() { Page = Page }.Start();
			stack.Children.Add(lblLabel);

			ILabelButton lblLabelButton = Core.BaitAndSwitch.Create<ILabelButton>();
			lblLabelButton.Text = "Label Button";
			lblLabelButton.Click += (object sender, EventArgs e) => new LabelButtonController() { Page = Page }.Start();
			stack.Children.Add(lblLabelButton);

			ILabelButton lblButton = Core.BaitAndSwitch.Create<ILabelButton>();
			lblButton.Text = "Button";
			lblButton.Click += (object sender, EventArgs e) => new ButtonController() { Page = Page }.Start();
			stack.Children.Add(lblButton);

			ILabelButton lblHyperLink = Core.BaitAndSwitch.Create<ILabelButton>();
			lblHyperLink.Text = "HyperLink";
			lblHyperLink.Click += (object sender, EventArgs e) => new HyperLinkController() { Page = Page }.Start();
			stack.Children.Add(lblHyperLink);

			ILabelButton lblCheckbox = Core.BaitAndSwitch.Create<ILabelButton>();
			lblCheckbox.Text = "Checkbox";
			lblCheckbox.Click += (object sender, EventArgs e) => new CheckboxController() { Page = Page }.Start();
			stack.Children.Add(lblCheckbox);

			ILabelButton lblImage = Core.BaitAndSwitch.Create<ILabelButton>();
			lblImage.Text = "Image";
			lblImage.Click += (object sender, EventArgs e) => new ImageController() { Page = Page }.Start();
			stack.Children.Add(lblImage);

			ILabelButton lblImageButton = Core.BaitAndSwitch.Create<ILabelButton>();
			lblImageButton.Text = "ImageButton";
			lblImageButton.Click += (object sender, EventArgs e) => new ImageButtonController() { Page = Page }.Start();
			stack.Children.Add(lblImageButton);

			ILabelButton lblPasswordBox = Core.BaitAndSwitch.Create<ILabelButton>();
			lblPasswordBox.Text = "PasswordBox";
			lblPasswordBox.Click += (object sender, EventArgs e) => new PasswordTextBoxControler() { Page = Page }.Start();
			stack.Children.Add(lblPasswordBox);

			ILabelButton lblCalendar = Core.BaitAndSwitch.Create<ILabelButton>();
			lblCalendar.Text = "Calendar";
			lblCalendar.Click += (object sender, EventArgs e) => new CalendarController() { Page = Page }.Start();
			stack.Children.Add(lblCalendar);

			ILabelButton lblTextBox = Core.BaitAndSwitch.Create<ILabelButton>();
			lblTextBox.Text = "TextBox";
			lblTextBox.Click += (object sender, EventArgs e) => new TextBoxController() { Page = Page }.Start();
			stack.Children.Add(lblTextBox);

			ILabelButton lblTextArea = Core.BaitAndSwitch.Create<ILabelButton>();
			lblTextArea.Text = "TextArea";
			lblTextArea.Click += (object sender, EventArgs e) => new TextAreaController() { Page = Page }.Start();
			stack.Children.Add(lblTextArea);

			ILabelButton lblpkr = Core.BaitAndSwitch.Create<ILabelButton>();
			lblpkr.Text = "List_Picker";
			lblpkr.Click += (object sender, EventArgs e) => new ListPickerController() { Page = Page }.Start();
			stack.Children.Add(lblpkr);

			ILabelButton lblRelativePanel = Core.BaitAndSwitch.Create<ILabelButton>();
			lblRelativePanel.Text = "RelativePanel";
			lblRelativePanel.Click += (object sender, EventArgs e) => new RelativePanelController() { Page = Page }.Start();
			stack.Children.Add(lblRelativePanel);

			ILabelButton lblDatePicker = Core.BaitAndSwitch.Create<ILabelButton>();
			lblDatePicker.Text = "DatePicker";
			lblDatePicker.Click += (object sender, EventArgs e) => new DatePickerController() { Page = Page }.Start();
			stack.Children.Add(lblDatePicker);

			ILabelButton lblTimePicker = Core.BaitAndSwitch.Create<ILabelButton>();
			lblTimePicker.Text = "TimePicker";
			lblTimePicker.Click += (object sender, EventArgs e) => new TimePickerController() { Page = Page }.Start();
			stack.Children.Add(lblTimePicker);

			ILabelButton lblMenu = Core.BaitAndSwitch.Create<ILabelButton>();
			lblMenu.Text = "Menu";
			lblMenu.Click += (object sender, EventArgs e) => new MenuController() { Page = Page }.Start();
			stack.Children.Add(lblMenu);

			// Establishes the content and title of the page.
			Page.Title = "Choose one control/feature to test";
            Page.Content = stack;
        }
    }
}