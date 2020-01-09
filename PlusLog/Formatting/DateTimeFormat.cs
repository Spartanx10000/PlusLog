using System;
using System.Collections.Generic;
using System.Text;

namespace PlusLog.Formatting
{
    class DateTimeFormat
    {
        public static string GetDate()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm");
        }
    }
}
