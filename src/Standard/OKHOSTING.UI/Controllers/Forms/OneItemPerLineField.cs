using OKHOSTING.Core;
using OKHOSTING.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OKHOSTING.UI.Controllers.Forms
{
	/// <summary>
	/// A field for IStringSerialized values
	/// <para xml:lang="es">
	/// Un campo para valores de cadena serializados.
	/// </para>
	/// </summary>
	public class OneItemPerLineField : StringField
	{
		/// <summary>
		/// The type of the string serializable.
		/// <para xml:lang="es">El tipo de la serialización de la cadena.</para>
		/// </summary>
		public readonly Type EnumerableType;

		/// <summary>
		/// Initializes a new instance of the StringSerializableField class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase StringSerializableField.</para>
		/// </summary>
		/// <param name="ienumerableType">String serializable type.</param>
		public OneItemPerLineField(Form form, Type ienumerableType) : base(form)
		{
			if (ienumerableType == null)
			{
				throw new ArgumentNullException(nameof(ienumerableType));
			}

			if (!ienumerableType.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IEnumerable)))
			{
				throw new ArgumentOutOfRangeException(nameof(ienumerableType), "Type does not implement IEnumerable interface");
			}

			EnumerableType = ienumerableType;
		}

		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">Obtiene o establece el valor a serializar.</para>
		/// </summary>
		/// <value>The value.</value>
		public override object Value
		{
			get
			{
				Type itemType = EnumerableType.GetEnumerableItemType();
				IList values = (IList) typeof(List<>).MakeGenericType(itemType).CreateInstance();

				if (string.IsNullOrWhiteSpace(ValueControl.Value))
				{
					return values;
				}

				foreach (var line in ValueControl.Value.Split('\n'))
				{
					values.Add(Data.Convert.ToObject(line, itemType));
				}

				return values;
			}
			set
			{
				if (value == null)
				{
					ValueControl.Value = null;
				}
				else
				{
					StringBuilder sb = new StringBuilder();

					foreach (var s in ((IEnumerable) value))
					{
						sb.AppendLine(Data.Convert.ToString(s));
					}

					ValueControl.Value = sb.ToString();
				}
			}
		}

		/// <summary>
		/// Gets the type of the value.
		/// <para xml:lang="es">Obtien el tipo del valor.</para>
		/// </summary>
		public override Type ValueType
		{
			get
			{
				return EnumerableType;
			}
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
	}
}
