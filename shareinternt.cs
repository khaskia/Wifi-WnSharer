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
    public partial class shareinternt : Form
    {
        public shareinternt()
        {
            InitializeComponent();

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
           tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        private void ctlModernBlack1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage3);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage4);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
            Process.Start(Environment.ExpandEnvironmentVariables(@"%localappdata%\Packages\windows.immersivecontrolpanel_cw5n1h2txyewy\LocalState\Indexed\Settings\en-US\Classic_{9EF86966-2F35-49BE-A9F6-398E0B844411}.settingcontent-ms"));

            }
            catch (Exception)
            {
                
            
            }

        }
    }
}
