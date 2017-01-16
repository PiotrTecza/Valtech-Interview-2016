using System;
using System.Collections.Generic;
using System.Linq;

namespace Valtech.PaperRound.Core.Delivery.Strategies
{
    /// <summary>
    /// Implements north first delivery approach
    /// </summary>
    public class NorthFirstDeliveryStrategy : IDeliveryStrategy
    {
        /// <summary>
        /// Strategy name
        /// </summary>
        public string DeliveryStrategyName => "North First Delivery";

        /// <summary>
        /// Calculates <see cref="DeliveryResult"/> for given street layout
        /// </summary>
        /// <param name="houseNumbers">Descriebes street layout</param>
        /// <returns>Result calcuated by the strategu for given street layout</returns>
        public DeliveryResult Calculate(IEnumerable<int> houseNumbers)
        {
            if (houseNumbers == null)
            {
                throw new ArgumentNullException();
            }

            var oddNumbers = houseNumbers.Where(x => x % 2 == 1);
            var evenNumbersReversed = houseNumbers.Where(x => x % 2 == 0).Reverse();
            var crossRoadNumber = evenNumbersReversed.Any() ? 1 : 0;
            var listToVisit = oddNumbers.Concat(evenNumbersReversed);

            return new DeliveryResult
            {
                Name = DeliveryStrategyName,
                HouseVisitOrder = String.Join(",", listToVisit),
                CrossRoadNumber = crossRoadNumber
            };
        }
    }
}
