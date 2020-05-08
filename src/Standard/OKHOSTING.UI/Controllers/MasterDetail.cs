using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;

namespace OKHOSTING.UI.Controllers
{
	/// <summary>
	/// Controller that allows child classes to easily create master-detail
	/// views that allow for compact mode in small screens
	/// </summary>
	public abstract class MasterDetail : Controller
	{
		/// <summary>
		/// Container for the master view
		/// </summary>
		public IUserControl Master { get; protected set; }

		/// <summary>
		/// Container for the detail view
		/// </summary>
		public IUserControl Detail { get; protected set; }

		/// <summary>
		/// Grid that contains both master and detail views. Only used when
		/// CompactMode is false
		/// </summary>
		public IGrid Grid { get; protected set; }

		/// <summary>
		/// Curently runnig controller on the Detail, if any
		/// </summary>
		public Controller DetailController { get; protected set; }

		/// <summary>
		/// If true, both master and detail are shown in the same page,
		/// otherwise, the master and detail are shown in different, abyacent pages
		/// </summary>
		public bool CompactMode { get; set; }

		public MasterDetail()
		{
		}

		public MasterDetail(IPage page) : base(page)
		{
		}

		public override void Refresh()
		{
			DetailController?.Refresh();
		}

		protected internal override void OnStart()
		{
			Detail = BaitAndSwitch.Create<IUserControl>();
			Detail.App = Page.App;

			OnMasterStart();

			if (CompactMode)
			{
				Page.Content = Master;
			}
			else
			{
				Grid = BaitAndSwitch.Create<IGrid>();
				Grid.ColumnCount = 2;
				Grid.RowCount = 1;

				Grid.SetContent(0, 0, Master);
				Grid.SetContent(0, 1, Detail);

				Page.Content = Grid;
			}
		}

		protected void SetDetail(Controller detailController)
		{
			//finish current detail, if any
			DetailController?.Finish();

			detailController.Page = Detail;
			detailController.Finished += DetailController_Finished;
			detailController.Start();

			if (CompactMode)
			{
				Page.Content = Master;
			}
			else
			{
				Grid.SetContent(0, 1, Detail);
			}
		}

		private void DetailController_Finished(object sender, EventArgs e)
		{
			if (CompactMode)
			{
				Page.Content = Master;
			}
		}

		protected abstract void OnMasterStart();
	}
}