using System;
using System.Linq;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Net4.WebForms.Controls;
using System.Collections.Generic;

namespace OKHOSTING.UI.Net4.WebForms
{
	/// <summary>
	/// It represents a page of a form
	/// <para xml:lang="es">Representa una pagina de un formulario.</para>
	/// </summary>
	public partial class Page : System.Web.UI.Page, IPage
	{
		/// <summary>
		/// The content holder.
		/// <para xml:lang="es">El contenido que contiene la pagina.</para>
		/// </summary>
		protected System.Web.UI.WebControls.PlaceHolder ContentHolder;

		/// <summary>
		/// Restores Page state (content & title) and launch events
		/// <para xml:lang="es">Restaura el estado de la pagina (Contenido y titulo) y lanza eventos</para>
		/// </summary>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			//assign as current page
			Platform.Current.Page = this;

			//load javascript dependencies
			Page.ClientScript.RegisterClientScriptInclude("jquery", ResolveUrl("~/js/jquery.js"));
			Page.ClientScript.RegisterClientScriptInclude("jquery-ui", ResolveUrl("~/js/jquery-ui.js"));
			Page.ClientScript.RegisterClientScriptInclude("PageSize", ResolveUrl("~/js/PageSize.js"));

			//if this is the first request, get page size and finish
			if (Width == 0 && Height == 0)
			{
				string pageSizeJS = @"
				<script type='text/javascript'>
					$(document).ready
					(
						function()
						{
							SetPageSize();
						}
					);
				</script>";

				//register javascripts
				Page.ClientScript.RegisterStartupScript(this.GetType(), "SetPageSize", pageSizeJS);
				Response.Flush();
				Response.End();

				return;
			}

			//create placeholder for content
			if (ContentHolder == null)
			{
				ContentHolder = new System.Web.UI.WebControls.PlaceHolder();
				ContentHolder.ID = "ContentHolder";
				base.Form.Controls.Add(ContentHolder);
			}

			//search for a rewrite rule for this uri
			var rule = Platform.Current.GetUrlRewriteRuleFor(new Uri(Request.RawUrl, UriKind.Relative));

			if (rule!= null)
			{
				//should we start a different controller than the current one?
				if (Platform.Current.Controller != null)
				{
					bool startNew = false;

					if (!rule.ControllerType.IsAssignableFrom(Platform.Current.Controller.GetType()))
					{
						startNew = true;
					}
					else
					{
						var currentUri = rule.GetUri(Platform.Current.Controller).ToString();

						if (currentUri != Request.RawUrl)
						{
							startNew = true;
						}
					}

					if (startNew)
					{
						var newController = rule.GetController(new Uri(Request.RawUrl, UriKind.Relative));
						newController.Start();
					}
				}
			}

			//there is no controller assigned, exit
			if (Platform.Current.Controller == null)
			{
				return;
			}

			//get title and content from the state, in case it has a different Page instance
			Title = Platform.Current.PageState?.Title;
			Content = Platform.Current.PageState?.Content;

			if (!IsPostBack)
			{
				return;
			}

			//keep track of wich IInputControls had ther value updated so we can reaise IInputControl.OnValueChanged
			List<IWebInputControl> updatedInputControls = new List<IWebInputControl>();

			//restore state
			foreach (var control in GetAllControls())
			{
				if (control is IWebInputControl && ((IWebInputControl) control).HandlePostBack())
				{
					updatedInputControls.Add((IWebInputControl) control);
				}
			}

			//raise IInputControl.ValueChanged events
			foreach (IWebInputControl control in updatedInputControls)
			{
				control.RaiseValueChanged();
			}

			//handle uploaded files
			//foreach (string f in Request.Files)
			//{
			//	System.Web.HttpPostedFile file = Request.Files[f];

			//	if (file.ContentLength <= 0)
			//	{
			//		continue;
			//	}

			//	WebFilePicker control = ContentHolder.FindControl(f) as WebFilePicker;
			//	control.Container.Value = new System.IO.BinaryReader(file.InputStream).ReadBytes((int)file.InputStream.Length);
			//}

			//raise button click events
			foreach (string postedValueName in Request.Form.AllKeys.Where(k => !k.StartsWith("__")))
			{
				//get posted value by user
				string postedValue = Request.Form[postedValueName];
				string controlName = postedValueName;

				//is this an image button?
				if (postedValueName.EndsWith(".x"))
				{
					controlName = postedValueName.Split('.').First();	
				}
				
				//get control that corresponds to this input
				IWebClickableControl control = ContentHolder.FindControl(controlName) as IWebClickableControl;
					
				if (control is Button && postedValue == ((Button) control).Text)
				{
					control?.RaiseClick();
				}
				else if (control is IImageButton)
				{
					control?.RaiseClick();
				}
			}

			//raise labelbutton, checkbox & image click events

			string eventTarget = Request.Form["__EVENTTARGET"];
			string eventArgument = Request.Form["__EVENTARGUMENT"];

			//get control that corresponds to this input
			if (!string.IsNullOrWhiteSpace(eventTarget))
			{
				IWebClickableControl control = ContentHolder.FindControl(eventTarget) as IWebClickableControl;
				control?.RaiseClick();
			}
		}

		/// <summary>
		/// Gets or sets the content.
		/// <para xml:lang="es">Obtiene o establece el contenido.</para>
		/// </summary>
		/// <value>The content.
		/// <para xml:lang="es">El contenido.</para>
		/// </value>
		public IControl Content
		{
			get
			{
				if (ContentHolder.Controls.Count == 0)
				{
					return null;
				}

				return (IControl) ContentHolder.Controls[0];
			}
			set
			{
				ContentHolder.Controls.Clear();

				if (value != null)
				{
					ContentHolder.Controls.Add((System.Web.UI.Control) value);
				}
			}
		}

		/// <summary>
		/// Gets the width.
		/// <para xml:lang="es">Obtiene el ancho de la pagina.</para>
		/// </summary>
		/// <value>The width.
		/// <para xml:lang="es">El ancho.</para>
		/// </value>
		public double Width
		{
			get
			{
				if (!OKHOSTING.UI.Session.Current.ContainsKey(typeof(Page) + ".Width"))
				{
					OKHOSTING.UI.Session.Current[typeof(Page) + ".Width"] = (double) 0;
				}

				return (double) OKHOSTING.UI.Session.Current[typeof(Page) + ".Width"];
			}
		}

		/// <summary>
		/// Gets the height.
		/// <para xml:lang="es">Obtiene la altura de la pagina.</para>
		/// </summary>
		/// <value>The height.
		/// <para xml:lang="es">La altura</para>
		/// </value>
		public double Height
		{
			get
			{
				if (!OKHOSTING.UI.Session.Current.ContainsKey(typeof(Page) + ".Height"))
				{
					OKHOSTING.UI.Session.Current[typeof(Page) + ".Height"] = (double) 0;
				}

				return (double) OKHOSTING.UI.Session.Current[typeof(Page) + ".Height"];
			}
		}

		public IEnumerable<IControl> GetAllControls()
		{
			foreach (IControl ctr in Platform.GetAllControls(this))
			{
				yield return ctr;
			}
		}

		/// <summary>
		/// Ons the pre render.
		/// <para xml:lang="es">Hace todos los pasos previos a la representacion.</para>
		/// </summary>
		/// <returns>The pre render.</returns>
		/// <param name="e">E.</param>
		protected override void OnPreRender(EventArgs e)
		{
			//save page state
			if (Platform.Current.PageState != null)
			{
				Platform.Current.PageState.Title = Title;
				Platform.Current.PageState.Content = Content;
			}

			//allow friendly urls on forms
			Form.Action = Request.RawUrl;

			base.OnPreRender(e);
		}

		/// <summary>
		/// Performs the steps of initialization and configuration required to create a page.
		/// <para xml:lang="es">Realiza las etapas de inicializacion y configuracion requeridas para crear una pagina.</para>
		/// </summary>
		/// <returns>The init.</returns>
		/// <param name="e">E.</param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			EnsureChildControls();
		}
	}
}