using System;
using System.IO;
using System.Linq;

namespace Valtech.PaperRound.Core.Specification.Readers
{
    /// <summary>
    /// Parses space separated street specification file
    /// </summary>
    public class SpaceSeparatedSpecificationReader : ISpecificationReader
    {
        /// <summary>
        /// Parses street specification file
        /// </summary>
        /// <param name="fileName">Street specification file name to parse</param>
        /// <returns>Parsed street specification object</returns>
        public StreetSpecification ParseSpecification(string fileName)
        {
            var lines = File.ReadAllText(fileName);
            var houseNumbers = lines.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
            return new StreetSpecification(houseNumbers);
        }
    }
}
