using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsCalculator.BusinessLayer;
using System.Collections.Generic;
using System.Linq;

namespace StatsCalculatorUnitTests
{
    [TestClass]
    public class BusinessUnitTests
    {

        [TestInitialize]
        public void Initialize()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void TestAddSumMethodEvenNumberLength()
        {
            var numbers = new List<double> { 23.234, 234.348657, 234.465, 0, 2342.234, 234242.2342 };

            StatisticsCalculator cal = new StatisticsCalculator();
            var result = cal.CalculateSum(numbers.ToArray());

            Assert.AreEqual(numbers.Sum(), result);

        }
    }
}
