using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        /// Test number when length of numbers are even
        /// </summary>
        [TestMethod]
        public void TestParsing()
        {
            DataReader reader = new DataReader();
            var result =  reader.ReadCSVData(@"C:\\Users\\mailn\\OneDrive\\Desktop\\SampleData.csv");

        }
    }
}
