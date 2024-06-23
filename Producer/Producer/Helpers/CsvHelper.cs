using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace Producer
{
    public static class CsvHelper
    {
        public static List<Dictionary<string, object>> LerCsv(string filePath)
        {
            var records = new List<Dictionary<string, object>>();

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    var dynamicRecords = csv.GetRecords<dynamic>();

                    foreach (var dynamicRecord in dynamicRecords)
                    {
                        var record = new Dictionary<string, object>();

                        foreach (var keyValuePair in (IDictionary<string, object>)dynamicRecord)
                        {
                            if (double.TryParse(keyValuePair.Value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                            {
                                record.Add(keyValuePair.Key, value);
                            }
                            else
                            {
                                record.Add(keyValuePair.Key, keyValuePair.Value.ToString());
                            }
                        }

                        records.Add(record);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }

            return records;
        }
    }
}
