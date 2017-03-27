
namespace Multithreading.Training.ParallelInvoke
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
            //Parallel.Invoke(
            //    ()=> 
            //{
            //    Run("task A1 is running");
            //    Run("                   task B1 is running");
            //    Run("                                       task C1 is running");
            //}
            ///*, ()=> 
            //{
            //    Run("task A2 is running");
            //    Run("                   task B2 is running");
            //    Run("                                       task C2 is running");
            //}*/);

            Parallel.Invoke(
                () => Run("task A1 is running")
                , () => Run("                   task B1 is running")
                , () => Run("                                       task C1 is running")
            );

            Console.ReadKey();
        }

        private static void Run(string message)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(message);
                Thread.Sleep(200);
            }
        }
    }
}
