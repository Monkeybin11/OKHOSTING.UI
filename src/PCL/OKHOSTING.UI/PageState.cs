namespace OKHOSTING.UI
{
	/// <summary>
	/// Represents the "state" of a page, which consist only of a Title and a Content.
	/// Use this class to save/restore a page state
	/// </summary>
	public class PageState
	{
		public PageState()
		{
		}

		public PageState(string title, Controls.IControl content)
		{
			Title = title;
			Content = content;
		}

		public string Title { get; set; }
		public Controls.IControl Content { get; set; }
	}
}