using StatsCalculator.Common;
using System;

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
        /// Calculate the population based Standard deviation for a given set of values
        /// </summary>
        /// <param name="values">Data samples/set</param>
        /// <returns>Population based standard deviation</returns>
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
            var mean = CalculateArithmeticMean(values);
            var result = _CalculateSumForVariance(values, mean) / (values.Length - 1);
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

        /// <summary>
        /// validate input
        /// </summary>
        /// <param name="values"></param>
        private void _ValidateInput(double[] values)
        {
            if (values == null || values.Length == 0)
                throw new ApiException($"Values cannot be empty", 405, ProductErrorCodes.INVALIDINPUT);

        }

    }
}
