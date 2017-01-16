using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using Valtech.PaperRound.Core.Specification;
using Valtech.PaperRound.Core.Test;

namespace Valtech.PaperRound.Core.Teest.Specification
{
    [TestFixture]
    public class StreetSpecificationTestFixture
    {
        private IFixture fixture;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            fixture = new Fixture();
        }

        [Test]
        public void StreetSpecification_WhenArgumentIsNull_ShouldThrowException()
        {
            //Arrange

            //Act
            TestDelegate action = () => new StreetSpecification(null);

            //Assert
            Assert.That(action, Throws.Exception.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void HouseNumbers_WhenInvoked_ShouldReturnHouseNumberList()
        {
            //Arrange
            var houseNumbers = fixture.CreateMany<int>();
            var subject = new StreetSpecification(houseNumbers);

            //Act
            var specificationHouseNumbers = subject.HouseNumbers;

            //Assert
            CollectionAssert.AreEqual(houseNumbers, specificationHouseNumbers);
        }

        [TestCaseSource(typeof(TestCaseSourceFactory), "InvalidStreetSpecification")]
        public void Validate_WhenInvokedAndInputIsNotValid_ShouldReturnFalse(IEnumerable<int> houseNumbers)
        {
            //Arrange
            var subject = new StreetSpecification(houseNumbers);

            //Act
            var isValid = subject.Validate();

            //Assert
            Assert.That(isValid, Is.False);
        }

        [TestCaseSource(typeof(TestCaseSourceFactory), "ValidStreetSpecification")]
        public void Validate_WhenInvokedAndInputIsValid_ShouldReturnTrue(IEnumerable<int> houseNumbers)
        {
            //Arrange
            var subject = new StreetSpecification(houseNumbers);

            //Act
            var isValid = subject.Validate();

            //Assert
            Assert.That(isValid, Is.True);
        }
    }
}
