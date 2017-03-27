
namespace Multithreading.Training.TaskFactory
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
            var parrentTask = new Task(() =>
            {
                var cts = new CancellationTokenSource();

                var taskFactory = new TaskFactory<string>(cts.Token, TaskCreationOptions.AttachedToParent
                    , TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

                var childTasks = new Task<string>[]
                {
                    taskFactory.StartNew(()=>Run(cts.Token, "First task")),
                    taskFactory.StartNew(()=>Run(cts.Token, "Second task")),
                    taskFactory.StartNew(()=>Run(cts.Token, "Third task"))
                };

                for (int i = 0; i < childTasks.Length; i++)
                    childTasks[i].ContinueWith(_ => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);

                taskFactory.ContinueWhenAll(childTasks, _ =>
                {
                    var resultBuider = new StringBuilder("RESULT: " + Environment.NewLine);

                    for (int i = 0; i < _.Length; i++)
                        resultBuider.AppendLine
                        (!String.IsNullOrWhiteSpace(_[i].Result) 
                        ? _[i].Result : string.Format("task {0} result is empty", i));

                    return resultBuider.ToString();
                }
                , CancellationToken.None).ContinueWith(_ => Console.WriteLine(_.Result));
            });

            parrentTask.Start();

            Console.ReadKey();
        }

        private static string Run(CancellationToken token, string taskName)
        {
            if (string.IsNullOrWhiteSpace(taskName))
                throw new ArgumentNullException("taskName");

            for (int i = 0; i < 5; i++)
            {
                token.ThrowIfCancellationRequested();
                Console.WriteLine("{0} is running", taskName);
                Thread.Sleep(200);
            }

            return String.Format("{0} is completed", taskName);
        }
    }
}
