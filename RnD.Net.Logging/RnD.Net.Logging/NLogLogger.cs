
namespace RnD.Net.Logging
{
    using NLog;
    using System;

    public class NLogLogger : ILogger
    {
        readonly NLog.ILogger logger;

        public NLogLogger()
        {
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public NLogLogger(Type type)
        {
            this.logger = LogManager.GetCurrentClassLogger(type);
        }

        public NLogLogger(string name)
        {
            this.logger = LogManager.GetLogger(name);
        }

        public void Error(object message, Exception ex = null)
        {
            this.logger.Error(ex, message as string, message);
        }

        public void Fatal(object message, Exception ex = null)
        {
            this.logger.Fatal(ex, message as string, message);
        }

        public void Info(object message, Exception ex = null)
        {
            this.logger.Info(ex, message as string, message);
        }

        public void Warn(object message, Exception ex = null)
        {
            this.logger.Info(ex, message as string, message);
        }
    }
}
