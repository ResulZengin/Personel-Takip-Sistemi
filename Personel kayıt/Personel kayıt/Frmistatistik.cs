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

namespace Personel_kayıt
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VJO627U\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel Sayısı
            baglantı.Open();
            SqlCommand komut1=new SqlCommand("Select Count(*) From Tbl_Personel",baglantı);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplamPersonel.Text = dr1[0].ToString();
            }
            baglantı.Close();
            //Evli Personel Sayısı
            baglantı.Open ();

            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=1 ",baglantı);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvliPersonel.Text = dr2[0].ToString();
            }
            baglantı.Close ();
            //Bekar Personel Sayısı
            baglantı.Open () ;
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=0", baglantı);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekarSayısı.Text = dr3[0].ToString();
            }

            baglantı.Close () ;

            //şehir saysısı
            baglantı.Open() ;
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(PerSehir)) From Tbl_Personel",baglantı);
            SqlDataReader dr4 =komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblSehirSayısı.Text = dr4[0].ToString();
            }

            baglantı.Close();

            //Toplam Maaş
            baglantı.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas) From Tbl_Personel",baglantı);
            SqlDataReader dr5= komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblToplamMaas.Text = dr5[0].ToString();
            }
            baglantı.Close() ;
            //Ortalama Maaş
          
            baglantı.Open ();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) From Tbl_Personel",baglantı);
            SqlDataReader dr6=komut6.ExecuteReader();
            while(dr6.Read())
            {
                LblOrtalamaMaas.Text = dr6[0].ToString();
            }
            baglantı.Close();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
