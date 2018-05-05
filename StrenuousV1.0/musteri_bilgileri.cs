using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrenuousV1._0
{
    public partial class musteri_bilgileri : UserControl
    {
        public musteri_bilgileri()
        {
            InitializeComponent();
        }

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
    }    

}
