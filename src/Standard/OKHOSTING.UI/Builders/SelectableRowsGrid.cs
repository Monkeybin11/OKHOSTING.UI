using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System.Collections.Generic;

namespace OKHOSTING.UI.Builders
{
	public class SelectableRowsGrid: IBuilder<IGrid>
	{
		protected readonly IGrid Grid;

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

		public SelectableRowsGrid(IGrid grid, CheckBoxesPosition checkBoxesPosition, bool firstCheckSelectsAll)
		{
			Grid = grid;
			int checkBoxesColumn = 0;

			if (checkBoxesPosition == CheckBoxesPosition.Right)
			{
				checkBoxesColumn = grid.ColumnCount - 1;
			}

			CheckBoxes = new ICheckBox[grid.RowCount];

			for (int row = 0; row < grid.RowCount; row++)
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