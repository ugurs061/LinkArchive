using LinkArchive.Business;
using LinkArchive.Forms;
using System;
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
        private void HomePage_Load(object sender, EventArgs e)
        {
            this.curTblLinks = null;
            gvTablo.BorderStyle = BorderStyle.None;
            gvTablo.DefaultCellStyle.SelectionBackColor = Color.Green;
            gvTablo.EditMode = DataGridViewEditMode.EditProgrammatically;
            gvTablo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tblLinksBusiness.GetVeri(gvTablo);

            // category combosunu ayarla
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Özel");
            cmbCategory.Items.Add("Eğitim");
            cmbCategory.Items.Add("İş");
            cmbCategory.Items.Add("Okul");
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.SelectedIndex = 0;
            cmbCategory.Sorted = true;
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
            //try
            //{
            //    int secilenAlan = gvTablo.SelectedCells[0].RowIndex;

            //    DialogResult result = MessageBox.Show("Seçili link silinsin mi ?", "Uyarı", MessageBoxButtons.YesNo);

            //    if (result == DialogResult.Yes && gvTablo.CurrentRow.Cells[0].Value.ToString().Trim() != "")
            //    {
            //        con.Open();
            //        cmd.Connection = con;
            //        cmd.CommandText = "DELETE from tblLinks WHERE Id='" + gvTablo.Rows[secilenAlan].Cells["Id"].Value.ToString() + "' ";
            //        cmd.ExecuteNonQuery();
            //        cmd.Dispose();//bellekten atar
            //        con.Close();

            //        GetVeri();

            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Lütfen silmek istediğiniz satırı seçiniz");

            //}
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

    }
}
