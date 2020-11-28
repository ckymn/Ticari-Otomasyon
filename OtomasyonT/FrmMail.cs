using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace OtomasyonT
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            txtMail.Text = mail;
        }
        // MESAJI GONDERME ASAMALARI
        private void btnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            // kendi mail adresi ve sifresini yaziyoruz
            istemci.Credentials = new System.Net.NetworkCredential("Mail", "Sifre");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mesajim.To.Add(rchMesaj.Text);
            mesajim.From = new MailAddress("Mail");
            mesajim.Subject = txtkonu.Text;
            mesajim.Body = rchMesaj.Text;
            istemci.Send(mesajim);
        }
    }
}
