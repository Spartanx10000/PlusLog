using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PlusLog.Config.Xml.Mail
{
    [XmlRoot(ElementName = "receiver")]
    public class Receiver
    {
        [XmlAttribute(AttributeName = "email")]
        public string Email { get; set; }
    }
}
