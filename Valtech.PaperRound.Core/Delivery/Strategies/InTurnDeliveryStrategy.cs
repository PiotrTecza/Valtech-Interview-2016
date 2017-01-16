using System;
using System.Collections.Generic;

namespace Valtech.PaperRound.Core.Delivery.Strategies
{
    /// <summary>
    /// Implements in turn from west to east delivery approach, regardless of which side of the road houses are on
    /// </summary>
    public class InTurnDeliveryStrategy : IDeliveryStrategy
    {
        /// <summary>
        /// Strategy name
        /// </summary>
        public string DeliveryStrategyName => "In Turn Delivery";

        /// <summary>
        /// Calculates <see cref="DeliveryResult"/> for given street layout
        /// </summary>
        /// <param name="houseNumbers">Descriebes street layout</param>
        /// <returns>Result calcuated by the strategu for given street layout</returns>
        public DeliveryResult Calculate(IEnumerable<int> houseNumbers)
        {
            var previousNumber = 0;
            var crossRoadNumber = 0;

            if(houseNumbers == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var number in houseNumbers)
            {
                if (previousNumber == 0)
                {
                    previousNumber = number;
                    continue;
                }

                if (previousNumber % 2 != number % 2)
                {
                    crossRoadNumber++;
                }

                previousNumber = number;
            }

            return new DeliveryResult
            {
                Name = DeliveryStrategyName,
                HouseVisitOrder = String.Join(",", houseNumbers),
                CrossRoadNumber = crossRoadNumber
            };
        }
    }
}
