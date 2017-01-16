using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using Valtech.PaperRound.Core.Delivery.Strategies;

namespace Valtech.PaperRound.Core.Test.Delivery.Strategies
{
    [TestFixture]
    class InTurnDeliveryStrategyTestFixture
    {
        private IFixture fixture;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());
        }

        [Test]
        public void Calculate_WhenHouseNumberListIsNull_ShouldThrowException()
        {
            //Arrange
            var subject = fixture.Create<InTurnDeliveryStrategy>();

            //Act
            TestDelegate action = () => subject.Calculate(null);

            //Assert
            Assert.That(action, Throws.Exception.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Calculate_WhenHouseNumberListIsEmpty_ShouldReturnValidReport()
        {
            //Arrange
            var subject = fixture.Create<InTurnDeliveryStrategy>();
            var houseNumbers = Enumerable.Empty<int>();

            //Act
            var result = subject.Calculate(houseNumbers);

            //Assert
            Assert.That(result.CrossRoadNumber, Is.EqualTo(0));
            Assert.That(result.HouseVisitOrder, Is.Empty);
            Assert.That(result.Name, Is.EqualTo(subject.DeliveryStrategyName));
        }

        [TestCaseSource(typeof(TestCaseSourceFactory), "InTurnDeliveryHouseNumbers")]
        public void Calculate_WhenHouseNumberListIsNotEMpty_ShouldReturnValidReport(IEnumerable<int> houseNumbers, int crosRoadNumber)
        {
            //Arrange
            var subject = fixture.Create<InTurnDeliveryStrategy>();
            var expectedHouseVisitOrder = String.Join(",", houseNumbers);

            //Act
            var result = subject.Calculate(houseNumbers);

            //Assert
            Assert.That(result.CrossRoadNumber, Is.EqualTo(crosRoadNumber));
            Assert.That(result.HouseVisitOrder, Is.EqualTo(expectedHouseVisitOrder));
            Assert.That(result.Name, Is.EqualTo(subject.DeliveryStrategyName));
        }
    }
}
