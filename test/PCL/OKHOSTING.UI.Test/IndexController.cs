using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Test
{
	public class IndexController: Controller
	{
		public override void Start()
		{
			base.Start();

			IGrid grid = Platform.Current.Create<IGrid>();
			grid.ColumnCount = 1;
			grid.RowCount = 3;

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

			Platform.Current.Page.Title = "Choose one control to test";
			Platform.Current.Page.Content = grid;
		}
	}
}