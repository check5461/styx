using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace StrenuousV1._0
{
    public partial class musteri_bilgileri : UserControl
    {
        public musteri_bilgileri()
        {
            InitializeComponent();
        }
        

        private static string connectionString = "Data Source=DESKTOP-N0FIF4F\\STYXSERVER;Initial Catalog=musteritakip;Integrated Security=True";

        private void filterByIdToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void musteri_bilgileri_Load(object sender, EventArgs e)
        {

        }

        private void musteriUrun_dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            string filterById = "SELECT musID, domains, ftp_ip, ftp_pw, bas_tarihi, bit_tarihi, alinmis_ucret, alinacak_ucret, yillik_altyapi_ucreti FROM dbo.musteriurunbilgisi WHERE MusID ='" + TextBox_Arama.Text + "';";
            Veritabani.DataGridDoldur(filterById, musteriUrun_dataGrid);
        }

        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton12_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string kayit = "insert into dbo.musteriurunbilgisi(musID,domains,ftp_ip,ftp_pw,bas_tarihi,bit_tarihi,alinmis_ucret,alinacak_ucret,yillik_altyapi_ucreti) values (@musID,@domains,@ftp_ip,@ftp_pw,@bas_tarihi,@bit_tarihi,@alinmis_ucret,@alinacak_ucret,@yillik_altyapi_ucreti)";
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, connection);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                SqlParameter parammusID = new SqlParameter("musID", TextBox_Mus_ID.Text);
                SqlParameter paramdomains = new SqlParameter("@domains", TextBox_domain_adi.Text);
                SqlParameter paramftp_ip = new SqlParameter("@ftp_ip", TextBox_ftp_ip.Text);
                SqlParameter paramftp_pw = new SqlParameter("@ftp_pw", TextBox_FTP_Sifre.Text);
                SqlParameter parambas_tarihi = new SqlParameter("@bas_tarihi", bas_tarihi.Value);
                SqlParameter parambit_tarihi = new SqlParameter("@bit_tarihi", bit_tarihi.Value);
                SqlParameter paramalinmis_ucret = new SqlParameter("@alinmis_ucret", decimal.Parse(TextBox_alinmis_ucret.Text));
                SqlParameter paramalinacak_ucret = new SqlParameter("@alinacak_ucret", decimal.Parse(TextBox_alinacak_ucret.Text));
                SqlParameter paramyillik_altyapi_ucreti = new SqlParameter("@yillik_altyapi_ucreti", decimal.Parse(TextBox_Altyapi_ucreti.Text));

                komut.Parameters.Add(parammusID);
                komut.Parameters.Add(paramdomains);
                komut.Parameters.Add(paramftp_ip);
                komut.Parameters.Add(paramftp_pw);
                komut.Parameters.Add(parambas_tarihi);
                komut.Parameters.Add(parambit_tarihi);
                komut.Parameters.Add(paramalinmis_ucret);
                komut.Parameters.Add(paramalinacak_ucret);
                komut.Parameters.Add(paramyillik_altyapi_ucreti);
                //komut.Parameters.AddWithValue("@tcno", txtTc.Text);
                //komut.Parameters.AddWithValue("@isim", txtIsim.Text);
                //komut.Parameters.AddWithValue("@soyisim", txtSoyisim.Text);
                //komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                //komut.Parameters.AddWithValue("@adres", txtAdres.Text);
                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                connection.Close();
                MessageBox.Show("Müşteri Kayıt İşlemi Gerçekleşti.");
            }
        }

        private void musteriUrun_dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox_Mus_ID.Text = musteriUrun_dataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            TextBox_domain_adi.Text = musteriUrun_dataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            TextBox_ftp_ip.Text = musteriUrun_dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            TextBox_FTP_Sifre.Text = musteriUrun_dataGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
            bas_tarihi.Text = musteriUrun_dataGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
            bit_tarihi.Text = musteriUrun_dataGrid.Rows[e.RowIndex].Cells[6].Value.ToString();
            TextBox_alinmis_ucret.Text = musteriUrun_dataGrid.Rows[e.RowIndex].Cells[7].Value.ToString();
            TextBox_alinacak_ucret.Text = musteriUrun_dataGrid.Rows[e.RowIndex].Cells[8].Value.ToString();
            TextBox_Altyapi_ucreti.Text = musteriUrun_dataGrid.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button_urunDuzenle_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
               
                string query = "UPDATE dbo.musteriurunbilgisi SET domains=@domains,  ftp_ip=@ftp_ip , ftp_pw=@ftp_pw, bas_tarihi=@bas_tarihi /*,bit_tarihi=@bit_tarihi*/ ,alinmis_ucret=@alinmis_ucret , alinacak_ucret=@alinacak_ucret, yillik_altyapi_ucreti=@yillik_altyapi_ucreti WHERE domains=@domains";
                //komut = new SqlCommand(query, connection);
                //komut.Parameters.AddWithValue("@musID", TextBox_Mus_ID);
                //komut.Parameters.AddWithValue("@domains", TextBox_domain_adi.Text);
                //komut.Parameters.AddWithValue("@ftp_ip", TextBox_ftp_ip.Text);
                //komut.Parameters.AddWithValue("@ftp_pw", TextBox_FTP_Sifre.Text);
                //komut.Parameters.AddWithValue("@bas_tarihi", TextBox_baslangic_tarihi.Text);
                //komut.Parameters.AddWithValue("@bit_tarihi", TextBox_Bitis_Tarihi.Text);
                //komut.Parameters.AddWithValue("@alinmis_ucret", TextBox_alinmis_ucret.Text);
                //komut.Parameters.AddWithValue("@alinacak_ucret", TextBox_alinacak_ucret.Text);
                //komut.Parameters.AddWithValue("@yillik_altyapi_ucreti", TextBox_Altyapi_ucreti.Text);

                //connection.Open();
                //komut.ExecuteNonQuery();
                //connection.Close();
                SqlCommand komut = new SqlCommand(query, connection);
                SqlParameter parammusID = new SqlParameter("@musID", TextBox_Mus_ID.Text);
                SqlParameter paramdomains = new SqlParameter("@domains", TextBox_domain_adi.Text);
                SqlParameter paramftp_ip = new SqlParameter("@ftp_ip", TextBox_ftp_ip.Text);
                SqlParameter paramftp_pw = new SqlParameter("@ftp_pw", TextBox_FTP_Sifre.Text);
                SqlParameter parambas_tarihi = new SqlParameter("@bas_tarihi", bas_tarihi.Value);
                //SqlParameter parambit_tarihi = new SqlParameter("@bit_tarihi", bit_tarihi.Value);
                SqlParameter paramalinmis_ucret = new SqlParameter("@alinmis_ucret", decimal.Parse(TextBox_alinmis_ucret.Text));
                SqlParameter paramalinacak_ucret = new SqlParameter("@alinacak_ucret", decimal.Parse(TextBox_alinacak_ucret.Text));
                SqlParameter paramyillik_altyapi_ucreti = new SqlParameter("@yillik_altyapi_ucreti", decimal.Parse(TextBox_Altyapi_ucreti.Text));
                komut.Parameters.Add(parammusID);
                komut.Parameters.Add(paramdomains);
                komut.Parameters.Add(paramftp_ip);
                komut.Parameters.Add(paramftp_pw);
                komut.Parameters.Add(parambas_tarihi);
                //komut.Parameters.Add(parambit_tarihi);
                komut.Parameters.Add(paramalinmis_ucret);
                komut.Parameters.Add(paramalinacak_ucret);
                komut.Parameters.Add(paramyillik_altyapi_ucreti);
                komut.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string MusteriUrunSil = "SELECT * FROM dbo.musteriurunbilgisi WHERE domains=@domains ";
                SqlCommand UrunSil = new SqlCommand(MusteriUrunSil,connection);
                UrunSil.Parameters.AddWithValue("@domains", TextBox_domain_adi.Text);

                SqlDataAdapter da = new SqlDataAdapter(UrunSil);
                SqlDataReader dr = UrunSil.ExecuteReader();

                if (dr.Read()) 
                {
                    string isim = dr["musID"].ToString() + " " + dr["domains"].ToString();
                    dr.Close();
                   
                    DialogResult durum = MessageBox.Show(isim + " kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                    
                    if (DialogResult.Yes == durum) 
                    {
                         MusteriUrunSil = "DELETE from dbo.musteriurunbilgisi where domains=@domains";
                        
                        SqlCommand silKomutu = new SqlCommand(MusteriUrunSil, connection);
                        silKomutu.Parameters.AddWithValue("@domains", TextBox_domain_adi.Text);
                        silKomutu.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Silindi...");
                        
                    }
                }
                else
                    MessageBox.Show("Müşteri Bulunamadı.");
                connection.Close();
            }

        }
            
    }
}


