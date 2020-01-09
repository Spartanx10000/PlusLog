using System;
using System.Collections.Generic;
using System.Text;

namespace PlusLog.Formatting
{
    class FileLogFormat
    {
        public static string SuccessLog(string message)
        {
            return BaseLog("SUCCESS", message);
        }

        public static string DebugLog(string message)
        {
            return BaseLog("DEBUG", message);
        }

        public static string InfoLog(string message)
        {
            return BaseLog("INFO", message);
        }

        public static string WarningLog(string message)
        {
            return BaseLog("WARNING", message);
        }

        public static string ErrorLog(string message)
        {
            return BaseLog("ERROR", message);
        }

        private static string BaseLog(string type, string message)
        {
            return string.Format("[" + type + "][" + DateTimeFormat.GetDate() + " " + DateTimeFormat.GetTime() + "] -> {0}", message);
        }
    }
}
