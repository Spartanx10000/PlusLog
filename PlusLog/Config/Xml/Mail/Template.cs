using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PlusLog.Config.Xml.Mail
{
    [XmlRoot(ElementName = "template")]
    public class Template
    {
        [XmlAttribute(AttributeName = "path")]
        public string Path { get; set; }
    }
}
