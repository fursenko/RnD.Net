using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading.Training.ExceptionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            try
            {
                AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException1; ;

                Console.WriteLine("main thread");

                ThreadPool.QueueUserWorkItem(_ => Run());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadKey();
        }

        private static void CurrentDomain_UnhandledException1(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("asfdadf"); ;
        }

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Console.WriteLine("ee");
        }

        private static void Test()
        {
            throw new NotImplementedException();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        private static void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine("         thread:  {0}", Thread.CurrentThread.ManagedThreadId);

                object sd = null;
                if (i == 20) throw new AggregateException("hello");
            }
        }
    }
}
