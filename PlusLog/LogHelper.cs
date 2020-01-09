using System;
using PlusLog.Config;
using PlusLog.Config.Xml;
using PlusLog.Config.Xml.Database;
using PlusLog.Config.Xml.File;
using PlusLog.Config.Xml.Mail;
using PlusLog.Targets;
using PlusLog.Utilities;

namespace PlusLog
{
    ///<summary>
    ///This class contains the methods to access the different loggers supported by the PlusLog library.
    ///</summary>
    public class LogHelper
    {

        private static Configuration _Config = XmlConfigurator.GetConfiguration();

        ///<summary>This method creates an instance of the FileLogger class.</summary>
        ///<returns>Returns an instance of the FileLogger class.</returns>
        public static FileLogger GetFileLogger()
        {
            FileLogger log;
            try
            {
                FileSettings settings = _Config.FileSettings;
                if (settings != null)
                {
                    if (settings.File != null)
                    {
                        string file = settings.File.Name;
                        string path = settings.File.Path;
                        if(string.IsNullOrEmpty(file) )
                        {
                            file = "log.txt";
                        }

                        if (string.IsNullOrEmpty(path))
                        {
                            path = System.AppDomain.CurrentDomain.BaseDirectory;
                        }
                        log = new FileLogger(file, path);
                    }
                    else
                    {
                        throw new Exception("File settings not found.");
                    }
                }
                else
                {
                    throw new Exception("Invalid scheme -> fileSettings not found.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return log;
        }

        ///<summary>This method creates an instance of the DbLogger class.</summary>
        ///<param name="connectionName">The name of the connection used for the Database Logger.</param>
        ///<returns>Returns an instance of the DbLogger class.</returns>
        public static DbLogger GetDbLogger(string connectionName)
        {
            DbLogger log;
            try
            {
                DbSettings settings = _Config.DbSettings;
                if (settings != null)
                {
                    Connection conn = settings.Connection.Find(x => x.Name == connectionName);
                    if (conn != null)
                    {
                        log = new DbLogger(DbConnection.GetConnectionString(conn));
                    }
                    else
                    {
                        throw new Exception("The parameters for the connection in the file were not found.");
                    }
                }
                else
                {
                    throw new Exception("Invalid scheme -> DbSettings not found.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return log;
        }

        ///<summary>This method creates an instance of the MailLogger class.</summary>
        ///<returns>Returns an instance of the MailLogger class.</returns>
        public static MailLogger GetMailLogger()
        {
            MailLogger log;
            try
            {
                MailSettings settings = _Config.MailSettings;
                if (settings != null)
                {
                    Sender sender = settings.Sender;
                    Receiver receiver = settings.Receiver;
                    if (sender != null && receiver != null)
                    {
                        log = new MailLogger(settings);
                    }
                    else
                    {
                        throw new Exception("The parameters for sending emails were not found.");
                    }
                }
                else
                {
                    throw new Exception("Invalid scheme -> MailSettings not found.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return log;
        }

    }
}
