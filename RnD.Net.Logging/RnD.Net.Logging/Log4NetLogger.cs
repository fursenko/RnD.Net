
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace RnD.Net.Logging
{
    using System;
    using System.Configuration;
    public class Log4NetLogger : ILogger
    {
        readonly log4net.ILog log;

        public Log4NetLogger(Type type)
        {
            log = log4net.LogManager.GetLogger(type);
        }

        public Log4NetLogger(string name)
        {
            log = log4net.LogManager.GetLogger(name);
        }

        public void Debug(object message, Exception ex = null)
        {
            log.Debug(message, ex);
        }

        public void Info(object message, Exception ex = null)
        {
            log.Info(message, ex);
        }

        public void Warn(object message, Exception ex = null)
        {
            log.Warn(message, ex);
        }

        public void Error(object message, Exception ex = null)
        {
            log.Error(message, ex);
        }

        public void Fatal(object message, Exception ex = null)
        {
            log.Fatal(message, ex);
        }
    }
}
