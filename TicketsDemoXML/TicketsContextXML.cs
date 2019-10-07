using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using TicketsDemo.Data.Entities;

namespace TicketsDemoXML
{
    public class TicketsContextXML
    {
        public IEnumerable<Train> Trains { get; set; } 

        // тут буде колекція якась
        public TicketsContextXML()
        {
            // тут буде зчитування файла
            XmlSerializer serializer = new XmlSerializer(typeof(List<Train>));

            using (FileStream stream = File.OpenRead("Trains.xml"))
            {
                Trains = (List<Train>)serializer.Deserialize(stream);
            }
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Train>));

            using (FileStream stream = File.OpenWrite("Trains.xml"))
            {
                serializer.Serialize(stream, Trains);
            }
        }
    }
}
