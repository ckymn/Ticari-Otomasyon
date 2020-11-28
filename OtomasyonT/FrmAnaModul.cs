using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtomasyonT
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        private void Bank_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        FrmUrunler fr1;
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr1 == null)
            {
                fr1 = new FrmUrunler();
                fr1.MdiParent = this;
                fr1.Show();
            }
        }
        FrmMusteriler fr2;
        private void btnMusterıler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null)
            {
                fr2 = new FrmMusteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        FrmFirmalar fr3;
        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr3 == null)
            {
                fr3 = new FrmFirmalar();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }
        FrmPersonel fr4;
        private void btnPersonleller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr4 == null)
            {
                fr4 = new FrmPersonel();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }
        FrmRehber fr5;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // daha once fr5 hic acilmadiysa
            if (fr5 == null)
            {
                fr5 = new FrmRehber();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }

        FrmFaturalar fr6;
        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr6 == null)
            {
                fr6 = new FrmFaturalar();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }
    }
}
