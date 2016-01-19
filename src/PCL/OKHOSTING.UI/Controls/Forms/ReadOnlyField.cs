using System;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A read-only field
	/// </summary>
	public class ReadOnlyField : FormField
	{
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

		public override object Value
		{
			get
			{
				return ValueControl.Text;
			}
			set
			{
				ValueControl.Text = (string) value;
			}
		}

		public override Type ValueType
		{
			get
			{
				return typeof(string);
			}
		}

		/// <summary>
		/// Creates a read only value cell
		/// </summary>
		protected override void CreateValueControl()
		{
			ValueControl = Platform.Current.Create<ILabel>();
		}
	}
}