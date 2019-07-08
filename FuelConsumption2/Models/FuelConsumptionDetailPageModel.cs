using System;
using Prism.Mvvm;
using Reactive.Bindings;

namespace FuelConsumption2.Models
{
    public class FuelConsumptionDetailPageModel : BindableBase
    {

        private string pricePerLitter;
        public string PricePerLitter
        {
            get => pricePerLitter;
            set => SetProperty(ref pricePerLitter, value);
        }

        private string litter;
        public string Litter
        {
            get => litter;
            set => SetProperty(ref litter, value);
        }

        private string odo;
        public string Odo
        {
            get => odo;
            set => SetProperty(ref odo, value);
        }

        private string trip;
        public string Trip
        {
            get => trip;
            set => SetProperty(ref trip, value);
        }

        private string date = DateTime.Now.ToString("yyyy/MM/dd");
        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        private string memo;
        public string Memo
        {
            get => memo;
            set => SetProperty(ref memo, value);
        }

        private string fuelType;
        public string FuelType
        {
            get => fuelType;
            set => SetProperty(ref fuelType, value);
        }

        public FuelConsumptionDetailPageModel(FuelConsumptionInfo fuelConsumptionInfo)
        {
            PricePerLitter = fuelConsumptionInfo.PricePerLitter.ToString("F2");
            Litter = fuelConsumptionInfo.Litter.ToString("F2");
            Odo = fuelConsumptionInfo.Odo.ToString("F2");
            Trip = fuelConsumptionInfo.Trip.ToString("F2");
            Date = fuelConsumptionInfo.Date.ToString("yyyy/MM/dd");
            Memo = fuelConsumptionInfo.Memo;
            FuelType = fuelConsumptionInfo.FuelType;
        }
    }
}
