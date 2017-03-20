using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

    class SearchFiles
    {

      public static void ProcessFile(string path ) {

        if (ext.Contains(Path.GetExtension(path)))
        {
            System.Windows.Forms.MessageBox.Show(path);

        }

    }
    static string[] ext = null;

    public static void ApplyAllFiles(string folder, Action<string> fileAction, string[] extension)
    {
        ext = extension;
        foreach (string file in Directory.GetFiles(folder))
        {
            fileAction(file);
        }
        foreach (string subDir in Directory.GetDirectories(folder))
        {
            try
            {
                ApplyAllFiles(subDir, fileAction , ext);
            }
            catch
            {  }
        }
    }
}

