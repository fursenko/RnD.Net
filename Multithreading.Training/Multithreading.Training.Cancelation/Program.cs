
namespace Multithreading.Training.Cancellation
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            var cancelationTokenSource = new CancellationTokenSource();

            ThreadPool.QueueUserWorkItem(_ => Run(cancelationTokenSource.Token, 1000));

            Console.WriteLine("Press the key to cancel the operation");
            Console.ReadKey();

            cancelationTokenSource.Cancel();

            Console.ReadKey();
        }

        static void Run(CancellationToken token, int counter)
        {
            for (int i = 0; i < counter; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Cancelation was requested");
                    break;
                }

                Console.WriteLine("Operation tick: {0}", i);
                Thread.Sleep(500);
            }

            Console.WriteLine("Operation is finished");
        }
    }
}
