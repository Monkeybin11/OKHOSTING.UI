﻿using OKHOSTING.UI.Controls;
using System;
using System.Linq;

namespace OKHOSTING.UI.Net4.Console.Controls
{
	/// <summary>
	/// Represents a control that is autocomplete.
	/// <para xml:lang="es">Representa un control que es autocomplete.</para>
	/// </summary>
	public class Autocomplete : System.Web.UI.WebControls.Panel, IAutocomplete
	{
		/// <summary>
		/// The inner text box.
		/// <para xml:lang="es">El cuadro de tecxto</para>
		/// </summary>
		protected readonly TextBox InnerTextBox;

		/// <summary>
		/// The inner auto complete extender.
		/// <para xml:lang="es">La extencion del control autocomplete</para>
		/// </summary>
		protected readonly AjaxControlToolkit.AutoCompleteExtender InnerAutoCompleteExtender;

		/// <summary>
		/// The inner watermark extender.
		/// <para xml:lang="es">El texto con marca de agua del control.</para>
		/// </summary>
		protected readonly AjaxControlToolkit.TextBoxWatermarkExtender InnerWatermarkExtender;

		/// <summary>
		/// The session identifier.
		/// <para xml:lang="es">El identificador de la sesión</para>
		/// </summary>
		protected readonly string SessionId;

		/// <summary>
		/// Initializes a new instance of the OKHOSTING.UI.Net4.Console.Controls.Autocomplete class.
		/// <para xml:alng="es">Inicializa una nueva instacia de la clase OKHOSTING.UI.Net4.Console.Controls.Autocomplete</para>
		/// </summary>
		public Autocomplete()
		{
			//set a default id so we ensure the extender's TargetControlID is set
			InnerTextBox = (TextBox) Platform.Current.Create<ITextBox>();
			InnerTextBox.ID = "Autocomplete_InnerTextBox_" + new Random().Next();
			base.Controls.Add(InnerTextBox);

			//ajax autocompleter
			InnerAutoCompleteExtender = new AjaxControlToolkit.AutoCompleteExtender();
			InnerAutoCompleteExtender.ID = base.UniqueID + "_AutoCompleteExtender";
			InnerAutoCompleteExtender.TargetControlID = InnerTextBox.ID;
			InnerAutoCompleteExtender.UseContextKey = true;
			InnerAutoCompleteExtender.ServiceMethod = "Search";
			InnerAutoCompleteExtender.ServicePath = "/Services/AutoCompleteService.asmx";
			//InnerAutoCompleteExtender.CompletionListCssClass = "AutoComplete_List";
			//InnerAutoCompleteExtender.CompletionListItemCssClass = "AutoComplete_ListItem";
			InnerAutoCompleteExtender.EnableCaching = false;
			base.Controls.Add(InnerAutoCompleteExtender);

			//ajax watermark
			InnerWatermarkExtender = new AjaxControlToolkit.TextBoxWatermarkExtender();
			InnerWatermarkExtender.WatermarkText = "Search";
			InnerWatermarkExtender.ID = base.UniqueID + "_TextBoxWatermarkExtender";
			InnerWatermarkExtender.TargetControlID = InnerTextBox.ID;
			//InnerWatermarkExtender.WatermarkCssClass = "AutoComplete_Watermark";
			base.Controls.Add(InnerWatermarkExtender);

			//add a unique id to session so we can invoke OnSearching from a ashx page
			SessionId = "Autocomplete_" + new Random().Next();
			OKHOSTING.UI.Session.Current[SessionId] = this;
			InnerAutoCompleteExtender.ContextKey = SessionId;
		}

		/// <summary>
		/// Occurs when searching.
		/// <para xml:lang="es">Evento que ocurre al momento de buscar.</para>
		/// </summary>
		public event EventHandler<AutocompleteSearchEventArgs> Searching;

		/// <summary>
		/// IAs the utocomplete. on searching.
		/// <para xml:lang="es">Es la funcion de autocompletar al hacer la busqueda</para>
		/// </summary>
		/// <returns>The utocomplete. on searching.
		/// <para xml:lang="es">El autocompletar en la busqueda.</para>
		/// </returns>
		/// <param name="text">Text.
		/// <para xml:lang="es">El texto.</para>
		/// </param>
		AutocompleteSearchEventArgs IAutocomplete.OnSearching(string text)
		{
			AutocompleteSearchEventArgs e = new AutocompleteSearchEventArgs(text);

			Searching?.Invoke(this, e);

			return e;
		}

		/// <summary>
		/// Ons the pre render.
		/// <para xml:lang="es">Es el metodo que se ejectua antes de generar el control si es que hay un valor cambiado.</para>
		/// </summary>
		/// <param name="e">E.
		/// <para xml:lang="es">Eventos del objeto</para>
		/// </param>
		protected override void OnPreRender(EventArgs e)
		{
			InnerTextBox.AutoPostBack = ValueChanged != null;
			base.OnPreRender(e);
		}

		#region IInputControl

		/// <summary>
		/// Occurs when value changed.
		/// <para xml:lang="es">Es un evento que ocurre cuando se cambia el valor del texto</para>
		/// </summary>
		public event EventHandler<string> ValueChanged;

		/// <summary>
		/// Gets or sets the II nput control string value.
		/// <para xml:lang="es">Obtiene o establece el valor de la cadena en el control de entrada</para>
		/// </summary>
		/// <value>The II nput control string value.
		/// <para xml:lang="es">El valor de la cadena del contro,l de entrada</para>
		/// </value>
		string IInputControl<string>.Value
		{
			get
			{
				return InnerTextBox.Text;
			}
			set
			{
				InnerTextBox.Text = value;
			}
		}

		/// <summary>
		/// Raises the value changed.
		/// <para xml:lang="es">Detecta si hay un valor cambiado al momento de hacer el postback</para>
		/// </summary>
		/// <returns>The value changed.
		/// <para xml:lang="es">El valor cambiado.</para>
		/// </returns>
		protected internal void RaiseValueChanged()
		{
			ValueChanged?.Invoke(this, ((IInputControl<string>)this).Value);
		}

		#endregion

		#region IControl

		/// <summary>
		/// Gets or sets the name of the IC ontrol.
		/// <para xml:lang="es">Obtiene o establece el nombre del control</para>
		/// </summary>
		/// <value>The name of the IC ontrol.
		/// <para xml:lang="es">El nombre del control.</para>
		/// </value>
		string IControl.Name
		{
			get
			{
				return InnerTextBox.ID;
			}
			set
			{
				InnerTextBox.ID = value;
			}
		}

		/// <summary>
		/// Gets or sets the color of the IC ontrol. background.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del control.</para>
		/// </summary>
		/// <value>The color of the IC ontrol. background.
		/// <para xml:lang="es">El color de fondo del control.</para>
		/// </value>
		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Current.Parse(InnerTextBox.BackColor);
			}
			set
			{
				InnerTextBox.BackColor = Platform.Current.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the color of the IC ontrol. border.
		/// <para xml:lang="es">obtiene o establece el color del borde del control.</para>
		/// </summary>
		/// <value>The color of the IC ontrol. border.
		/// <para xml:lang="es">El color del borde del control</para>
		/// </value>
		Color IControl.BorderColor
		{
			get
			{
				return Platform.Current.Parse(InnerTextBox.BorderColor);
			}
			set
			{
				InnerTextBox.BorderColor = Platform.Current.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the width of the IC ontrol.
		/// <para xml:lang="es">Obtiene o establece el ancho del control</para>
		/// </summary>
		/// <value>The width of the IC ontrol.
		/// <para xml:lang="es">El ancho del control</para>
		/// </value>
		double? IControl.Width
		{
			get
			{
				if (InnerTextBox.Width.IsEmpty)
				{
					return null;
				}

				return InnerTextBox.Width.Value;
			}
			set
			{
				if (value.HasValue)
				{
					InnerTextBox.Width = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					InnerTextBox.Width = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		/// <summary>
		/// Gets or sets the height of the IC ontrol.
		/// <para xml:lang="es">Obtiene o establece la altura del control.</para>
		/// </summary>
		/// <value>The height of the IC ontrol.
		/// <para xml:lang="es">La altura del control</para>
		/// </value>
		double? IControl.Height
		{
			get
			{
				if (InnerTextBox.Height.IsEmpty)
				{
					return null;
				}

				return InnerTextBox.Height.Value;
			}
			set
			{
				if (value.HasValue)
				{
					InnerTextBox.Height = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					InnerTextBox.Height = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		/// <summary>
		/// Gets or sets the IC ontrol. margin.
		/// <para xml:lang="es">Obtiene o establece el margen del control.</para>
		/// </summary>
		/// <value>The IC ontrol. margin.
		/// <para xml:lang="es">El margen del control.</para>
		/// </value>
		Thickness IControl.Margin
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(InnerTextBox.Style["margin-left"], out left)) thickness.Left = left;
				if (double.TryParse(InnerTextBox.Style["margin-top"], out top)) thickness.Top = top;
				if (double.TryParse(InnerTextBox.Style["margin-right"], out right)) thickness.Right = right;
				if (double.TryParse(InnerTextBox.Style["margin-bottom"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) InnerTextBox.Style["margin-left"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) InnerTextBox.Style["margin-top"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) InnerTextBox.Style["margin-right"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) InnerTextBox.Style["margin-bottom"] = string.Format("{0}px", value.Bottom);
			}
		}

		/// <summary>
		/// Gets or sets the width of the IC ontrol. border.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del control.</para>
		/// </summary>
		/// <value>The width of the IC ontrol. border.
		/// <para xml:lang="es">El ancho del borde del control.</para>
		/// </value>
		Thickness IControl.BorderWidth
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(InnerTextBox.Style["border-left-width"], out left)) thickness.Left = left;
				if (double.TryParse(InnerTextBox.Style["border-top-width"], out top)) thickness.Top = top;
				if (double.TryParse(InnerTextBox.Style["border-right-width"], out right)) thickness.Right = right;
				if (double.TryParse(InnerTextBox.Style["border-bottom-width"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) InnerTextBox.Style["border-left-width"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) InnerTextBox.Style["border-top-width"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) InnerTextBox.Style["border-right-width"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) InnerTextBox.Style["border-bottom-width"] = string.Format("{0}px", value.Bottom);
			}
		}

		/// <summary>
		/// Gets or sets the IC ontrol. horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del control.</para>
		/// </summary>
		/// <value>The IC ontrol. horizontal alignment.
		/// <para xml:lang="es">La alineacion horizontal del control</para>
		/// </value>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				string cssClass = InnerTextBox.CssClass.Split().Where(c => c.StartsWith("horizontal-alignment")).SingleOrDefault();

				//if not horizontal alignment is provided, the alignment back to the left.
				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return HorizontalAlignment.Left;
				}

				//Verify the horizontal alignment provided.
				if (cssClass.EndsWith("left"))
				{
					return HorizontalAlignment.Left;
				}
				else if (cssClass.EndsWith("right"))
				{
					return HorizontalAlignment.Right;
				}
				else if (cssClass.EndsWith("center"))
				{
					return HorizontalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return HorizontalAlignment.Fill;
				}
				else
				{
					return HorizontalAlignment.Left;
				}
			}
			set
			{
				Platform.Current.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				Platform.Current.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the IC ontrol. vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical del cvontrol</para>
		/// </summary>
		/// <value>The IC ontrol. vertical alignment.
		/// <para xml:lang="es">La alineacion vertical del control</para>
		/// </value>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				string cssClass = InnerTextBox.CssClass.Split().Where(c => c.StartsWith("vertical-alignment")).SingleOrDefault();

				//if not vertical alignment is provided, the alignment back to the top.
				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return VerticalAlignment.Top;
				}

				//Verify the vertical alignment provided.
				if (cssClass.EndsWith("top"))
				{
					return VerticalAlignment.Top;
				}
				else if (cssClass.EndsWith("bottom"))
				{
					return VerticalAlignment.Bottom;
				}
				else if (cssClass.EndsWith("center"))
				{
					return VerticalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return VerticalAlignment.Fill;
				}
				else
				{
					return VerticalAlignment.Top;
				}
			}
			set
			{
				Platform.Current.RemoveCssClassesStartingWith(this, "vertical-alignment");
				Platform.Current.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">Obtiene o establece un valor de objeto arbitrario que puede ser usado para almacenar informacion personalizada sobre este elemento</para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.</para>
		/// </remarks>
		object IControl.Tag
		{
			get; set;
		}

		#endregion

		#region ITextControl

		/// <summary>
		/// Gets or sets the color of the IT ext control. font.
		/// <para xml:lang="es">Obtiene o establece el color del texto del control.</para>
		/// </summary>
		/// <value>The color of the IT ext control. font.
		/// <para xml:lang="es">El color del texto del control.</para>
		/// </value>
		Color ITextControl.FontColor
		{
			get
			{
				return Platform.Current.Parse(InnerTextBox.ForeColor);
			}
			set
			{
				InnerTextBox.ForeColor = Platform.Current.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets IT ext control. font family.
		/// <para xml:alng="es">Obtiene o establece la tipografia del texto del control.</para>
		/// </summary>
		/// <value>Tipografia del texto del control.</value>
		string ITextControl.FontFamily
		{
			get
			{
				return InnerTextBox.Font.Name;
			}
			set
			{
				InnerTextBox.Font.Name = value;
			}
		}

		/// <summary>
		/// Gets or sets the size of the IT ext control. font.
		/// <para xml:lang="es">Obtiene o establece el tamaño del texto del control</para>
		/// </summary>
		/// <value>The size of the IT ext control. font.
		/// <para xml:lamg="es">El tamaño del texto del control.</para>
		/// </value>
		double ITextControl.FontSize
		{
			get
			{
				return InnerTextBox.Font.Size.Unit.Value;
			}
			set
			{
				InnerTextBox.Font.Size = new System.Web.UI.WebControls.FontUnit(value, System.Web.UI.WebControls.UnitType.Pixel);
			}
		}

		/// <summary>
		/// Gets or sets IT ext control. bold.
		/// <para xml:lang="es">Obtiene o establece la existencia del texto del control en negritas</para>
		/// </summary>
		/// <value>IT ext control. bold.
		/// <para xml:lang="es">Texto en negritas del control.</para>
		/// </value>
		bool ITextControl.Bold
		{
			get
			{
				return InnerTextBox.Font.Bold;
			}
			set
			{
				InnerTextBox.Font.Bold = value;
			}
		}

		/// <summary>
		/// Gets or sets IT ext control. italic.
		/// <para xml:lang="es">Obtiene o establece la existencia de texto en italica.</para>
		/// </summary>
		/// <value>IT ext control. italic.
		/// <para xml:lang="es">Texto del control en italica.</para>
		/// </value>
		bool ITextControl.Italic
		{
			get
			{
				return InnerTextBox.Font.Italic;
			}
			set
			{
				InnerTextBox.Font.Italic = value;
			}
		}

		/// <summary>
		/// Gets or sets IT ext control. underline.
		/// <para xml:lang="es">Obtiene o establece el texto subrayado en el control.</para>
		/// </summary>
		/// <value>IT ext control. underline.
		/// <para xml:lang="es">Texto subrayado en el control.</para>
		/// </value>
		bool ITextControl.Underline
		{
			get
			{
				return InnerTextBox.Font.Underline;
			}
			set
			{
				InnerTextBox.Font.Underline = value;
			}
		}

		/// <summary>
		/// Gets or sets IT ext control. text horizontal alignment.
		/// <para xml:lang="es">Obtiene o establece la laineacion horizontal del texto del control.</para>
		/// </summary>
		/// <value>IT ext control. text horizontal alignment.
		/// <para xml:lang="es">La alineacion horizontal del texto del control.</para>
		/// </value>
		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{

			get
			{
				string cssClass = InnerTextBox.CssClass.Split().Where(c => c.StartsWith("text-horizontal-alignment")).SingleOrDefault();

				//if not text horizontal alignment is provided, the alignment back to the left.
				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return HorizontalAlignment.Left;
				}

				//Verify the text horizontal alignment provided.
				if (cssClass.EndsWith("left"))
				{
					return HorizontalAlignment.Left;
				}
				else if (cssClass.EndsWith("right"))
				{
					return HorizontalAlignment.Right;
				}
				else if (cssClass.EndsWith("center"))
				{
					return HorizontalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return HorizontalAlignment.Fill;
				}
				else
				{
					return HorizontalAlignment.Left;
				}
			}
			set
			{
				Platform.Current.RemoveCssClassesStartingWith(this, "text-horizontal-alignment");
				Platform.Current.AddCssClass(this, "text-horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets IT ext control. text vertical alignment.
		/// <para xml:lang="es">Obtiene o establece la laineacion vertical del texto del control.</para>
		/// </summary>
		/// <value>IT ext control. text vertical alignment.
		/// <para xml:lang="es">La alineacion vertical del texto del control</para>
		/// </value>
		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get
			{
				string cssClass = InnerTextBox.CssClass.Split().Where(c => c.StartsWith("text-vertical-alignment")).SingleOrDefault();

				//if not text vertical alignment is provided, the alignment back to the top.
				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return VerticalAlignment.Top;
				}

				//Verify the vertical alignment provided.
				if (cssClass.EndsWith("top"))
				{
					return VerticalAlignment.Top;
				}
				else if (cssClass.EndsWith("bottom"))
				{
					return VerticalAlignment.Bottom;
				}
				else if (cssClass.EndsWith("center"))
				{
					return VerticalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return VerticalAlignment.Fill;
				}
				else
				{
					return VerticalAlignment.Top;
				}
			}
			set
			{
				Platform.Current.RemoveCssClassesStartingWith(this, "text-vertical-alignment");
				Platform.Current.AddCssClass(this, "text-vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets IT ext control. text padding.
		/// <para xml:lang="es">Obtiene o establece la existencia de padding del texto del control</para>
		/// </summary>
		/// <value>IT ext control. text padding.
		/// <para xml:lang="es">El padding del texto del control.</para>
		/// </value>
		Thickness ITextControl.TextPadding
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["padding-left"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["padding-top"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["padding-right"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["padding-bottom"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["padding-left"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["padding-top"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["padding-right"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["padding-bottom"] = string.Format("{0}px", value.Bottom);
			}
		}

		/// <summary>
		/// Represents the base class for classes containing event data and provides a value to use in events that do not include event data
		/// <para xml:lang="es">Representa la clase base para las clases que contienen datos de eventos y proporciona 
		/// un valor para utilizar en los eventos que no incluyen datos de evento.</para>
		/// </summary>
		private class EventArgs<T>
		{
			public EventArgs()
			{
			}
		}

		#endregion
	}
}