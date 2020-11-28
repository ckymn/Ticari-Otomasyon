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

        // sql baglantisi
        sqlbaglantisi bgl = new sqlbaglantisi();
        // urun listeleme
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER", bgl.baglanti());
            // veri tabanindan cektigimiz degerleri dataTable yerlestir.
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        // URUN TEK TUS ILE TEMIZLEME
        void temizle()
        {
            txtAd.Text = "";
            txtMarka.Text = "";
            txtModel.Text = "";
            mskYil.Text = "";
            nudAdet.Value = 0;
            txtAlis.Text = "";
            txtSatis.Text = "";
            rchDetay.Text = "";
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            // form yuklendigi zaman listele metodunu calistir
            listele();
            temizle();
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
            MessageBox.Show("URUN SILINDI", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //son hali listeleme
            listele();
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {

        }

        // guncelleme islemi
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_URUNLER set URUNAD=@P1,MARKA=@P2,MODEL=@P3,YIL=@P4,ADET=@P5,ALISFIYAT=@P6,SATISFIYAT=@P7,DETAY=@P8 where ID=@P9", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", mskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((nudAdet.Text).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtAlis.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtSatis.Text));
            komut.Parameters.AddWithValue("@p8", rchDetay.Text);
            komut.Parameters.AddWithValue("@p9", txtId.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("URUN BILGISI GUNCELLENDI", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // imlecin satiri degisecegi zaman olusacak islemler
            DataRow dr = new gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["ID"].ToString();
                txtAd.Text = dr["URUNAD"].ToString();
                txtMarka.Text = dr["MARKA"].ToString();
                txtModel.Text = dr["MODEL"].ToString();
                mskYil.Text = dr["YIL"].ToString();
                nudAdet.Value = decimal.Parse(dr["ADET"].ToString());
                txtAlis.Text = dr["ALISFIYAT"].ToString();
                txtSatis.Text = dr["SATISFIYAT"].ToString();
                rchDetay.Text = dr["DETAY"].ToString();
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
