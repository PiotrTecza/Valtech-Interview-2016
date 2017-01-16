using System.Text;
using Valtech.PaperRound.Core.Specification;
using Valtech.PaperRound.Core.Delivery.Strategies;
using Valtech.PaperRound.Core.Report.Presenters;
using Valtech.PaperRound.Core.Delivery;

namespace Valtech.PaperRound.Core.Report.Providers
{
    /// <summary>
    /// Provides a report for all delivery strategies
    /// </summary>
    public class DeliveryStrategyReportProvider : IReportProvider
    {
        private IReportPresenter presenter;
        private IDeliveryStrategy[] deliveryStrategies;

        /// <summary>
        /// Initializes a new Instance of <see cref="DeliveryStrategyReportProvider"/> class
        /// </summary>
        /// <param name="presenter">Presenter used to display a report</param>
        /// <param name="deliveryStrategies">Delivery strategies for which a report will be created</param>
        public DeliveryStrategyReportProvider(IReportPresenter presenter, IDeliveryStrategy[] deliveryStrategies)
        {
            this.presenter = presenter;
            this.deliveryStrategies = deliveryStrategies;
        }

        /// <summary>
        /// Creates a report for delivery strategies and presents it using given presenter
        /// </summary>
        /// <param name="streetSpecification">Street specification based on which a report will be created</param>
        public void Create(StreetSpecification streetSpecification)
        {
            foreach (var deliveryApproach in deliveryStrategies)
            {
                var deliveryResult = deliveryApproach.Calculate(streetSpecification.HouseNumbers);
                var report = BuildReport(deliveryResult);
                presenter.Present(report);
            }
        }

        private string BuildReport(DeliveryResult result)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"Approach type: {result.Name}");
            sb.AppendLine($"Visit order: {result.HouseVisitOrder}");
            sb.AppendLine($"Cross road number: {result.CrossRoadNumber}");
            return sb.ToString();
        }
    }
}
