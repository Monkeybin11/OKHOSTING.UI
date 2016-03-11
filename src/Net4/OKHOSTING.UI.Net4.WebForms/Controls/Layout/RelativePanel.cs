using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NativeControl = System.Web.UI.Control;

namespace OKHOSTING.UI.Net4.WebForms.Controls.Layout
{
	public class RelativePanel: System.Web.UI.WebControls.Panel, IRelativePanel
	{
		protected readonly ControlList _Children;
		protected readonly List<string> ClientScripts = new List<string>();

		public RelativePanel()
		{
			_Children = new ControlList(this);
		}

		IList<IControl> IRelativePanel.Children
		{
			get
			{
				return _Children;
			}
		}

		void IRelativePanel.Add(IControl control, RelativePanelHorizontalContraint horizontalContraint, RelativePanelVerticalContraint verticalContraint, IControl referenceControl)
		{
			if (control == null)
			{
				throw new ArgumentNullException(nameof(control));
			}

			//if no reference control is provided, then use this panel as reference
			if (referenceControl == null)
			{
				referenceControl = this;
			}

			base.Controls.Add((NativeControl) control);

			//the anchors at the current control
			string myHorizontalAnchor = "center";
			string myVerticalAnchor = "center";

			//the anchors at the reference control
			string atHorizontalAnchor = "center";
			string atVerticalAnchor = "center";

			//the reference control's id
			string of = ((NativeControl)referenceControl).ClientID;

			//horizontal constraint

			switch (horizontalContraint)
			{
				case RelativePanelHorizontalContraint.CenterWith:
					myHorizontalAnchor = "center";
					atHorizontalAnchor = "center";
					break;

				case RelativePanelHorizontalContraint.LeftOf:
					myHorizontalAnchor = "right";
					atHorizontalAnchor = "left";
					break;

				case RelativePanelHorizontalContraint.LeftWith:
					myHorizontalAnchor = "left";
					atHorizontalAnchor = "left";
					break;

				case RelativePanelHorizontalContraint.RightOf:
					myHorizontalAnchor = "left";
					atHorizontalAnchor = "right";
					break;

				case RelativePanelHorizontalContraint.RightWith:
					myHorizontalAnchor = "right";
					atHorizontalAnchor = "right";
					break;
			}

			//vertical constraint

			switch (verticalContraint)
			{
				case RelativePanelVerticalContraint.AboveOf:
					myVerticalAnchor = "bottom";
					atVerticalAnchor = "top";
					break;

				case RelativePanelVerticalContraint.BelowOf:
					myVerticalAnchor = "top";
					atVerticalAnchor = "bottom";
					break;

				case RelativePanelVerticalContraint.BottomWith:
					myVerticalAnchor = "bottom";
					atVerticalAnchor = "bottom";
					break;

				case RelativePanelVerticalContraint.CenterWith:
					myVerticalAnchor = "center";
					atVerticalAnchor = "center";
					break;

				case RelativePanelVerticalContraint.TopWith:
					myVerticalAnchor = "top";
					atVerticalAnchor = "top";
					break;
			}

			string positionJS = string.Format
			(
				@"
				$('#{0}').position
				(
					{{
						my: '{1} {2}',
						at: '{3} {4}',
						of: '#{5}'
					}}
				);", 
				((NativeControl) control).ClientID, myHorizontalAnchor, myVerticalAnchor, atHorizontalAnchor, atVerticalAnchor, ((NativeControl) referenceControl).ClientID
			);

			ClientScripts.Add(positionJS);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			string positionJS = string.Format
			(
				@"
				<script type='text/javascript'>
					$(document).ready
					(
						function()
						{{
							{0}
						}}
					);
				</script>"
			, string.Join(Environment.NewLine, ClientScripts)
			);

			((System.Web.UI.Page) Platform.Current.Page).ClientScript.RegisterStartupScript(this.GetType(), "position_" + base.ClientID, positionJS);
		}

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
				return Platform.Current.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = Platform.Current.Parse(value);
			}
		}

		Color IControl.BorderColor
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
				if (base.Width.IsEmpty)
				{
					return null;
				}

				return base.Width.Value;
			}
			set
			{
				if (value.HasValue)
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

		Thickness IControl.Margin
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["margin-left"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["margin-top"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["margin-right"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["margin-bottom"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["margin-left"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["margin-top"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["margin-right"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["margin-bottom"] = string.Format("{0}px", value.Bottom);
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["border-left-width"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["border-top-width"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["border-right-width"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["border-bottom-width"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["border-left-width"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["border-top-width"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["border-right-width"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["border-bottom-width"] = string.Format("{0}px", value.Bottom);
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
				Platform.Current.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				Platform.Current.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
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
				Platform.Current.RemoveCssClassesStartingWith(this, "vertical-alignment");
				Platform.Current.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// </remmarks>
		object IControl.Tag
		{
			get; set;
		}

		#endregion

		public class ControlList : IList<IControl>
		{
			private readonly RelativePanel ContainerPanel;

			public ControlList(RelativePanel containerPanel)
			{
				ContainerPanel = containerPanel;
			}

			public IControl this[int index]
			{
				get
				{
					return (IControl) ContainerPanel.Controls[index];
				}
				set
				{
					ContainerPanel.Controls.RemoveAt(index);
					ContainerPanel.Controls.AddAt(index, (NativeControl) value);
				}
			}

			public int Count
			{
				get
				{
					return ContainerPanel.Controls.Count;
				}
			}

			public bool IsReadOnly
			{
				get
				{
					return false;
				}
			}

			public void Add(IControl item)
			{
				ContainerPanel.Controls.Add((NativeControl) item);
			}

			public void Clear()
			{
				ContainerPanel.Controls.Clear();
			}

			public bool Contains(IControl item)
			{
				return ContainerPanel.Controls.Contains((NativeControl) item);
			}

			public void CopyTo(IControl[] array, int arrayIndex)
			{
				for (int i = 0; i < ContainerPanel.Controls.Count; i++)
				{
					array[i] = (IControl) ContainerPanel.Controls[i];
				}
			}

			public IEnumerator<IControl> GetEnumerator()
			{
				foreach (NativeControl control in ContainerPanel.Controls)
				{
					yield return (IControl) control;
				}
			}

			public int IndexOf(IControl item)
			{
				return ContainerPanel.Controls.IndexOf((NativeControl) item);
			}

			public void Insert(int index, IControl item)
			{
				ContainerPanel.Controls.AddAt(index, (NativeControl) item);
			}

			public bool Remove(IControl item)
			{
				if (Contains(item))
				{
					ContainerPanel.Controls.Remove((NativeControl)item);
					return true;
				}
				else
				{
					return false;
				}
			}

			public void RemoveAt(int index)
			{
				ContainerPanel.Controls.RemoveAt(index);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}
	}
}