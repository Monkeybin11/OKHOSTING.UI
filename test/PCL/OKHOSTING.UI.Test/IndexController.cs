using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	public class IndexController: Controller
	{
		public override void Start()
		{
			base.Start();

			
			IGrid grid = Platform.Current.Create<IGrid>();
			grid.ColumnCount = 1;
			grid.RowCount = 20;
			//grid.SetHeight();

			ILabelButton lblAutocomplete = Platform.Current.Create<ILabelButton>();
			lblAutocomplete.Text = "Autocomplete";
			lblAutocomplete.Click += (object sender, EventArgs e) => new AutocompleteController().Start();
			grid.SetContent(0, 0, lblAutocomplete);

			ILabelButton lblLabel = Platform.Current.Create<ILabelButton>();
			lblLabel.Text = "Label";
			lblLabel.Click += (object sender, EventArgs e) => new LabelController().Start();
			grid.SetContent(1, 0, lblLabel);

			ILabelButton lblLabelButton = Platform.Current.Create<ILabelButton>();
			lblLabelButton.Text = "Label Button";
			lblLabelButton.Click += (object sender, EventArgs e) => new LabelButtonController().Start();
			grid.SetContent(2, 0, lblLabelButton);

			ILabelButton lblButton = Platform.Current.Create<ILabelButton>();
			lblButton.Text = "Button";
			lblButton.Click += (object sender, EventArgs e) => new ButtonController().Start();
			grid.SetContent(3, 0, lblButton);

			ILabelButton lblHyperLink = Platform.Current.Create<ILabelButton>();
			lblHyperLink.Text = "HyperLink";
			//lblHyperLink.Click += (object sender, EventArgs e) => new HyperLinkController().Start();
			grid.SetContent(4, 0, lblHyperLink);


			ILabelButton lblCheckbox = Platform.Current.Create<ILabelButton>();
			lblCheckbox.Text = "Checkbox";
			lblCheckbox.Click += (object sender, EventArgs e) => new CheckboxController().Start();
			grid.SetContent(5, 0, lblCheckbox);

			ILabelButton lblImage = Platform.Current.Create<ILabelButton>();
			lblImage.Text = "Image";
			lblImage.Click += (object sender, EventArgs e) => new ImageController().Start();
			grid.SetContent(6, 0, lblImage);

			ILabelButton lblImageButton = Platform.Current.Create<ILabelButton>();
			lblImageButton.Text = "ImageButton";
			lblImageButton.Click += (object sender, EventArgs e) => new ImageButtonController().Start();
			grid.SetContent(7, 0, lblImageButton);

			ILabelButton lblPasswordBox = Platform.Current.Create<ILabelButton>();
			lblPasswordBox.Text = "PasswordBox";
			lblPasswordBox.Click += (object sender, EventArgs e) => new PasswordTextBoxControler().Start();
			grid.SetContent(8, 0, lblPasswordBox);

			ILabelButton lblCalendar = Platform.Current.Create<ILabelButton>();
			lblCalendar.Text = "Calendar";
			lblCalendar.Click += (object sender, EventArgs e) => new CalendarController().Start();
			grid.SetContent(9, 0, lblCalendar);

			ILabelButton lblarea = Platform.Current.Create<ILabelButton>();
			lblarea.Text = "Text_Area";
			lblarea.Click += (object sender, EventArgs e) => new TextAreaController().Start();
			grid.SetContent(10, 0, lblarea);

			ILabelButton lblpkr = Platform.Current.Create<ILabelButton>();
			lblpkr.Text = "List_Picker";
			lblpkr.Click += (object sender, EventArgs e) => new ListPickerController().Start();
			grid.SetContent(11, 0, lblpkr);
			
			ILabelButton lblRelativePanel = Platform.Current.Create<ILabelButton>();
			lblRelativePanel.Text = "RelativePanel";
			lblRelativePanel.Click += (object sender, EventArgs e) => new RelativePanelController().Start();
			grid.SetContent(12, 0, lblRelativePanel);

			ILabelButton lblForm = Platform.Current.Create<ILabelButton>();
			lblForm.Text = "Form";
			lblForm.Click += (object sender, EventArgs e) => new FormController().Start();
			grid.SetContent(13, 0, lblForm);

			Platform.Current.Page.Title = "Choose one control to test";
			Platform.Current.Page.Content = grid;
			

		}
	 }
}