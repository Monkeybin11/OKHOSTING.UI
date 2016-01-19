using OKHOSTING.Data.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// An item that will be displayed in the dataform
	/// </summary>
	public abstract class FormField
	{
		#region Public properties

		//abstract

		/// <summary>
		/// The type of value that this field will show/accept
		/// </summary>
		public abstract Type ValueType { get; }

		/// <summary>
		/// Value selected by the user
		/// </summary>
		public abstract object Value { get; set; }

		//non abstract

		/// <summary>
		/// Id or programing-friendly name that you give to this field.
		/// A single form should not contain 2 fields with the same field
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// Label that shows the caption or name for this field
		/// </summary>
		public virtual ILabel CaptionControl { get; protected set; }

		/// <summary>
		/// Control that parses the value to web
		/// </summary>
		public virtual IControl ValueControl { get; protected set; }

		/// <summary>
		/// If set to true, this field must be set to 100% of the form's width and use a complete row for itself
		/// </summary>
		public virtual bool TableWide { get; set; }

		/// <summary>
		/// Container form
		/// </summary>
		public virtual Form Container { get; set; }

		/// <summary>
		/// Category of the field. Used for grouping fields in the DataForm
		/// </summary>
		public virtual string Category { get; set; }

		/// <summary>
		/// Gets or sets a value that defines the order in which fields appear on the DataForm
		/// </summary>
		public virtual uint SortOrder { get; set; }

		/// <summary>
		/// If true, the current field cannot be left empty, validated in javascript
		/// </summary>
		public virtual bool Required { get; set; }

		#endregion

		#region Methods

		//abstract

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected abstract void CreateValueControl();

		//non abstract

		/// <summary>
		/// Indicates wether all information written by the user has been succesfully validated or not
		/// </summary>
		public virtual bool IsValid
		{
			get
			{
				if (Required)
				{
					return new RequiredValidator().Validate(Value) == null;
				}
				else
				{
					return true;
				}
			}
		}

		/// <summary>
		/// Returns the field's Id
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (CaptionControl == null)
			{
				return null;
			}
			else
			{
				return CaptionControl.Text;
			}
		}

		#endregion
	}
}