namespace Valtech.PaperRound.Core.Report.Presenters
{
    /// <summary>
    /// Abstraction allowing to provide differet way of presenting report
    /// </summary>
    public interface IReportPresenter
    {
        /// <summary>
        /// Presenst the report
        /// </summary>
        /// <param name="report">Report to be presented</param>
        void Present(string report);
    }
}
