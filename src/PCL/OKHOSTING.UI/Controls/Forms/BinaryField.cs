using System;
using static OKHOSTING.Core.StringExtensions;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Field for binary values (byte[])
	/// <para xml:lang="es">Campo para valores binarios (byte[]).</para>
	/// </summary>
	public class BinaryField: FormField
	{
		/// <summary>
		/// Gets or sets the value control.
		/// <para xml:lang="es">Obtiene o establece el valor del control</para>
		/// </summary>
		/// <value>The value control.
		/// <para xml:lang="es">El valor del control.</para>
		/// </value>
		public new IInputControl<string> ValueControl
		{
			get
			{
				return (IInputControl<string>) base.ValueControl;
			}
			protected set
			{
				base.ValueControl = value;
			}
		}

		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">Obtiene o establece el valor.</para>
		/// </summary>
		/// <value>The value.</value>
		public override object Value
		{
			get
			{
				return ValueControl.Value.FromBase64ToBytes();
			}
			set
			{
				if (value == null)
				{
					ValueControl.Value = null;
				}
				else
				{
					ValueControl.Value = ((byte[]) value).FromBytesToBase64();
				}
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
				return typeof(byte[]);
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// <para xml:lang="es">Crea los controles para visualizar el campo.</para>
		/// </summary>
		protected override void CreateValueControl()
		{
			ValueControl = Platform.Current.Create<ITextArea>();
		}
	}
}