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
            this.DoubleBuffered = true;// Titreşimi azaltmak için kullanılır
        }

        // load
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = $"Welcome to LinkArchive v1.0 ({Environment.UserName})";
            this.curTblLinksDto = null;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimumSize = new Size(800, 500);
            //this.StartPosition = FormStartPosition.CenterScreen;

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
            tblLinksBusiness.GetCategory(cmbCategory, true);

            cmbOwner.DropDownStyle = ComboBoxStyle.DropDownList;
            tblLinksBusiness.GetOwner(cmbOwner);

            // combodan birşey seçildiğinde btnSearch'e click yap
            cmbCategory.SelectedIndexChanged += (ss, ee) => { btnSearch.PerformClick(); };
            cmbOwner.SelectedIndexChanged += (ss, ee) => { btnSearch.PerformClick(); };
        }

        private void GvTablo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // çift tıklandığında ilgili url adresini tarayıcıda aç

            System.Diagnostics.Process.Start(curTblLinksDto.Url);

        }

        private void GvTablo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetSelectedRow();
        }

        private void SetSelectedRow()
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
            // add butonuna basınca form kapanması ve yeniden listelenmesi
            tblLinksForm f = new tblLinksForm(null);

            if (f.ShowDialog() == DialogResult.OK)
            {
                tblLinksBusiness.GetVeri(gvTablo, null);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetSelectedRow();

            if (this.curTblLinksDto == null)
            {
                MessageBox.Show("Please select for edit row");
                return;
            }

            // edit butonuna basınca form kapanması ve yeniden listelenmesi
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
                // todo: delete işlemini yap

                DialogResult result = MessageBox.Show("Seçili link silinsin mi ?", "Uyarı", MessageBoxButtons.YesNo);




                if (result == DialogResult.Yes)
                {


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
            searchDto.CategoryName = cmbCategory.Text;
            searchDto.CreateOwner = cmbOwner.Text;

            tblLinksBusiness.GetVeri(gvTablo, searchDto);
        }

        private void btnCAdd_Click(object sender, EventArgs e)
        {

            frmCategory c = new frmCategory();


            if (c.ShowDialog() == DialogResult.OK)
            {
                tblLinksBusiness.GetCategory(cmbCategory, false);
            }


        }
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }
    }
}
