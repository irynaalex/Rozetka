using System;
using System.IO;
using System.Xml.Serialization;

namespace Task4RozetkaUA.Models
{
    public class FilterReader
    {
        public static Filters ReadFiltersFromXML()
        {
            XmlSerializer xmlFormat = new(typeof(Filters));
            try
            {
                string path = Directory.GetCurrentDirectory();
                path = path[0..^24];
                path = Path.Combine(path, @"C:\Users\Serhii\Desktop\EpamWEBtest\Task4RozetkaUA\resources\TestData.xml");
                using Stream fStream = File.OpenRead(path);
                return (Filters)xmlFormat.Deserialize(fStream);
            }
            catch (Exception)
            {
                Console.WriteLine("Can`t open filters file");
                return null;
            }
        }
    }
}
