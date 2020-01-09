using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PlusLog.Config.Xml.Database
{
    [XmlRoot(ElementName = "dbSettings")]
    public class DbSettings
    {
        [XmlElement(ElementName = "connection")]
        public List<Connection> Connection { get; set; }
    }
}
