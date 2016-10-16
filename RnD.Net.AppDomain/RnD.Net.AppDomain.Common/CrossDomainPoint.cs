
namespace RnD.Net.AppDomain.Common
{
    using System;
    using System.Threading;

    public abstract class BaseContext
    {
        public string name;
    }

    public class NonSerializableContext: BaseContext
    {
        public NonSerializableContext(string name)
        {
            base.name = name;
        }
    }

    [Serializable]
    public class CrossDomainContext
    {
        public string name;

        public CrossDomainContext(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.GetType().ToString(), name);
        }
    }

    public class CrossDomainPoint : MarshalByRefObject
    {
        readonly DateTime time = DateTime.Now;
        public CrossDomainPoint()
        {

            Console.WriteLine("{0} created at: {1}", this.GetType().FullName, time.ToString());
        }

        public void Run()
        {
            Console.WriteLine("{0}.Run", this.GetType().FullName);
        }

        public Guid GetId()
        {
            Console.WriteLine("{0}.GetId in domain: {1}", this.GetType().Name, Thread.GetDomain().FriendlyName);
            return Guid.NewGuid();
        }

        public CrossDomainContext GetContext()
        {
            Console.WriteLine("{0}.GetId in domain: {1}", this.GetType().Name, Thread.GetDomain().FriendlyName);

            var context = new CrossDomainContext("Context");

            return context;
        }

        public NonSerializableContext GetNonSerializableContext()
        {
            var context = new NonSerializableContext("Context");
            return context;
        }
    }
}
