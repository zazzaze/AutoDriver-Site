using System;
using System.IO;

namespace Driver.Service
{
    public class FileLogger : ILogger
    {
        private const String path = "logs.log";
        public async void WriteLog(String content)
        {
            try
            {
                using (StreamWriter sw = File.AppendText("logs.log"))
                {
                    await sw.WriteLineAsync(DateTime.Now+":\t"+content);
                }
            }
            catch(Exception e){}
        }
    }
}