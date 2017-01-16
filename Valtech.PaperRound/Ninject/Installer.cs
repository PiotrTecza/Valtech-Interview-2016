using Ninject.Modules;
using Valtech.PaperRound.Core.Delivery.Strategies;
using Valtech.PaperRound.Core.Report;
using Valtech.PaperRound.Core.Report.Presenters;
using Valtech.PaperRound.Core.Report.Providers;
using Valtech.PaperRound.Core.Specification.Readers;

namespace Valtech.PaperRound.Ninject
{
    class Installer : NinjectModule
    {
        public override void Load()
        {
            Bind<IDeliveryStrategy>().To<NorthFirstDeliveryStrategy>();
            Bind<IDeliveryStrategy>().To<InTurnDeliveryStrategy>();
            Bind<IReportPresenter>().To<ConsoleReportPresenter>();
            Bind<ISpecificationReader>().To<SpaceSeparatedSpecificationReader>();
            Bind<IReportProvider>().To<SpecificationReportProvider>();
            Bind<IReportProvider>().To<DeliveryStrategyReportProvider>();
            Bind<ReportBuilder>().ToSelf();
        }
    }
}
