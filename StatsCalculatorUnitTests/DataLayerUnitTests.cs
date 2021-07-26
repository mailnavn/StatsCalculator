using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsCalculator.DataLayer;
using System;

namespace StatsCalculatorUnitTests
{
    [TestClass]
    public class DataLayerUnitTests
    {

        /// <summary>
        /// Test if the file not found exception is thrown and caught
        /// </summary>
        [TestMethod]
        public void TestFileDoesNotExist()
        {
            DataReader reader = new DataReader();
            var result = reader.ReadCSVData("blah");
            Assert.ThrowsException<AggregateException>(() => { result.Wait(); }, $"The file blah does not exist on disk");
        }
    }
}
