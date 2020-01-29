using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OKHOSTING.UI.Controls.Layout
{
    public class ResponsiveGrid
    {
        public Dictionary<int, IGrid> Layouts { get; set; } = new Dictionary<int, IGrid>();

        public void SetContent(int row, int column, IControl content)
        {
            foreach (var grid in Layouts.Values)
            {
                grid.SetContent(row, column, content);
            }
        }

        public void SetColumnSpan(int columnSpan, IControl content)
        {
            throw new NotImplementedException();
        }

        public void SetRowSpan(int rowSpan, IControl content)
        {
            throw new NotImplementedException();
        }

        public void SetHeight(int row, double height)
        {
            throw new NotImplementedException();
        }

        public void SetWidth(int column, double width)
        {
            throw new NotImplementedException();
        }

       public IGrid GetGrid(double pageWidth)
        {
            int ky = 0;
            foreach (var key in Layouts.Keys)
            {
                if (key <= pageWidth && key >= ky)
                {
                    ky = key;
                }
            }

            return Layouts[ky];
        }
    }
}