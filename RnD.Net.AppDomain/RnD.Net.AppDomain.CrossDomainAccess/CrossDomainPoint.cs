
namespace RnD.Net.AppDomain.CrossDomainAccess
{
    using System;

    [Serializable]
    public class CrossDomainPoint: MarshalByRefObject
    {
        private readonly DateTime time;
        public CrossDomainPoint()
        {
            this.time = DateTime.Now;
            Console.WriteLine("'{0}' created at: {1:D}", this.GetType().FullName, time.ToString());
        }

        public void Run()
        {
            Console.WriteLine("{0}.Run",this.GetType().ToString());
        }
    }
}