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
using System.Data.Sql;
using System.IO;

namespace StrenuousV1._0
{
    public partial class page_musterilerim : UserControl
    {
        public page_musterilerim()
        {
            InitializeComponent();
        }
        //Veritabanı Bağlantı DataSource kodu
        private static string connectionString = "Data Source=DESKTOP-N0FIF4F\\STYXSERVER;Initial Catalog=musteritakip;Integrated Security=True";


        //veriekleme butonu ve kodu
        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string kayit = "insert into dbo.musteribilgi(adi,soyadi,tc,tel1,tel2, adress, personelId) values ( @adi, @soyadi, @tc, @tel1, @tel2, @adress, @personelId)";
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, connection);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.    
                SqlParameter paramadi = new SqlParameter("@adi", textbox_musteriadi_txt.Text);
                SqlParameter paramsoyadi = new SqlParameter("@soyadi", textbox_musterisoyadı_txt.Text);
                SqlParameter paramtc = new SqlParameter("@tc", textbox_tcno_txt.Text);
                SqlParameter paramtel1 = new SqlParameter("@tel1", textbox_gsmno_text.Text);
                SqlParameter paramtel2 = new SqlParameter("@tel2", textbox_sabithat_txt.Text);
                SqlParameter paramadres = new SqlParameter("@adress", textbox_adresbil_txt.Text);
                SqlParameter parampersonel_Id = new SqlParameter("@personelId", textbox_personel_id_txt.Text);

                komut.Parameters.Add(paramadi);
                komut.Parameters.Add(paramsoyadi);
                komut.Parameters.Add(paramtc);
                komut.Parameters.Add(paramtel1);
                komut.Parameters.Add(paramtel2);
                komut.Parameters.Add(paramadres);
                komut.Parameters.Add(parampersonel_Id);
                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                connection.Close();
                MessageBox.Show("Müşteri Kayıt İşlemi Gerçekleşti.");
            }
        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE dbo.musteribilgi SET adi=@adi,  soyadi=@soyadi , tc=@tc, tel1=@tel2, adress=@adress , personelId=@personelId WHERE musID=@musID";

                SqlCommand komut = new SqlCommand(query, connection);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                SqlParameter paramadi = new SqlParameter("@adi", textbox_musteriadi_txt.Text);
                SqlParameter paramsoyadi = new SqlParameter("@soyadi", textbox_musterisoyadı_txt.Text);
                SqlParameter paramtc = new SqlParameter("@tc", textbox_tcno_txt.Text);
                SqlParameter paramtel1 = new SqlParameter("@tel1", textbox_gsmno_text.Text);
                SqlParameter paramtel2 = new SqlParameter("@tel2", textbox_sabithat_txt.Text);
                SqlParameter paramadres = new SqlParameter("@adress", textbox_adresbil_txt.Text);
                SqlParameter parampersonel_Id = new SqlParameter("@personelId", textbox_personel_id_txt.Text);


                komut.Parameters.Add(paramadi);
                komut.Parameters.Add(paramsoyadi);
                komut.Parameters.Add(paramtc);
                komut.Parameters.Add(paramtel1);
                komut.Parameters.Add(paramtel2);
                komut.Parameters.Add(paramadres);
                komut.Parameters.Add(parampersonel_Id);
                komut.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string MusteriUrunSil = "SELECT * FROM dbo.musteribilgi WHERE  musID=@musID";
                SqlCommand UrunSil = new SqlCommand(MusteriUrunSil, connection);
                UrunSil.Parameters.AddWithValue("@musID", textBox_Musteri_id_txt.Text);

                SqlDataAdapter da = new SqlDataAdapter(UrunSil);
                SqlDataReader dr = UrunSil.ExecuteReader();

                if (dr.Read())
                {
                    string isim = dr["musID"].ToString() + " " + dr["tc"].ToString();
                    dr.Close();

                    DialogResult durum = MessageBox.Show(isim + " kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                    if (DialogResult.Yes == durum)
                    {
                        MusteriUrunSil = "DELETE from dbo.musteribilgi where tc=@tc";

                        SqlCommand silKomutu = new SqlCommand(MusteriUrunSil, connection);
                        silKomutu.Parameters.AddWithValue("@tc", textbox_tcno_txt.Text);
                        silKomutu.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Silindi...");

                    }
                }
                else
                    MessageBox.Show("Müşteri Bulunamadı.");
                connection.Close();
            }
        }

        private void musteriDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                textBox_Musteri_id_txt.Text = musteriDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                textbox_tcno_txt.Text = musteriDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                textbox_musteriadi_txt.Text = musteriDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                textbox_musterisoyadı_txt.Text = musteriDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                textbox_gsmno_text.Text = musteriDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                textbox_sabithat_txt.Text = musteriDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                textbox_personel_id_txt.Text = musteriDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                textbox_adresbil_txt.Text = musteriDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
        }

        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {
            string filterById1 = "SELECT musteriID, adi, soyadi, tc, tel1, tel2, adress, personelId FROM dbo.musteribilgi WHERE musteriID ='" + TextBox_Arama.Text + "';";
            Veritabani.DataGridDoldur(filterById1, musteriDataGridView);
        }
        
        private void filterByMusteriToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.musteribilgiTableAdapter.FilterByMusteri(this.musteritakipDataSet.musteribilgi);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void musteriDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }

    }

