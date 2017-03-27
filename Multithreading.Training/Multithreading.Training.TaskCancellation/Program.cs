

namespace Multithreading.Training.TaskCancellation
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
            var cts = new CancellationTokenSource();
            var task = new Task(() => Run(cts.Token), cts.Token);

            task.Start();

            try
            {
                Console.WriteLine("Tas is completely finished");
            }
            catch (AggregateException x)
            {
                x.Handle(_ => _ is OperationCanceledException);
                Console.WriteLine("Task is cancelled");
            }

            Console.ReadKey();
        }

        static void Run(CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();
                Console.WriteLine("Task is running");
                Thread.Sleep(250);
            }
        }
    }
}
