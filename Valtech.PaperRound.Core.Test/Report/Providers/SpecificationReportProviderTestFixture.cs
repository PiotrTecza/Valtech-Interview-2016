using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Valtech.PaperRound.Core.Report.Presenters;
using Valtech.PaperRound.Core.Report.Providers;
using Valtech.PaperRound.Core.Specification;

namespace Valtech.PaperRound.Core.Test.Report.Providers
{
    [TestFixture]
    public class SpecificationReportProviderTestFixture
    {
        private IFixture fixture;
        private Mock<IReportPresenter> reportPresenterMock;
        private StreetSpecification streetSpecification;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());

            reportPresenterMock = fixture.Freeze<Mock<IReportPresenter>>();
        }

        [TearDown]
        public void TearDown()
        {
            reportPresenterMock.Reset();
        }

        [SetUp]
        public void SetUp()
        {
            streetSpecification = fixture.Create<StreetSpecification>();
        }

        [Test]
        public void Create_WhenInvoked_ShouldSendReportToReportPresenter()
        {
            //Arrange
            var subject = fixture.Create<SpecificationReportProvider>();

            //Act
            subject.Create(streetSpecification);

            //Assert
            reportPresenterMock.Verify(x => x.Present(It.IsAny<string>()), Times.Once);
        }
    }
}
