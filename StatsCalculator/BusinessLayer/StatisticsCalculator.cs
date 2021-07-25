using StatsCalculator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsCalculator.BusinessLayer
{
    public class StatisticsCalculator : IStatisticsCalculator
    {

        /// <summary>
        /// Calculates the arithmetic mean and returns the value back
        /// </summary>
        /// <param name="values">Data set of values</param>
        /// <returns>arithmetic mean</returns>
        public double CalculateArithmeticMean(double[] values)
        {
            _ValidateInput(values);
            return CalculateSum(values) / values.Length;
        }

        /// <summary>
        /// Calculate the Sample Standard deviation for a given set of values
        /// </summary>
        /// <param name="values">Data samples/set</param>
        /// <returns>Sample standard deviation</returns>
        public double CalculateSampleStandardDeviation(double[] values)
        {
            _ValidateInput(values);
            var mean = CalculateArithmeticMean(values);
            var result = _SumForSDCalculation(values, mean) / values.Length;
            return Math.Sqrt(result);
        }

        public double FrequencyOfNumbersInBinTen(double[] values)
        {
            throw new NotImplementedException();
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
        /// validate input
        /// </summary>
        /// <param name="values"></param>
        private void _ValidateInput(double[] values)
        {
            if (values == null || values.Length == 0)
                throw new ApiException($"Values cannot be empty", 405, ProductErrorCodes.INVALIDINPUT);

        }

        /// <summary>
        /// Calculates the sum for standard deviation calculation
        /// </summary>
        /// <param name="values"></param>
        /// <param name="mean"></param>
        /// <returns></returns>
        private double _SumForSDCalculation(double[] values, double mean)
        {
            double sum = 0;

            // There are 2 pointers from starting and from the end to reduce the time complexity to o(N/2)
            for (int i = 0, j = values.Length - 1; i < j; i++, j--)
            {
                var diff = values[i] - mean;
                sum += (diff * diff);

                var diff_revOrder = values[j] - mean;
                sum += (diff * diff);

                if (values.Length % 2 != 0)
                {
                    var val = values[values.Length / 2];
                    var diff_mid = val - mean;
                    sum += (diff_mid * diff_mid);
                }
            }
            return Math.Round(sum, 10, MidpointRounding.AwayFromZero);
        }

    }
}
