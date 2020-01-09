using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PlusLog.Config.Xml.Mail
{
    [XmlRoot(ElementName = "mailSettings")]
    public class MailSettings
    {
        [XmlElement(ElementName = "template")]
        public Template Template { get; set; }
        [XmlElement(ElementName = "smtp")]
        public Smtp Smtp { get; set; }
        [XmlElement(ElementName = "sender")]
        public Sender Sender { get; set; }
        [XmlElement(ElementName = "receiver")]
        public Receiver Receiver { get; set; }
    }
}
