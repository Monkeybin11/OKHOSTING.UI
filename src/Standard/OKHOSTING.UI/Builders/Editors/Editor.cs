using OKHOSTING.Core;
using OKHOSTING.Data.Validation;
using System;

namespace OKHOSTING.UI.Builders.Editors
{
	public abstract class Editor : IDisposable, IBuilder
	{
		public virtual IControl Control { get; protected set; }

		/// <summary>
		/// Value selected by the user
		/// <para xml:lang="es">El valor seleccionado por el usuario.</para>
		/// </summary>
		public virtual object Value
		{
			get
			{
				return GetValue();
			}
			set
			{
				SetValue(value);
			}
		}

		/// <summary>
		/// If true, the current field cannot be left empty, validated in javascript
		/// <para xml:lang="es">
		/// Si es verdadero, el campo actual no puede dejarse vacío, la validacion es en javascript.
		/// </para>
		/// </summary>
		public virtual bool Required { get; set; }

		/// <summary>
		/// Indicates wether all information written by the user has been succesfully validated or not
		/// <para xml:lang="es">
		/// Indica si toda la informacion escrita por el usuario se ha validado o no con exito.
		/// </para>
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

		public void Dispose()
		{
			Control?.Dispose();
		}

		/// <summary>
		/// Actually gets the value out of the editor Control
		/// </summary>
		/// <returns></returns>
		protected abstract object GetValue();

		/// <summary>
		/// Sets the editor control with the given value
		/// </summary>
		protected abstract void SetValue(object value);
	}

	/// <summary>
	/// An item that will be displayed in the dataform
	/// <para xml:lang="es">Un elemento que se muestra en el dataform</para>
	/// </summary>
	public abstract class Editor<TControl, TValue> : Editor, IBuilder<TControl> where TControl : IControl
	{
		public Editor()
		{
			base.Control = BaitAndSwitch.Create<TControl>();
		}

		public new TControl Control
		{
			get
			{
				return (TControl) base.Control;
			}
			protected set
			{
				base.Control = value;
			}
		}
		
		/// <summary>
		/// Value selected by the user
		/// <para xml:lang="es">El valor seleccionado por el usuario.</para>
		/// </summary>
		public new virtual TValue Value
		{
			get
			{
				return (TValue) base.Value;
			}
			set
			{
				base.Value = value;
			}
		}
	}
}