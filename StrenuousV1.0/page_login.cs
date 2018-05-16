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
        string superAdminID = "SuperAdmin";
        string superAdminPW = "Process5461";
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
            string girilenId = TextBox_KulAdi.Text;
            string girilenPw = TextBox_Sifre.Text;
            if(girilenId.Equals(superAdminID) && girilenPw.Equals(superAdminPW))
            {
                //Super admin girisi, oraya yonlendir.
                Parent.Controls.Find("superAdminPanel1", true)[0].Visible = true;
                Parent.Controls.Find("superAdminPanel1", true)[0].BringToFront();
                return; //No need to continue further.
            }
            bool basariliMi = false;
            SqlConnection baglanti = new SqlConnection();
            try
            {
                baglanti.ConnectionString = "Data Source=DESKTOP-N0FIF4F\\STYXSERVER;Initial Catalog=musteritakip;Integrated Security=True";
                baglanti.Open();
                SqlParameter prm1 = new SqlParameter("@kullaniciAdi", girilenId);
                SqlParameter prm2 = new SqlParameter("@sifre", girilenPw);
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
                    Parent.Controls.Find("panel2", true)[0].Visible = true; //Show panel again
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
