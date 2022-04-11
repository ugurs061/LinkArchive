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
    public partial class EditForm : Form
    {
        tblLinks tblLink;
        public EditForm(tblLinks tblLink)
        {
            this.tblLink = tblLink;

            InitializeComponent();

            txtTittle.Text = tblLink.Tittle;
            txtLink.Text = tblLink.Link;
            cBoxKategori.SelectedIndex =cBoxKategori.FindStringExact(tblLink.Kategori) ;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-9UN9R3H;Initial Catalog=LinkArchive;Integrated Security=True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update tblLinks set Tittle = @tittle, Link = @link, Kategori = @kategori where Id = @Id", baglanti);

            cmd.Parameters.Add("@Id", tblLink.Id);
            cmd.Parameters.Add("@tittle", txtTittle.Text);
            cmd.Parameters.Add("@link", txtLink.Text);
            cmd.Parameters.Add("@kategori", cBoxKategori.Text);

            cmd.ExecuteNonQuery();

            this.DialogResult = DialogResult.OK;//formu onay formu gibi gösterme

            baglanti.Close();



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
