﻿using System;
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
        public List<Train> Trains { get; set; } 
        

        
        public TicketsContextXML()
        {
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<Train>));

            using (FileStream stream = File.OpenRead("C:/Users/Admin/Desktop/TicketsDemo-master/TicketsDemo-master/TicketsDemoXML/bin/Debug/Trains.xml"))
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
