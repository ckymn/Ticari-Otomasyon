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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        // veri tabanina baglanma
        sqlbaglantisi bgl = new sqlbaglantisi();
        // gelen verileri listeleme islemi
        void personelListe()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_PERSONELLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        // sehirleri listeleme
        void sehirlistele()
        {
            SqlCommand komut = new SqlCommand("Select Sehir From TBL_ILLER ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti();
        }
        // tek tus ile butun alanalri temziler
        void temizle()
        {
            txtAd.Text = "";
            txtId.Text = "";
            txtGorev.Text = "";
            mskTc.Text = "";
            mskTelefon1.Text = "";
            txtMail.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text = "";
        }
        // form yuklenince calisacak islemler
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            personelListe();

            sehirlistele();

            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,GOREV,ADRES) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTelefon1.Text);
            komut.Parameters.AddWithValue("@p5", mskTc.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", cmbIl.Text);
            komut.Parameters.AddWithValue("@p8", cmbIlce.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.Parameters.AddWithValue("@p10", rchAdres.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("MUSTERI SISTEME EKLENDI", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelListe();
        }

        // bunlar grid alanina verri tabaninda gelen degerleri foculadigin zaman degerleri group Control`e aktarir
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = new gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtId.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                mskTelefon1.Text = dr["TELEFON"].ToString();
                mskTc.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                cmbIl.Text = dr["IL"].ToString();
                cmbIlce.Text = dr["ILCE"].ToString();
                rchAdres.Text = dr["ADRES"].ToString();
                txtGorev.Text = dr["GOREV"].ToString();

            }
        }
        // temizle
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }
        // sil
        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_PERSONELLER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("PERSONEL LISTEDEN SILINDI", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
            personelListe();
            temizle();
        }

        //guncelle
        private void btnGuncelle_Paint(object sender, PaintEventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_MUSTERILER set " +
               "AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4,MAIL=@p5,IL=@p6,ILCE=@p7,GOREV=@p8,ADRES=@p9 where ID=@p10", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", mskTc.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbIl.Text);
            komut.Parameters.AddWithValue("@p7", cmbIlce.Text);
            komut.Parameters.AddWithValue("@p8", txtGorev.Text);
            komut.Parameters.AddWithValue("@p9", rchAdres.Text);
            komut.Parameters.AddWithValue("@p10", txtId.Text);


            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("MUSTERI BILGISI GUNCELLENDI", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            personelListe();
            temizle();
        }
    }
}
