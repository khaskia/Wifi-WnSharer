using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
namespace SharingWifi
{
    public partial class EditText : Form
    {
        public EditText()
        {
            InitializeComponent();
        }
        public string RemoveEmptyLines(string lines)
        {
            return Regex.Replace(lines, @"^\s*$\n|\r", "", RegexOptions.Multiline).TrimEnd();
        }
        private void EditText_Load(object sender, EventArgs e)
        {
            

            try
            {
                FileStream F = new FileStream("wifi.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamReader re = new StreamReader(F);

                richTextBox1.Text = re.ReadToEnd();
                richTextBox1.Text = RemoveEmptyLines(richTextBox1.Text);
                re.Dispose();
            }
            catch (Exception)
            {
                
                throw;
            }

            
        }

        private void button6_Click(object sender, EventArgs e)
        {

            File.Delete("wifi.txt");

            FileStream F = new FileStream("wifi.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamWriter sw1 = new StreamWriter(F);
            sw1.WriteLine(RemoveEmptyLines(richTextBox1.Text));
            sw1.Dispose();



            this.Close();
        }

        private void ctlModernBlack1_Load(object sender, EventArgs e)
        {

        }
    }
}
