using LinkArchive.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkArchive
{
    public partial class frmCategory : Form
    {
        SqlHelper sqlHelper = new SqlHelper(Constants.DefConString);
        public frmCategory()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
        }

        private void frmCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var category=txtCategory.Text.Trim();
            
            if (category != null)
            {
                var sql = "insert into tblCategory (Category) values (@Category)";
                
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Category", category));

                var res = sqlHelper.ExecuteNoneQuery(sql, parameters);
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Added");

                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var category = txtCategory.Text.Trim();

            if (category != null)
            {
                var sql = "delete from tblCategory where Category=@Category";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Category", category));

                var res = sqlHelper.ExecuteNoneQuery(sql, parameters);

                MessageBox.Show("Deleted");
            }
        }
    }
}
