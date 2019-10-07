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
        TicketsContextXML ctx = new TicketsContextXML();

        public void CreateTrain(Train train)
        {
            ctx.Trains.ToList().Add(train);
            ctx.Save();
        }

        public void DeleteTrain(Train train)
        {
            throw new NotImplementedException();
        }

        public List<Train> GetAllTrains()
        {
            throw new NotImplementedException();
        }

        public Train GetTrainDetails(int trainId)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrain(Train train)
        {
            throw new NotImplementedException();
        }
    }
}
