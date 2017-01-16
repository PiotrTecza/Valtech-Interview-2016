namespace Valtech.PaperRound.Core.Delivery
{
    /// <summary>
    /// Describes delivery result
    /// </summary>
    public class DeliveryResult
    {
        /// <summary>
        /// Strategy name used to calculate the result
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of house numbers in order they were visited
        /// </summary>
        public string HouseVisitOrder { get; set; }

        /// <summary>
        /// Number of times the road has to be crossed to make a delivery
        /// </summary>
        public int CrossRoadNumber { get; set; }
    }
}
