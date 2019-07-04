using System;
using System.Collections.Generic;
using System.Text;

namespace FuelConsumption2.Models
{
    public class FuelConsumptionInfo
    {
        public double PricePerLitter { get; set; }
        public double Litter { get; set; }
        public double Odo { get; set; }
        public DateTime Date { get; set; }
        public string Memo { get; set; }

        public double FuelConsumption(FuelConsumptionInfo fuelConsumptionInfo)
        {
            var trip = Odo - fuelConsumptionInfo.Odo;
            return Math.Truncate(trip / Litter);
        }
    }
}
