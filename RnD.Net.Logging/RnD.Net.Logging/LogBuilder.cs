
namespace RnD.Net.Logging
{
    using System;
    using System.Configuration;

    public static class LogBuilder
    {
        public static ILogger GetLogger(Type type = null)
        {
            if (ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).GetSection("log4net") != null) return new Log4NetLogger(type);
            else if (ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).GetSection("nlog") != null) return new NLogLogger();

            else throw new ApplicationException("Logging configuration setting doesn't exist");
        }
    }
}
