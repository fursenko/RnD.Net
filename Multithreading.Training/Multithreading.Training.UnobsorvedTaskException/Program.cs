using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Multithreading.Training.UnobsorvedTaskException
{
    public class Example
    {
        public void Test()
        {
            Task t = new Task(() =>
            {
                Console.WriteLine("Do test, just before exception.");
                throw new Exception();
            }); t.Start();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TaskScheduler.UnobservedTaskException += new EventHandler<UnobservedTaskExceptionEventArgs>
                (TaskScheduler_UnobservedTaskException);
            Example example = new Example();
            example.Test();
            Thread.Sleep(2000); // delay is needed to make sure the task is done before calling GC. 
            Console.WriteLine("Done sleeping");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadLine();
        }
        static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine("Error.");
            e.SetObserved();
        }
    }
}
