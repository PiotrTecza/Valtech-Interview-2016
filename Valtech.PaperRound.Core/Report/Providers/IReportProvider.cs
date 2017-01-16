using Valtech.PaperRound.Core.Specification;

namespace Valtech.PaperRound.Core.Report.Providers
{
    /// <summary>
    /// Abstraction allowing to provide report parts
    /// </summary>
    public interface IReportProvider
    {
        /// <summary>
        /// Creates a report for <see cref="StreetSpecification"/>
        /// </summary>
        /// <param name="streetSpecification">Street specification for which a report will be created</param>
        void Create(StreetSpecification streetSpecification);
    }
}
