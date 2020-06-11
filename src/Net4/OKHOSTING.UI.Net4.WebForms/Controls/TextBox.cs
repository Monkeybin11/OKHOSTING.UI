using System;
using System.Drawing;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// It represents a text box control.
	/// <para xml:lang="es">Representa un control de cuadro de texto.</para>
	/// </summary>
	public class TextBox : TextBoxBase, ITextBox, IInputControl
	{
		#region IInputControl

		/// <summary>
		/// Gets or sets the user imput value.
		/// <para xml:lang="es">Obtiene o establece el valor de entrada del usuario</para>
		/// </summary>
		/// <value>The input value.
		/// <para xml:lang="es">El valor de entrada.</para>
		/// </value>
		string IInputControl<string>.Value
		{
			get
			{
				return base.Text;
			}
			set
			{
				var changed = false;

				if (((ITextBox) this).Value != value)
				{
					changed = true;
				}

				base.Text = value;

				if (changed)
				{
					OnValueChanged();
				}
			}
		}

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">Ocurre cuando el valor fue cambiado.</para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		#endregion

		#region IWebInputControl

		void IInputControl.HandlePostBack()
		{
			string postedValue = Page?.Request.Form[ID] ?? string.Empty;
			((ITextBox) this).Value = postedValue;
		}

		protected void OnValueChanged()
		{
			ValueChanged?.Invoke(this, ((IInputControl<string>)this).Value);
		}

		#endregion

		/// <summary>
		/// Gets or sets the type of the user input textbox.
		/// <para xml:lang="es">Obtiene o establece el tipo de entrada del usuario al textbox.</para>
		/// </summary>
		/// <value>The type of the user input.</value>
		ITextBoxInputType ITextBox.InputType
		{
			get
			{
				//if not InputType is provided, the InputType back to the text.
				if (base.Attributes["type"] == null)
				{
					return ITextBoxInputType.Text;
				}

				//InputTypes
				switch (base.Attributes["type"])
				{
					case "date":
						return ITextBoxInputType.Date;

					case "datetime":
						return ITextBoxInputType.DateTime;

					case "email":
						return ITextBoxInputType.Email;

					case "number":
						return ITextBoxInputType.Number;

					case "tel":
						return ITextBoxInputType.Telephone;

					case "text":
						return ITextBoxInputType.Text;

					case "time":
						return ITextBoxInputType.Time;

					case "url":
						return ITextBoxInputType.Url;

					default:
						return ITextBoxInputType.Text;
				}
			}
			set
			{
				switch (value)
				{
					case ITextBoxInputType.Date:
					case ITextBoxInputType.DateTime:
						base.Attributes["type"] = "datetime-local";
						break;

					case ITextBoxInputType.Email:
						base.Attributes["type"] = "email";
						break;

					case ITextBoxInputType.Number:
						base.Attributes["type"] = "number";
						base.Attributes["step"] = "0.01";
						break;

					case ITextBoxInputType.Telephone:
						base.Attributes["type"] = "tel";
						break;

					case ITextBoxInputType.Text:
						base.Attributes["type"] = "text";
						break;

					case ITextBoxInputType.Time:
						base.Attributes["type"] = "time";
						break;

					case ITextBoxInputType.Url:
						base.Attributes["type"] = "url";
						break;

					default:
						base.Attributes["type"] = "text";
						break;
				}
			}
		}

		/// <summary>
		/// The text that appears when the TextBox is empty (in a lighter color), use it as an alternative to a using a separate label to indicate this TextBox expected input
		/// </summary>
		string ITextBox.Placeholder
		{
			get
			{
				return Attributes["placeholder"];
			}
			set
			{
				Attributes["placeholder"] = value;
			}
		}

		/// <summary>
		/// The font color of the Placeholder text
		/// </summary>
		Color ITextBox.PlaceholderColor
		{
			get;
			set;
		}

		/// <summary>
		/// Ons the pre render.
		/// <para xml:lang="es">Ocurre antes de cambiar el valor</para>
		/// </summary>
		/// <returns>The pre render.</returns>
		/// <param name="e">E.</param>
		protected override void OnPreRender(EventArgs e)
		{
			//AutoPostBack = ValueChanged != null;
			base.OnPreRender(e);
		}
	}
}