
namespace Multithreading.Training.Timer
{
    using System;
    using System.Threading;

    class Program
    {
        private static System.Threading.Timer timer;

        static void Main(string[] args)
        {
            Console.WriteLine("timer creation");
            //timer = new Timer(Run, "tets", 0, Timeout.Infinite);
            timer = new Timer(Run, "state", Timeout.Infinite, Timeout.Infinite);
            Console.WriteLine("timer creation");
            Console.WriteLine("start timer");
            timer.Change(0, -1);
            Console.ReadKey();
        }

        private static void Run(object state)
        {
            Console.WriteLine(state.ToString());
            Console.WriteLine("thread working");
            Thread.Sleep(500);

            // the same:  timer.Change(0, Timeout.Infinite);
            timer.Change(0, -1);

        }
    }
}
