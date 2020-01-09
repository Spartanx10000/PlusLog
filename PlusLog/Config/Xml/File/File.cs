using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PlusLog.Config.Xml.File
{
    [XmlRoot(ElementName = "File")]
    public class File
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "path")]
        public string Path { get; set; }
    }
}
