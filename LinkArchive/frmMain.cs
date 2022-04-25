using LinkArchive.Business;
using LinkArchive.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LinkArchive
{
    public partial class frmMain : Form
    {
        // variables
        SqlHelper sqlHelper = new SqlHelper(Constants.DefConString);
        tblLinksDto curTblLinksDto;

        // constructor
        public frmMain()
        {
            InitializeComponent();


        }

        // load
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = $"Welcome to LinkArchive v1.0 ({Environment.MachineName})";
            this.curTblLinksDto = null;
            //gvTablo.BorderStyle = BorderStyle.None;
            gvTablo.DefaultCellStyle.SelectionBackColor = Color.Green;
            gvTablo.EditMode = DataGridViewEditMode.EditProgrammatically;
            gvTablo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvTablo.AllowUserToAddRows = false;
            gvTablo.MultiSelect = false;
            gvTablo.CellClick += GvTablo_CellClick;
            gvTablo.CellDoubleClick += GvTablo_CellDoubleClick;
            tblLinksBusiness.GetVeri(gvTablo, null);


            // category combosunu ayarla
            cmbCategory.Items.Clear();
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Sorted = true;
            tblLinksBusiness.GetCategory(cmbCategory);

            

            //var sql = "select * from tblCategory ";

            //List<string> list = sqlHelper.GetCategory(sql);

            //foreach (string item in list)
            //{ 
            //    cmbCategory.Items.Add(item);
            //}
            //cmbCategory.SelectedIndex = 2;

            //frmCategory c = new frmCategory();

            //if (c.ShowDialog() == DialogResult.OK)
            //{
            //    tblLinksBusiness.GetCategory(cmbCategory);
            //}

        }

        private void GvTablo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // todo: will do 
            // çift tıklandığında ilgili url adresini tarayıcıda aç
        }

        private void GvTablo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //seçilen satır
            int selectedNdx = gvTablo.SelectedCells[0].RowIndex;
            var idVal = gvTablo.Rows[selectedNdx].Cells["Id"].Value;

            if (idVal != DBNull.Value)
            {
                var oId = Convert.ToInt32(idVal);

                if (oId > 0)
                {
                    tblLinksDto tblLinksDto = new tblLinksDto();

                    tblLinksDto.Id = oId;
                    tblLinksDto.CategoryId = Convert.ToInt32(gvTablo.Rows[selectedNdx].Cells["CategoryId"].Value);
                    tblLinksDto.CategoryName = Convert.ToString(gvTablo.Rows[selectedNdx].Cells["CategoryName"].Value);
                    tblLinksDto.Title = gvTablo.Rows[selectedNdx].Cells["Title"].Value.ToString();
                    tblLinksDto.Url = gvTablo.Rows[selectedNdx].Cells["Url"].Value.ToString();
                    tblLinksDto.CreateOwner = gvTablo.Rows[selectedNdx].Cells["CreateOwner"].Value.ToString();
                    tblLinksDto.CreatedAt = Convert.ToDateTime(gvTablo.Rows[selectedNdx].Cells["CreatedAt"].Value);

                    curTblLinksDto = tblLinksDto;
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ekle butonuna basınca form kapanması ve yeniden listelenmesi
            tblLinksForm f = new tblLinksForm(null);

            if (f.ShowDialog() == DialogResult.OK)
            {
                tblLinksBusiness.GetVeri(gvTablo, null);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.curTblLinksDto == null)
            {
                MessageBox.Show("Please select for edit row");
                return;
            }

            // ekle butonuna basınca form kapanması ve yeniden listelenmesi
            tblLinksForm f = new tblLinksForm(this.curTblLinksDto);

            if (f.ShowDialog() == DialogResult.OK)
            {
                tblLinksBusiness.GetVeri(gvTablo, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {


                DialogResult result = MessageBox.Show("Seçili link silinsin mi ?", "Uyarı", MessageBoxButtons.YesNo);

                var sql = "DELETE from tblLinks WHERE Id=@Id";

                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("@Id", curTblLinksDto.Id));



                if (result == DialogResult.Yes)
                {
                    var res = sqlHelper.ExecuteNoneQuery(sql, parameters);

                    tblLinksBusiness.GetVeri(gvTablo, null);

                }
            }
            catch
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçiniz");

            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            tblLinksDto searchDto = new tblLinksDto();
            searchDto.Title = txtTitle.Text.Trim();

            searchDto.Url = txtUrl.Text.Trim();

            

            tblLinksBusiness.GetVeri(gvTablo, searchDto);
        }

        private void btnCAdd_Click(object sender, EventArgs e)
        {
            //?? kategori ekleyince yenilemiyor

            frmCategory c = new frmCategory();


            if (c.ShowDialog() == DialogResult.OK)
            {
                tblLinksBusiness.GetCategory(cmbCategory);
            }


        }
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // todo: uyarı mesajı ile sor
                this.Close();
            }
        }
    }
}
