namespace Valtech.PaperRound.Core.Specification.Readers
{
    /// <summary>
    /// Represents street specification reader
    /// </summary>
    public interface ISpecificationReader
    {
        /// <summary>
        /// Parses street specification file
        /// </summary>
        /// <param name="fileName">Street specification file name to parse</param>
        /// <returns>Parsed street specification object</returns>
        StreetSpecification ParseSpecification(string fileName);
    }
}
