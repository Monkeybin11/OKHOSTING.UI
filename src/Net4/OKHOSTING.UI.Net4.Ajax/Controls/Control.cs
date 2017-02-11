using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Net4.Ajax.Controls
{
	public abstract class Control : UI.Controls.IControl
	{
		public Color BackgroundColor
		{
			get;
			set;
		}

		public Color BorderColor
		{
			get;
			set;
		}

		public Thickness BorderWidth
		{
			get;
			set;
		}

		public bool Enabled
		{
			get;
			set;
		}

		public double? Height
		{
			get;
			set;
		}

		public HorizontalAlignment HorizontalAlignment
		{
			get;
			set;
		}

		public Thickness Margin
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public object Tag
		{
			get;
			set;
		}

		public VerticalAlignment VerticalAlignment
		{
			get;
			set;
		}

		public bool Visible
		{
			get;
			set;
		}

		public double? Width
		{
			get;
			set;
		}

		public abstract void Dispose();

		/// <summary>
		/// Renders the current control to a HTML string
		/// </summary>
		public abstract string Render();
	}
}
