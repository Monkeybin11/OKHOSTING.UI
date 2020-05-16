using OKHOSTING.Core;
using OKHOSTING.UI.Builders.Editors;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Builders.Forms
{
	/// <summary>
	/// An item that will be displayed in the form
	/// <para xml:lang="es">Un elemento que se muestra en el formulario</para>
	/// </summary>
	public class Field
	{
		/// <summary>
		/// Id or programing-friendly name that you give to this field.
		/// A single form should not contain 2 fields with the same field
		/// <para xml:lang="es">
		/// El Id o el nombre que tu le das a este campo.
		/// En una misma instancia no deve contener dos campos con el mismo nombre.
		/// </para>
		/// </summary>
		public string Name;

		/// <summary>
		/// Editor that will allow display/update of a value
		/// </summary>
		public Editor Editor;

		/// <summary>
		/// Caption to be placed on top or besides the editor to signal to the user
		/// the field that this editor represents
		/// </summary>
		public ILabel Caption = BaitAndSwitch.Create<ILabel>();

		/// <summary>
		/// If set to true, this field must be set to 100% of the form's width and use a complete row for itself
		/// <para xml:lang="es">
		/// Si es verdadero, este campo deve estar ajustado al 100% del ancho del formulario y el uso de una fila, completada por si misma.
		/// </para>
		/// </summary>
		public bool TableWide;

		/// <summary>
		/// Category of the field. Used for grouping fields in the DataForm
		/// <para xml:lang="es">
		/// Categoria del campo. Se utiliza para agrupar campos en el DataForm.
		/// </para>
		/// </summary>
		public string Category;

		/// <summary>
		/// Gets or sets a value that defines the order in which fields appear on the DataForm
		/// <para xml:lang="es">
		/// Obtiene o establece un valor que define el orden en el que apareceran los campos en el DataForm.
		/// </para>
		/// </summary>
		public int SortOrder;

		/// <summary>
		/// Container form
		/// <para xml:lang="es">Form contenedor.</para>
		/// </summary>
		public Form Container;
	}
}
