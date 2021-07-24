using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsCalculator.BusinessLayer
{
    public class StatisticsCalculator : IStatisticsCalculator
    {
        public double CalculateArithmeticMean(double[] values)
        {

            throw new NotImplementedException();
        }

        public double CalculateStandardDeviation(double[] values)
        {
            throw new NotImplementedException();
        }

        public double FrequencyOfNumbersInBinTen(double[] values)
        {
            throw new NotImplementedException();
        }

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

    }
}
