using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A read-only field
	/// <para xml:lang="es">Un campo de solo lectura.</para>
	/// </summary>
	public class ActivateOnClickEditor : Editor<Controls.Layout.IStack, string>
	{
		public readonly ILabelButton LabelButton;
		public readonly Editor RealEditor;

		public ActivateOnClickEditor(Editor realEditor)
		{
			if (realEditor == null)
			{
				throw new ArgumentNullException(nameof(realEditor));
			}

			RealEditor = realEditor;
			LabelButton = BaitAndSwitch.Create<ILabelButton>();
			LabelButton.Click += labelButton_Click;

			//make real editor invisible until the label is clicked
			RealEditor.Control.Visible = false;

			//add both controls to the stack
			Control.Children.Add(LabelButton);
			Control.Children.Add(RealEditor.Control);
		}

		/// <summary>
		/// Makes labelButton invisible and the real editor si shown
		/// </summary>
		private void labelButton_Click(object sender, System.EventArgs e)
		{
			LabelButton.Visible = false;
			RealEditor.Control.Visible = true;
		}

		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			return RealEditor.Value;
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			RealEditor.Value = value;
			LabelButton.Text = value?.ToString();
		}
	}
}