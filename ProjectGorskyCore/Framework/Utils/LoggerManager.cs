using NLog;

namespace Framework.Utils
{
    public static class LoggerManager
    {
        private static Logger? _logger;

        public static Logger Logger 
        { 
            get 
            {
                if (_logger == null)
                {
                    _logger = LogManager.GetLogger("Common");
                }
                return _logger;
            }

            private set 
            {
                _logger = value;
            }
        }
    }
}
