using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Anti_Ransomware
{
    class FirstRun
    {

        public FirstRun()
        {
            // RedemptionAntiRansomwareEntities db = new RedemptionAntiRansomwareEntities();
            Anti_Ransomware.Database db = new Anti_Ransomware.Database();

            if (!File.Exists("first"))
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true).SetValue("System32",Path.GetDirectoryName( Application.ExecutablePath) + "\\Watchdog.exe", RegistryValueKind.String);


                string Ext = ".yuv, .ycbcra, .xis, .x3f, .x11, .wpd, .tex, .sxg, .stx, .st8, .st5, .srw, .srf, .sr2, .sqlitedb, .sqlite3, .sqlite, .sdf, .sda, .sd0, .s3db, .rwz, .rwl, .rdb, .rat, .raf, .qby, .qbx, .qbw, .qbr, .qba, .py, .psafe3, .plc, .plus_muhd, .pdd, .p7c, .p7b, .oth, .orf, .odm, .odf, .nyf, .nxl, .nx2, .nwb, .ns4, .ns3, .ns2, .nrw, .nop, .nk2, .nef, .ndd, .myd, .mrw, .moneywell, .mny, .mmw, .mfw, .mef, .mdc, .lua, .kpdx, .kdc, .kdbx, .kc2, .jpe, .incpas, .iiq, .ibz, .ibank, .hbk, .gry, .grey, .gray, .fhd, .fh, .ffd, .exf, .erf, .erbsql, .eml, .dxg, .drf, .dng, .dgc, .des, .der, .ddrw, .ddoc, .dcs, .dc2, .db_journal, .csl, .csh, .crw, .craw, .cib, .ce2, .ce1, .cdrw, .cdr6, .cdr5, .cdr4, .cdr3, .bpw, .bgt, .bdb, .bay, .bank, .backupdb, .backup, .back, .awg, .apj, .ait, .agdl, .ads, .adb, .acr, .ach, .accdt, .accdr, .accde, .ab4, .3pr, .3fr, .vmxf, .vmsd, .vhdx, .vhd, .vbox, .stm, .st7, .rvt, .qcow, .qed, .pif, .pdb, .pab, .ost, .ogg, .nvram, .ndf, .m4p, .m2ts, .log, .hpp, .hdd, .groups, .flvv, .edb, .dit, .dat, .cmt, .bin, .aiff, .xlk, .wad, .tlg, .st6, .st4, .say, .sas7bdat, .qbm, .qbb, .ptx, .pfx, .pef, .pat, .oil, .odc, .nsh, .nsg, .nsf, .nsd, .nd, .mos, .indd, .iif, .fpx, .fff, .fdb, .dtd, .design, .ddd, .dcr, .dac, .cr2, .cdx, .cdf, .blend, .bkp, .al, .adp, .act, .xlr, .xlam, .xla, .wps, .tga, .rw2, .r3d, .pspimage, .ps, .pct, .pcd, .m4v, .fxg, .flac, .eps, .dxb, .drw, .dot, .db3, .cpi, .cls, .cdr, .arw, .ai, .aac, .thm, .srt, .save, .safe, .rm, .pwm, .pages, .obj, .mlb, .md, .mbx, .lit, .laccdb, .kwm, .idx, .html, .flf, .dxf, .dwg, .dds, .csv, .css, .config, .cfg, .cer, .asx, .aspx, .aoi, .accdb, .7zip, .1cd, .xls, .wab, .rtf, .prf, .ppt, .oab, .msg, .mapimail, .jnt, .doc, .dbx, .contact, .n64, .m4a, .m4u, .m3u, .mid, .wma, .flv, .3g2, .mkv, .3gp, .mp4, .mov, .avi, .asf, .mpeg, .vob, .mpg, .wmv, .fla, .swf, .wav, .mp3, .qcow2, .vdi, .vmdk, .vmx, .wallet, .upk, .sav, .re4, .ltx, .litesql, .litemod, .lbf, .iwi, .forge, .das, .d3dbsp, .bsa, .bik, .asset, .apk, .gpg, .aes, .ARC, .PAQ, .tar.bz2, .tbk, .bak, .tar, .tgz, .gz, .7z, .rar, .zip, .djv, .djvu, .svg, .bmp, .png, .gif, .raw, .cgm, .jpeg, .jpg, .tif, .tiff, .NEF, .psd, .cmd, .bat, .sh, .class, .jar, .java, .rb, .asp, .cs, .brd, .sch, .dch, .dip, .pl, .vbs, .vb, .js, .asm, .pas, .cpp, .php, .ldf, .mdf, .ibd, .MYI, .MYD, .frm, .odb, .dbf, .db, .mdb, .sql, .SQLITEDB, .SQLITE3, .011, .010, .009, .008, .007, .006, .005, .004, .003, .002, .001, .pst, .onetoc2, .asc, .lay6, .lay, .ms11 (Security copy), .ms11, .sldm, .sldx, .ppsm, .ppsx, .ppam, .docb, .mml, .sxm, .otg, .odg, .uop, .potx, .potm, .pptx, .pptm, .std, .sxd, .pot, .pps, .sti, .sxi, .otp, .odp, .wb2, .123, .wks, .wk1, .xltx, .xltm, .xlsx, .xlsm, .xlsb, .slk, .xlw, .xlt, .xlm, .xlc, .dif, .stc, .sxc, .ots, .ods, .hwp, .602, .dotm, .dotx, .docm, .docx, .DOT, .3dm, .max, .3ds, .xml, .txt, .CSV, .uot, .RTF, .pdf, .XLS, .PPT, .stw, .sxw, .ott, .odt, .DOC, .pem, .p12, .csr, .crt, .key";
                string[] FileExtensions = Ext.Split(',');
                foreach (string item in FileExtensions)
                {
                    Extensions ext = new Extensions();
                    ext.Ext = item.Trim().Replace(" ", "");
                    db.Extension.Add(ext);
                }
                db.SaveChanges();
                StreamWriter sw = new StreamWriter("first");
                sw.Close();

                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Please give us the highest available permission to start !");
                    Application.Exit();
                }
            }
           


        }

    }
}
