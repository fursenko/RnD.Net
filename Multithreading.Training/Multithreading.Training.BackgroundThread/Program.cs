
namespace Multithreading.Training.BackgroundThread
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("MAIN thread");

            var thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start("      thread B ...");

            //Run("MAIN thread...");
            Console.ReadKey();
            Console.WriteLine("main thread is finished");
        }

        private static void Run(object threadMessage)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(threadMessage);
                Thread.Sleep(1000);
            }
        }
    }
}
