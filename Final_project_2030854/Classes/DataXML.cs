using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Final_project_2030854.Classes
{
     public class DataXML
    {
        private static string path = "../../DATA/";
        public static void Save(string file, List<Trainer>list)
        {

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter writer = XmlWriter.Create( path + file, settings))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Trainer>));
                serializer.Serialize(writer, list);
            }
        }
        public static List<Trainer> Load(string file)
        {
            List<Trainer> list = new List<Trainer>();

            using (StreamReader reader = new StreamReader(path + file))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Trainer>));
                list = (List<Trainer>)serializer.Deserialize(reader);
            }
            return list;
        }
    }
}
