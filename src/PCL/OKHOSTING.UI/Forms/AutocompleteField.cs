using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Forms
{
	/// <summary>
	/// A form field that uses an autocomplete for data input
	/// <para xml:lang="es">Un campo de formulario que utiliza una función de autocompletar para la entrada de datos</para>
	/// </summary>
	public class AutocompleteField : FormField
	{
		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">Obtiene o establece el valor</para>
		/// </summary>
		/// <value>The value.</value>
		public override object Value
		{
			get
			{
				return ValueControl.Value;
			}
			set
			{
				if(value == null)
				{
					ValueControl.Value = null;
				}
				else
				{
					ValueControl.Value = value.ToString();
				}
			}
		}

		/// <summary>
		/// Control that parses the value to web
		/// <para xml:lang="es">Control que analiza el valor de Web</para>
		/// </summary>
		public new IAutocomplete ValueControl
		{
			get
			{
				return (IAutocomplete) base.ValueControl;
			}
			protected set
			{
				base.ValueControl = value;
			}
		}

		/// <summary>
		/// Gets the type of the value.
		/// <para xml:lang="es">Obtiene el tipo del valor.</para>
		/// </summary>
		/// <value>The type of the value.</value>
		public override Type ValueType
		{
			get
			{
				return typeof(string);
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">Crea los controles para visualizar el campo</para>
		/// </summary>
		protected override void CreateValueControl()
		{
			ValueControl = Platform.Current.Create<IAutocomplete>();
		}
	}
}