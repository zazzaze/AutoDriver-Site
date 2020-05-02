using System;

namespace Driver.Service
{
    public class Logger
    {
        public void CreateLog(ILogger logger, String content)
        {
            logger.WriteLog(content);
        }
    }
}