using System;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.Ajax.Controls
{
	/// <summary>
	/// It represents a text label
	/// <para xml:lang="es">Representa una etiqueta de texto</para> 
	/// </summary>
	public class Label : TextControl, ILabel
	{
		string _Text;

		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = Core.StringExtensions.TextToHtml(value);
			}
		}

		public override void Dispose()
		{
			throw new NotImplementedException();
		}

		public override string Render()
		{
			return $"<span>{Text}</span>";
		}
	}
}