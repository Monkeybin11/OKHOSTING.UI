using OKHOSTING.UI.Net4.WebForms.Controls;
using System;
using System.Linq;
using System.Collections.Generic;

namespace OKHOSTING.UI.Net4.WebForms
{
	/// <summary>
	/// It represents a page of a form
	/// <para xml:lang="es">Representa una pagina de un formulario.</para>
	/// </summary>
	public abstract partial class Page : System.Web.UI.Page, IPage
	{
		/// <summary>
		/// App that is running on this page
		/// </summary>
		public virtual App App
		{
			get
			{
				if (Session[$"{nameof(Page)}.{nameof(App)}"] == null)
				{
					Session[$"{nameof(Page)}.{nameof(App)}"] = Core.BaitAndSwitch.Create<App>();
				}

				return (App) Session[$"{nameof(Page)}.{nameof(App)}"];
			}
			set
			{
				Session[$"{nameof(Platform)}.{nameof(App)}"] = value;
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
				return (IControl) Session[$"{nameof(Page)}.{nameof(Content)}"];
			}
			set
			{
				Session[$"{nameof(Page)}.{nameof(Content)}"] = value;
			}
		}

		string IPage.Title
		{
			get
			{
				return (string) Session[$"{nameof(Page)}.{nameof(Title)}"];
			}
			set
			{
				Session[$"{nameof(Page)}.{nameof(Title)}"] = value;
			}
		}

		/// <summary>
		/// Gets the width.
		/// <para xml:lang="es">Obtiene el ancho de la pagina.</para>
		/// </summary>
		/// <value>The width.
		/// <para xml:lang="es">El ancho.</para>
		/// </value>
		public double? Width
		{
			get
			{
				if (Session[$"{nameof(Page)}.{nameof(Width)}"] == null)
				{
					Session[$"{nameof(Page)}.{nameof(Width)}"] = (double) 0;
				}

				return (double) Session[$"{nameof(Page)}.{nameof(Width)}"];
			}
		}

		/// <summary>
		/// Gets the height.
		/// <para xml:lang="es">Obtiene la altura de la pagina.</para>
		/// </summary>
		/// <value>The height.
		/// <para xml:lang="es">La altura</para>
		/// </value>
		public double? Height
		{
			get
			{
				if (Session[$"{nameof(Page)}.{nameof(Height)}"] == null)
				{
					Session[$"{nameof(Page)}.{nameof(Height)}"] = (double) 0;
				}

				return (double) Session[$"{nameof(Page)}.{nameof(Height)}"];
			}
		}

		/// <summary>
		/// If set to true, all postbacks will be sent with AJAX instead of normal POST.
		/// This is not compatible with friendly URLs since we stay at the same URL all the
		/// </summary>
		public bool AjaxPostback { get; set; }

		public void InvokeOnMainThread(Action action)
		{
			System.Threading.Tasks.Task.Run(action);
		}

		/// <summary>
		/// This will be executed only once at the begining of every new user session.
		/// You should override this in your Net4.WebForms.Page and start a controller or do something
		/// </summary>
		public abstract void OnAppStart();

		/// <summary>
		/// Assign a name to all controls created, using a unique counter (per user session) to avoid duplicate names
		/// </summary>
		protected internal int ControlCounter = 0;

		/// <summary>
		/// Restores Page state (content & title) and launch events
		/// <para xml:lang="es">Restaura el estado de la pagina (Contenido y titulo) y lanza eventos</para>
		/// </summary>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Platform.CurrentPage = this;

			//initialize javascript
			InitJavaScript();

			//if this is the first load, exit and wait for page size on the second load
			if (Width == 0 && Height == 0)
			{
				return;
			}

			//initialize the page state
			InitState();
			
			//check usage of friendly urls
			InitRouting();

			//if there is no controller assigned, exit
			if (App[this]?.Controller == null)
			{
				return;
			}

			//handle postback events
			if (IsPostBack)
			{
				HandleEvents();
				HandleDragDrop();
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
			//refresh content from session
			Form.Controls.Clear();

			if (Content != null)
			{
				Form.Controls.Add((System.Web.UI.Control) Content);
			}

			Title = ((IPage) this).Title;

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
			EnableViewState = false;
			base.OnInit(e);
			EnsureChildControls();
		}

		/// <summary>
		/// Append the basic javascript references
		/// </summary>
		protected virtual void InitJavaScript()
		{
			//load javascript dependencies
			ClientScript.RegisterClientScriptInclude("jquery", ResolveUrl("~/JS/jquery.js"));
			ClientScript.RegisterClientScriptInclude("PageSize", ResolveUrl("~/JS/PageSize.js"));

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
				Page.ClientScript.RegisterStartupScript(GetType(), "SetPageSize", pageSizeJS);

				return;
			}

			ClientScript.RegisterClientScriptInclude("jquery-ui", ResolveUrl("~/JS/jquery-ui.js"));
			ClientScript.RegisterClientScriptInclude("jquery-ui-i18n", ResolveUrl("~/JS/jquery-ui-i18n.min.js"));
			ClientScript.RegisterClientScriptInclude("DragDrop", ResolveUrl("~/JS/DragDrop.js"));
			ClientScript.GetPostBackEventReference(this, string.Empty);

			if (AjaxPostback)
			{
				ClientScript.RegisterClientScriptInclude("AjaxPostback", ResolveUrl("~/JS/AjaxPostback.js"));
			}
		}

		/// <summary>
		/// Replace old Pages with the current one in the App.State,
		/// since webforms pages are by default recycled among requests
		/// </summary>
		protected virtual void InitState()
		{
			//replace old page with current one
			//var pages = App.State.Keys.Where(p => p is Page);

			//if (pages.Any())
			//{
			//	Stack<PageState> newState = new Stack<PageState>();

			//	foreach (var page in pages.ToArray())
			//	{
			//		var stateStack = App.State[page];

			//		foreach (var item in stateStack.Reverse())
			//		{
			//			newState.Push(item);
			//		}

			//		App.State.Remove(page);
			//	}

			//	App.State.Add(this, newState);

			//	foreach (PageState st in newState)
			//	{
			//		st.Controller.Page = this;
			//	}
			//}

			//set this as the main page since web apps are 1 page only
			App.MainPage = this;

			//this is the first load of the app, we need to run a controller overriding OnAppStart
			if (!App.State[this].Any())
			{
				OnAppStart();
			}
			else
			{
				//get title and content from the state, in case it has a different Page instance
				//var state = App[this];
				//Title = state?.Title;
				//Content = state?.Content;
			}
		}

		/// <summary>
		/// Checks if a friendly URL is being used and if so,
		/// shows the controller that corresponds to that URL
		/// </summary>
		protected virtual void InitRouting()
		{
			//search for a rewrite rule for this uri
			var rule = Platform.GetUrlRewriteRuleFor(new Uri(Request.RawUrl, UriKind.Relative));

			var state = App[this];

			//should we start a different controller than the current one?
			if (rule != null && state?.Controller != null)
			{
				bool startNew = false;

				if (!rule.ControllerType.IsAssignableFrom(state.Controller.GetType()))
				{
					startNew = true;
				}
				else
				{
					var currentUri = rule.GetUri(state.Controller).ToString();

					if (currentUri != Request.RawUrl)
					{
						startNew = true;
					}
				}

				if (startNew)
				{
					var newController = rule.GetController(new Uri(Request.RawUrl, UriKind.Relative));
					newController.Page = this;
					newController.Start();
				}
			}
		}

		/// <summary>
		/// Raises ValueChanged and Click events
		/// </summary>
		protected virtual void HandleEvents()
		{
			//keep track of wich IInputControls had their value updated so we can reaise IInputControl.OnValueChanged
			List<IInputControl> updatedInputControls = new List<IInputControl>();
			var allControls = App.GetParentAndAllChildren(Content).ToArray();

			foreach (var control in allControls)
			{
				((System.Web.UI.Control) control).Page = this;
			}

			//handle posted values
			foreach (IInputControl control in allControls.Where(c => c is IInputControl))
			{
				control.HandlePostBack();
			}

			//raise button click events
			foreach (IClickable control in allControls.Where(c => c is IClickable))
			{
				control.HandleClick();
			}
		}

		/// <summary>
		/// Raises the DragDrop.ControlDropped event
		/// </summary>
		protected virtual void HandleDragDrop()
		{
			if (Request.Form.AllKeys.Contains("dragdrop_dragged") && Request.Form.AllKeys.Contains("dragdrop_droppedOn"))
			{
				var allControls = App.GetAllChildren(Content);
				var dragged = allControls.Where(c => c.Name == Request.Form["dragdrop_dragged"]).Single();
				var droppedOn = allControls.Where(c => c.Name == Request.Form["dragdrop_droppedOn"]).Single();

				DragDrop.RaiseDropped(dragged, droppedOn);
			}
		}

		public override int GetHashCode()
		{
			return Session?.SessionID.GetHashCode() ?? base.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Page)
			{
				return Page.Session.SessionID.Equals(Session.SessionID);
			}
			else
			{
				return base.Equals(obj);
			}
		}
	}
}