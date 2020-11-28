using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OtomasyonT
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.Blue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.CadetBlue;

        }
        // BURDA GIRIS BUTONUNA TIKLADIKTAN SONRA VERI TABANINDA BULUNAN KULLANICILAR ILE KIYASLAMA YAPILDIKTAN SONRA ANA SAYFAYA BIZLERI YONLEDIRECEK
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From TBL_ADMIN where KullaniciAdi=@p1 and Sifre=@p2", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaModul fr = new FrmAnaModul();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("HATALI KULLANICIADI VEYA SIFRE", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();

        }

    }
}
