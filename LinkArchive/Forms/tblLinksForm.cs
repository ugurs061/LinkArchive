using LinkArchive.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LinkArchive.Forms
{
    public partial class tblLinksForm : Form
    {
        // variables
        SqlHelper sqlHelper = new SqlHelper(Constants.DefConString);
        tblLinksDto curTblLinkDto;

        // constructor
        public tblLinksForm(tblLinksDto tblLinksDto)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.curTblLinkDto = tblLinksDto;
        }

        // load
        private void tblLinksForm_Load(object sender, EventArgs e)
        {
            // category combosunu ayarla
            //cmbCategory.Items.Clear();
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            //cmbCategory.Sorted = true;
            //var sql = "select * from tblCategory ";
            //List<string> list = sqlHelper.GetCategory(sql);
            //foreach (string item in list)
            //{
            //    cmbCategory.Items.Add(item);
            //}
            //cmbCategory.SelectedIndex = 2;

            tblLinksBusiness.GetCategory(cmbCategory, false);

            // diğer text görsellerini ayarla
            if (this.curTblLinkDto == null) // add yapılacak demek
            {
                this.Text = "Add";
                btnAdd.Text = "Save";
            }
            else // edit yapılacak demek
            {
                this.Text = "Edit";
                btnAdd.Text = "Save";

                txtUrl.Text = this.curTblLinkDto.Url;
                txtTitle.Text = this.curTblLinkDto.Title;
                cmbCategory.Text = this.curTblLinkDto.CategoryName;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // verileri ekrandan topla (grab)
            var title = txtTitle.Text.Trim();
            var link = txtUrl.Text.Trim();
            var category = cmbCategory.Text.Trim();

            // validations
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a title");
                txtTitle.Focus();
                return;
            }

            if (string.IsNullOrEmpty(link))
            {
                MessageBox.Show("Please enter a link");
                txtUrl.Focus();
                return;
            }

            if (this.curTblLinkDto == null)
            {
                var sql = "insert into tblLinks (Title, Url, Category) values (@Title, @Url, @Category)";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Title", title));
                parameters.Add(new SqlParameter("@Url", link));
                parameters.Add(new SqlParameter("@Category", category));

                var res = sqlHelper.ExecuteNoneQuery(sql, parameters);

                if (res.Item1)
                {
                    // kayıt başarılı
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    // kayıt başarısız. Sonuç, Item2 stringinde.
                }

            }
            else
            {
                var sql = "update tblLinks set Title = @Title, Url = @Url, Category = @Category where Id = @Id";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Id", this.curTblLinkDto.Id));
                parameters.Add(new SqlParameter("@Title", title));
                parameters.Add(new SqlParameter("@Url", link));
                parameters.Add(new SqlParameter("@Category", category));

                var res = sqlHelper.ExecuteNoneQuery(sql, parameters);

                if (res.Item1)
                {
                    // kayıt başarılı
                    this.DialogResult = DialogResult.OK;


                }
                else
                {
                    // kayıt başarısız. Sonuç, Item2 stringinde.
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tblLinksForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
