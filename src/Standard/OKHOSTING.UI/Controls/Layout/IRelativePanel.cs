namespace OKHOSTING.UI.Controls.Layout
{
	/// <summary>
	/// Inspired by UWP and Xamarin.Forms RelativePanel's
	/// <para xml:lang="es">
	/// Un RelativePanel inspirado por WPF y Xamarin.Forms
	/// </para>
	/// </summary>
	public interface IRelativePanel : IContainer
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
		void Add(IControl control, RelativePanelHorizontalContraint horizontalContraint, RelativePanelVerticalContraint verticalContraint, IControl referenceControl);
	}

	/// <summary>
	/// IRelativePanel extensions.
	/// <para xml:lang="es">
	/// Extencion del RelativePanel
	/// </para>
	/// </summary>
	public static class IRelativePanelExtensions
	{
		/// <summary>
		/// Adds a control to the panel and positions it using the constraints, relative to the container panel
		/// <para xml:lang="es">
		/// Agrega un control al panel y lo posiciona usando las restricciones, con relacion al panel contenedor.
		/// </para>
		/// </summary>
		/// <param name="control">
		/// Control to add and position to the panel.
		/// <para xml:lang="es">
		/// Control a agregar y posicionar al panel.
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
		/// Restriccion vertical a usar.
		/// </para>
		/// </param>
		public static void Add(this IRelativePanel panel, IControl control, RelativePanelHorizontalContraint horizontalContraint, RelativePanelVerticalContraint verticalContraint)
		{
			panel.Add(control, horizontalContraint, verticalContraint, null);
		}
	}

	/// <summary>
	/// Relative panel horizontal contraint.
	/// <para xml:lang="es">
	/// Restriccione horizontal del RelativePanel.
	/// </para>
	/// </summary>
	public enum RelativePanelHorizontalContraint
	{
		/// <summary>
		/// The horizontal center of the control is aligned with the horizontal center of the reference
		/// <para xml:lang="es">
		/// El centro horizontal del control es alineado con el centro horizontal de la referencia.
		/// </para>
		/// </summary>
		CenterWith,

		/// <summary>
		/// The left border of the control is aligned with the left border of the reference
		/// <para xml:lang="es">
		/// El borde izquierdo del control se alinea con el borde izquierdo de la referencia.
		/// </para>
		/// </summary>
		LeftWith,

		/// <summary>
		/// The right border of the control is aligned with the right border of the reference.
		/// <para xml:lang="es">
		/// El borde derecho del control es alineado con el borde derecho de la referencia.
		/// </para>
		/// </summary>
		RightWith,

		/// <summary>
		/// The right border of the control is aligned with the left border of the reference.
		/// <para xml:lang="es">
		/// El borde derecho del control es alineado con el borde izquierdo de la referencia.
		/// </para>
		/// </summary>
		LeftOf,

		/// <summary>
		/// The left border of the control is aligned with the right border of the reference.
		/// <para xml:lang="es">
		/// El borde izquierdo del control es alineado con el borde derecho de la referencia.
		/// </para>
		/// </summary>
		RightOf,
	}

	/// <summary>
	/// Relative panel vertical contraint.
	/// <para xml:lang="es">
	/// Restriccion vertical del RelativePanel.
	/// </para>
	/// </summary>
	public enum RelativePanelVerticalContraint
	{
		/// <summary>
		/// The vertical center of the control is aligned with the vertical center of the reference.
		/// <para xml:lang="es">
		/// El centro vertical del control es alineado con el centro vertical de la referencia.
		/// </para>
		/// </summary>
		CenterWith,

		/// <summary>
		/// The top border of the control is aligned with the top border of the reference.
		/// <para xml:lang="es">
		/// El borde superior del control es alineado con el borde superior de la referencia.
		/// </para>
		/// </summary>
		TopWith,

		/// <summary>
		/// The bottom border of the control is aligned with the bottom border of the reference.
		/// <para xml:lang="es">
		/// El borde inferior del control es alineado con el borde inferior de la referencia.
		/// </para>
		/// </summary>
		BottomWith,

		/// <summary>
		/// The bottom border of the control is aligned with the top border of the reference.
		/// <para xml:lang="es">
		/// El borde inferior del control es alineado con el borde inferior de la referencia.
		/// </para>
		/// </summary>
		AboveOf,

		/// <summary>
		/// The top border of the control is aligned with the bottom border of the reference.
		/// <para xml:lang="es">
		/// El borde superior del control es alineado con el borde inferior de la referencia.
		/// </para>
		/// </summary>
		BelowOf,
	}
}