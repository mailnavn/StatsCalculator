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

        double CalculateArithmeticMean(List<double> values);

        double CalculateStandardDeviation(List<double> values);

        double FrequencyOfNumbersInBinTen(List<double> values);


    }
}
