using log4net;
using System;
using System.Reflection;

namespace Netactica.Tools
{
    /// <summary>
    /// Herramiento para generar el log en cada uno de los metodos
    /// </summary>
    /// <remarks>JUAN RICARDO DIAZ - 2018-08-01</remarks>
    public class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Agrega un mensaje al log con una excepcion fatal
        /// </summary>
        /// <param name="Message">mensaje de error</param>
        /// <param name="ex">Exception</param>
        public static void ErrorFatal(string Message, Exception ex = null)
        {
            if (ex != null)
                log.Error(Message, ex);
            else
                log.Error(Message);
        }

        /// <summary>
        /// Agrega un mensaje al log de tipo warning
        /// </summary>
        /// <param name="Message">mensaje de error</param>
        /// <param name="ex">Exception</param>
        public static void Warning(string Message, Exception ex = null)
        {
            if (ex != null)
                log.Warn(Message, ex);
            else
                log.Warn(Message);
        }

        /// <summary>
        /// Agrega un mensaje de log de tipo info
        /// </summary>
        /// <param name="Message">mensaje de error</param>
        /// <param name="ex">Exception</param>
        public static void Info(string Message, Exception ex = null)
        {
            if (ex != null)
                log.Info(Message, ex);
            else
                log.Info(Message);
        }
    }
}