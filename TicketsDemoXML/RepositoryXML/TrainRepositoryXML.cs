using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;

namespace TicketsDemoXML.RepositoryXML 
{
    public class TrainRepositoryXML : ITrainRepository
    {

        public void CreateTrain(Train train)
        {
            TicketsContextXML ctx = new TicketsContextXML();
            ctx.Trains.ToList().Add(train);
            ctx.Save();
        }

        public void DeleteTrain(Train train)
            
        {
            TicketsContextXML ctx = new TicketsContextXML();
            ctx.Trains.Remove(train);
            ctx.Save();
           
        }

        public List<Train> GetAllTrains()
        {
            TicketsContextXML ctx = new TicketsContextXML();
            return ctx.Trains;
            
        }

        public Train GetTrainDetails(int trainId)
        {
            TicketsContextXML ctx = new TicketsContextXML();
            var train = ctx.Trains.FirstOrDefault(t => t.Id == trainId);
            foreach (var c in train.Carriages)
            {
                foreach (var p in c.Places)
                {
                    p.Carriage = c;
                }
                c.Train = train;
            }
            return train;
        }

        public void UpdateTrain(Train train)
        {
            TicketsContextXML ctx = new TicketsContextXML();
            var i = ctx.Trains.FindIndex(t => train.Id == t.Id);
            ctx.Trains[i] = train;
        }            
    }
}
