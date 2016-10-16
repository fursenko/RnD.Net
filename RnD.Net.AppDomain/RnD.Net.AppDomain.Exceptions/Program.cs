using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RnD.Net.AppDomain.Exceptions
{
    public class CrossDomainPoint : MarshalByRefObject
    {
        private readonly DateTime time;
        public CrossDomainPoint()
        {
            this.time = DateTime.Now;
            Console.WriteLine("'{0}' created at: {1:D}", this.GetType().FullName, time.ToString());
        }

        public void Run()
        {
            Console.WriteLine("{0}.Run", this.GetType().ToString());
        }

        public void ThrowException()
        {
            throw new ApplicationException(String.Format("ERROR: {0}", System.AppDomain.CurrentDomain.FriendlyName));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Cross domain exception test");
                var dm = System.AppDomain.CreateDomain("nd");
                var dmProxy = dm.CreateInstanceAndUnwrap(Assembly.GetEntryAssembly().FullName, typeof(CrossDomainPoint).FullName) as CrossDomainPoint;
                dmProxy.ThrowException();
                Console.WriteLine("finish");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                //throw;
            }
            
        }
    }
}
