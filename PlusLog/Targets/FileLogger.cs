using System;
using System.IO;
using System.Threading.Tasks;
using PlusLog.Enumerators;
using PlusLog.Formatting;

namespace PlusLog.Targets
{
    ///<summary>This class contains the methods to use the file logger.</summary>
    public class FileLogger
    {
        private static string _FileName;
        private static string _FilePath;

        ///<summary>FileLogger class constructor.</summary>
        ///<param name="fileName">The name of the file.</param>
        ///<param name="filePath">The path of the file.</param>
        internal FileLogger(string fileName, string filePath)
        {
            _FileName = fileName;
            _FilePath = filePath;
        }

        ///<summary>This method records a success event.</summary>
        ///<param name="message">The message that is logged.</param>
        public void Success(string message)
        {
            try
            {
                LogAsync(EventType.Success, message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        ///<summary>This method records a info event.</summary>
        ///<param name="message">The message that is logged.</param>
        public void Info(string message)
        {
            try
            {
                LogAsync(EventType.Info, message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        ///<summary>This method records a debug event.</summary>
        ///<param name="message">The message that is logged.</param>
        public void Debug(string message)
        {
            try
            {
                LogAsync(EventType.Debug, message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        ///<summary>This method records a warning event.</summary>
        ///<param name="message">The message that is logged.</param>
        public void Warning(string message)
        {
            try
            {
                LogAsync(EventType.Warning, message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        ///<summary>This method records a error event.</summary>
        ///<param name="message">The message that is logged.</param>
        public void Error(string message)
        {
            try
            {
                LogAsync(EventType.Error, message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static async void LogAsync(EventType type, string message)
        {
            try
            {
                await Task.Run(() => {
                    string log = string.Empty;
                    switch (type)
                    {
                        case EventType.Success:
                            log = FileLogFormat.SuccessLog(message);
                            break;
                        case EventType.Info:
                            log = FileLogFormat.InfoLog(message);
                            break;
                        case EventType.Debug:
                            log = FileLogFormat.DebugLog(message);
                            break;
                        case EventType.Warning:
                            log = FileLogFormat.WarningLog(message);
                            break;
                        case EventType.Error:
                            log = FileLogFormat.ErrorLog(message);
                            break;
                    }
                    using (StreamWriter streamWriter = new StreamWriter(_FilePath + _FileName, true))
                    {
                        streamWriter.WriteLine(log);
                        streamWriter.Close();
                    }
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
