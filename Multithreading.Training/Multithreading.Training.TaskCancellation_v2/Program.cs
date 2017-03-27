

namespace Multithreading.Training.TaskCancellation_v2
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var cts = new CancellationTokenSource();
            var task = new Task<string>(()=>Run(cts.Token));
            task.Start();

            cts.Cancel();

            try { Console.WriteLine("RESULT: {0}", task.Result); }
            catch (AggregateException e)
            {
                e.Handle(_ => _ is OperationCanceledException);

                Console.WriteLine("Task was cancelled");
            }

            Console.WriteLine("program is finished");
            Console.ReadKey();
        }

        //static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    Console.WriteLine("UEX");
        //    Console.WriteLine(e.ExceptionObject.ToString());
        //}

        private static string Run(CancellationToken token)
        {
            for (int i = 0; i < 10; i++)
            {
                token.ThrowIfCancellationRequested();
                Console.WriteLine("task is running");
                Thread.Sleep(200);
            }

            return "task is finished";
        }
    }
}
