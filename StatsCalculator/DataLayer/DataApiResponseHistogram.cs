using System.Collections.Generic;

namespace StatsCalculator.DataLayer
{
    public class DataApiResponseHistogram
    {
        public string Bucket { get; set; }

        public double Frequency { get; set; }

        public List<double> Values { get; set; }

    }

}
