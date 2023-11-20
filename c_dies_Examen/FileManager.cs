using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace c_dies_Examen
{
    public class FileManager
    {
        public void SaveToFile(string str,string sv,List<User>LLUU)
        {
            if (sv == "xml")
            {
                XML(str,LLUU);
            }else if (sv == "json")
            {
                JSON(str, LLUU);
            }
            else if (sv == "txt")
            {
                TXT(str, LLUU);
            }
            else
            {
                throw new Exception(" ошибка ");
            }
        }
        public void LoadFromFile(string str, string sv, List<User> LLUU)
        {
            if (sv == "xml")
            {
                LisXML(str);
            }
            else if (sv == "json")
            {
                LisJSON(str);
            }
            else if (sv == "txt")
            {
                LisTXT(str);
            }
            else
            {
                throw new Exception(" ошибка ");
            }
        }
        public void OuEstText(string str)
        {
            var f = System.IO.File.ReadAllText(str);
            Console.WriteLine(" отправлено ");
            if (f.Length != 0)
            {
                Console.WriteLine(" файл получен ");
            }
        }
        public void JSON(string str, List<User> LLUU)
        {
            string json = JsonConvert.SerializeObject(LLUU);
            System.IO.File.WriteAllText(str, json);
            OuEstText(str);
        }
        public void XML(string str, List<User> LLUU)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<User>));
            using (FileStream fstream = new FileStream(str, FileMode.OpenOrCreate))
            {
                xml.Serialize(fstream, LLUU);
            }
            OuEstText(str);

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(str);
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    XmlNode? attr = xnode.Attributes.GetNamedItem("User");
                    Console.WriteLine(attr?.Value);
                    Console.WriteLine(xnode.InnerText);
                }
            }
        }

        async public void TXT(string str2, List<User> LLUU)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(str2, FileMode.OpenOrCreate)))
            {
                foreach (var p in LLUU)
                {
                    writer.Write(p.ID);
                    writer.Write(p.UserName);
                    writer.Write(p.Email);
                    writer.Write("\n");
                }
            }

            OuEstText(str2);
        }

        public List<User> LisJSON(string str)
        {
            List<User>U2= new List<User>();
            string json = System.IO.File.ReadAllText(str);
            Console.WriteLine(JsonConvert.DeserializeObject(json));
            return U2;
        }

        public void LisXML(string str)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(str);
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    XmlNode? attr = xnode.Attributes.GetNamedItem("User");
                    Console.WriteLine(attr?.Value);
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "ID")
                        {
                            Console.WriteLine(childnode.InnerText);
                        }
                        if (childnode.Name == "UserName")
                        {
                            Console.WriteLine(childnode.InnerText);
                        }
                        if (childnode.Name == "Email")
                        {
                            Console.WriteLine(childnode.InnerText);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        async public void LisTXT(string str)
        {
            Console.WriteLine(System.IO.File.ReadAllText(str));
        }
    }
}
