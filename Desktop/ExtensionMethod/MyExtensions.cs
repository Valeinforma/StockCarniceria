using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ExtensionMethod
{
    public static class MyExtensions
    {
        public static void HideColumns(this DataGridView grid, params string[] columnNames)
        {
            foreach (var columnName in columnNames)
            {
                if (grid.Columns.Contains(columnName))
                {
                    grid.Columns[columnName].Visible = false;
                }
            }
        }
    }
}
