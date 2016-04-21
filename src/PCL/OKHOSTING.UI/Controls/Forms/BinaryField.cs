using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Field for binary values (byte[])
	/// </summary>
	public class BinaryField: FormField
	{
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

		public override object Value
		{
			get
			{
				return PCLCrypto.WinRTCrypto.CryptographicBuffer.DecodeFromBase64String(ValueControl.Value);
			}
			set
			{
				if (value == null)
				{
					ValueControl.Value = null;
				}
				else
				{
					ValueControl.Value = PCLCrypto.WinRTCrypto.CryptographicBuffer.EncodeToBase64String((byte[]) value);
				}
			}
		}

		public override Type ValueType
		{
			get
			{
				return typeof(byte[]);
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			ValueControl = Platform.Current.Create<ITextArea>();
		}
	}
}