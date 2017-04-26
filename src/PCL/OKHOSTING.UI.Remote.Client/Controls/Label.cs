using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Client.Controls
{
	/// <summary>
	/// It represents a text label
	/// <para xml:lang="es">Representa una etiqueta de texto</para> 
	/// </summary>
	public class Label : TextControl, ILabel
	{
		/// <summary>
		/// Gets or sets the text of this Label. Also converts from text to html formated text 
		/// <para xml:lang="es">Obtiene o establece el texto de esta etiqueta. Tambien convierte de texto a texto en formato HTML.</para>
		/// </summary>
		public string Text
		{
			get;
			set;
		}
	}
}