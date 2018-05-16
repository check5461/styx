using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrenuousV1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            page_destek1.BringToFront();
        }

        Bunifu.Framework.UI.Drag MoveForm = new Bunifu.Framework.UI.Drag();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm.Grab(this);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            MoveForm.Release();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            MoveForm.MoveObject();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void musteri_button_Click(object sender, EventArgs e)
        {
            page_musterilerim1.BringToFront();
        }

        private void musteribilgileri_Click(object sender, EventArgs e)
        {
            musteri_bilgileri1.BringToFront();
        }

        private void kisiselbilgilerim_Click(object sender, EventArgs e)
        {
            page_kisiselbilgilerim1.BringToFront();
        }

        private void page_login1_Load(object sender, EventArgs e)
        {

        }
    }
}
