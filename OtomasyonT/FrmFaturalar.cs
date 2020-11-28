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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_FATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        //TEMZLE
        void temizle()
        {
            txtAlici.Text = "";
            txtId.Text = "";
            txtSeri.Text = "";
            txtSiraNo.Text = "";
            txtTeslimAlan.Text = "";
            txtTeslimEden.Text = "";
            txtVergiD.Text = "";
            mskSaat.Text = "";
            mskTarih.Text = "";
            
        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        // kaydetme islemi
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // faturaid  verisi bos ise fatura bilgisi kaydedilicek
            if(txtFaturaId.Text == "")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());

                komut.Parameters.AddWithValue("@p1", txtSeri.Text);
                komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
                komut.Parameters.AddWithValue("@p3", mskTarih.Text);
                komut.Parameters.AddWithValue("@p4", mskSaat.Text);
                komut.Parameters.AddWithValue("@p5", txtVergiD.Text);
                komut.Parameters.AddWithValue("@p6", txtAlici.Text);
                komut.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
                komut.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti();
                MessageBox.Show("FATURABILGISI SISTEME KAYDEDILDI ","BILGI",MessageBoxButtons.OK,MessageBoxIcon.Information);
                listele();
            }
            else if (txtFaturaId.Text != "")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtFiyat.Text);
                tutar = fiyat * miktar;
                txtTutar.Text = tutar.ToString();

                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD , MIKTAR , FIYAT, TUTAR ,FATURAID ) values (@p1,@p2,#@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtUrunAd.Text);
                komut2.Parameters.AddWithValue("@p2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", txtFiyat.Text);
                komut2.Parameters.AddWithValue("@p4", txtTutar.Text);
                komut2.Parameters.AddWithValue("@p5", txtFaturaId.Text);

                komut2.ExecuteNonQuery();
                bgl.baglanti();
                MessageBox.Show("FATURAYA AIT URUN KAYDEDILDI ", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = new gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtId.Text = dr["FATURABILGIID"].ToString();
                txtSiraNo.Text = dr["SIRANO"].ToString();
                txtSeri.Text = dr["SERINO"].ToString();
                mskTarih.Text = dr["TARIH"].ToString();
                mskSaat.Text = dr["SAAT"].ToString();
                txtVergiD.Text = dr["ALICI"].ToString();
                txtAlici.Text = dr["VERGIDAIRE"].ToString();
                txtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
                txtTeslimAlan.Text = dr["TESLIMALAN"].ToString();
                
            }
        }
        // TEMIZLE BUTONU
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }
        // SIL BUTONU
        private void btnSil_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Delete from TBL_FATURABILGI where FATURABILGIID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();// insert update delete komutlarinda calisir.
            bgl.baglanti().Close();
            MessageBox.Show("FATURA SILINDI SILINDI", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI set " +
               "SERI=@p1,SIRA=@p2,TARIH=@p3,SAAT=@p4,VERGIDAIRE=@p5,ALICI=@p6,TESLIMEDEN=@p7,TESLIMALAN=@p8 where FATURABILGIID=@p9", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", txtSeri.Text);
            komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
            komut.Parameters.AddWithValue("@p3", mskTarih.Text);
            komut.Parameters.AddWithValue("@p4", mskSaat.Text);
            komut.Parameters.AddWithValue("@p5", txtVergiD.Text);
            komut.Parameters.AddWithValue("@p6", txtAlici.Text);
            komut.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
            komut.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
 
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("fATURA BILGISI GUNCELLENDI", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            // burdaki fatura urunlerini faturaurundetay kisminda acmasini sagliycak
            FrmFaturaUrunDetay frm = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if(dr != null)
            {
                frm.id = dr["FATURABILGIID"].ToString();
                frm.Show();

            }
        }
    }
}
