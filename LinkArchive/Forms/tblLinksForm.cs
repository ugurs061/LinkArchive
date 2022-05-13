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
                var userName = Environment.UserName;
                var categoryId = int.Parse(cmbCategory.SelectedValue.ToString()); // category ıd tutmak için 

                var sql = "insert into tblLinks (CategoryId, Title, Url, CreateOwner, CreatedAt, IsDeleted) values (@CategoryId, @Title, @Url, @CreateOwner, @CreatedAt, @IsDeleted)";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@CategoryId", categoryId));
                parameters.Add(new SqlParameter("@Title", title));
                parameters.Add(new SqlParameter("@Url", link));
                parameters.Add(new SqlParameter("@CreateOwner", userName));

                // parametre verirken parametre tipini belirtmemiz gerekiyor.
                var pCreatedAt = new SqlParameter("@CreatedAt", System.Data.SqlDbType.DateTime);
                pCreatedAt.Value = DateTime.Now;
                parameters.Add(pCreatedAt);

                var pIsDeleted = new SqlParameter("@IsDeleted", System.Data.SqlDbType.Int);
                pIsDeleted.Value = 0;
                parameters.Add(pIsDeleted);

                var res = sqlHelper.ExecuteNoneQuery(sql, parameters);

                if (res.Item1)
                {
                    // kayıt başarılı
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    // kayıt başarısız. Sonuç, Item2 stringinde.
                    MessageBox.Show(res.Item2);
                }

            }
            else
            {
                // todo: Güncelleme de hata var 

                var categoryId = int.Parse(cmbCategory.SelectedValue.ToString());

                var sql = "update tblLinks set CategoryId=@CategoryId, Title = @Title, Url = @Url where Id = @Id";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Id", this.curTblLinkDto.Id));
                parameters.Add(new SqlParameter("@Title", title));
                parameters.Add(new SqlParameter("@Url", link));
                parameters.Add(new SqlParameter("@CategoryId", categoryId));

                var res = sqlHelper.ExecuteNoneQuery(sql, parameters);

                if (res.Item1)
                {
                    // kayıt başarılı
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    // kayıt başarısız. Sonuç, Item2 stringinde.
                    MessageBox.Show(res.Item2);
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
