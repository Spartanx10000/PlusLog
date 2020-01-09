using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PlusLog.Config.Xml.Mail
{
    [XmlRoot(ElementName = "sender")]
    public class Sender
    {
        [XmlAttribute(AttributeName = "email")]
        public string Email { get; set; }
        [XmlAttribute(AttributeName = "password")]
        public string Password { get; set; }
    }
}
