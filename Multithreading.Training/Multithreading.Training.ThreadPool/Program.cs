
namespace Multithreading.Training.ThreadPool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MAIN THREAD");

            System.Threading.ThreadPool.QueueUserWorkItem(Run, "...... thread in TP");

            Run("MAIN THREAD");

            Console.WriteLine("MAIN THREAD IS FINISHED");
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
