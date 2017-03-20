using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

class SearchFiles
{
    //  Anti_Ransomware.RedemptionAntiRansomwareEntities db = new Anti_Ransomware.RedemptionAntiRansomwareEntities();
    Anti_Ransomware.Database db = new Anti_Ransomware.Database();
    static int Randomn = 0;
    static int RandomCounter = 0;
    public static int HoneyCount = 0;
    static int PassedHoneyCount = 0;
    private static Random random = new Random();
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public void ProcessFile(string path , bool isHoneypot)
    {
        if (ext.Contains(Path.GetExtension(path)))
        {

            try
            {
                string tmp = Path.GetDirectoryName(path);
                if (db.AuditingZones.Where(x => x.ZonePath == tmp).Count() == 0)
                {
                    if (isHoneypot)
                    {
                        if (Randomn == RandomCounter)
                        {
                            if (PassedHoneyCount <= HoneyCount)
                            {
                                Anti_Ransomware.Honeypot az = new Anti_Ransomware.Honeypot();

                                string ran = RandomString(10);
                             //   Clipboard.SetText("Created : " + Path.GetDirectoryName(path) + "\\" + ran);

                                Directory.CreateDirectory(Path.GetDirectoryName(path) + "\\" + ran);

                                System.Windows.Forms.MessageBox.Show("Created : " + Path.GetDirectoryName(path) + "\\" + ran);
                                StreamWriter sw = new StreamWriter(Path.GetDirectoryName(path) + "\\" + ran + "\\" + RandomString(5) + ".docx");
                                sw.Write(RandomString(20));
                                sw.Close();


                                StreamWriter sw2 = new StreamWriter(Path.GetDirectoryName(path) + "\\" + ran + "\\" + RandomString(5) + ".pdf");
                                sw2.Write(RandomString(20));
                                sw2.Close();




                                StreamWriter sw3 = new StreamWriter(Path.GetDirectoryName(path) + "\\" + ran + "\\" + RandomString(5) + ".jpg");
                                sw3.Write(RandomString(20));
                                sw3.Close();


                                StreamWriter sw4 = new StreamWriter(Path.GetDirectoryName(path) + "\\" + ran + "\\" + RandomString(5) + ".png");
                                sw4.Write(RandomString(20));
                                sw4.Close();

                                az.HoneypotPath = Path.GetDirectoryName(Path.GetDirectoryName(path) ) + "\\" + ran;

                                db.Honeypots.Add(az);
                                db.SaveChanges();
                                Random r = new Random();
                                Randomn = r.Next(1, 20);
                                RandomCounter = 0;
                                PassedHoneyCount++;
                            }
                            else
                            {
                                return;
                            }

                        }
                        else
                        {
                            RandomCounter++;
                        }

                    }
                    else
                    {
                        Anti_Ransomware.AuditingZone az = new Anti_Ransomware.AuditingZone();
                        az.ZonePath = Path.GetDirectoryName(path);
                        db.AuditingZones.Add(az);
                        db.SaveChanges();
                    }

                    
                }
                else
                { }
            }
            catch (Exception nn)
            {
                if (isHoneypot)
                {
                    if (PassedHoneyCount <= HoneyCount)
                    {
                        Anti_Ransomware.Honeypot az = new Anti_Ransomware.Honeypot();

                        string ran = RandomString(10);
                        Directory.CreateDirectory(Path.GetDirectoryName(path) + "\\" + ran);

                        StreamWriter sw = new StreamWriter(Path.GetDirectoryName(path) + "\\" + ran + "\\" + RandomString(5) + ".docx");
                        sw.Write(RandomString(20));
                        sw.Close();


                        StreamWriter sw2 = new StreamWriter(Path.GetDirectoryName(path) + "\\" + ran + "\\" + RandomString(5) + ".pdf");
                        sw2.Write(RandomString(20));
                        sw2.Close();




                        StreamWriter sw3 = new StreamWriter(Path.GetDirectoryName(path) + "\\" + ran + "\\" + RandomString(5) + ".jpg");
                        sw3.Write(RandomString(20));
                        sw3.Close();


                        StreamWriter sw4 = new StreamWriter(Path.GetDirectoryName(path) + "\\" + ran + "\\" + RandomString(5) + ".png");
                        sw4.Write(RandomString(20));
                        sw4.Close();

                        az.HoneypotPath = Path.GetDirectoryName(Path.GetDirectoryName(path)) + "\\" + ran;

                        db.Honeypots.Add(az);
                        db.SaveChanges();
                        Random r = new Random();
                        Randomn = r.Next(1, 20);
                        RandomCounter = 0;
                        PassedHoneyCount++;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Anti_Ransomware.AuditingZone az = new Anti_Ransomware.AuditingZone();
                    az.ZonePath = Path.GetDirectoryName(path);
                    db.AuditingZones.Add(az);
                    db.SaveChanges();
                }
            }          
         

        }

    }
    string[] ext = null;

    public void ApplyAllFiles(string folder, Action<string , bool> fileAction, string[] extension ,bool IsHoneyPot)
    {
        ext = extension;
        try
        {
            foreach (string file in Directory.GetFiles(folder))
            {
                fileAction(file , IsHoneyPot);
            }
        }
        catch (Exception)
        {
            return;
        }

        foreach (string subDir in Directory.GetDirectories(folder))
        {
            try
            {
                ApplyAllFiles(subDir, fileAction, ext , IsHoneyPot);
            }
            catch
            { }
        }
    }
}

