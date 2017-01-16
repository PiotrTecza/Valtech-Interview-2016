using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.IO;
using System.Reflection;
using Valtech.PaperRound.Core.Specification.Readers;

namespace Valtech.PaperRound.Core.Teest.Specification.Readers
{
    [TestFixture]
    public class SpaceSeparatedSpecificationReaderTestFixture
    {
        private IFixture fixture;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            fixture = new Fixture();
        }

        [Test]
        public void ParseSpecification_WhenInvokedAndFileDoesNotExist_ShouldThrowException()
        {
            //Arrange
            var subject = fixture.Create<SpaceSeparatedSpecificationReader>();
            var fileName = fixture.Create<string>();
            
            //Act
            TestDelegate action = () => subject.ParseSpecification(fileName);

            //Assert
            Assert.That(action, Throws.Exception.InstanceOf<FileNotFoundException>());
        }

        [Test]
        public void ParseSpecification_WhenInvokedAndFileFormatIsWrong_ShouldThrowException()
        {
            //Arrange
            var subject = fixture.Create<SpaceSeparatedSpecificationReader>();
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Locati‌​on);
            var fileName = $@"{executingDirectory}\TestFiles\streetWrongFormat.txt";

            //Act
            TestDelegate action = () => subject.ParseSpecification(fileName);

            //Assert
            Assert.That(action, Throws.Exception.InstanceOf<FormatException>());
        }

        [Test]
        public void ParseSpecification_WhenInvokedAndFileFormatIsCorrect_ShouldReturnStreetSpecification()
        {
            //Arrange
            var subject = fixture.Create<SpaceSeparatedSpecificationReader>();
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Locati‌​on);
            var fileName = $@"{executingDirectory}\TestFiles\street.txt";

            //Act
            var streetSpecification = subject.ParseSpecification(fileName);

            //Assert
            Assert.That(streetSpecification, Is.Not.Null);
        }
    }
}
