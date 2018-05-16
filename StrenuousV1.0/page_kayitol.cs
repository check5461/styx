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
    public partial class page_kayitol : UserControl
    {
        public page_kayitol()
        {
            InitializeComponent();
        }

        public object Close { get; private set; }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            
            List<string> veriler = new List<string>();
            veriler.Add(TxtKulAdi.Text);
            veriler.Add(TxtSifre.Text);
            veriler.Add(TxtAdi.Text);
            veriler.Add(TxtSoyadi.Text);
            veriler.Add(TxtTcNo.Text);
            veriler.Add(TxtTelefon.Text);
            Veritabani.KayitEkle(veriler);
            int basarilimi = Veritabani.SeriNoEkle(TxtSeriNo.Text, Veritabani.PersonelIdAl(TxtTcNo.Text));
            if (basarilimi > 0)
            {
                if (DialogResult.OK == MessageBox.Show("Kayıt Başarılı, Giriş Sayfasına Yönlendiriliyorsunuz.", "Basarili", MessageBoxButtons.OK))
                {
                    Parent.Controls.Find("page_login1", true)[0].BringToFront();

                }
                    
                    
            }
            else
            {
                //Hata dondur, serinumarasi ekleyemedi
            }
        }
    }
}
