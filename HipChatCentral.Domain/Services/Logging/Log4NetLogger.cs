using HipChatCentral.Domain.Interfaces;
using log4net;

namespace HipChatCentral.Domain.Services.Logging
{
    public class Log4NetLogger <T>: ICustomLogger <T>
    {
        private ILog _logger;

        public Log4NetLogger ()
        {            
            _logger = LogManager.GetLogger(typeof(T));
        }

        public void DebugLog(string logstring, params object [] parameters)
        {
            _logger.DebugFormat(logstring, parameters);                                                
        }

        public void InfoLog(string logstring, params object [] parameters)
        {
            _logger.InfoFormat(logstring, parameters);
        }        
    }
}