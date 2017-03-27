
namespace Multithreading.Training.Task
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
            var task = new Task<string>(_ => Run(_ as String), "");
            task.Start();

            task.Wait();

            Console.WriteLine("task is finished");
            Console.ReadKey();
        }

        private static string Run(string v)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("task running");
                Thread.Sleep(200);
            }

            return Guid.NewGuid().ToString();
        }
    }
}
