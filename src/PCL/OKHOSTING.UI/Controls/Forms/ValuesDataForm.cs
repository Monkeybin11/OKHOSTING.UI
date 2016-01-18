using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A dataForm that creates fields automatically for a DataValue conllection
	/// </summary>
	public class ValuesDataForm: DataForm
	{
		/// <summary>
		/// Creates a collection of fields for displaying a collection of DataValues
		/// </summary>
		public void AddFieldsFrom(List<DataValue> dvalues)
		{
			//if there's no values defined, exit
			if (dvalues == null) throw new ArgumentNullException("dvalues");

			//create fields
			foreach (DataValue dv in dvalues)
			{
				AddFieldFrom(dv);
			}
		}

		/// <summary>
		/// Creates a field for a DataValue
		/// </summary>
		public void AddFieldFrom(DataValue dvalue)
		{
			//if there's no values defined, exit
			if (dvalue == null) throw new ArgumentNullException("dvalue");

			//field
			FormField field;
			field = FormField.CreateFieldFrom(dvalue);

			//set container
			field.Container = this;

			//add to fields collection
			Fields.Add(field);
		}

		/// <summary>
		/// Returns the field that corresponds to this DataValue
		/// </summary>
		public FormField GetFieldFor(DataValue dvalue)
		{
			//if there's no values defined, exit
			if (dvalue == null) throw new ArgumentNullException("dvalue");

			//search corresponding field for this DataValue
			foreach (FormField f in Fields)
			{
				if (f.Id == dvalue.Name)
				{
					//return this field
					return f;
				}
			}

			//nothing was found
			return null;
		}

		/// <summary>
		/// Copies all values entered by the user to a DavaValueInstance collection
		/// </summary>
		/// <param name="dvalues">Collection where values will be copied to</param>
		public void CopyValuesTo(List<DataValueInstance> dvalues)
		{
			//validate arguments
			if (dvalues == null) throw new ArgumentNullException("dvalues");

			
			//create fields
			foreach (DataValueInstance dv in dvalues)
			{
				//search corresponding field for this DataValueInstance
				foreach (FormField f in Fields)
				{
					if (f.Id == dv.DataValue.Name)
					{
						//assing value
						dv.Value = TypeConverter.ChangeType(f.Value, dv.DataValue.ValueType);
					}
				}
			}
		}

		/// <summary>
		/// Gets values from a DavaValueInstance collection and applies them to the current fields
		/// </summary>
		/// <param name="dvalues">Collection where values will be copied to</param>
		public void CopyValuesFrom(List<DataValueInstance> dvalues)
		{
			//validate arguments
			if (dvalues == null) throw new ArgumentNullException("dvalues");

			//create fields
			foreach (DataValueInstance dv in dvalues)
			{
				//search corresponding field for this DataValueInstance
				foreach (FormField f in Fields)
				{
					if (f.Id == dv.DataValue.Name)
					{
						//assing value
						f.Value = dv.Value;
					}
				}
			}
		}
	}
}
