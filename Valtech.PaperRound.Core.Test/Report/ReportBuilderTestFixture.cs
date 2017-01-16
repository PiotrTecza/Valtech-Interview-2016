using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Valtech.PaperRound.Core.Report;
using Valtech.PaperRound.Core.Report.Providers;
using Valtech.PaperRound.Core.Specification;
using Valtech.PaperRound.Core.Specification.Readers;

namespace Valtech.PaperRound.Core.Test.Report
{
    [TestFixture]
    public class ReportBuilderTestFixture
    {
        private IFixture fixture;
        private Mock<IReportProvider> reportProviderFirstMock;
        private Mock<IReportProvider> reportProviderSecondMock;
        private Mock<ISpecificationReader> specificationReaderMock;

        private StreetSpecification streetSpecification;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());

            reportProviderFirstMock = fixture.Create<Mock<IReportProvider>>();
            reportProviderSecondMock = fixture.Create<Mock<IReportProvider>>();

            fixture.Inject(new IReportProvider[] { reportProviderFirstMock.Object, reportProviderSecondMock.Object });
            specificationReaderMock = fixture.Freeze<Mock<ISpecificationReader>>();
        }

        [TearDown]
        public void TearDown()
        {
            specificationReaderMock.Reset();
            reportProviderFirstMock.Reset();
            reportProviderSecondMock.Reset();
        }

        [SetUp]
        public void SetUp()
        {
            streetSpecification = fixture.Create<StreetSpecification>();

            specificationReaderMock.Setup(x => x.ParseSpecification(It.IsAny<string>())).Returns(streetSpecification);
        }

        [Test]
        public void GenerateReport_WhenInvoked_ShouldSendStreetSpecificationToReprortProviders()
        {
            //Arrange
            var subject = fixture.Create<ReportBuilder>();
            var fileName = fixture.Create<string>();
            //Act
            subject.GenerateReport(fileName);

            //Assert
            reportProviderFirstMock.Verify(x => x.Create(streetSpecification), Times.Once);
            reportProviderSecondMock.Verify(x => x.Create(streetSpecification), Times.Once);
        }
    }
}
