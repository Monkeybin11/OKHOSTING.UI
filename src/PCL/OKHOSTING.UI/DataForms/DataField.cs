using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.DataForms
{
	public abstract class DataField<T>
	{
		/// <summary>
		/// Label that displays the name of the field
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Container form
		/// </summary>
		public DataForm Container { get; set; }

		/// <summary>
		/// Category of the field. Used for grouping fields in the DataForm
		/// </summary>
		public string Category { get; set; }

		/// <summary>
		/// If true, the current field cannot be left empty, validated in javascript
		/// </summary>
		public bool Required { get; set; }

		/// <summary>
		/// Gets or sets a value that defines the order in which fields appear on the DataForm
		/// </summary>
		public uint SortOrder { get; set; }

		/// <summary>
		/// Indicates wether all information written by the user has been succesfully validated or not
		/// </summary>
		public virtual bool IsValid
		{
			get
			{
				if (Required)
				{
					return !Value.Equals(default(T));
				}
				else
				{
					return true;
				}
			}
		}

		/// <summary>
		/// Type of value that this field will accept
		/// </summary>
		public Type ValueType
		{
			get
			{
				return typeof(T);
			}
		}

		/// <summary>
		/// The actual value that is "displayed to / modified by" the user
		/// </summary>
		public abstract T Value { get; set; }
	}
}