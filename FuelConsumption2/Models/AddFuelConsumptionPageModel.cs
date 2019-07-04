using System;
using System.Collections.ObjectModel;
using FuelConsumption2.Views;
using Prism.Mvvm;

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

        private DateTime date;
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

        private int fuelTypeSelectedIndex;
        public int FuelTypeSelectedIndex
        {
            get => fuelTypeSelectedIndex;
            set => SetProperty(ref fuelTypeSelectedIndex, value);
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

        //public FuelConsumptionInfo FuelConsumptionInfo { get; set; }
        public Action<FuelConsumptionInfo> ChangedItemAction { get; set; }
        public Action<FuelConsumptionInfo> ItemAddAction { get; set; }
        public Action SaveAction { get; set; }

        public AddFuelConsumptionPageModel()
        {
            FuelTypes = new ObservableCollection<string>
            {
                "レギュラー",
                "ハイオク",
                "軽油"
            };
            FuelTypeSelectedIndex = 0;
        }

        public void AddToMenuItems()
        {
            if (EditMode)
            {
                //if (FuelConsumptionInfo != null)
                //{
                //    FuelConsumptionInfo.PricePerLitter = PricePerLitter;
                //    FuelConsumptionInfo.Litter = Litter;
                //    FuelConsumptionInfo.Odo = Odo;
                //    FuelConsumptionInfo.Date = Date;
                //    FuelConsumptionInfo.Memo = Memo;
                //}
                ChangedItemAction(new FuelConsumptionInfo
                {
                    PricePerLitter = PricePerLitter,
                    Litter = Litter,
                    Odo = Odo,
                    Date = Date,
                    Memo = Memo
                });
            }
            else
            {
                ItemAddAction(new FuelConsumptionInfo
                {
                    PricePerLitter = PricePerLitter,
                    Litter = Litter,
                    Odo = Odo,
                    Date = Date,
                    Memo = Memo
                });
            }

            SaveAction();
            NavigationClass.CloseModal();
        }
    }
}
