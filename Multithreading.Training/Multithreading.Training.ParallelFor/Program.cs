
namespace Multithreading.Training.ParallelFor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            //Parallel.For(0, 9000, )

            //var timer = new Timer()
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.ForEach<string>(GetTestData(), _ => Console.WriteLine("Thread: {0}, data: {1}", Thread.CurrentThread.ManagedThreadId, _));
            //Array.ForEach<string>(GetTestData().ToArray(), _ => Console.WriteLine("Thread: {0}, data: {1}", Thread.CurrentThread.ManagedThreadId, _));
            stopwatch.Stop();

            Console.WriteLine("Result: {0} ms", stopwatch.ElapsedMilliseconds);

            Console.ReadKey();
        }

        static List<string> GetTestData()
        {
            var list = new List<string>();

            for (int i = 0; i < 1000; i++)
            {
                list.Add(Guid.NewGuid().ToString());
            }

            return list;
        }
    }
}
