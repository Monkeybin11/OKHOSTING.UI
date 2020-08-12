using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OKHOSTING.UI.Builders
{
	/// <summary>
	/// A grid that has rows with child rows, and the child rows are shown when the user
	/// clicks the "expand" button on the parent row
	/// </summary>
	public class TreeGrid<T>: IBuilder<IGrid>
	{
		protected readonly IGrid Grid;

		/// <summary>
		/// The rows of this grid
		/// </summary>
		protected readonly List<Row> Rows;

		/// <summary>
		/// The ammount of pixels that a subrow will move to the right, compared to it's parent
		/// </summary>
		public int SubRowMargin { get; set; } = 20;

		/// <summary>
		/// The items that will be displayed, each as a row
		/// </summary>
		public readonly IEnumerable<T> ParentItems;

		IControl IBuilder.Control
		{
			get
			{
				return Grid;
			}
		}

		public IGrid Control
		{
			get
			{
				return Grid;
			}
		}

		public TreeGrid(IEnumerable<T> parentItems)
		{
			Grid = BaitAndSwitch.Create<IGrid>();
			ParentItems = parentItems;

			IControl[] headers = CreateHeaders().ToArray();
			
			Grid.ClearContent();
			Grid.ColumnCount = headers.Length;
			Grid.ShowGridLines = true;
			
			Rows = CreateParentRows().ToList();

			Grid.RowCount = Rows.Count + 1;

			//set first header with margin
			headers[0].Margin = new Thickness(SubRowMargin, 0, 0, 0);
			Grid.SetContent(0, 0, headers[0]);

			//set rest of the headers
			for (int column = 1; column < headers.Length; column++)
			{
				Grid.SetContent(0, column, headers[column]);
			}

			//set rows
			foreach (var row in Rows)
			{
				SetRowContent(row);
			}
		}

		/// <summary>
		/// Puts the contents of a row in the grid, using row.Index to locate the appropiate position
		/// </summary>
		protected virtual void SetRowContent(Row row)
		{
			int index = Rows.IndexOf(row);

			//create child rows if necessary
			if (row.Children == null)
			{
				CreateChildrenRows(row);
			}

			var children = row.Children?.ToArray();

			//create expand/collapse button 
			if (children != null && children.Length > 0 && row.ExpandButton == null)
			{
				row.ExpandButton = CreateExpandButton(row);
			}

			//set the content of the first column, including expand button if this row has children
			var first = row.GetFirstColumnContent();

			if (row.ExpandButton == null)
			{
				first.Margin = new Thickness(SubRowMargin * (row.Depth + 1), 0, 0, 0);
			}
			else
			{
				first.Margin = new Thickness(SubRowMargin * row.Depth, 0, 0, 0);
			}

			Grid.SetContent(index + 1, 0, first);

			//set content for the rest of the row
			var content = row.Content.ToArray();

			for (int column = 1; column < Grid.ColumnCount; column++)
			{
				Grid.SetContent(index + 1, column, content[column]);
			}
		}

		/// <summary>
		/// Returns the members that showld be dispolayed in the grid as columns
		/// </summary>
		protected virtual IEnumerable<MemberInfo> GetMembers()
		{ 
			return typeof(T).GetAllMemberInfos().Where(m => 
			(
				(m is FieldInfo && ((FieldInfo) m).IsPublic)
				|| 
				(m is PropertyInfo && ((PropertyInfo) m).GetMethod != null && ((PropertyInfo) m).GetMethod.IsPublic)
			)
			&& 
			!Data.MemberExpression.GetReturnType(m).IsCollection());
		}

		/// <summary>
		/// Returns the children items of a parent. 
		/// </summary>
		/// <remarks>
		/// Override this method to implement custom children loading, pe: files, database rows, etc.
		/// </remarks>
		protected virtual IEnumerable<T> GetChildren(T item)
		{
			var type = typeof(T);
			var enumerableType = typeof(IEnumerable<T>);
			var childrenMember = type.GetAllMemberInfos().Where(m => Data.MemberExpression.GetReturnType(m).IsAssignableFrom(enumerableType)).FirstOrDefault();

			if (childrenMember == null)
			{
				return null;
			}

			var children = (IEnumerable<T>) Data.MemberExpression.GetValue(childrenMember, item);
			return children;
		}
		
		#region Create controls

		/// <summary>
		/// Creates an expand/collapse button
		/// </summary>
		protected virtual ILabelButton CreateExpandButton(Row row)
		{
			var control = BaitAndSwitch.Create<ILabelButton>();
			control.Click += cmdExpand_Click;
			control.TextHorizontalAlignment = HorizontalAlignment.Center;
			control.TextVerticalAlignment = VerticalAlignment.Center;
			control.Tag = row;
			control.Width = SubRowMargin;

			if (row.Collapsed)
			{
				control.Text = "+";
			}
			else
			{ 
				control.Text = "-";
			}

			return control;
		}

		/// <summary>
		/// Creates the controls that will be placed at the top of the grid, displaying the column names
		/// </summary>
		protected virtual IEnumerable<IControl> CreateHeaders()
		{
			var members = GetMembers();

			foreach (var member in members)
			{
				yield return CreateHeader(member);
			}
		}

		/// <summary>
		/// Creates a control that will be placed at the top of the grid, displaying the member name
		/// </summary>
		protected virtual IControl CreateHeader(MemberInfo member)
		{
			var lblHeader = BaitAndSwitch.Create<ILabelButton>();
			lblHeader.Text = Translator.Translate(member);
			lblHeader.Click += lblHeader_Click;
			lblHeader.Tag = member;

			return lblHeader;
		}

		/// <summary>
		/// Creates a control to display the value of a member in a cell
		/// </summary>
		protected virtual IControl CreateCell(T item, MemberInfo member)
		{
			var content = BaitAndSwitch.Create<ILabelButton>();
			content.Click += content_Click;
			content.Text = Data.MemberExpression.GetValue(member, item)?.ToString();
			content.Tag = item;
			content.VerticalAlignment = VerticalAlignment.Center;

			return content;
		}

		/// <summary>
		/// Creates all initial rows, one for each of the parent items
		/// </summary>
		protected virtual IEnumerable<Row> CreateParentRows()
		{
			foreach (var item in ParentItems)
			{
				yield return CreateRow(item);
			}
		}

		/// <summary>
		/// Creates a row from one of the items
		/// </summary>
		protected virtual Row CreateRow(T item)
		{
			var row = new Row();
			row.Tag = item;
			row.Collapsed = true;

			var controls = new List<IControl>();
			var members = GetMembers();

			foreach (var member in members)
			{
				var content = CreateCell(item, member);
				
				if (content != null)
				{
					controls.Add(content);
				}
			}

			row.Content = controls;

			return row;
		}

		/// <summary>
		/// Creates the children rows of a parent
		/// </summary>
		protected virtual IEnumerable<Row> CreateChildrenRows(Row parent)
		{
			var newRows = new List<Row>();
			var childrenItems = GetChildren(parent.Tag);

			if (childrenItems == null)
			{
				parent.Children = newRows;
				return newRows;
			}

			foreach (var childItem in childrenItems)
			{
				var childRow = CreateRow(childItem);
				childRow.Parent = parent;
				childRow.Depth = parent.Depth + 1;

				newRows.Add(childRow);
			}

			parent.Children = newRows;
			return newRows;
		}

		#endregion

		#region Event handling

		protected virtual void cmdExpand_Click(object sender, EventArgs e)
		{
			var cmdExpand = (ILabelButton) sender;
			var row = (Row) cmdExpand.Tag;
			int index = Rows.IndexOf(row);
			var newCollapsedValue = !row.Collapsed;

			//from expanded to collapsed
			if (newCollapsedValue)
			{
				var children = row.RecursiveNonCollapsedChildern.ToArray();

				//delete rows that where collapsed
				foreach (var child in children)
				{
					int childIndex = Rows.IndexOf(child);
					Grid.ClearContentRow(childIndex + 1);
				}

				//delete rows from Rows collection
				foreach (var child in children)
				{
					Rows.Remove(child);
				}

				//move bottom content up
				var bottomCount = Grid.RowCount - children.Length - index - 2;

				for (int childIndex = 0; childIndex < bottomCount; childIndex++)
				{
					Grid.MoveRowContent(index + childIndex + children.Length + 2, index + childIndex + 2);
				}

				Grid.RowCount = Grid.RowCount - children.Length;
				row.Collapsed = newCollapsedValue;
				cmdExpand.Text = "+";
			}
			//from collapsed to expanded
			else
			{
				//create new rows if necessary
				if (row.Children == null)
				{
					CreateChildrenRows(row);
				}

				row.Collapsed = newCollapsedValue;

				var children = row.RecursiveNonCollapsedChildern.ToArray();
				var bottomCount = Grid.RowCount - index - 2;
				Grid.RowCount = Grid.RowCount + children.Length;

				//insert children to Rows colelction
				Rows.InsertRange(index + 1, children);

				//move content to the bottom
				for (int childIndex = bottomCount - 1; childIndex >= 0; childIndex--)
				{
					Grid.MoveRowContent(index + childIndex + 2, index + childIndex + children.Length + 2);
				}

				//insert the just expanded content
				foreach (var child in children)
				{
					SetRowContent(child);
				}

				cmdExpand.Text = "-";
			}
		}

		/// <summary>
		/// Raised when the user clicks aon a header
		/// </summary>
		protected virtual void lblHeader_Click(object sender, EventArgs e)
		{
		}

		protected virtual void content_Click(object sender, EventArgs e)
		{
		}

		#endregion

		#region Row class

		/// <summary>
		/// Represents a row in a TreeGrid, with optional children rows
		/// </summary>
		public class Row
		{
			/// <summary>
			/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
			/// <para xml:lang="es">
			/// Obtiene o establece un objeto de valor arbitrario que se puede usar para almacenar informacion personalizada sobre este elemento.
			/// </para>
			/// </summary>
			public T Tag { get; set; }

			/// <summary>
			/// Means how many parents this row has. The more parents, the more margin to the right
			/// </summary>
			public int Depth { get; set; }

			/// <summary>
			/// The expand button associated with this row, if it contains children. 
			/// </summary>
			/// <remarks>
			/// Might be null when the row has no children
			/// </remarks>
			public ILabelButton ExpandButton { get; set; }

			/// <summary>
			/// When true, the row will not display it's children. 
			/// When false, the children rows will be visible.
			/// </summary>
			public bool Collapsed { get; set; }

			/// <summary>
			/// Parent row
			/// </summary>
			public Row Parent { get; set; }

			/// <summary>
			/// The content that must be placed in the row, each control will be put in a column
			/// </summary>
			public IEnumerable<IControl> Content { get; set; }

			/// <summary>
			/// The children rows of this row, will be visible when collapsed is false, with a little padding to the right of the current row
			/// </summary>
			public IEnumerable<Row> Children { get; set; }

			public IEnumerable<Row> RecursiveChildern
			{
				get 
				{
					if (Children == null)
					{
						yield break;
					}

					foreach (var child in Children)
					{
						yield return child;

						foreach (var subChild in child.RecursiveChildern)
						{
							yield return subChild;
						}
					}
				}
			}

			public IEnumerable<Row> RecursiveNonCollapsedChildern
			{
				get
				{
					if (Collapsed || Children == null)
					{
						yield break;
					}

					foreach (var child in Children)
					{
						yield return child;

						foreach (var subChild in child.RecursiveNonCollapsedChildern)
						{
							yield return subChild;
						}
					}
				}
			}

			/// <summary>
			/// Returns the content that will be placed on the first column of this row.
			/// If the row contains children rows, an IFlow containing an expand button and the content
			/// of the first column will be returned, otherwise, just the content of the first column
			/// </summary>
			public IControl GetFirstColumnContent()
			{
				var flow = BaitAndSwitch.Create<IFlow>();

				if (ExpandButton != null)
				{
					flow.Children.Add(ExpandButton);
				}

				flow.Children.Add(Content.First());

				return flow;
			}
		}

		#endregion
	}
}