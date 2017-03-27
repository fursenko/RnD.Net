
namespace Multithreading.Training.TaskStatusObserver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static Task observableTask = null;

        static void Main(string[] args)
        {
            var taskObserver = new Task(() => Observe());
            //observableTask = taskObserver.ContinueWith(_ => Run(), TaskContinuationOptions.AttachedToParent);
            observableTask = new Task(() => Run());

            taskObserver.Start();
            //observableTask.Start();

            Console.ReadKey();
        }
        private static void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Log("INTERNAL", "running");
            }

            Log("INTERNAL", "completed");
        }

        private static void Observe()
        {
            Thread.Sleep(200);

            if (observableTask == null)
            {
                Log("OBSERVER", "task is null");
                Observe();
            }

            Log("OBSERVER", observableTask.Status.ToString());

            if (observableTask.IsCompleted) return;

            Observe();
        }

        static void Log(string sender, string message)
        {
            Console.WriteLine("[Task {0}]: {1}", sender, message);
        }
    }
}
