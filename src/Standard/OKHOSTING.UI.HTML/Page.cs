using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.HTML
{
	public class Page : IPage
	{
		public App App { get; set; }
		public string Title { get; set; }
		public IControl Content { get; set; }

		public double? Width => throw new NotImplementedException();

		public double? Height => throw new NotImplementedException();

		public event EventHandler Resized;
	}
}