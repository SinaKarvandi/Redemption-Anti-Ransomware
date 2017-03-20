using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Anti_Ransomware
{
    public partial class EnterBaseDrive : Form
    {
        public EnterBaseDrive()
        {
            InitializeComponent();
        }
        public string Folder = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            Folder = textBox1.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = f.SelectedPath.ToString();
            }
        }
    }
}
