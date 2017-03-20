using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Watchdog
{
    class Utility
    {
        public Utility(bool IsHoneyPot)
        {
            this.IsHoneyPot = IsHoneyPot;
        }
        private System.IO.FileSystemWatcher m_Watcher;
        bool IsHoneyPot = false;
        public void DisableWatchDog()
        {
            // For Disable
            m_Watcher.EnableRaisingEvents = false;
            m_Watcher.Dispose();
        }
        public void EnableWatchDog(string DirectoryPath, bool CheckSubFolders)
        {
            // For Enable
            m_Watcher = new System.IO.FileSystemWatcher();
            m_Watcher.Filter = "*.*";
            m_Watcher.Path = DirectoryPath + "\\";

            if (CheckSubFolders)
            {
                m_Watcher.IncludeSubdirectories = true;
            }
            m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
            | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
            //  m_Watcher.Created += new FileSystemEventHandler(OnChanged);
            m_Watcher.Deleted += new FileSystemEventHandler(OnChanged);
            //  m_Watcher.Renamed += new RenamedEventHandler(OnRenamed);
            m_Watcher.EnableRaisingEvents = true;
        }
        private string ExecuteCommand(string command)
        {

            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command)
            {

                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process proc = new Process())
            {
                proc.StartInfo = procStartInfo;
                proc.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                proc.Start();

                string output = proc.StandardOutput.ReadToEnd();

                if (string.IsNullOrEmpty(output))
                    output = proc.StandardError.ReadToEnd();

                return output;
            }

        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string[] AllFile = Directory.GetFiles(Path.GetDirectoryName(e.FullPath));


            foreach (string item in AllFile)
            {
                    string processID = ExecuteCommand("WhoUses.exe " + Path.GetFileName(item));
                    if (processID.Count() != 441 && processID.Count() != 92 && processID.Count() != 23)
                    {
                        string[] splitter = new string[1] { "0x" };
                        string[] splitter2 = new string[1] { " " };
                    string HexProcessID = processID.Split(splitter, StringSplitOptions.RemoveEmptyEntries)[1].Split(splitter2, StringSplitOptions.None)[0].Trim();
                        int DeciamalProcessID = Int32.Parse(HexProcessID, System.Globalization.NumberStyles.HexNumber);

                    if (IsHoneyPot)
                    {
                        System.Windows.Forms.MessageBox.Show("The process " + DeciamalProcessID.ToString() + " touches Honeypots, Well there it have to be kill accoiding our privacy...");
                        try
                        {
                            System.Diagnostics.Process.GetProcessById(DeciamalProcessID).Kill();

                        }
                        catch (Exception)
                        {
                            System.Windows.Forms.MessageBox.Show("We attempt to kill it but is was not successful , It might be in a greater permission or other thing ... please try to kill it manually .","error",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
                        }


                        return;

                    }
                    System.Windows.Forms.MessageBox.Show("The process " + DeciamalProcessID.ToString() + " seems suspicious ! We're going to monitor it.");
                    

                        Process ffmpeg = new Process();
                        ffmpeg.StartInfo.FileName = "FileMonitor.exe";
                        ffmpeg.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                        ffmpeg.StartInfo.Arguments = DeciamalProcessID.ToString();
                        ffmpeg.Start();

                    }
              
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {

        }
    }
}
