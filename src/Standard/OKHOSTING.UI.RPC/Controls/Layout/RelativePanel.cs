using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.RPC.Controls.Layout
{
	/// <summary>
	/// Inspired by UWP and Xamarin.Forms RelativePanel's
	/// <para xml:lang="es">
	/// Un RelativePanel inspirado por WPF y Xamarin.Forms
	/// </para>
	/// </summary>
	public class RelativePanel : Container, IRelativePanel
	{
		/// <summary>
		/// Adds a control to the panel and positions it using the constraints and references given
		/// <para xml:lang="es">
		/// Agrega un control al panel y le posiciona el uso de las restricciones y referencias dadas.
		/// </para>
		/// </summary>
		/// <param name="control">
		/// Control to add and position to the panel
		/// <para xml:lang="es">
		/// Control a agregar y posicionar al apnel.
		/// </para>
		/// </param>
		/// <param name="horizontalContraint">
		/// Horizontal constraint to use
		/// <para xml:lang="es">
		/// Restriccion horizontal a usar.
		/// </para>
		/// </param>
		/// <param name="verticalContraint">
		/// Vertical constraint to use
		/// <para xml:lang="es">
		/// Restriccion vertical a usar
		/// </para>
		/// </param>
		/// <param name="referenceControl">
		/// Control that will be used as a reference for the vertical and horizontal constriant. 
		/// If value is NULL, then the reference will be the panel itself
		/// <para xml:lang="es">
		/// Control que se utiliza como referencia para la restriccion vertical y horizontal.
		/// Si el valor es nulo, la referencia sera el propio panel.
		/// </para>
		/// </param>
		public void Add(IControl control, RelativePanelHorizontalContraint horizontalContraint, RelativePanelVerticalContraint verticalContraint, IControl referenceControl)
		{
			throw new System.NotImplementedException();
		}
	}
}