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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        // Form yuklendigi zaman calisacak islemler
        private void FrmRehber_Load(object sender, EventArgs e)
        {
            // MUSTERI BILGILERI
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,SOYAD,TELEFON,TELEFON2,MAIL from TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            // FIRMA BILGILERI
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select AD,YETKILIADSOYAD,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX from TBL_FIRMALAR", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

        }
        // musteriler icin mail adresi alma
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            // musterilerde sectigimiz satirim degerini dr`ye atiycak
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["MAIL"].ToString(); // dr icindeki adresi stringe cevirip gostericek
            }

            frm.Show();
        }
        // firmalar icin mail adresi alma
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            // firmalarda sectigimiz satiri bulma islemi
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["MAIL"].ToString();
            }
            frm.Show();
        }
    }
}
