using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace StrenuousV1._0
{
    public partial class page_login : UserControl
    {
        public page_login()
        {
            InitializeComponent();
        }

        private void main_streneous_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Parent.Controls.Find("page_kayitol1", true)[0].BringToFront();
        }

        private void bunifuImageButton3_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            bool basariliMi = false;
            SqlConnection baglanti = new SqlConnection();
            try
            {
                baglanti.ConnectionString = "Data Source=DESKTOP-N0FIF4F\\STYXSERVER;Initial Catalog=musteritakip;Integrated Security=True";
                baglanti.Open();
                SqlParameter prm1 = new SqlParameter("@kullaniciAdi", TextBox_KulAdi.Text);
                SqlParameter prm2 = new SqlParameter("@sifre", TextBox_Sifre.Text);
                string sql = "SELECT * FROM S_personel WHERE kullaniciAdi = @kullaniciAdi AND sifre = @sifre";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                using (SqlDataReader oReader = komut.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        basariliMi = true;
                    }
                }
                if (basariliMi)
                {
                    lblHata.ResetText();
                    lblexhata.ResetText();
                    lblDogrulama.Text = "Giriş Başarılı. Yönlendiriliyorsunuz.";
                    Parent.Controls.Find("page_musterilerim1", true)[0].BringToFront();
                    this.Hide();
                    lblDogrulama.Text = "";
                    //Veri tipi
                }
                else
                {
                    lblDogrulama.ResetText();
                    lblexhata.ResetText();
                    MessageBox.Show("Hatalı Giriş Denemesi");

                }
            }
            catch (Exception ex)
            {
                lblDogrulama.ResetText();
                lblHata.ResetText();
                lblexhata.Text = ex.Message;
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
