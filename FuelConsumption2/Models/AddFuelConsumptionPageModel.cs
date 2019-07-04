using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FuelConsumption2.Views;
using Prism.Mvvm;
using Xamarin.Forms.Internals;

namespace FuelConsumption2.Models
{
    public class AddFuelConsumptionPageModel : BindableBase
    {
        public ObservableCollection<string> FuelTypes { get; set; }

        private double pricePerLitter;
        public double PricePerLitter
        {
            get => pricePerLitter;
            set => SetProperty(ref pricePerLitter, value);
        }

        private double litter;
        public double Litter
        {
            get => litter;
            set => SetProperty(ref litter, value);
        }

        private double odo;
        public double Odo
        {
            get => odo;
            set => SetProperty(ref odo, value);
        }

        private DateTime date = DateTime.Now;
        public DateTime Date
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

        private string fuelTypeSelectedItem;
        public string FuelTypeSelectedItem
        {
            get => fuelTypeSelectedItem;
            set => SetProperty(ref fuelTypeSelectedItem, value);
        }

        private string actionButtonText = "Add";
        public string ActionButtonText
        {
            get => actionButtonText;
            set => SetProperty(ref actionButtonText, value);
        }

        private bool editMode;
        public bool EditMode
        {
            get => editMode;
            set
            {
                if (value)
                    ActionButtonText = "Edit";
                else
                    ActionButtonText = "Add";
                editMode = value;
            }
        }


        private readonly List<FuelConsumptionInfo> _fuelConsumptionInfos;
        
        public FuelConsumptionInfo EditFuelConsumptionInfo { get; set; }
        public double BaseOdo { get; set; }
        public Action ChangedItemAction { get; set; }
        public Action<FuelConsumptionInfo> ItemAddAction { get; set; }
        public Action SaveAction { get; set; }

        public AddFuelConsumptionPageModel(IEnumerable<FuelConsumptionInfo> fuelConsumptionInfos)
        {
            this._fuelConsumptionInfos = new List<FuelConsumptionInfo>(fuelConsumptionInfos);
            FuelTypes = new ObservableCollection<string>
            {
                "レギュラー",
                "ハイオク",
                "軽油"
            };
            FuelTypeSelectedItem = FuelTypes[0];
        }

        public void AddToMenuItems()
        {
            if (EditMode)
            {
                // 二分探索
                //FuelConsumptionInfo next = null;
                //FuelConsumptionInfo prev = null;
                //foreach (var fuelConsumptionInfo in _fuelConsumptionInfos)
                //{
                //    if (fuelConsumptionInfo.Odo > Odo)
                //}

                _fuelConsumptionInfos.Remove(EditFuelConsumptionInfo);
                var preItem = new FuelConsumptionInfo { Odo = Odo };
                var list = new List<FuelConsumptionInfo>(_fuelConsumptionInfos)
                {
                    preItem
                };
                var sortedList = new List<FuelConsumptionInfo>(list.OrderByDescending(info => info.Odo));
                var index = sortedList.IndexOf(preItem);

                var next = index > 0 ? sortedList[index - 1] : new FuelConsumptionInfo { Odo = BaseOdo };
                var prev = index < sortedList.Count - 1 ? sortedList[index + 1] : new FuelConsumptionInfo { Odo = BaseOdo };

                EditFuelConsumptionInfo.PricePerLitter = PricePerLitter;
                EditFuelConsumptionInfo.Litter = Litter;
                EditFuelConsumptionInfo.Odo = Odo;
                EditFuelConsumptionInfo.Trip = Odo - prev.Odo;
                EditFuelConsumptionInfo.Date = Date;
                EditFuelConsumptionInfo.Memo = Memo;
                EditFuelConsumptionInfo.FuelType = FuelTypeSelectedItem;

                ChangedItemAction();
                //ChangedItemAction(EditFuelConsumptionInfo, new FuelConsumptionInfo
                //{
                //    PricePerLitter = PricePerLitter,
                //    Litter = Litter,
                //    Trip = Odo - prev.Odo,
                //    Odo = Odo,
                //    Date = Date,
                //    Memo = Memo,
                //    FuelType = FuelTypeSelectedItem
                //});

                next.Trip = next.Odo - Odo;
            }
            else
            {
                var preItem = new FuelConsumptionInfo { Odo = Odo };
                var list = new List<FuelConsumptionInfo>(_fuelConsumptionInfos)
                {
                    preItem
                };
                var sortedList = new List<FuelConsumptionInfo>(list.OrderByDescending(info => info.Odo));
                var index = sortedList.IndexOf(preItem);

                var next = index > 0 ? sortedList[index - 1] : new FuelConsumptionInfo { Odo = BaseOdo };
                var prev = index < sortedList.Count - 1 ? sortedList[index + 1] : new FuelConsumptionInfo { Odo = BaseOdo };

                ItemAddAction(new FuelConsumptionInfo
                {
                    PricePerLitter = PricePerLitter,
                    Litter = Litter,
                    Trip = prev.Odo > .0 ? Odo - prev.Odo : .0,
                    Odo = Odo,
                    Date = Date,
                    Memo = Memo,
                    FuelType = FuelTypeSelectedItem
                });

                next.Trip = next.Odo - Odo;
            }

            SaveAction();
            NavigationClass.CloseModal();
        }

        private FuelConsumptionInfo GetLast()
        {
            var fuelConsumptionInfo = new FuelConsumptionInfo
            {
                Odo = BaseOdo
            };
            if (_fuelConsumptionInfos.Count > 0)
                fuelConsumptionInfo = _fuelConsumptionInfos.First();
            return fuelConsumptionInfo;
        }
    }
}
