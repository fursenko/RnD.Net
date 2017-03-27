
namespace Multithreading.Training.SharedContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        public static string message { get { return Guid.NewGuid().ToString(); } }

        static void Main(string[] args)
        {
            CallContext.LogicalSetData("message", message);
            ThreadPool.QueueUserWorkItem(_ => 
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    ExecutionContext.Capture();
                    Console.WriteLine("     Thread: {0} ; message: {1}", Thread.CurrentThread.ManagedThreadId, CallContext.LogicalGetData("message"));
                }
            });

            CallContext.LogicalSetData("message", message);
            ExecutionContext.SuppressFlow();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    ExecutionContext.Capture();
                    Console.WriteLine("         Thread: {0} ; message: {1}", Thread.CurrentThread.ManagedThreadId, CallContext.LogicalGetData("message"));
                }
            });

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("main thread: {0}", CallContext.LogicalGetData("message"));
                Thread.Sleep(1000);
            }


            Console.ReadKey();

        }
    }
}
