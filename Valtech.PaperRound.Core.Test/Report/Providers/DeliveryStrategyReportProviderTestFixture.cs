using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System.Collections.Generic;
using Valtech.PaperRound.Core.Delivery;
using Valtech.PaperRound.Core.Delivery.Strategies;
using Valtech.PaperRound.Core.Report.Presenters;
using Valtech.PaperRound.Core.Report.Providers;
using Valtech.PaperRound.Core.Specification;

namespace Valtech.PaperRound.Core.Test.Report.Providers
{
    [TestFixture]
    public class DeliveryStrategyReportProviderTestFixture
    {
        private IFixture fixture;
        private Mock<IDeliveryStrategy> deliveryStrategyFirstMock;
        private Mock<IDeliveryStrategy> deliveryStrategySecondMock;
        private Mock<IReportPresenter> reportPresenterMock;

        private DeliveryResult deliveryResult1;
        private DeliveryResult deliveryResult2;
        private StreetSpecification streetSpecification;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());

            deliveryStrategyFirstMock = fixture.Create<Mock<IDeliveryStrategy>>();
            deliveryStrategySecondMock = fixture.Create<Mock<IDeliveryStrategy>>();

            fixture.Inject(new IDeliveryStrategy[] { deliveryStrategyFirstMock.Object, deliveryStrategySecondMock.Object });
            reportPresenterMock = fixture.Freeze<Mock<IReportPresenter>>();
        }

        [TearDown]
        public void TearDown()
        {
            deliveryStrategyFirstMock.Reset();
            deliveryStrategySecondMock.Reset();
            reportPresenterMock.Reset();
        }

        [SetUp]
        public void SetUp()
        {
            deliveryResult1 = fixture.Create<DeliveryResult>();
            deliveryResult2 = fixture.Create<DeliveryResult>();
            streetSpecification = fixture.Create<StreetSpecification>();

            deliveryStrategyFirstMock.Setup(x => x.Calculate(It.IsAny<IEnumerable<int>>())).Returns(deliveryResult1);
            deliveryStrategySecondMock.Setup(x => x.Calculate(It.IsAny<IEnumerable<int>>())).Returns(deliveryResult2);
        }

        [Test]
        public void Create_WhenInvoked_ShouldGetReportsFromEachDeliveryStrategy()
        {
            //Arrange
            var subject = fixture.Create<DeliveryStrategyReportProvider>();

            //Act
            subject.Create(streetSpecification);

            //Assert
            deliveryStrategyFirstMock.Verify(x => x.Calculate(streetSpecification.HouseNumbers), Times.Once);
            deliveryStrategySecondMock.Verify(x => x.Calculate(streetSpecification.HouseNumbers), Times.Once);
        }

        [Test]
        public void Create_WhenInvoked_ShouldSendReportToReportPresenterForEachStrategy()
        {
            //Arrange
            var subject = fixture.Create<DeliveryStrategyReportProvider>();
            var numberOfStrategies = 2;

            //Act
            subject.Create(streetSpecification);

            //Assert
            reportPresenterMock.Verify(x => x.Present(It.IsAny<string>()), Times.Exactly(numberOfStrategies));
        }
    }
}
