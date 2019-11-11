using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;
using TicketsDemo.Domain.DefaultImplementations.PriceCalculationStrategy;
using TicketsDemo.Domain.Interfaces;

namespace TicketsDemo.Domain.DefaultImplementations
{
    public class DefaultPriceCalculationDecorator : IPriceCalculationStrategy
    {
        IPriceCalculationStrategy _strategy;
        ITrainRepository _trainRepository;
        public DefaultPriceCalculationDecorator(DefaultPriceCalculationStrategy strategy, ITrainRepository trainRepository)
        {
            _strategy = strategy;
            _trainRepository = trainRepository;
        }
        

        public List<PriceComponent> CalculatePrice(PlaceInRun placeInRun)
        {
            var train = _trainRepository.GetTrainDetails(placeInRun.Run.TrainId);
            var priceComponents = new List<PriceComponent>();
            priceComponents.AddRange(_strategy.CalculatePrice(placeInRun));
            var sum = 0m;
            foreach (var p in priceComponents)
            {
                sum += p.Value;
            }
            var AgencyComponent = new PriceComponent { Name = "AgencyMargin", Value = train.CompanyMargin.Margin * sum };
            priceComponents.Add(AgencyComponent);
            return priceComponents
;
        }
    }
}
