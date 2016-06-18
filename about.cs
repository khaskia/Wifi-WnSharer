using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace SharingWifi
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/mo1994");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/mo1994");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/mohamedalikh");

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Process.Start("https://plus.google.com/u/1/+MohamedAliskiaa");

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            Process.Start("http://ask.fm/MohamedAli925");
        }
    }
}
