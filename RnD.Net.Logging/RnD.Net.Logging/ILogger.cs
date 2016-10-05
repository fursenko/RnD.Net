
namespace RnD.Net.Logging
{
    using System;

    public interface ILogger
    {
        void Info(object message, Exception ex = null);

        void Warn(object message, Exception ex = null);

        void Error(object message, Exception ex = null);

        void Fatal(object message, Exception ex = null);        
    }
}
