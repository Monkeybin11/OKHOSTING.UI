namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// It contains the events of Button.
	/// <para xml:lang="es">
	/// Contiene los eventos del Button.
	/// </para>
	/// </summary>
	public interface IButton: ITextControl, IClickable
	{
		string Text
		{
			get; set;
		}
	}
}