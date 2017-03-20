using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Expressions;
using FlatUI;
using System.IO;

namespace Anti_Ransomware
{
	public partial class Main : Form
	{
		private Boolean ProgressOngoing = false;

		public Main()
		{
			InitializeComponent();
		}

		private void SpawnAlertButton_Click(object sender, EventArgs e)
		{
			this.FlatAlertBox.Visible = false;
			FlatAlertBox._Kind kind = this.GetAlertBoxKind();
			this.FlatAlertBox.kind = kind;
			this.FlatAlertBox.Visible = true;
		}

		/// <summary>
		/// Get the alert box type from the radio buttons.
		/// </summary>
		/// <returns>Alert box kind</returns>
		private FlatAlertBox._Kind GetAlertBoxKind()
		{
			//if (this.SuccessRadioButton.Checked)
				return FlatUI.FlatAlertBox._Kind.Success;
			/*else if (this.ErrorRadioButton.Checked)
				return FlatUI.FlatAlertBox._Kind.Error;
			else return FlatUI.FlatAlertBox._Kind.Info;*/
		}

        private void FlatToggleStyle2_CheckedChanged(object sender)
        {
            if (FlatToggleStyle2.Checked)
            {
                FlatToggleStyle3.Checked = true;
                flatToggle1.Checked = true;
                flatToggle2.Checked = true;
            }
            else 
            {
                FlatToggleStyle3.Checked = false;
                flatToggle1.Checked = false;
                flatToggle2.Checked = false;
            }
            this.Refresh();
        }

        private void FormSkin_Click(object sender, EventArgs e)
        {
        }

        private void FormSkin_Enter(object sender, EventArgs e)
        {
            try
            {
                var a = System.Diagnostics.Process.GetProcessesByName("Watchdog")[0];
                FlatToggleStyle3.Checked = true;
            }
            catch (Exception ff)
            {
                FlatToggleStyle3.Checked = false;

            }
            Database db = new Database();
            if (db.AuditingZones.Select(x => new { x.ZoneID }.ZoneID).Count()==0)
            {
                flatToggle2.Checked = false;
            }
            else
            {
                flatToggle2.Checked = true;

            }

            if (db.Honeypots.Select(x => new { x.HoneypotID }.HoneypotID).Count() == 0)
            {
                flatToggle1.Checked = false;
            }
            else
            {
                flatToggle1.Checked = true;
            }
            if (!flatToggle1.Checked || !flatToggle2.Checked || !FlatToggleStyle3.Checked)
            {
                FlatToggleStyle2.Checked = false;
            }
            else
            {
                FlatToggleStyle2.Checked = true;

            }
            /***************************/
            FirstRun f = new FirstRun();

            listBox1.BackColor = Color.FromArgb(60, 70, 73);
            listBox2.BackColor = Color.FromArgb(60, 70, 73);
            listBox3.BackColor = Color.FromArgb(60, 70, 73);

            this.Icon = Icon.ExtractAssociatedIcon("icon.ico");
            FlatAlertBox.Text = "You can Monitor and Configure your Anti Ransomware here...";
            this.FlatAlertBox.Visible = false;
            FlatAlertBox._Kind kind = FlatUI.FlatAlertBox._Kind.Info;
            this.FlatAlertBox.kind = kind;
            this.FlatAlertBox.Visible = true;
        }

        private void TabPage2_Enter(object sender, EventArgs e)
        {
            //   RedemptionAntiRansomwareEntities db = new RedemptionAntiRansomwareEntities();
            Anti_Ransomware.Database db = new Anti_Ransomware.Database();

            listBox2.DataSource = db.Extension.OrderBy(x=>x.Ext).Select(x => new { x.Ext }.Ext).ToList();
            listBox1.DataSource = db.AuditingZones.Select(x => new { x.ZonePath }.ZonePath).ToList();
            listBox3.DataSource = db.Honeypots.Select(x => new { x.HoneypotPath }.HoneypotPath).ToList();
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            /*listBox4.BackColor = Color.FromArgb(60, 70, 73);

            //  RedemptionAntiRansomwareEntities db = new RedemptionAntiRansomwareEntities();
            Anti_Ransomware.Database db = new Anti_Ransomware.Database();

            listBox4.DataSource = db.Dumps.Select(x => new { x.DumpPath }.DumpPath).ToList();
            */
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
          /*  try
            {
                if (string.IsNullOrEmpty(listBox4.SelectedItem.ToString()) && File.Exists(listBox4.SelectedItem.ToString()))
                {
                    File.Delete(listBox4.SelectedItem.ToString());
                }
            }
            catch (Exception)
            {
            }*/

        }

        private void Tab2Button_Click(object sender, EventArgs e)
        {
          /*  try
            {
                if (string.IsNullOrEmpty(listBox4.SelectedItem.ToString()) && File.Exists(listBox4.SelectedItem.ToString()))
                {
                    saveFileDialog1.Filter = "Dump Files | *.dump";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(listBox4.SelectedItem.ToString(), saveFileDialog1.FileName);

                    }
                }
            }
            catch (Exception)
            {

            }*/

        }

        private void ProgressButton_Click(object sender, EventArgs e)
        {
            EnterBaseDrive ebd = new EnterBaseDrive();
            ebd.ShowDialog();
            //    RedemptionAntiRansomwareEntities db = new RedemptionAntiRansomwareEntities();
            Anti_Ransomware.Database db = new Anti_Ransomware.Database();

            listBox5.DataSource = db.Extension.Select(x => new { x.Ext }.Ext).ToList();

            List<string> lst = new List<string>();
            foreach (var item in listBox5.Items)
            {
                lst.Add(item.ToString());
            }

            FlatAlertBox.Text = "Scan for special Directory Started .";
            this.FlatAlertBox.Visible = false;
            FlatAlertBox._Kind kind = FlatUI.FlatAlertBox._Kind.Success;
            this.FlatAlertBox.kind = kind;
            this.FlatAlertBox.Visible = true;
            SearchFiles sf = new SearchFiles();
            Thread t3 = new Thread(delegate ()
            {
               sf.ApplyAllFiles(ebd.Folder,sf.ProcessFile, lst.ToArray(),false);
            });
            t3.Start();
        }

        private void FlatTrackBar_Scroll(object sender)
        {
            if (FlatTrackBar.Value == 0)
            {
                FlatNumeric.Value = 10;
            }
            if (FlatTrackBar.Value == 1)
            {
                FlatNumeric.Value = 20;
            }
            if (FlatTrackBar.Value == 2)
            {
                FlatNumeric.Value = 30;
            }
        }

        private void FlatToggleStyle1_CheckedChanged(object sender)
        {
            try
            {
                if (FlatToggleStyle1.Checked == true && !File.Exists("Watchdog.exe"))
                {
                    File.Move("Watchdog-diabled.exe", "Watchdog.exe");

                    
                }

                if (FlatToggleStyle1.Checked == false && File.Exists("Watchdog.exe"))
                {
                    File.Move("Watchdog.exe", "Watchdog-diabled.exe");

                }


            }
            catch (Exception ee)
            {
                FlatToggleStyle1.Checked = true;
                MessageBox.Show("Watchdog can't be disable bcuz it is use in processes !");
            }
        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            if (File.Exists("Watchdog.exe"))
            {
                FlatToggleStyle1.Checked = true;
            }
            else
            {
                FlatToggleStyle1.Checked = false;

            }
        }

        private void flatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Watchdog.exe");
                FlatAlertBox.Text = "Watchdog is running ...";
                this.FlatAlertBox.Visible = false;
                FlatAlertBox._Kind kind = FlatUI.FlatAlertBox._Kind.Success;
                this.FlatAlertBox.kind = kind;
                this.FlatAlertBox.Visible = true;
            }
            catch (Exception)
            {
                FlatAlertBox.Text = "Watchdog is probably disabled ! Please enable watchdog and do the starting manually.";
                this.FlatAlertBox.Visible = false;
                FlatAlertBox._Kind kind = FlatUI.FlatAlertBox._Kind.Error;
                this.FlatAlertBox.kind = kind;
                this.FlatAlertBox.Visible = true;
            }
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            if (FlatNumeric.Value == 0)
            {
                MessageBox.Show("Please specify how much honeypot you need ! It cannot be zero ...");
                return;
            }

            EnterBaseDrive ebd = new EnterBaseDrive();
            ebd.ShowDialog();
            //    RedemptionAntiRansomwareEntities db = new RedemptionAntiRansomwareEntities();
            Anti_Ransomware.Database db = new Anti_Ransomware.Database();

            listBox5.DataSource = db.Extension.Select(x => new { x.Ext }.Ext).ToList();

            List<string> lst = new List<string>();
            foreach (var item in listBox5.Items)
            {
                lst.Add(item.ToString());
            }

            FlatAlertBox.Text = "Put for Honeypot Directory Started .";
            this.FlatAlertBox.Visible = false;
            FlatAlertBox._Kind kind = FlatUI.FlatAlertBox._Kind.Success;
            this.FlatAlertBox.kind = kind;
            this.FlatAlertBox.Visible = true;
            SearchFiles sf = new SearchFiles();
            SearchFiles.HoneyCount = Convert.ToInt32(FlatNumeric.Value)-1;
            Thread t3 = new Thread(delegate ()
            {
                sf.ApplyAllFiles(ebd.Folder, sf.ProcessFile, lst.ToArray() ,true);
            });
            t3.Start();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {
   



        }

        private void TabPage1_Enter(object sender, EventArgs e)
        {
            FormSkin_Enter(null, null);
        }
    }
}
