
namespace RnD.Net.WcfSecurity.SecurityContext.Host
{
    using System;
    using System.ServiceModel;

    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(SecurityContextProvider));

            try
            {
                host.Opened += Host_Opened;
                host.Closed += Host_Closed;
                host.Open();
                Console.ReadKey();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
            finally
            { if (host != null) host.Close(); }
        }

        static void Host_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Service is stopped");
        }

        static void Host_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Service is started");
        }
    }
}
