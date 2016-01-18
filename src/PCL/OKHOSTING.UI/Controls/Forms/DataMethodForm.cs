using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A form used to retrieve all parameters necessary for executing a DataMethod
	/// </summary>
	public class DataMethodForm: DataForm
	{
		/// <summary>
		/// Adds a field for every argument that the DataMethos needs in order to be invoked
		/// </summary>
		/// <param name="dmethod">DataMethod which parameters will be used as fields</param>
		public void AddFieldsFrom(DataMethod dmethod)
		{
			uint order = 0;
			if (dmethod == null) throw new ArgumentNullException("dmethod");

			//add a field for each parameter
			foreach (ParameterInfo param in dmethod.InnerMember.GetParameters())
			{
				FormField field;

				field = FormField.CreateFieldFrom(param.ParameterType);
				
				//set common values
				field.Container = this;
				field.Id = param.Name;
				field.Required = true;
				field.Text = OKHOSTING.Softosis.Core.Globalization.Translator.Current[dmethod.FullName + "." + param.Name];
				field.SortOrder = order++;
				Fields.Add(field);
			}
		}

		/// <summary>
		/// Copies all field values to a list of objects that will be used as parameters to invoke a DataMethod
		/// </summary>
		/// <param name="parameters">List of objects that will be used as parameters to invoke a DataMethod</param>
		public void CopyParametersTo(List<object> parameters)
		{
			//validate arguments
			if (parameters == null) throw new ArgumentNullException("dvalues");

			//search corresponding field for this DataValueInstance
			foreach (FormField f in Fields)
			{
				f.RetrieveUserInput();
				f.ControlToValue();
				parameters.Add(f.Value);
			}
		}
	}
}
