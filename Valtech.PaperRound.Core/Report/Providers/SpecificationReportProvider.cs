using System.Linq;
using System.Text;
using Valtech.PaperRound.Core.Specification;
using Valtech.PaperRound.Core.Report.Presenters;

namespace Valtech.PaperRound.Core.Report.Providers
{
    public class SpecificationReportProvider : IReportProvider
    {
        /// <summary>
        /// Provides a report for street specification
        /// </summary>
        private IReportPresenter presenter;

        /// <summary>
        /// Initializes a new Instance of <see cref="SpecificationReportProvider"/> class
        /// </summary>
        /// <param name="presenter">Presenter used to display a report</param>
        public SpecificationReportProvider(IReportPresenter presenter)
        {
            this.presenter = presenter;
        }

        /// <summary>
        /// Creates a report for street specification and presents it using given presenter
        /// </summary>
        /// <param name="streetSpecification">Street specification for which a report will be created</param>
        public void Create(StreetSpecification streetSpecification)
        {
            var report = BuildReport(streetSpecification);
            presenter.Present(report);
        }

        private string BuildReport(StreetSpecification streetSpecification)
        {
            var sb = new StringBuilder();
            int housesCount = streetSpecification.HouseNumbers.Count();
            int oddHousesCount = streetSpecification.HouseNumbers.Where(x => x % 2 == 1).Count();
            int evenHousesCount = housesCount - oddHousesCount;
            bool isValid = streetSpecification.Validate();

            sb.AppendLine($"Specification is valid: {isValid}");
            sb.AppendLine($"Number of houses on the street: {housesCount}");
            sb.AppendLine($"Number of houses on the north: {oddHousesCount}");
            sb.AppendLine($"Number of houses on the south: {evenHousesCount}");
            return sb.ToString();
        }
    }
}
