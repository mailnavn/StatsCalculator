namespace StatsCalculator.BusinessLayer
{
    /// <summary>
    /// The interface contains various methods for calculating statistical data
    /// </summary>
    public interface IStatisticsCalculator
    {
        /// <summary>
        /// Calculates the arithmetic mean
        /// </summary>
        /// <param name="values">Data set</param>
        /// <returns>arithmetic mean of the given data set</returns>
        double CalculateArithmeticMean(double[] values);

        /// <summary>
        /// Calculates the standard deviation for a given data set
        /// </summary>
        /// <param name="values">Data set</param>
        /// <param name="sdType">Population or Sample type enum</param>
        /// <returns>standare deviation value</returns>
        double CalculateStandardDeviation(double[] values, SDType sdType);

        double FrequencyOfNumbersInBinTen(double[] values);

        double CalculateSum(double[] values);

    }
}
