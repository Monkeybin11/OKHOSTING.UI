using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A read-only field
	/// <para xml:lang="es">Un campo de solo lectura.</para>
	/// </summary>
	public class ReadOnlyField : FormField
	{
		/// <summary>
		/// Gets or sets the value control.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor del control.
		/// </para>
		/// </summary>
		public new ILabel ValueControl
		{
			get
			{
				return (ILabel) base.ValueControl;
			}
			protected set
			{
				base.ValueControl = value;
			}
		}

		/// <summary>
		/// Gets or sets the value.
		/// <para xml:lang="es">
		/// Obtiene o establece el valor del campo.
		/// </para>
		/// </summary>
		public override object Value
		{
			get
			{
				return ValueControl.Text;
			}
			set
			{
				ValueControl.Text = value?.ToString();
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
		/// Creates a read only value cell
		/// <para xml:lang="es">Crea una celda con valor de solo lectura.</para>
		/// </summary>
		protected override void CreateValueControl()
		{
			ValueControl = Platform.Current.Create<ILabel>();
		}
	}
}