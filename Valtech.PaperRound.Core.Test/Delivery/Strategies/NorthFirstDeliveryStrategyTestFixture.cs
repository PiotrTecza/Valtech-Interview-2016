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
    class NorthFirstDeliveryStrategyTestFixture
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
            var subject = fixture.Create<NorthFirstDeliveryStrategy>();

            //Act
            TestDelegate action = () => subject.Calculate(null);

            //Assert
            Assert.That(action, Throws.Exception.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Calculate_WhenHouseNumberListIsEmpty_ShouldReturnValidReport()
        {
            //Arrange
            var subject = fixture.Create<NorthFirstDeliveryStrategy>();
            var houseNumbers = Enumerable.Empty<int>();

            //Act
            var result = subject.Calculate(houseNumbers);

            //Assert
            Assert.That(result.CrossRoadNumber, Is.EqualTo(0));
            Assert.That(result.HouseVisitOrder, Is.Empty);
            Assert.That(result.Name, Is.EqualTo(subject.DeliveryStrategyName));
        }

        [TestCaseSource(typeof(TestCaseSourceFactory), "NorthFirstDeliveryHouseNumbers")]
        public void Calculate_WhenHouseNumberListIsNotEMpty_ShouldReturnValidReport(IEnumerable<int> houseNumbers, IEnumerable<int> orderedHouseNumbers, int crosRoadNumber)
        {
            //Arrange
            var subject = fixture.Create<NorthFirstDeliveryStrategy>();
            var expectedHouseVisitOrder = String.Join(",", orderedHouseNumbers);

            //Act
            var result = subject.Calculate(houseNumbers);

            //Assert
            Assert.That(result.CrossRoadNumber, Is.EqualTo(crosRoadNumber));
            Assert.That(result.HouseVisitOrder, Is.EqualTo(expectedHouseVisitOrder));
            Assert.That(result.Name, Is.EqualTo(subject.DeliveryStrategyName));
        }
    }
}
