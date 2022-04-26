using System;
using System.Collections.Generic;
using System.Data;
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

                if (!string.IsNullOrEmpty(searchDto.Url))
                {
                    sb.AppendLine("t1.Url like @p2 and ");
                    parameters.Add(new SqlParameter("@p2", $"%{searchDto.Url}%"));

                }

                if (!string.IsNullOrEmpty(searchDto.CategoryName))
                {

                    if (searchDto.CategoryName != "-All-")
                    {
                        sb.AppendLine("t2.CategoryName like @p3 and ");
                        parameters.Add(new SqlParameter("@p3", $"%{searchDto.CategoryName}%"));
                    }

                }

                if (!string.IsNullOrEmpty(searchDto.CreateOwner))
                {
                    if (searchDto.CreateOwner != "-All-")
                    {
                        sb.AppendLine("t1.CreateOwner like @p4 and ");
                        parameters.Add(new SqlParameter("@p4", $"%{searchDto.CreateOwner}%"));
                    }

                }


                sb.AppendLine("t1.IsDeleted = 0 order by t1.Id desc");

                gv.DataSource = sqlHelper.GetTable(sb.ToString(), parameters).Item2;
            }

            gv.Columns["CategoryId"].Visible = false;
        }

        // GetCategory - Category Id ve Name listesini döndürür
        public static void GetCategory(ComboBox cmb, bool addAll)// bool değer döndürmeli. Çünkü -All- yazısı add ve edit formundaki kategoride gözükmemeli.
        {
            var sqlHelper = new SqlHelper(Constants.DefConString);
            var dataTable = sqlHelper.GetTable("select Id, CategoryName from tblCategory order by CategoryName").Item2;
            // Soyut satır ekledik
            if (addAll)
            {
                dataTable.Rows.Add(new object[] { 0, "-All-" });
            }

            cmb.DataSource = dataTable;
            cmb.DisplayMember = "CategoryName";
            cmb.ValueMember = "Id";
        }
        public static void GetOwner(ComboBox cmb)
        {
            var sqlHelper = new SqlHelper(Constants.DefConString);

            var dataTable = sqlHelper.GetTable("select distinct CreateOwner from tblLinks order by CreateOwner").Item2;

            // cmbyi kendimiz ayarladık
            cmb.BeginUpdate();
            cmb.Items.Clear();
            cmb.Items.Add("-All-");

            foreach (DataRow row in dataTable.Rows)
            {
                cmb.Items.Add(row["CreateOwner"]);
            }

            cmb.EndUpdate();
            cmb.SelectedIndex = 0;


        }

    }
}
