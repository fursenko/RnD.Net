
namespace Multithreading.Training.CancellationCallBack
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            var ctsA = new CancellationTokenSource();
            ctsA.Token.Register(() => { Console.WriteLine("Cancelation CallBack A 1"); });
            ctsA.Token.Register(() => { Console.WriteLine("Cancelation CallBack A 2"); });

            var ctsB = new CancellationTokenSource();
            ctsB.Token.Register(() => { Console.WriteLine("Cancelation CallBack B 1"); });
            ctsB.Token.Register(() => { Console.WriteLine("Cancelation CallBack B 2"); });

            var ctsC = new CancellationTokenSource();
            ctsC.Token.Register(() => { Console.WriteLine("Cancelation CallBack C 1"); });

            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(ctsA.Token, ctsB.Token, ctsC.Token);
            linkedTokenSource.Token.Register(() => { Console.WriteLine("Linked token is canceled"); });

            //ctsB.Cancel();
            ctsA.Cancel();

            Console.ReadKey();
        }
    }
}
