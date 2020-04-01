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
		/// Raised when the page is resized
		/// </summary>
		public event EventHandler Resized;

		/// <summary>
		/// App that is running on this page
		/// </summary>
		public virtual App App
		{
			get
			{
				return (App)Session["App"];
			}
			set
			{
				Session["App"] = value;
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
				if (Form.Controls.Count == 0)
				{
					return null;
				}

				return (IControl)Form.Controls[0];
			}
			set
			{
				Form.Controls.Clear();

				if (value != null)
				{
					Form.Controls.Add((System.Web.UI.Control)value);
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
		public double? Width
		{
			get
			{
				if (Session[typeof(Page) + ".Width"] == null)
				{
					Session[typeof(Page) + ".Width"] = (double)0;
				}

				return (double)Session[typeof(Page) + ".Width"];
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
				if (Session[typeof(Page) + ".Height"] == null)
				{
					Session[typeof(Page) + ".Height"] = (double)0;
				}

				return (double)Session[typeof(Page) + ".Height"];
			}
		}

		/// <summary>
		/// Assign a name to all controls created, using a unique counter (per user session) to avoid duplicate names
		/// </summary>
		protected internal int ControlCounter = 0;

		/// <summary>
		/// Raises the Resized event
		/// </summary>
		protected internal void OnResized()
		{
			Resized?.Invoke(this, null);
		}

		/// <summary>
		/// Restores Page state (content & title) and launch events
		/// <para xml:lang="es">Restaura el estado de la pagina (Contenido y titulo) y lanza eventos</para>
		/// </summary>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Session["Page"] = this;

			//initialize javascript
			InitJavaScript();

			//initialize the page state
			InitState();
			
			//check usage of friendly urls
			InitRouting();

			//there is no controller assigned, exit
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
			//save page state
			var state = App[this];

			if (state != null)
			{
				state.Title = Title;
				state.Content = Content;
			}

			//allow friendly urls on forms
			Form.Action = Request.RawUrl;

			ControlCounter = 0;

			foreach (var control in GetAllControls())
			{
				if (string.IsNullOrWhiteSpace(control.Name))
				{
					control.Name = $"ctr_{control.GetType().Name}_{ControlCounter++}";
				}
			}

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

		/// <summary>
		/// Append the basic javascript references
		/// </summary>
		protected virtual void InitJavaScript()
		{
			//load javascript dependencies
			Page.ClientScript.RegisterClientScriptInclude("jquery", ResolveUrl("~/JS/jquery.js"));
			Page.ClientScript.RegisterClientScriptInclude("jquery-ui", ResolveUrl("~/JS/jquery-ui.js"));
			Page.ClientScript.RegisterClientScriptInclude("jquery-ui-i18n", ResolveUrl("~/JS/jquery-ui-i18n.min.js"));
			Page.ClientScript.RegisterClientScriptInclude("PageSize", ResolveUrl("~/JS/PageSize.js"));
			Page.ClientScript.RegisterClientScriptInclude("DragDrop", ResolveUrl("~/JS/DragDrop.js"));

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
		}

		/// <summary>
		/// Replace old Pages with the current one in the App.State,
		/// since webforms pages are by default recycled among requests
		/// </summary>
		protected virtual void InitState()
		{
			//replace old page with current one
			var pages = App.State.Keys.Where(p => p is Page);

			if (pages.Any())
			{
				Stack<PageState> newState = new Stack<PageState>();

				foreach (var page in pages.ToArray())
				{
					var stateStack = App.State[page];

					foreach (var item in stateStack.Reverse())
					{
						newState.Push(item);
					}

					App.State.Remove(page);
				}

				App.State.Add(this, newState);

				foreach (PageState st in newState)
				{
					st.Controller.Page = this;
				}
			}

			//get title and content from the state, in case it has a different Page instance
			var state = App[this];
			Title = state?.Title;
			Content = state?.Content;
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

			//handle posted values
			foreach (IInputControl control in GetAllControls().Where(c => c is IInputControl))
			{
				if (control.HandlePostBack())
				{
					updatedInputControls.Add(control);
				}
			}

			//raise IInputControl.ValueChanged events
			foreach (IInputControl control in updatedInputControls)
			{
				control.RaiseValueChanged();
			}

			//raise button click events
			foreach (Controls.IClickable control in GetAllControls().Where(c => c is Controls.IClickable))
			{
				control.RaiseClick();
			}
		}

		/// <summary>
		/// Raises the DragDrop.ControlDropped event
		/// </summary>
		protected virtual void HandleDragDrop()
		{
			if (Request.Form.AllKeys.Contains("dragdrop_dragged") && Request.Form.AllKeys.Contains("dragdrop_dropped"))
			{
				var allControls = App.GetAllChildren(Content);
				var dragged = allControls.Where(c => c.Name == Request.Form["dragdrop_dragged"]).Single();
				var dropped = allControls.Where(c => c.Name == Request.Form["dragdrop_dropped"]).Single();

				DragDrop.RaiseDropped(dragged, dropped);
			}
		}

		protected IEnumerable<IControl> GetAllControls()
		{
			foreach (IControl ctr in ControlExtensions.GetAllControls(this).Where(c => c is IControl))
			{
				yield return ctr;
			}
		}
	}
}