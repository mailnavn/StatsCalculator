using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsCalculator.DataLayer
{
    public interface IDataReader
    {
        Task<List<double>> ReadCSVData(string filePath);
    }
}
