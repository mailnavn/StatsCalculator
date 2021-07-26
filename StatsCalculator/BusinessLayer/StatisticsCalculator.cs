using StatsCalculator.Common;
using System;
using System.Collections.Generic;

namespace StatsCalculator.BusinessLayer
{
    public class StatisticsCalculator : IStatisticsCalculator
    {

        /// <summary>
        /// Calculates the arithmetic mean for a given data set
        /// </summary>
        /// <param name="values">Data set</param>
        /// <returns>arithmetic mean</returns>
        public double CalculateArithmeticMean(double[] values)
        {
            _ValidateInput(values);
            return CalculateSum(values) / values.Length;
        }

        /// <summary>
        /// Calculates the standard deviation for a given data set
        /// </summary>
        /// <param name="values">Data set</param>
        /// <param name="sdType">Population or Sample type enum</param>
        /// <returns>standare deviation value</returns>
        public double CalculateStandardDeviation(double[] values, SDType sdType)
        {
            _ValidateInput(values);
            var mean = CalculateArithmeticMean(values);
            double result;
            if (SDType.Population.ToString() == sdType.ToString())
                result = _CalculateSumForVariance(values, mean) / values.Length;
            else
                result = _CalculateSumForVariance(values, mean) / (values.Length - 1);

            return Math.Round(Math.Sqrt(result), 10, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Calculate sample based standard deviation for the given set of values
        /// </summary>
        /// <param name="values">Data samples</param>
        /// <returns>Sample based standard deviation</returns>
        public double CalculateSampleStandardDeviation(double[] values)
        {
            _ValidateInput(values);
            var mean    = CalculateArithmeticMean(values);
            var result  = _CalculateSumForVariance(values, mean) / (values.Length - 1);
            return Math.Sqrt(result);
        }

        /// <summary>
        /// Builds an histogram of the frequency of numbers in the data set provided based on the bucket value range.
        /// </summary>
        /// <param name="values">Data set</param>
        /// <param name="binBucketRange">The range of bucket, example 10 means 0 to <10, 10 to <20 </param>
        /// <returns>Dictionary of the histogram with key = ranges and value = list of numbers in the range. For example, for 0 to less than 10(in bins of 10), key= 1 values = (1.44, 2.34, 10.00), 3 </returns>
        public Dictionary<long, Tuple<List<double>, long>> GetHistogramAndFrequency(double[] values, int binBucketRange)
        {
            _ValidateInput(values);
            if (binBucketRange < 1)
                throw new ApiException($"The range '{binBucketRange}' is not valid", 405, ProductErrorCodes.INVALIDINPUT);

            for(int i=0; i < values.Length; i++)
            {
                var divValue = values[i] / 10;
                var intModVal = (int)Math.Truncate(divValue);

                if (values[i] < binBucketRange)
                    _AddToHistogram(1, values[i]);
                else
                    _AddToHistogram(intModVal + 1, values[i]);
            }
            return _Histogram;
        }

        /// <summary>
        /// Calculates the sum of list of numbers rounding up to 10 decimal points with mid point rounding as away from zero
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>

        //TODO: Make the rounding up configurable ?
        public double CalculateSum(double[] values)
        {
            double sum = 0;
            for (int i = 0, j = values.Length - 1; i < j; i++, j--)
            {
                sum += values[i] + values[j];
            }

            if (values.Length % 2 != 0)
                sum += values[values.Length / 2];

            // Rounding to 10 decimal places, closest to the away from zero 
            // The Math.Round() in .Net 5 has considerable performance improvement 
            return Math.Round(sum, 10, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Calculates the sum for variance calculation
        /// </summary>
        /// <param name="values"></param>
        /// <param name="mean"></param>
        /// <returns></returns>
        private double _CalculateSumForVariance(double[] values, double mean)
        {
            double sum = 0;

            // There are 2 pointers from starting and from the end to reduce the time complexity to o(N/2)
            for (int i = 0, j = values.Length - 1; i < j; i++, j--)
            {
                var diff = values[i] - mean;
                sum += diff * diff;

                var diff_revOrder = values[j] - mean;
                sum += diff_revOrder * diff_revOrder;
            }

            if (values.Length % 2 != 0)
            {
                var val = values[values.Length / 2];
                var diff_mid = val - mean;
                sum += diff_mid * diff_mid;
            }

            return Math.Round(sum, 10, MidpointRounding.AwayFromZero);
        }

        #region private properties
        /// <summary>
        /// validate input
        /// </summary>
        /// <param name="values"></param>
        private void _ValidateInput(double[] values)
        {
            if (values == null || values.Length == 0)
                throw new ApiException($"Values cannot be empty", 405, ProductErrorCodes.INVALIDINPUT);
        }


        private void _AddToHistogram(long key, double value)
        {
            if (!_Histogram.ContainsKey(key))
                _Histogram.Add(key, Tuple.Create<List<double>, long>(new List<double> { value }, 1));
            else
            {
                var histogramValues = _Histogram[key];
                var listOfValues = histogramValues.Item1;
                listOfValues.Add(value);
                _Histogram[key] = Tuple.Create<List<double>, long>(listOfValues, listOfValues.Count);
            }
        }

        /// <summary>
        /// Histogram of data sets
        /// </summary>
        private Dictionary<long, Tuple<List<double>, long>> _Histogram = new();
        #endregion
    }
}
