using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;
using System.Diagnostics.Contracts;

namespace Microsoft.Web.Portal.Common.Logging
{
    /// <summary>
    /// Log level enumeration
    /// </summary>
    public enum LogLevel {
        Debug,
        Information,
        Warning,
        Error,
        Fatal
    };

    /// <summary>
    /// Logger implementation using log4net
    /// </summary>
    public class Log4NetLogger : ILogger
    {
        /// <summary>
        /// the Log instance
        /// </summary>
        private ILog _log = null;

        /// <summary>
        /// cosntructor, initializes the Log4Net
        /// </summary>
        public Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
            _log = LogManager.GetLogger("graph.microsoft.io"); // todo: we need to get this inforamtion from the log file, so that it can be shared
        }

        /// <summary>
        /// Logs the message
        /// </summary>
        /// <param name="level">log level</param>
        /// <param name="message">message to log</param>
        public void Log(LogLevel level, string message)
        {
            Contract.Requires(!string.IsNullOrEmpty(message));

            switch (level)
            {
                case LogLevel.Debug:
                    _log.Debug(message);
                    break;
                case LogLevel.Error:
                    _log.Error(message);
                    break;
                case LogLevel.Fatal:
                    _log.Fatal(message);
                    break;
                case LogLevel.Information:
                    _log.Info(message);
                    break;
                case LogLevel.Warning:
                    _log.Warn(message);
                    break;
            }
        }
    }
}
