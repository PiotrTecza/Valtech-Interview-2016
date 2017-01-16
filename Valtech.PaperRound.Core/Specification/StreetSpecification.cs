using System;
using System.Collections.Generic;
using System.Linq;

namespace Valtech.PaperRound.Core.Specification
{
    /// <summary>
    /// Representation of street specification
    /// </summary>
    public class StreetSpecification
    {
        private IEnumerable<int> houseNumbers;

        /// <summary>
        /// Initializes a new Instance of <see cref="StreetSpecification"/> class
        /// </summary>
        /// <param name="houseNumbers">House numbers present on a street in west-east order</param>
        public StreetSpecification(IEnumerable<int> houseNumbers)
        {
            if(houseNumbers == null)
            {
                throw new ArgumentNullException();
            }

            this.houseNumbers = houseNumbers;
        }

        /// <summary>
        /// Copy of house numbers
        /// </summary>
        public IEnumerable<int> HouseNumbers => houseNumbers.ToList();


        /// <summary>
        /// Validates specification according to the common house numbering rules
        /// </summary>
        /// <returns>Determines whether a street specification is valid</returns>
        public bool Validate()
        {
            int nextOddNumberExpected = 1;
            int nextEvenNumberExpected = 2;

            foreach (int number in houseNumbers)
            {
                if (number % 2 == 1 && number == nextOddNumberExpected)
                {
                    nextOddNumberExpected += 2;
                    continue;
                }
                if (number % 2 == 0 && number == nextEvenNumberExpected)
                {
                    nextEvenNumberExpected += 2;
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}
