using System;
using System.Linq;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class Image : System.Web.UI.WebControls.Image, UI.Controls.IImage
	{
		#region IControl

		string IControl.Name
		{
			get
			{
				return base.ID;
			}
			set
			{
				base.ID = value;
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return WebForms.Page.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = WebForms.Page.Parse(value);
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return WebForms.Page.Parse(base.BorderColor);
			}
			set
			{
				base.BorderColor = WebForms.Page.Parse(value);
			}
		}

		double IControl.Width
		{
			get
			{
				return base.Width.Value;
			}
			set
			{
				base.Width = new System.Web.UI.WebControls.Unit(value, System.Web.UI.WebControls.UnitType.Pixel);
			}
		}

		double IControl.Height
		{
			get
			{
				return base.Height.Value;
			}
			set
			{
				base.Height = new System.Web.UI.WebControls.Unit(value, System.Web.UI.WebControls.UnitType.Pixel);
			}
		}

		Thickness IControl.Margin
		{
			get
			{
				Thickness value = new Thickness();

				try
				{
					value.Top = double.Parse(base.Style["margin-top"]);
					value.Right = double.Parse(base.Style["margin-right"]);
					value.Bottom = double.Parse(base.Style["margin-bottom"]);
					value.Left = double.Parse(base.Style["margin-left"]);
				}
				catch { }

				return value;
			}
			set
			{
				base.Style["margin-top"] = string.Format("{0}px", value.Top);
				base.Style["margin-right"] = string.Format("{0}px", value.Right);
				base.Style["margin-bottom"] = string.Format("{0}px", value.Bottom);
				base.Style["margin-left"] = string.Format("{0}px", value.Left);
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				Thickness value = new Thickness();

				try
				{
					value.Top = double.Parse(base.Style["border-top-width"]);
					value.Right = double.Parse(base.Style["border-right-width"]);
					value.Bottom = double.Parse(base.Style["border-bottom-width"]);
					value.Left = double.Parse(base.Style["border-left-width"]);
				}
				catch { }

				return value;
			}
			set
			{
				base.Style["border-top-width"] = string.Format("{0}px", value.Top);
				base.Style["border-right-width"] = string.Format("{0}px", value.Right);
				base.Style["border-bottom-width"] = string.Format("{0}px", value.Bottom);
				base.Style["border-left-width"] = string.Format("{0}px", value.Left);
			}
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("horizontal-alignment")).SingleOrDefault();

				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return HorizontalAlignment.Left;
				}

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
				WebForms.Page.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				WebForms.Page.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("vertical-alignment")).SingleOrDefault();

				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return VerticalAlignment.Top;
				}

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
				WebForms.Page.RemoveCssClassesStartingWith(this, "vertical-alignment");
				WebForms.Page.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
			}
		}

		#endregion

		public void LoadFromFile(string filePath)
		{
			if (!File.Exists(filePath))
			{
				throw new ArgumentOutOfRangeException("filePath", "The file does not exist");
			}

			//file is not located inside the web app, so we create a copy in a temp directory			
			if (!filePath.StartsWith(this.Page.MapPath("/")))
			{
				string tempDirectoryPath = Path.Combine(OKHOSTING.Core.Net4.DefaultPaths.Custom, "Temp");

				if (!Directory.Exists(tempDirectoryPath))
				{
					Directory.CreateDirectory(tempDirectoryPath);
				}

				string tempFilePath = Path.Combine(tempDirectoryPath, Path.GetFileName(filePath));
			}

			//we finally get the "relative" path of the file and load it as a url
			string url = filePath.Replace(this.Page.MapPath("/"), string.Empty);
			LoadFromUrl(url);
		}

		public void LoadFromStream(Stream stream)
		{
			//save the sream to a temp file, and load as file from there
			string tempDirectoryPath = Path.Combine(OKHOSTING.Core.Net4.DefaultPaths.Custom, "Temp");

			if (!Directory.Exists(tempDirectoryPath))
			{
				Directory.CreateDirectory(tempDirectoryPath);
			}

			string tempFilePath = Path.Combine(tempDirectoryPath, new Random().Next().ToString());
			using (var fileStream = File.OpenWrite(tempFilePath))
			{
				stream.CopyTo(fileStream);
			}
		}

		public void LoadFromUrl(string url)
		{
			base.ImageUrl = url;
		}
	}
}
