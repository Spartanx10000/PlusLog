using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;
using PlusLog.Config.Xml.Mail;
using PlusLog.Enumerators;
using PlusLog.Formatting;

namespace PlusLog.Targets
{
    ///<summary>This class contains the methods to use the mail logger.</summary>
    public class MailLogger
    {
        private static string _TemplateName;
        private static string _TemplatePath;
        private static MailSettings _Settings;

        ///<summary>MailLogger class constructor.</summary>
        ///<param name="settings">Contains smtp settings.</param>
        internal MailLogger(MailSettings settings)
        {
            _TemplateName = "Template.html";
            _TemplatePath = System.AppDomain.CurrentDomain.BaseDirectory;
            _Settings = settings;
        }

        ///<summary>This method send a success event mail.</summary>
        ///<param name="subject">The subject of the mail.</param>
        ///<param name="message">The message that is sended.</param>
        public void Success(string subject, string message)
        {
            try
            {
                SendLogAsync(EventType.Success, subject, message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        ///<summary>This method send a info event mail.</summary>
        ///<param name="subject">The subject of the mail.</param>
        ///<param name="message">The message that is sended.</param>
        public void Info(string subject, string message)
        {
            try
            {
                SendLogAsync(EventType.Info, subject, message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        ///<summary>This method send a debug event mail.</summary>
        ///<param name="subject">The subject of the mail.</param>
        ///<param name="message">The message that is sended.</param>
        public void Debug(string subject, string message)
        {
            try
            {
                SendLogAsync(EventType.Debug, subject, message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        ///<summary>This method send a warning event mail.</summary>
        ///<param name="subject">The subject of the mail.</param>
        ///<param name="message">The message that is sended.</param>
        public void Warning(string subject, string message)
        {
            try
            {
                SendLogAsync(EventType.Warning, subject, message);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        ///<summary>This method send a error event mail.</summary>
        ///<param name="subject">The subject of the mail.</param>
        ///<param name="message">The message that is sended.</param>
        public void Error(string subject, string message)
        {
            try
            {
                SendLogAsync(EventType.Error, subject, message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static async void SendLogAsync(EventType type, string subject, string message)
        {
            try
            {
                await Task.Run(() => {

                    string log = string.Empty;

                    //using (StreamReader streamReader = new StreamReader(TemplatePath + TemplateName, true))
                    //{
                    //    log = streamReader.ReadToEnd();
                    //}

                    using (StreamReader streamReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("PlusLog.Template.Template.html")))
                    {
                        log = streamReader.ReadToEnd();
                    }

                    switch (type)
                    {
                        case EventType.Success:
                            log = MailLogFormat.SuccessLog(log, message);
                            break;
                        case EventType.Info:
                            log = MailLogFormat.InfoLog(log, message);
                            break;
                        case EventType.Debug:
                            log = MailLogFormat.DebugLog(log, message);
                            break;
                        case EventType.Warning:
                            log = MailLogFormat.WarningLog(log, message);
                            break;
                        case EventType.Error:
                            log = MailLogFormat.ErrorLog(log, message);
                            break;
                    }

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(_Settings.Sender.Email);
                        mailMessage.Subject = subject;
                        mailMessage.Body = log;
                        mailMessage.IsBodyHtml = true;
                        mailMessage.To.Add(new MailAddress(_Settings.Receiver.Email));
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = _Settings.Smtp.Host;
                        smtp.EnableSsl = Convert.ToBoolean(_Settings.Smtp.Enablessl);
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = _Settings.Sender.Email;  
                        NetworkCred.Password = _Settings.Sender.Password; 
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = int.Parse(_Settings.Smtp.Port);  
                        smtp.Send(mailMessage);                       
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
