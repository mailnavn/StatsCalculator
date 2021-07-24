using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsCalculator.BusinessLayer
{
    /// <summary>
    /// The interface contains various methods for calculating statistical data
    /// </summary>
    public interface IStatisticsCalculator
    {
        double CalculateArithmeticMean(double[] values);

        double CalculateStandardDeviation(double[] values);

        double FrequencyOfNumbersInBinTen(double[] values);

        double CalculateSum(double[] values);

    }
}
