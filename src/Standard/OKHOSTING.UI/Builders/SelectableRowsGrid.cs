using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System.Collections.Generic;

namespace OKHOSTING.UI.Builders
{
	public class SelectableRowsGrid: IBuilder<IGrid>
	{
		protected readonly IGrid Grid = BaitAndSwitch.Create<IGrid>();

		public ICheckBox[] CheckBoxes
		{
			get;
			protected set;
		}

		public IEnumerable<int> SelectedIndexes
		{
			get
			{
				for (int row = 0; row < Control.RowCount; row++)
				{
					if (CheckBoxes[row].Value)
					{
						yield return row;
					}
				}
			}
		}

		public SelectableRowsGrid(int rows, int columns, CheckBoxesPosition checkBoxesPosition, bool firstCheckSelectsAll)
		{
			Grid.RowCount = rows;
			Grid.ColumnCount = columns + 1;
			int checkBoxesColumn = 0;

			if (checkBoxesPosition == CheckBoxesPosition.Right)
			{
				checkBoxesColumn = columns - 1;
			}

			CheckBoxes = new ICheckBox[rows];

			for (int row = 0; row < rows; row++)
			{
				CheckBoxes[row] = BaitAndSwitch.Create<ICheckBox>();
				Grid.SetContent(row, checkBoxesColumn, CheckBoxes[row]);
			}

			if (firstCheckSelectsAll)
			{
				CheckBoxes[0].ValueChanged += firstCheckBox_ValueChanged;
			}
		}

		private void firstCheckBox_ValueChanged(object sender, bool e)
		{
			var firstCheckBox = (ICheckBox) sender;

			for (int row = 1; row < Control.RowCount; row++)
			{
				CheckBoxes[row].Value = firstCheckBox.Value;
			}
		}

		public IGrid Control => Grid;

		IControl IBuilder.Control => Grid;

		public enum CheckBoxesPosition
		{
			Left,
			Right,
		}
	}
}