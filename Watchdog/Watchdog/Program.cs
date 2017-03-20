using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watchdog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists(@"C:\RedemptionBKUP"))
            {
                Directory.CreateDirectory(@"C:\RedemptionBKUP");
            }

            // Set Infinite wait
            Thread t1 = new Thread(delegate ()
            {
                Thread.Sleep(Timeout.InfiniteTimeSpan);
            });
            t1.Start();


            Thread t2 = new Thread(delegate ()
            {
                Watchdog wd = new Watchdog();
                wd.Watch();
                
            });
            t2.Start();




        }
    }
}
