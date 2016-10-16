
namespace RnD.Net.AppDomain.Monitoring
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            using (var domainMonitor = new AppDomainMonitorManager(AppDomain.CurrentDomain))
            {
                var list = new List<object>();
                for (int i = 0; i < 100; i++)
                {
                    list.Add(new byte[10000]);
                }

                for (int i = 0; i < 100; i++) {new byte[10000].GetType();}

                var stop = Environment.TickCount + 5000;
                while (Environment.TickCount < stop) ;
            }
        }
    }
}
