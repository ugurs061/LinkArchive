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
        tblLinks curTblLink;

        // constructor
        public tblLinksForm(tblLinks tblLinks)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.curTblLink = tblLinks;
        }

        // load
        private void tblLinksForm_Load(object sender, EventArgs e)
        {
            // category combosunu ayarla
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Özel");
            cmbCategory.Items.Add("Eğitim");
            cmbCategory.Items.Add("İş");
            cmbCategory.Items.Add("Okul");
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.SelectedIndex = 0;
            cmbCategory.Sorted = true;

            // diğer text görsellerini ayarla
            if (this.curTblLink == null) // add yapılacak demek
            {
                this.Text = "Add";
                btnAdd.Text = "Add";
            }
            else // edit yapılacak demek
            {
                this.Text = "Edit";
                btnAdd.Text = "Edit";

                txtLink.Text = this.curTblLink.Url;
                txtTittle.Text = this.curTblLink.Title;
                cmbCategory.Text = this.curTblLink.Category;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // verileri ekrandan topla (grab)
            var title = txtTittle.Text.Trim();
            var link = txtLink.Text.Trim();
            var category = cmbCategory.Text.Trim();

            // validations
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a title");
                txtTittle.Focus();
                return;
            }

            if (string.IsNullOrEmpty(link))
            {
                MessageBox.Show("Please enter a link");
                txtLink.Focus();
                return;
            }

            if (this.curTblLink == null)
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
                parameters.Add(new SqlParameter("@Id", this.curTblLink.Id));
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
    }
}
