using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Valtech.PaperRound.Core.Test
{
    public class TestCaseSourceFactory
    {
        public static IEnumerable InTurnDeliveryHouseNumbers
        {
            get
            {
                yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5 }, 4);
                yield return new TestCaseData(new List<int> { 1, 3, 5, 7 }, 0);
                yield return new TestCaseData(new List<int> { 2, 4, 6 }, 0);
                yield return new TestCaseData(new List<int> { 1, 3, 5, 2, 4 }, 1);
            }
        }

        public static IEnumerable NorthFirstDeliveryHouseNumbers
        {
            get
            {
                yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5 }, new List<int> { 1, 3, 5, 4, 2}, 1);
                yield return new TestCaseData(new List<int> { 1, 3, 5, }, new List<int> { 1, 3, 5}, 0);
                yield return new TestCaseData(new List<int> { 2, 4, 6 }, new List<int> { 6, 4, 2}, 1);
            }
        }

        public static IEnumerable InvalidStreetSpecification
        {
            get
            {
                yield return new TestCaseData(new List<int> { 5, 4, 3, 2, 1 });
                yield return new TestCaseData(new List<int> { 1, 5, 2, 3, 4 });
                yield return new TestCaseData(new List<int> { 1, 4, 2, 3, 5 });
            }
        }

        public static IEnumerable ValidStreetSpecification
        {
            get
            {
                yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5 });
                yield return new TestCaseData(new List<int> { 1, 3, 5, 2, 4 });
                yield return new TestCaseData(new List<int> { 2, 4, 1, 3, 5 });
            }
        }
    }
}
