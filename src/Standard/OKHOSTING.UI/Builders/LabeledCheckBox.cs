using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;

namespace OKHOSTING.UI.Builders
{
	public class LabeledCheckBox : IBuilder<IFlow>
	{
		protected readonly IFlow Flow = BaitAndSwitch.Create<IFlow>();
		public readonly ICheckBox CheckBox = BaitAndSwitch.Create<ICheckBox>();
		public readonly ILabelButton Label = BaitAndSwitch.Create<ILabelButton>();
		
		public IFlow Control => Flow;

		IControl IBuilder.Control => Flow;

		public LabeledCheckBox(string labelText)
		{
			if (string.IsNullOrWhiteSpace(labelText))
			{
				throw new ArgumentNullException(nameof(labelText));
			}

			Label.Click += Label_Click;
			Label.Text = labelText;

			Flow.Children.Add(CheckBox);
			Flow.Children.Add(Label);
		}

		private void Label_Click(object sender, EventArgs e)
		{
			CheckBox.Value = !CheckBox.Value;
		}
	}
}