using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrenuousV1._0
{
    class Veritabani
    {
        private static string connectionString = "Data Source=DESKTOP-N0FIF4F\\STYXSERVER;Initial Catalog=musteritakip;Integrated Security=True";
        static public int SeriNoKontrol(string kontrolEdilecekNo)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT atananPersonelId FROM SeriNumaralari WHERE seriNo = @gelenSeriNo";
                SqlParameter paramSeriNo = new SqlParameter("@gelenSEriNo", kontrolEdilecekNo);
                SqlCommand komut = new SqlCommand(query, connection);
                komut.Parameters.Add(paramSeriNo);
                using (SqlDataReader theReader = komut.ExecuteReader())
                {
                    while (theReader.Read())
                    {
                        Object gelenVeri = theReader.GetValue(0);
                        if(gelenVeri == null)
                        {
                            return 0; //Seri no var ise ve bos ise
                        }
                        else
                        {
                            return 1; //Seri no kullaniliyor
                        }
                    }
                } 
                // Do work here; connection closed on following line.
            }
            return -1;
        }
        static public void DataGridDoldur(string query, Bunifu.Framework.UI.BunifuCustomDataGrid dataGrid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var dataAdapter = new SqlDataAdapter(query, connection);
                var commandBuild = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGrid.ReadOnly = true;
                dataGrid.DataSource = ds.Tables[0];
            }
        }
        static public void DataGridDoldur1(string query, Bunifu.Framework.UI.BunifuCustomDataGrid dataGrid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var dataAdapter = new SqlDataAdapter(query, connection);
                var commandBuild = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGrid.ReadOnly = true;
                dataGrid.DataSource = ds.Tables[0];
            }
        }
        static public List<dynamic> SelectSorgusuTekSatir(string query, int sutunSayisi)
        {
            //Veritabani.SelectSorgusuTekSatir("SELECT * FROM S_Personel;", 8);
            List<dynamic> wholeList = new List<dynamic>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand komut = new SqlCommand(query, connection);
                // komut.parameters.add(paramserino);
                using (SqlDataReader thereader = komut.ExecuteReader())
                {
                    while (thereader.Read())
                    {
                        try
                        {
                            for (int column = 0; column < sutunSayisi ; ++column)
                            {
                                wholeList.Add(thereader.GetValue(column));
                            }
                        }
                        catch(IndexOutOfRangeException e)
                        {
                            break; //TODO: Hata verirse ilk buraya bak
                        }
                    }
                }
                
            }
            return wholeList;
        }
        static public int KayitEkle(List<string> kayitBilgileri)
        {
            if(kayitBilgileri.Count != 6)
            {
                return -1; //Hata, yanlis parametre
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO S_Personel(kullaniciAdi, sifre, adi, soyadi, tckimlik, telefon) VALUES(@kullaniciAdi,@sifre,@adi,@soyadi,@tckimlik,@telefon);";
                SqlParameter paramKullaniciAdi = new SqlParameter("@kullaniciAdi", kayitBilgileri[0]);
                SqlParameter paramSifre = new SqlParameter("@sifre", kayitBilgileri[1]);
                SqlParameter paramAdi = new SqlParameter("@adi", kayitBilgileri[2]);
                SqlParameter paramSoyadi = new SqlParameter("@soyadi", kayitBilgileri[3]);
                SqlParameter paramTckimlik = new SqlParameter("@tckimlik", kayitBilgileri[4]);
                SqlParameter paramTelefon = new SqlParameter("@telefon", kayitBilgileri[5]);
                SqlCommand komut = new SqlCommand(query, connection);
                komut.Parameters.Add(paramKullaniciAdi);
                komut.Parameters.Add(paramSifre);
                komut.Parameters.Add(paramAdi);
                komut.Parameters.Add(paramSoyadi);
                komut.Parameters.Add(paramTckimlik);
                komut.Parameters.Add(paramTelefon);
                return komut.ExecuteNonQuery();
                // Do work here; connection closed on following line.
            }
        }
        static public int PersonelIdAl(string tcKimlik)
        {
            int dbPersonelId = -1;
             using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT PersonelID FROM S_personel WHERE tckimlik=@tcKimlik";
                SqlParameter paramTcKimlik = new SqlParameter("@tcKimlik", tcKimlik);
                SqlCommand komut = new SqlCommand(query, connection);
                komut.Parameters.Add(paramTcKimlik);
                using(SqlDataReader theReader = komut.ExecuteReader())
                {
                    while (theReader.Read())
                    {
                        dbPersonelId = theReader.GetInt32(0);
                    }
                }
            }
            return dbPersonelId;
        }
        static public int SeriNoEkle(string gelenSeriNo, int personelId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE SeriNumaralari SET atananPersonelId=@personelId WHERE seriNo=@seriNo";
                SqlParameter paramPersonel = new SqlParameter("@seriNo", gelenSeriNo);
                SqlParameter paramSeriNo = new SqlParameter("@personelId", personelId);
                SqlCommand komut = new SqlCommand(query, connection);
                komut.Parameters.Add(paramPersonel);
                komut.Parameters.Add(paramSeriNo);
                return komut.ExecuteNonQuery();
                // Do work here; connection closed on following line.
            }
        }
    }
}
