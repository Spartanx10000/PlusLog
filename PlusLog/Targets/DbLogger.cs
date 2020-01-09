using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PlusLog.Enumerators;
using PlusLog.Formatting;

namespace PlusLog.Targets
{
    ///<summary>This class contains the methods to use the database logger.</summary>
    public class DbLogger
    {
        private static string _ConnectionString;

        ///<summary>DbLogger class constructor.</summary>
        ///<param name="connection">The name of the connection used for the database Logger.</param>
        internal DbLogger(string connection)
        {
            _ConnectionString = connection;
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
                    SqlConnection conex = new SqlConnection(_ConnectionString);
                    conex.Open();
                    SqlTransaction trans = conex.BeginTransaction();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conex;
                    cmd.Transaction = trans;
                    try
                    {
                        string logQuery = string.Empty;
                        switch (type)
                        {
                            case EventType.Success:
                                logQuery = DbLogFormat.SuccessLog(message);
                                break;
                            case EventType.Info:
                                logQuery = DbLogFormat.InfoLog(message);
                                break;
                            case EventType.Debug:
                                logQuery = DbLogFormat.DebugLog(message);
                                break;
                            case EventType.Warning:
                                logQuery = DbLogFormat.WarningLog(message);
                                break;
                            case EventType.Error:
                                logQuery = DbLogFormat.ErrorLog(message);
                                break;
                        }
                        System.Diagnostics.Debug.WriteLine(logQuery);
                        cmd.CommandText = logQuery;
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        conex.Close();
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
