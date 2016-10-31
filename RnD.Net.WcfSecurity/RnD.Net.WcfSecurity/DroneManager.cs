
namespace RnD.Net.WcfSecurity
{
    using System;
    using RnD.Net.WcfSecurity.Contracts;
    using System.ServiceModel;
    public class DroneManager : IDroneManager
    {
        public string GetInfo()
        {
            return "Drone info";
        }

        public void KillSelf()
        {
            Console.WriteLine("Killing");
            OperationContext.Current.Host.Close();
        }

        public string Ping()
        {
            return "DRONE PASSWORD";
        }
    }
}
