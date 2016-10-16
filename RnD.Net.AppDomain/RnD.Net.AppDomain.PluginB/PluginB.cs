
namespace RnD.Net.AppDomain.PluginB
{
    using Common;
    using System;
    using System.Threading;

    public class PluginB : MarshalByRefObject, IPlugin
    {
        public void Run()
        {
            for (int i = 0; i < 200; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("PUGIN-A: some activities");
            }
        }
    }
}
