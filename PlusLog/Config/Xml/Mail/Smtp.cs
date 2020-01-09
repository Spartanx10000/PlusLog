using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PlusLog.Config.Xml.Mail
{
    [XmlRoot(ElementName = "smtp")]
    public class Smtp
    {
        [XmlAttribute(AttributeName = "host")]
        public string Host { get; set; }
        [XmlAttribute(AttributeName = "enablessl")]
        public string Enablessl { get; set; }
        [XmlAttribute(AttributeName = "port")]
        public string Port { get; set; }
    }
}
