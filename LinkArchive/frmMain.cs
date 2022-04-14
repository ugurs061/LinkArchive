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
        tblLinks curTblLinks;
        
        

        // constructor
        public frmMain()
        {
            InitializeComponent();


        }

        // load
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.curTblLinks = null;
            gvTablo.BorderStyle = BorderStyle.None;
            gvTablo.DefaultCellStyle.SelectionBackColor = Color.Green;
            gvTablo.EditMode = DataGridViewEditMode.EditProgrammatically;
            gvTablo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tblLinksBusiness.GetVeri(gvTablo);

            // category combosunu ayarla
            cmbCategory.Items.Clear();
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Sorted = true;

            var sql = "select * from tblCategory ";
            
            List<string> list = sqlHelper.GetCategory(sql);
            
            foreach (string item in list)
            { 
                cmbCategory.Items.Add(item);
            }
            cmbCategory.SelectedIndex = 2;

            //frmCategory c = new frmCategory();

            //if (c.ShowDialog() == DialogResult.OK)
            //{
            //    tblLinksBusiness.GetCategory(cmbCategory);
            //}





        }

        private void dataGVTablo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //seçilen satır
            int selectedNdx = gvTablo.SelectedCells[0].RowIndex;
            var idVal = gvTablo.Rows[selectedNdx].Cells["Id"].Value;

            if (idVal != DBNull.Value)
            {
                var oId = Convert.ToInt32(idVal);

                if (oId > 0)
                {
                    tblLinks tblLinks = new tblLinks();
                    tblLinks.Id = oId;
                    tblLinks.Title = gvTablo.Rows[selectedNdx].Cells["Title"].Value.ToString();
                    tblLinks.Url = gvTablo.Rows[selectedNdx].Cells["Url"].Value.ToString();
                    tblLinks.Category = gvTablo.Rows[selectedNdx].Cells["Category"].Value.ToString();
                    curTblLinks = tblLinks;
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ekle butonuna basınca form kapanması ve yeniden listelenmesi
            tblLinksForm f = new tblLinksForm(this.curTblLinks);

            if (f.ShowDialog() == DialogResult.OK)
            {
                tblLinksBusiness.GetVeri(gvTablo);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.curTblLinks == null)
            {
                MessageBox.Show("Please select for edit row");
                return;
            }

            // ekle butonuna basınca form kapanması ve yeniden listelenmesi
            tblLinksForm f = new tblLinksForm(this.curTblLinks);

            if (f.ShowDialog() == DialogResult.OK)
            {
                tblLinksBusiness.GetVeri(gvTablo);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                

                DialogResult result = MessageBox.Show("Seçili link silinsin mi ?", "Uyarı", MessageBoxButtons.YesNo);

                var sql = "DELETE from tblLinks WHERE Id=@Id";

                List<SqlParameter> parameters = new List<SqlParameter>();
             
                parameters.Add(new SqlParameter("@Id", curTblLinks.Id));



                if (result == DialogResult.Yes)
                {
                    var res = sqlHelper.ExecuteNoneQuery(sql, parameters);
                    
                    tblLinksBusiness.GetVeri(gvTablo);

                }
            }
            catch
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçiniz");

            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {

            //if (txtTittle.Text.Trim() != "" || txtLink.Text.Trim() != "" || cBoxCategory.Text != "")
            //{
            //    SqlCommand komut = new SqlCommand("select * from tblLinks where Tittle like '%" + txtTittle.Text + "%'", con); // ???
            //    SqlDataAdapter adapter = new SqlDataAdapter(komut);
            //    DataSet ds = new DataSet();
            //    adapter.Fill(ds);
            //    gvTablo.DataSource = ds.Tables[0];
            //    con.Close();
            //}
        }

        private void btnCAdd_Click(object sender, EventArgs e)
        {
            frmCategory c = new frmCategory();
            c.ShowDialog();
        }
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
