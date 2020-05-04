using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLinesTest.Utils
{
    public static class UpdateDataSource 
    {
        public static void Update(DataGridView grid)
        {
            grid.DataSource = Configurations.linesData.Values.ToArray();
            grid.Update();
        }

    }
}
