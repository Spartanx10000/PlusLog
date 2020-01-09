using System;
using System.Collections.Generic;
using System.Text;

namespace PlusLog.Formatting
{
    class MailLogFormat
    {
        public static string SuccessLog(string log, string message)
        {
            return BaseLog("SUCCESS", log, message);
        }

        public static string DebugLog(string log, string message)
        {
            return BaseLog("DEBUG", log, message);
        }

        public static string InfoLog(string log, string message)
        {
            return BaseLog("INFO", log, message);
        }

        public static string WarningLog(string log, string message)
        {
            return BaseLog("WARNING", log, message);
        }

        public static string ErrorLog(string log, string message)
        {
            return BaseLog("ERROR", log, message);
        }

        private static string BaseLog(string type, string log, string message)
        {
            log = log.Replace("{Event}", type);
            log = log.Replace("{Message}", message);
            log = log.Replace("{Date}", DateTimeFormat.GetDate() + " " + DateTimeFormat.GetTime());
            return log;
        }
    }
}
