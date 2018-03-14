using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Net4.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OKHOSTING.UI.Employees.Net4.WebForms
{
    public class FilePicker : System.Web.UI.WebControls.FileUpload, IInputControl<byte[]>
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

        OKHOSTING.UI.Color IControl.BackgroundColor
        {
            get
            {
                return Platform.Current.Parse(base.BackColor);
            }
            set
            {
                base.BackColor = Platform.Current.Parse(value);
            }
        }

        OKHOSTING.UI.Color IControl.BorderColor
        {
            get
            {
                return Platform.Current.Parse(base.BorderColor);
            }
            set
            {
                base.BorderColor = Platform.Current.Parse(value);
            }
        }

        double? IControl.Width
        {
            get
            {
                if(base.Width.IsEmpty)
                {
                    return null;
                }

                return base.Width.Value;
            }
            set
            {
                if(value.HasValue)
                {
                    base.Width = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
                }
                else
                {
                    base.Width = new System.Web.UI.WebControls.Unit();
                }
            }
        }

        double? IControl.Height
        {
            get
            {
                if (base.Height.IsEmpty)
                {
                    return null;
                }

                return base.Height.Value;
            }
            set
            {
                if (value.HasValue)
                {
                    base.Height = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
                }
                else
                {
                    base.Height = new System.Web.UI.WebControls.Unit();
                }
            }
        }

        OKHOSTING.UI.Thickness IControl.Margin
        {
            get
            {
                double left, top, right, bottom;
                OKHOSTING.UI.Thickness thickness = new OKHOSTING.UI.Thickness();

                if (double.TryParse(base.Style["margin-left"], out left)) thickness.Left = left;
                if (double.TryParse(base.Style["margin-top"], out top)) thickness.Top = top;
                if (double.TryParse(base.Style["margin-right"], out right)) thickness.Right = right;
                if (double.TryParse(base.Style["margin-bottom"], out bottom)) thickness.Bottom = bottom;

                return new OKHOSTING.UI.Thickness(left, top, right, bottom);
            }
            set
            {
                if (value.Left.HasValue) base.Style["margin-left"] = string.Format("{0}px", value.Left);
                if (value.Top.HasValue) base.Style["margin-top"] = string.Format("{0}px", value.Top);
                if (value.Right.HasValue) base.Style["margin-right"] = string.Format("{0}px", value.Right);
                if (value.Bottom.HasValue) base.Style["margin-bottom"] = string.Format("{0}px", value.Bottom);
            }
        }

        OKHOSTING.UI.Thickness IControl.BorderWidth
        {
            get
            {
                double left, top, right, bottom;
                OKHOSTING.UI.Thickness thickness = new OKHOSTING.UI.Thickness();

                if (double.TryParse(base.Style["border-left-width"], out left)) thickness.Left = left;
                if (double.TryParse(base.Style["border-top-widt"], out top)) thickness.Top = top;
                if (double.TryParse(base.Style["border-right-widt"], out right)) thickness.Right = right;
                if (double.TryParse(base.Style["border-bottom-widt"], out bottom)) thickness.Bottom = bottom;

                return new OKHOSTING.UI.Thickness(left, top, right, bottom);
            }
            set
            {
                if (value.Left.HasValue) base.Style["margin-left"] = string.Format("{0}px", value.Left);
                if (value.Top.HasValue) base.Style["border-top-widt"] = string.Format("{0}px", value.Top);
                if (value.Right.HasValue) base.Style["border-right-widt"] = string.Format("{0}px", value.Right);
                if (value.Bottom.HasValue) base.Style["border-left-widt"] = string.Format("{0}px", value.Bottom);
            }
        }

        OKHOSTING.UI.HorizontalAlignment IControl.HorizontalAlignment
        {
            get
            {
                string cssClass = base.CssClass.Split().Where(c => c.StartsWith("horizontal-alignment")).SingleOrDefault();

                if(string.IsNullOrWhiteSpace(cssClass))
                {
                    return OKHOSTING.UI.HorizontalAlignment.Left;
                }

                if(cssClass.EndsWith("left"))
                {
                    return OKHOSTING.UI.HorizontalAlignment.Left;
                }
                else if (cssClass.EndsWith("right"))
                {
                    return OKHOSTING.UI.HorizontalAlignment.Right;
                }
                else if (cssClass.EndsWith("center"))
                {
                    return OKHOSTING.UI.HorizontalAlignment.Center;
                }
                else if (cssClass.EndsWith("fill"))
                {
                    return OKHOSTING.UI.HorizontalAlignment.Fill;
                }
                else
                {
                    return OKHOSTING.UI.HorizontalAlignment.Left;
                }
            }
            set
            {
                Platform.Current.RemoveCssClassesStartingWith(this, "horizontal-alignment");
                Platform.Current.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
            }
        }

        OKHOSTING.UI.VerticalAlignment IControl.VerticalAlignment
        {
            get
            {
                string cssClass = base.CssClass.Split().Where(c => c.StartsWith("vertical-alignment")).SingleOrDefault();

                if (string.IsNullOrWhiteSpace(cssClass))
                {
                    return OKHOSTING.UI.VerticalAlignment.Top;
                }

                if (cssClass.EndsWith("top"))
                {
                    return OKHOSTING.UI.VerticalAlignment.Top;
                }
                else if (cssClass.EndsWith("bottom"))
                {
                    return OKHOSTING.UI.VerticalAlignment.Bottom;
                }
                else if (cssClass.EndsWith("center"))
                {
                    return OKHOSTING.UI.VerticalAlignment.Center;
                }
                else if (cssClass.EndsWith("fill"))
                {
                    return OKHOSTING.UI.VerticalAlignment.Fill;
                }
                else
                {
                    return OKHOSTING.UI.VerticalAlignment.Top;
                }
            }
            set
            {
                Platform.Current.RemoveCssClassesStartingWith(this, "vertical-alignment");
                Platform.Current.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
            }
        }

        object IControl.Tag
        {
            get; set;
        }

        public byte[] Value
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        public ImageClientField Container { get; set; }

        public event EventHandler<byte[]> ValueChanged;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
    }
}