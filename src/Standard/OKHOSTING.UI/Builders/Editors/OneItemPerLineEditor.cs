using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// A field for IStringSerialized values
	/// <para xml:lang="es">
	/// Un campo para valores de cadena serializados.
	/// </para>
	/// </summary>
	public class OneItemPerLineEditor : TextAreaEditor<IEnumerable<object>>
	{
		/// <summary>
		/// The type of object that will be captured, one per line
		/// </summary>
		public readonly Type ItemType;

		public OneItemPerLineEditor(Type itemType)
		{
			if (itemType == null)
			{
				throw new ArgumentNullException(nameof(itemType));
			}

			ItemType = itemType;
		}

		/// <summary>
		/// Gets the is valid.
		/// <para xml:lang="es">Determina si el valor es valido.</para>
		/// </summary>
		public override bool IsValid
		{
			get
			{
				try
				{
					var instance = Value;
				}
				catch
				{
					return false;
				}

				return base.IsValid;
			}
		}

		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected override object GetValue()
		{
			List<object> values = new List<object>();

			if (string.IsNullOrWhiteSpace(Control.Value))
			{
				return values;
			}

			foreach (var line in Control.Value.Split('\n'))
			{
				values.Add(Data.Convert.ToObject(line, ItemType));
			}

			return values;
		}

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected override void SetValue(object value)
		{
			if (value == null)
			{
				Control.Value = null;
			}
			else
			{
				StringBuilder sb = new StringBuilder();

				foreach (var s in (IEnumerable) value)
				{
					sb.AppendLine(Data.Convert.ToString(s));
				}

				Control.Value = sb.ToString();
			}
		}
	}
}