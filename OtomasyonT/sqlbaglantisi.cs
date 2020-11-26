using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtomasyonT
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            // burda sql connection ile sql server veritabani adresine baglantisini gerceklestirdik
            SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-DQUKB5F3;Initial Catalog=Dbo TicariOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
