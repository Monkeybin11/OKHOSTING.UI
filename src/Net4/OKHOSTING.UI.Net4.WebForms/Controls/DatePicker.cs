using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// It is a control that represents a calendar
	/// <para xml:lang="es">Es un control que representa un calendario</para>
	/// </summary>
	public class DatePicker : TextBoxBase, IDatePicker, IInputControl
	{
		const string Format = "MM/dd/yyyy";

		public DatePicker()
		{
			//Attributes["pattern"] = @"(0[1-9]|1[0-9]|2[0-9]|3[01]).(0[1-9]|1[012]).[0-9]{4}";
			//Attributes["pattern"] = @"(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d";
			Attributes["placeholder"] = @"mm/dd/yyyy";
		}

		#region IInputControl

		/// <summary>
		/// Gets or sets the OKHOSTING.UI.Controls.IInputControl<System.DateTime?>. value.
		/// </summary>
		DateTime? IInputControl<DateTime?>.Value
		{
			get
			{
				var values = base.Text?.Split('/');

				try
				{
					return new DateTime(int.Parse(values[2]), int.Parse(values[0]), int.Parse(values[1]));
				}
				catch
				{
					return null;
				}
			}
			set
			{
				var changed = false;

				if (((IInputControl<DateTime?>) this).Value != value)
				{
					changed = true;
				}

				if (value != null)
				{
					base.Text = value.Value.ToString(Format);
				}
				else
				{
					base.Text = null;
				}

				if (changed)
				{
					OnValueChanged();
				}
			}
		}

		/// <summary>
		/// Occurs when value changed.
		/// </summary>
		public event EventHandler<DateTime?> ValueChanged;

		protected void OnValueChanged()
		{
			ValueChanged?.Invoke(this, ((IDatePicker)this).Value);
		}

		#endregion

		#region IWebInputControl

		bool IInputControl.CheckPostBack()
		{
			string postedValue = Page?.Request.Form[ID] ?? string.Empty;
			var values = postedValue?.Split('/');

			try
			{
				return ((IDatePicker) this).Value != new DateTime(int.Parse(values[2]), int.Parse(values[0]), int.Parse(values[1]));
			}
			catch 
			{
				return false;
			}
		}

		void IInputControl.HandlePostBack()
		{
			string postedValue = Page?.Request.Form[ID] ?? string.Empty;
			var values = postedValue?.Split('/');

			try
			{
				((IDatePicker)this).Value = new DateTime(int.Parse(values[2]), int.Parse(values[0]), int.Parse(values[1]));
			}
			catch { }
		}

		#endregion

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			string js = string.Format
			(
				@"
				<script type='text/javascript'>
					$(document).ready
					(
						function()
						{{
							$(""#{0}"").datepicker($.datepicker.regional[""en""]);
						}}
					);
				</script>"
			, ClientID
			);

			Page.ClientScript.RegisterStartupScript(GetType(), "datepicker_" + base.ClientID, js);
		}
	}
}