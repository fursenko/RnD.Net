

namespace Multithreading.Training.ChildTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            var mainTask = new Task<IEnumerable<string>>(()=> 
            {
                var result = new List<string>();

                new Task(() => result.Add(Run("TASK A is running", "A")), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result.Add(Run("                 TASK B is running", "B")), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result.Add(Run("                                    TASK C is running", "C")), TaskCreationOptions.AttachedToParent).Start();

                return result;
            });

            mainTask.ContinueWith(_ => { Array.ForEach(_.Result.ToArray(), Console.WriteLine); });
            mainTask.Start();

            Console.ReadKey();
        }

        private static string Run(string message, string taskName)
        {
            for (int i = 0; i < 5; i++)
                Console.WriteLine(message);

            return String.Format("Task: {0} is finished", taskName);
        }
    }
}
