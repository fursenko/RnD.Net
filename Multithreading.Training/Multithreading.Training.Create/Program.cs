
namespace Multithreading.Training.Create
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;


    class Program
    {
        public static string Bred { get; private set; }

        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "ROBOSPECTRA. TEST APP";

            Console.WriteLine("Main thread. Start additional thread");
            var thread = new Thread(Run);

            thread.Start("         THREAD B ....");
            thread.Join(5000);

            Run("MAIN THREAD...");

            //thread.Join(/*2000*/);

            Console.WriteLine("Main thread is finished");

            Console.ReadKey();

            //Thread.Sleep(5000);
        }

        private static void Run(object threadMessage)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(threadMessage);
            }
        }
    }
}
