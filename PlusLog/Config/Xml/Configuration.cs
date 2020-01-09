using System.Xml.Serialization;
using PlusLog.Config.Xml.Database;
using PlusLog.Config.Xml.File;
using PlusLog.Config.Xml.Mail;

namespace PlusLog.Config.Xml
{
    [XmlRoot(ElementName = "configuration")]
    public class Configuration
    {
        [XmlElement(ElementName = "fileSettings")]
        public FileSettings FileSettings { get; set; }

        [XmlElement(ElementName = "dbSettings")]
        public DbSettings DbSettings { get; set; }

        [XmlElement(ElementName = "mailSettings")]
        public MailSettings MailSettings { get; set; }
    }
}
