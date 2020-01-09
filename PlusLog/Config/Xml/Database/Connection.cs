using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PlusLog.Config.Xml.Database
{
    [XmlRoot(ElementName = "connection")]
    public class Connection
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "server")]
        public string Server { get; set; }
        [XmlAttribute(AttributeName = "database")]
        public string Database { get; set; }
        [XmlAttribute(AttributeName = "user")]
        public string User { get; set; }
        [XmlAttribute(AttributeName = "password")]
        public string Password { get; set; }
        [XmlAttribute(AttributeName = "path")]
        public string Path { get; set; }
    }
}
