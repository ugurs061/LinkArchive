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
    public partial class SaveForm : Form
    {
        public SaveForm()
        {
            InitializeComponent();
        }
        SqlHelper sqlHelper=new SqlHelper();
       
        SqlConnection baglanti=new SqlConnection(@"Data Source=DESKTOP-9UN9R3H;Initial Catalog=LinkArchive;Integrated Security=True");
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTittle.Text != "" || txtLink.Text != "" || cBoxKategori.Text !="")
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("insert into tblLinks (Tittle,Link,Kategori) values (@tittle,@link,@kategori)", baglanti);

                cmd.Parameters.Add("@tittle", txtTittle.Text);
                cmd.Parameters.Add("@link", txtLink.Text);
                cmd.Parameters.Add("@kategori", cBoxKategori.Text);

                cmd.ExecuteNonQuery();
                baglanti.Close();

                this.DialogResult = DialogResult.OK;//formu onay formu gibi gösterme

                this.Close();

            }
            else
            {
                MessageBox.Show("Lütfen eklemek istediğiniz bilgileri giriniz.");
            }
          

        }
       
        
        
        //void Ekle()
        //{
        //    string tittle = txtTittle.Text;
        //    string link = txtLink.Text;
        //    string kategori = cBoxKategori.Text;

        //    SqlParameter p1 = new SqlParameter("Tittle", tittle);
        //    SqlParameter p2 = new SqlParameter("Link", link);
        //    SqlParameter p3 = new SqlParameter("Kategori", kategori);

        //    sqlHelper.ExecuteProc("tblLinks", p1, p2, p3);

        //    MessageBox.Show("Eklendi");
        //}
        
    }
}
