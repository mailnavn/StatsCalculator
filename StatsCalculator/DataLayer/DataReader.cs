using CsvHelper;
using StatsCalculator.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StatsCalculator.DataLayer
{
    public class DataReader : IDataReader
    {
        public List<double> ReadCSVData(string filePath)
        {
            // Verify if the path exists
            if (!File.Exists(filePath))
                throw new ApiException($"The file {filePath} does not exist on disk", 404, ProductErrorCodes.FILEDOESNOTEXIST);

            var valuesString = new List<string>();
            var data = new List<double>();

            try
            {
                using StreamReader file = new(filePath);
                string line = file.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                    throw new ApiException($"The first line of csv file does not contain any data", 405, ProductErrorCodes.INVALIDINPUT);

                valuesString = line.Split(",").ToList();

                data = valuesString.Select(_ => double.TryParse(_, out double temp) ? temp : 0).ToList();

            }
            catch(Exception ex)
            {
                // Log error in log

                // throw api exception wrapping the caught exception
                throw new ApiException($"An exception occurred while reading the csv file {filePath}", 500, ProductErrorCodes.INTERNALSERVERERROR, ex);
            }
            return data;
        }
    }
}
