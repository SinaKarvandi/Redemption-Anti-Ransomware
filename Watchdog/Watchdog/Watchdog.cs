using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog
{
    class Watchdog
    {
        public void Watch()
        {
            Database db = new Database();
            foreach (var item in db.AuditingZones.Select(x => new { x.ZonePath }.ZonePath))
            {
                try
                {
                    Utility u = new Utility(false);
                    u.EnableWatchDog(item, false);

                }
                catch (Exception)
                {

                }
            }

            foreach (var item in db.Honeypots.Select(x => new { x.HoneypotPath }.HoneypotPath))
            {
                try
                {
                    Utility u = new Utility(true);
                    u.EnableWatchDog(item, false);

                }
                catch (Exception)
                {

                }
            }
        }
    }
}
