
namespace RnD.Net.LogTester_B
{
    using RnD.Net.Logging;
    using System;

    class Program
    {
        static ILogger logger = LogBuilder.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            try
            {
                FirstRun();
                //logger.Warn("TEST");
            }
            catch (Exception ex)
            {
                logger.Error("App Error", ex);
            }

            //Console.ReadKey();
        }

        static void FirstRun()
        {
            logger.Warn("First run");
            SecondRun();
        }

        static void SecondRun()
        {
            logger.Info("Second run");
            ThirdRun();
        }

        static void ThirdRun()
        {
            throw new ApplicationException("Eror");
        }
    }
}
