using System;
using Valtech.PaperRound.Core.Report.Presenters;

namespace Valtech.PaperRound
{
    /// <summary>
    /// Provides console specific implementation of <see cref="IReportPresenter"/>
    /// </summary>
    public class ConsoleReportPresenter : IReportPresenter
    {
        /// <summary>
        /// Displays report in console window
        /// </summary>
        /// <param name="report">Report to present</param>
        public void Present(string report)
        {
            Console.WriteLine(report);
        }
    }
}
