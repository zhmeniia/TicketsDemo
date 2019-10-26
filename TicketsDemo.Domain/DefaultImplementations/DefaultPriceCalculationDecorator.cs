using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDemo.Data.Entities;
using TicketsDemo.Domain.DefaultImplementations.PriceCalculationStrategy;
using TicketsDemo.Domain.Interfaces;

namespace TicketsDemo.Domain.DefaultImplementations
{
    public class DefaultPriceCalculationDecorator : IPriceCalculationStrategy
    {
        IPriceCalculationStrategy _strategy;
        public DefaultPriceCalculationDecorator(DefaultPriceCalculationStrategy strategy)
        {
            _strategy = strategy;
        }
        

        public List<PriceComponent> CalculatePrice(PlaceInRun placeInRun)
        {
            var priceComponents = new List<PriceComponent>();
            priceComponents.AddRange(_strategy.CalculatePrice(placeInRun));
            var sum = 0m;
            foreach (var p in priceComponents)
            {
                sum += p.Value;
            }
            var AgencyComponent = new PriceComponent { Name = "AgencyMargin", Value = 0.1m * sum };
            priceComponents.Add(AgencyComponent);
            return priceComponents;
        }
    }
}
