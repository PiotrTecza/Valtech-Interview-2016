using Valtech.PaperRound.Core.Report.Providers;
using Valtech.PaperRound.Core.Specification.Readers;

namespace Valtech.PaperRound.Core.Report
{
    /// <summary>
    /// Builds a report for a street specification layout file
    /// </summary>
    public class ReportBuilder
    {
        private ISpecificationReader reader;
        private IReportProvider[] reportProviders;

        /// <summary>
        /// Initializes a new Instance of <see cref="ReportBuilder"/> class
        /// </summary>
        /// <param name="reader">Reader able to parse street specification layout file</param>
        /// <param name="reportProviders">Providers for different report types</param>
        public ReportBuilder(ISpecificationReader reader, IReportProvider[] reportProviders)
        {
            this.reportProviders = reportProviders;
            this.reader = reader;
        }

        /// <summary>
        /// Generates report for a given street specification layout file
        /// </summary>
        /// <param name="fileName">Street specification layout file name</param>
        public void GenerateReport(string fileName)
        {
            var streetSpecification = reader.ParseSpecification(fileName);
            foreach (var reportProvider in reportProviders)
            {
                reportProvider.Create(streetSpecification);
            }
        }
    }
}
