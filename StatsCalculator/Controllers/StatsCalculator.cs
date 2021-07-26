using Microsoft.AspNetCore.Mvc;
using StatsCalculator.BusinessLayer;
using StatsCalculator.DataLayer;
using System;
using System.Collections.Generic;

namespace StatsCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsCalculator : ControllerBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataReader">DI object, DataReader</param>
        /// <param name="statsCalculator">DI object, StatisticsCalculator</param>
        public StatsCalculator(IDataReader dataReader, IStatisticsCalculator statsCalculator)
        {
            _dataReader = dataReader;
            _statisticsCalculator = statsCalculator;
        }

        /// <summary>
        /// Calculates the mean of a given sample set file
        /// </summary>
        /// <param name="filePath">The full file path of the csv file on server</param>
        /// <returns>IActionResult, the mean value for given data set</returns>
        [HttpGet("CalculateMean")]
        public IActionResult GetMean(string filePath)
        {
            try
            {
                var data = _dataReader.ReadCSVData(filePath);
                var mean = _statisticsCalculator.CalculateArithmeticMean(data.Result.ToArray());
                return Ok(mean);
            }
            catch (AggregateException ex)
            {
                return new ObjectResult(ex.InnerException.Message) { StatusCode = 500 };
            }

        }


        /// <summary>
        /// Calculates the standard deviation based on the data provided in a csv file and returns back the result
        /// </summary>
        /// <param name="filePath">The absolute path of the csv file</param>
        /// <param name="type">population or sample</param>
        /// <returns>IActionResult, the standard deviation value</returns>
        [HttpGet("CalculateStandardDeviation")]
        public IActionResult GetStandardDeviation(string filePath, string type)
        {
            try
            {
                var data = _dataReader.ReadCSVData(filePath);

                double standardDeviation;
                if (type.Trim().ToLower() == "population")
                {
                    standardDeviation = _statisticsCalculator.CalculateStandardDeviation(data.Result.ToArray(), SDType.Population);
                }
                else if (type.Trim().ToLower() == "sample")
                {
                    standardDeviation = _statisticsCalculator.CalculateStandardDeviation(data.Result.ToArray(), SDType.Sample);
                }
                else
                {
                    return new ObjectResult($"Unknown standard deviation type {type}") { StatusCode = 405 };
                }

                return Ok(new DataApiResponse { Value = standardDeviation });

            }
            catch (AggregateException ex)
            {
                return new ObjectResult(ex.InnerException.Message) { StatusCode = 500 };
            }

        }



        /// <summary>
        /// Creates a histogram and calculates the frequecy of 
        /// </summary>
        /// <param name="filePath">The absolute path of the csv file</param>
        /// <param name="type">10 for bin bucket of 10, from 0 to less than 10, 10 to less than 20</param>
        /// <returns></returns>
        [HttpGet("GetHistogramAndFrequency")]
        public IActionResult GetHistogramAndFrequency(string filePath, int bucketValueRange)
        {
            try
            {
                var data = _dataReader.ReadCSVData(filePath);
                var result = _statisticsCalculator.GetHistogramAndFrequency(data.Result.ToArray(), bucketValueRange);

                var response = new List<DataApiResponseHistogram>();
                foreach (KeyValuePair<long, Tuple<List<double>, double>> keyValue in result)
                {
                    var range2 = keyValue.Key * bucketValueRange - 1;
                    var range1 = keyValue.Key * bucketValueRange - bucketValueRange;

                    response.Add(new DataApiResponseHistogram { Bucket = $"Bucket{range1}-{range2}", Frequency = keyValue.Value.Item2, Values = keyValue.Value.Item1 });
                }
                return Ok(response);
            }
            catch (AggregateException ex)
            {
                return new ObjectResult(ex.InnerException.Message) { StatusCode = 500 };
            }

        }


        #region private properties
        private readonly IDataReader _dataReader;
        private readonly IStatisticsCalculator _statisticsCalculator;
        #endregion
    }

}
