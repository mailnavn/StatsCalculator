using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsCalculator.Common;
using StatsCalculator.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
