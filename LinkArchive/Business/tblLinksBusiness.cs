using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkArchive.Business
{
    public class tblLinksBusiness
    {
        // GetVeri - Gridveiwe tblLinks verilerini basar
        public static void GetVeri(DataGridView gv)
        {
            var sqlHelper = new SqlHelper(Constants.DefConString);
            gv.DataSource = sqlHelper.GetTable("select * from tblLinks order by Id desc").Item2;
        }
        public static void GetCategory(ComboBox gc)
        { 
        var sqlHelper = new SqlHelper(Constants.DefConString);
            gc.DataSource = sqlHelper.GetTable("select * from tblCategory order by Id desc").Item2;
        }

    }
}
