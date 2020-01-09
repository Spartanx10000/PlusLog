using System;
using System.Collections.Generic;
using System.Text;

namespace PlusLog.Formatting
{
    class DbLogFormat
    {
        //CREATE TABLE dbo.LOG_t001(
        //log_Id INTEGER IDENTITY(1,1),
        //log_Event CHAR(10) NULL,
        //log_Date DATETIME NULL,
        //log_Message VARCHAR(250) NULL,
        //PRIMARY KEY(log_Id));

        public static string SuccessLog(string message)
        {
            return SQLServerInsertLog("SUCCESS", message);
        }

        public static string DebugLog(string message)
        {
            return SQLServerInsertLog("DEBUG", message);
        }

        public static string InfoLog(string message)
        {
            return SQLServerInsertLog("INFO", message);
        }

        public static string WarningLog(string message)
        {
            return SQLServerInsertLog("WARNING", message);
        }

        public static string ErrorLog(string message)
        {
            return SQLServerInsertLog("ERROR", message);
        }

        private static string SQLServerInsertLog(string type, string message)
        {
            return string.Format("INSERT INTO LOG_t001(log_Event, log_Date, log_Message) VALUES ('{0}', GETDATE(), '{1}')", type, message);
        }
    }
}
