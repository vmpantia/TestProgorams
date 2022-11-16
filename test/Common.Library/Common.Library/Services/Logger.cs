using System.Diagnostics;

namespace Common.Library.Services
{
    public class Logger : ILogger
    {
        public string _filePath = string.Empty;
        public bool IsDebug = false;

        public Logger(string systemName, string fileDirectory)
        {
            //Create File Path
            _filePath = fileDirectory + systemName + Constant.UNDERSCORE + Global.ExecDate;

            //Check if Directory Exist
            if (!Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(_filePath);
            }

            var logFileInfo = new FileInfo(_filePath);
            //Check if File Exist
            if (!logFileInfo.Exists)
            {
                logFileInfo.Create();
            }
        }

        public void WriteInfoLog(string info)
        {
            var message = string.Format(Constant.LOG_FORMAT,
                                        DateTime.Now.ToString(),
                                        IsDebug ? Constant.LOG_TYPE_DEBUG : Constant.LOG_TYPE_INFO,
                                        info);
            WriteLog(message);
        }

        public void WriteErrorLog(Exception ex)
        {
            var message = string.Format(Constant.LOG_FORMAT,
                                        DateTime.Now.ToString(),
                                        Constant.LOG_TYPE_ERROR,
                                        ex.ToString());
            WriteLog(message);
        }

        public void WriteEventLog(string systemName, Exception ex)
        {
#pragma warning disable CA1416 // Validate platform compatibility
            EventLog.WriteEntry(systemName, ex.ToString(), EventLogEntryType.Error);
#pragma warning restore CA1416 // Validate platform compatibility
        }

        private void WriteLog(string message)
        {
            File.AppendAllText(_filePath, message);
        }

    }
}
