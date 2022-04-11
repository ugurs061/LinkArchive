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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            DatagridviewSetting(dataGVTablo);//datagrid özellikleri
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-9UN9R3H;Initial Catalog=LinkArchive;Integrated Security=True");
        SqlCommand kmt = new SqlCommand();

        public void DatagridviewSetting(DataGridView datagridview)
        {
            datagridview.BorderStyle = BorderStyle.None;
            datagridview.DefaultCellStyle.SelectionBackColor = Color.Green;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //ekle butonuna basınca form kapanması ve yeniden listelenmesi
            SaveForm f = new SaveForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                GetVeri();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenAlan = dataGVTablo.SelectedCells[0].RowIndex;

                DialogResult result = MessageBox.Show("Seçili link silinsin mi ?", "Uyarı", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes && dataGVTablo.CurrentRow.Cells[0].Value.ToString().Trim() != "")
                {
                    baglanti.Open();
                    kmt.Connection = baglanti;
                    kmt.CommandText = "DELETE from tblLinks WHERE Id='" + dataGVTablo.Rows[secilenAlan].Cells["Id"].Value.ToString() + "' ";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();//bellekten atar
                    baglanti.Close();

                    GetVeri();

                }
            }
            catch
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçiniz");

            }




        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //seçilen satırı edit ekranına getirme
            try
            {
                int secilenAlan = dataGVTablo.SelectedCells[0].RowIndex;

                tblLinks tblLinks = new tblLinks();

                tblLinks.Id = (int)dataGVTablo.Rows[secilenAlan].Cells["Id"].Value;
                tblLinks.Tittle = dataGVTablo.Rows[secilenAlan].Cells["Tittle"].Value.ToString();
                tblLinks.Link = dataGVTablo.Rows[secilenAlan].Cells["Link"].Value.ToString();
                tblLinks.Kategori = dataGVTablo.Rows[secilenAlan].Cells["Kategori"].Value.ToString();

                EditForm f = new EditForm(tblLinks);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    GetVeri();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Satır seçiniz");
                
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetVeri();
        }
        public void GetVeri()
        {
            baglanti.Open();
            string select = "select * from tblLinks Order By Id desc";
            SqlDataAdapter adapter = new SqlDataAdapter(select, baglanti);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGVTablo.DataSource = dt;
            baglanti.Close();



        }

        private void dataGVTablo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //seçilen satır
            int secilenAlan = dataGVTablo.SelectedCells[0].RowIndex;
            tblLinks tblLinks = new tblLinks();

            tblLinks.Id = (int)dataGVTablo.Rows[secilenAlan].Cells["Id"].Value;
            tblLinks.Tittle = dataGVTablo.Rows[secilenAlan].Cells["Tittle"].Value.ToString();
            tblLinks.Link = dataGVTablo.Rows[secilenAlan].Cells["Link"].Value.ToString();
            tblLinks.Kategori = dataGVTablo.Rows[secilenAlan].Cells["Kategori"].Value.ToString();



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (Convert.ToBoolean(baglanti.State) == false)
            {
                baglanti.Open();
            }
            if (txtTittle.Text.Trim() != "" || txtLink.Text.Trim() != "" || cBoxKategori.Text != "")
            {
                SqlCommand komut = new SqlCommand("select * from tblLinks where Tittle like '%" + txtTittle.Text + "%'", baglanti); // ???
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGVTablo.DataSource = ds.Tables[0];
                baglanti.Close();
            }


        }
    }
}
