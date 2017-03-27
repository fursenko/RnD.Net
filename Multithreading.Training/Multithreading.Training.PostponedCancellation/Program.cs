
namespace Multithreading.Training.PostponedCancellation
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource(3000);
            cts.Token.Register(() => { Console.WriteLine("Operation is cancelled"); });

            ThreadPool.QueueUserWorkItem(_ => Run(cts.Token));
            Console.ReadKey();
        }

        private static void Run(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested) break;
                Console.WriteLine("thread {0} is running", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(500);
            }

        }
    }
}
