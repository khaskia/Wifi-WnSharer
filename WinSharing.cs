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
    public partial class WinSharing : Form
    {
        public WinSharing()
        {
            InitializeComponent();
            label1.Text = "removesharing password \nand Enable public folder sharing";

        }
        public void ExecuteCommandOpen()
        {
            try
            {
                // NetWork Descovery :::::::::: 

                System.Diagnostics.ProcessStartInfo NetworkDescovery =
                  new System.Diagnostics.ProcessStartInfo("cmd", "/c " +"netsh advfirewall firewall set rule group=\"Network Discovery\" new enable=Yes");
                NetworkDescovery.RedirectStandardOutput = true;
                NetworkDescovery.UseShellExecute = false;
                NetworkDescovery.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = NetworkDescovery;
                proc.Start();
   
                string result = proc.StandardOutput.ReadToEnd();

                // NetWork Descovery :::::::::: 

                System.Diagnostics.ProcessStartInfo FileSharing =
                  new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "netsh advfirewall firewall set rule group=\"File and Printer Sharing\" new enable=Yes");
                FileSharing.RedirectStandardOutput = true;
                FileSharing.UseShellExecute = false;
                FileSharing.CreateNoWindow = true;
                System.Diagnostics.Process proc2 = new System.Diagnostics.Process();
                proc.StartInfo = FileSharing;
                proc.Start();

                string result2 = proc2.StandardOutput.ReadToEnd();

                string result3 = result + result2;
                MessageBox.Show(result3);



            }
            catch 
            {
                // Log the exception
            }
        }

        public void ExecuteCommandClose()
        {
            try
            {
                // NetWork Descovery :::::::::: 

                System.Diagnostics.ProcessStartInfo NetworkDescovery =
                  new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "netsh advfirewall firewall set rule group=\"Network Discovery\" new enable=No");
                NetworkDescovery.RedirectStandardOutput = true;
                NetworkDescovery.UseShellExecute = false;
                NetworkDescovery.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = NetworkDescovery;
                proc.Start();

                string result = proc.StandardOutput.ReadToEnd();

                // NetWork Descovery :::::::::: 

                System.Diagnostics.ProcessStartInfo FileSharing =
                  new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "netsh advfirewall firewall set rule group=\"File and Printer Sharing\" new enable=No");
                FileSharing.RedirectStandardOutput = true;
                FileSharing.UseShellExecute = false;
                FileSharing.CreateNoWindow = true;
                System.Diagnostics.Process proc2 = new System.Diagnostics.Process();
                proc.StartInfo = FileSharing;
                proc.Start();

                string result2 = proc2.StandardOutput.ReadToEnd();

                string result3 = result + result2;
                MessageBox.Show(result3);



            }
            catch 
            {
                // Log the exception
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                ExecuteCommandOpen();
                
            }
            else if (radioButton2.Checked == true)
            {

                ExecuteCommandClose();
            }
            else
            {
                MessageBox.Show("Error", "please check open or close");
            }

            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //  Process.Start( @"C:\Users\mohamedali\AppData\Local\Packages\windows.immersivecontrolpanel_cw5n1h2txyewy\LocalState\Indexed\Settings\en-US\Manage advanced sharing settings.settingcontent-ms");


           //Classic_{88C9D04D-39DD-41EE-A63B-23218D69717F}    To Open NetWorks




            Process.Start(Environment.ExpandEnvironmentVariables(@"%localappdata%\Packages\windows.immersivecontrolpanel_cw5n1h2txyewy\LocalState\Indexed\Settings\en-US\Classic_{5530E8CC-1B9E-4798-A880-BA719ADFBBBD}.settingcontent-ms"));
            // illustration Form
            Form2 f2 = new Form2();
            f2.Show();





            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = Environment.ExpandEnvironmentVariables(@"%localappdata%\Packages\windows.immersivecontrolpanel_cw5n1h2txyewy\LocalState\Indexed\Settings\en-US\Classic_{5530E8CC-1B9E-4798-A880-BA719ADFBBBD}.settingcontent-ms");
            //startInfo.UseShellExecute = true;
            //Process.Start(startInfo);
        }


        int togmov;
        int mvalueX;
        int mvalueY;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (togmov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mvalueX, MousePosition.Y - mvalueY);
            }
        }

    

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            togmov = 1;
            mvalueX = e.X;
            mvalueY = e.Y;
        }

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            togmov = 0;
        }


    }
}
