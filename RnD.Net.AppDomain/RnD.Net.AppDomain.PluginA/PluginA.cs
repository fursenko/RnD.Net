
namespace RnD.Net.AppDomain.PluginA
{
    using Common;
    using System;
    using System.Threading;

    [Serializable]
    public class PluginA : MarshalByRefObject,  IPlugin 
    {
        public void Run()
        {
            for (int i = 0; i < 200; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("{0} PUGIN-A: some activities", Thread.GetDomain().FriendlyName);
            }
        }
    }
}
