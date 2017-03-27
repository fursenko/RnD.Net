using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading.Training.ParalleOptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
            //Console.WriteLine("Enter the path directory");
            //var directory = Console.ReadLine();

            //Partitioner.Create()

            //if (!Directory.Exists(directory)) { Console.WriteLine("wrong path"); continue; }
            var pattern = "";
            Console.WriteLine("Enther the pattern");
            pattern = Console.ReadLine();

            Console.WriteLine("Totoal bytes: {0}", GetBytesSum(Directory.GetCurrentDirectory(), pattern, SearchOption.AllDirectories));

            Console.ReadKey();

            //}

        }

        private static Int64 GetBytesSum(string path, string searchPattern, SearchOption searchOption)
        {
            var files = Directory.EnumerateFiles(path, searchPattern, searchOption);
            Int64 total = 0;

            ParallelLoopResult result = Parallel.ForEach<string, Int64>(files,
                () => { return 0; }

            , (file, loopState, index, taskLocalTotal) =>
            {
                Int64 fileLength = 0;

                using (var fileStream = File.OpenRead(file))
                {
                    fileLength = fileStream.Length;
                }

                return fileLength + taskLocalTotal;
            }

            , taskLocalTotoal =>
            {
                Interlocked.Add(ref total, taskLocalTotoal);
            });

            return total;
        }
    }
}
