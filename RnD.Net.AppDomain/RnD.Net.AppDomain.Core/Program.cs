
namespace RnD.Net.AppDomain.Core
{
    using Common;
    using System;
    using System.Reflection;
    using System.Runtime.Remoting;
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LoadPlugin();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void LoadPlugin()
        {
            string path = @"C:\MAIN\Projects\RnD.Net\RnD.Net.AppDomain\Plugins\RnD.Net.AppDomain.PluginA.dll";

            var domain = AppDomain.CreateDomain("#newdomain");
            var proxy = domain.CreateInstanceAndUnwrap(Assembly.GetAssembly(typeof(Proxy)).FullName, typeof(Proxy).FullName) as Proxy;

            if(proxy == null || !RemotingServices.IsTransparentProxy(proxy))
            { Console.WriteLine("Cross domain proxy is null or not valid"); return; }

            //Console.ReadKey();

            var plugin = proxy.GetPlugin(path);

            if (plugin == null) { Console.WriteLine("Plugin hasn't been created"); return; }

            plugin.Run();
        }
    }
}
