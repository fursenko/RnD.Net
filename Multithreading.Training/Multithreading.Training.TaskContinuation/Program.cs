

namespace Multithreading.Training.TaskContinuation
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
            var cts = new CancellationTokenSource();

            var task = new Task(() => Run(), cts.Token);

            task.ContinueWith(_ => Complete(), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(_ => Cancel(), TaskContinuationOptions.OnlyOnCanceled);

            task.Start();
            cts.Cancel();

            Console.WriteLine("program is finished");
            Console.ReadKey();
        }

        private static void Cancel()
        {
            Console.WriteLine("task is cancelled");
        }

        private static void Complete()
        {
            Console.WriteLine("task is completed");
        }

        private static void Run()
        {
            Thread.Sleep(1000);
            Console.WriteLine("task is running");
        }


    }
}
