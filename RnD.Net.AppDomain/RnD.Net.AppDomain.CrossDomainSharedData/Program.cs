
namespace RnD.Net.AppDomain.CrossDomainSharedData
{
    using Common;
    using System;
    using System.Reflection;
    using System.Runtime.Remoting;

    class Program
    {
        static void ShareDataCrossDomain()
        {
            Console.WriteLine("{0}# Cross Domain Shared Data", Environment.NewLine);
            
            var domainName = "domain#2";

            Console.WriteLine("Create the new domain {0}", domainName);
            var newDomain = AppDomain.CreateDomain(domainName);

            var crossDomainPoint = newDomain.CreateInstanceAndUnwrap(Assembly.GetAssembly(typeof(CrossDomainPoint)).FullName
                , typeof(CrossDomainPoint).FullName) as CrossDomainPoint;

            Console.WriteLine("Is CrossDomainPoint null: {0}", crossDomainPoint == null);
            Console.WriteLine("Is CrossDomainPoint proxy: {0}", RemotingServices.IsTransparentProxy(crossDomainPoint));
            Console.WriteLine("CrossDomainPoint value: {0}", crossDomainPoint.GetId());
            var context = crossDomainPoint.GetContext();
            Console.WriteLine("Unload domain");
            AppDomain.Unload(newDomain);
            Console.WriteLine(context.ToString());

            //var cont
        }

        static void Main(string[] args)
        {
            try
            {
                ShareDataCrossDomain();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }    
        }
    }
}
