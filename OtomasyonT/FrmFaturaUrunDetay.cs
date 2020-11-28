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
    public partial class FrmFaturaUrunDetay : Form
    {
        public FrmFaturaUrunDetay()
        {
            InitializeComponent();
        }

        public string id;
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FATURADETAY where FATURAID = '" + id + "' ", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        private void FrmFaturaUrunDetay_Load(object sender, EventArgs e)
        {
            listele();

        }

      
    }
}
