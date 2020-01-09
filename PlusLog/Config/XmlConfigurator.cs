using PlusLog.Config.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace PlusLog.Config
{
    internal class XmlConfigurator
    {
        //Default path
        private static string _BasePath = System.AppDomain.CurrentDomain.BaseDirectory;
        //Configuration file
        private static string _ConfigFile = "Pluslog.config";

        public static Configuration GetConfiguration()
        {
            Configuration config;
            try
            {
                string filePath = _BasePath + _ConfigFile;
                if (File.Exists(filePath))
                {
                    XmlSerializer s = new XmlSerializer(typeof(Configuration));
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        config = (Configuration)s.Deserialize(sr);
                    }
                }
                else
                {
                    throw new Exception("The configuration file (Pluslog.config) cannot be found in the path: " + filePath);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return config;
        }

    }
}
