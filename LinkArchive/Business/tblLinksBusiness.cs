using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkArchive.Business
{
    public class tblLinksBusiness
    {
        // GetVeri - Gridveiwe tblLinks verilerini basar
        public static void GetVeri(DataGridView gv, tblLinksDto searchDto)
        {
            var sqlHelper = new SqlHelper(Constants.DefConString);

            if (searchDto == null)
            {
                gv.DataSource = sqlHelper.GetTable("select t1.Id, t1.CategoryId, t2.CategoryName, t1.Title, t1.Url, t1.CreateOwner, t1.CreatedAt from tblLinks t1 left join tblCategory t2 on t1.CategoryId = t2.Id where t1.IsDeleted = 0 order by t1.Id desc").Item2;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select t1.Id, t1.CategoryId, t2.CategoryName, t1.Title, t1.Url, t1.CreateOwner, t1.CreatedAt from tblLinks t1 left join tblCategory t2 on t1.CategoryId = t2.Id where 1=1 and ");

                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(searchDto.Title))
                {
                    sb.AppendLine("t1.Title like @p1 and ");
                    parameters.Add(new SqlParameter("@p1", $"%{searchDto.Title}%"));

                }

                sb.AppendLine("t1.IsDeleted = 0 order by t1.Id desc");

                gv.DataSource = sqlHelper.GetTable(sb.ToString(),parameters).Item2;
            }

            gv.Columns["CategoryId"].Visible = false;
        }

        // GetCategory - Category Id ve Name listesini döndürür
        public static void GetCategory(ComboBox cmb)
        {
            var sqlHelper = new SqlHelper(Constants.DefConString);
            cmb.DataSource = sqlHelper.GetTable("select Id, CategoryName from tblCategory order by CategoryName").Item2;
            cmb.DisplayMember = "CategoryName";
            cmb.ValueMember = "Id";
        }

    }
}
