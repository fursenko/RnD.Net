
namespace RnD.Net.AppDomain.CrossDomainAccess
{
    using System;
    using System.Reflection;
    using System.Runtime.Remoting;
    using System.Threading;

    class Program
    {
        static void Marshalling()
        {
            AppDomain domain = Thread.GetDomain();
            var domainName = domain.FriendlyName;
            Console.WriteLine("Default app domain: {0}", domainName);

            // Get the assembly, which contains the Main method
            var executeAssembly = Assembly.GetEntryAssembly().FullName;
            Console.WriteLine("Entry assembly: {0}", executeAssembly);

            Console.WriteLine("{0}# Cross domain access", Environment.NewLine);
            AppDomain newDomain = AppDomain.CreateDomain("ad#2", null, null);

            var crossDomainPoint = newDomain.CreateInstanceAndUnwrap(executeAssembly, typeof(CrossDomainPoint).FullName) as CrossDomainPoint;
            if (crossDomainPoint == null) { Console.WriteLine("CrossDomainRef is null"); return; }

            Console.WriteLine("CrossDomainRef: {0}", crossDomainPoint.GetType());
            Console.WriteLine("Is CrossDomainRef proxy: {0}", RemotingServices.IsTransparentProxy(crossDomainPoint));

            crossDomainPoint.Run();

            Console.WriteLine("Unload domain");
            AppDomain.Unload(newDomain);

            Console.WriteLine("Is CrossDomainPoint null: {0}", crossDomainPoint == null);
            crossDomainPoint.Run();
        }

        static void Main(string[] args)
        {
            try
            {
                Marshalling();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
