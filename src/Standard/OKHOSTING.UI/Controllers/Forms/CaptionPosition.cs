namespace OKHOSTING.UI.Controllers.Forms
{
	/// <summary>
	/// Determines wether the field's caption will be shown at the left or the top of the field's value
	/// <para xml:lang="es">Determina si el título del campo se muestra a la izquierda o la parte superior del valor del campo</para>
	/// </summary>
	public enum CaptionPosition
	{
		/// <summary>
		/// Put caption at the left of it's value
		/// <para xml:lang="es">Pone el titulo en la parte izquierda de su valor.</para>
		/// </summary>
		Left = 1,
		/// <summary>
		/// Put caption at the top of it's value
		/// <para xml:lang="es">Pone el titulo en la parte superior de su valor.</para>
		/// </summary>
		Top = 2,
	}
}