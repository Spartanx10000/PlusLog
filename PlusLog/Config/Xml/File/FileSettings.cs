using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PlusLog.Config.Xml.File
{
    [XmlRoot(ElementName = "fileSettings")]
    public class FileSettings
    {
        [XmlElement(ElementName = "file")]
        public File File { get; set; }
    }
}
