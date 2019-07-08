using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FuelConsumption2.Extensions;

namespace FuelConsumption2.Models.Csv
{
    public class CsvLoader
    {
        private readonly IEnumerable<Dictionary<string, string>> _enumerable;

        public double BaseOdo { get; set; }

        public CsvLoader(string path)
        {
            _enumerable = Load(path).Reverse();
        }

        private static IEnumerable<Dictionary<string, string>> Load(string path)
        {
            var csvLines = new List<string>(File.ReadAllText(path).UnifiedNewLine().Split('\n'));
            var names = csvLines[0].Split(',');
            csvLines.RemoveAt(0);
            csvLines.Remove("");

            var values = new List<Dictionary<string, string>>();
            foreach (var line in csvLines)
            {
                var splitLines = line.Split(',');
                var dict = new Dictionary<string, string>();
                values.Add(dict);
                foreach (var item in splitLines.Select((v, i) => new { Index = i, Value = v }))
                {
                    if (item.Index < names.Length)
                        dict.Add(names[item.Index], item.Value);
                }
            }

            return values;
        }

        public IEnumerable<FuelConsumptionInfo> GetSortedFuelConsumptionInfos()
        {
            var prev = new FuelConsumptionInfo
            {
                Odo = BaseOdo
            };
            var list = new List<FuelConsumptionInfo>();
            foreach (var value in _enumerable)
            {
                var odo = double.Parse(value["Mileage"]);
                var info = new FuelConsumptionInfo
                {
                    PricePerLitter = double.Parse(value["Price"]),
                    Litter = double.Parse(value["Amount"]),
                    Odo = odo,
                    Trip = odo - prev.Odo,
                    Date = DateTime.Parse(value["Date"]),
                    FuelType = value["FuelType"],
                    Memo = default
                };
                prev = info;
                list.Add(info);
            }

            return list.OrderByDescending(info => info.Odo);
        }
    }
}
