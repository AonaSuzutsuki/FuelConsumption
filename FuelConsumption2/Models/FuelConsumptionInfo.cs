using System;
using System.Collections.Generic;
using System.Text;

namespace FuelConsumption2.Models
{
    public class FuelConsumptionInfo
    {
        public double PricePerLitter { get; set; }
        public double Litter { get; set; }
        public double LitterPerTrip => Litter > .0d ? Trip / Litter : .0d;
        public double Trip { get; set; }
        public double Odo { get; set; }
        public DateTime Date { get; set; }
        public string FuelType { get; set; }
        public string Memo { get; set; }

        public string PricePerLitterText => $"{PricePerLitter} Yen/L";
        public string LitterText => $"{Litter} L";
        public string LitterPerTripText => $"{LitterPerTrip:F2} km/L";
        public string TripText => $"{Trip} km";
        public string OdoText => $"{Odo} km";
        public string DateText => $"{Date:yyyy/MM/dd}";
    }
}
