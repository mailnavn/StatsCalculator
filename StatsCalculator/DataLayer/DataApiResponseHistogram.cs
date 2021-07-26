using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsCalculator.DataLayer
{
    public class DataApiResponseHistogram
    {
        public string Bucket { get; set; }

        public double Frequency { get; set; }

        public List<double> Values { get; set; }

    }

}
