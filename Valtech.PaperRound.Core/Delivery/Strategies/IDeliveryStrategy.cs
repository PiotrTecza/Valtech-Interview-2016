using System.Collections.Generic;

namespace Valtech.PaperRound.Core.Delivery.Strategies
{
    /// <summary>
    /// Represents strategy used to deliver newspapers
    /// </summary>
    public interface IDeliveryStrategy
    {
        /// <summary>
        /// Strategy name
        /// </summary>
        string DeliveryStrategyName { get; }

        /// <summary>
        /// Calculates <see cref="DeliveryResult"/> for given street layout
        /// </summary>
        /// <param name="houseNumbers">Descriebes street layout</param>
        /// <returns>Result calcuated by the strategu for given street layout</returns>
        DeliveryResult Calculate(IEnumerable<int> houseNumbers);
    }
}
