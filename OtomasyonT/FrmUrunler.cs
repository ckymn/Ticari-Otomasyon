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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER", bgl.baglanti());
            // veri tabanindan cektigimiz degerleri dataTable yerlestir.
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            // form yuklendigi zaman listele metodunu calistir
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Verileri Kaydetme
            SqlCommand komut;
            komut = new SqlCommand("insert into TBL_URUNLER(URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", mskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((nudAdet.Text).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtAlis.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtSatis.Text));
            komut.Parameters.AddWithValue("@p8", rchDetay.Text);

            // sorgu calistirma islemi
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("URUN SISTEME EKLENDI", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //verileri ekledikten sonra listeleme iselemi
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutSil = new SqlCommand("Delete From TBL_URUNLER where ID=@p1", bgl.baglanti());
            komutSil.Parameters.AddWithValue("@p1", txtId.Text);

            //sorgu calistirma islemi
            komutSil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("URUN SILINDI", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //son hali listeleme
            listele();
        }
    }
}
