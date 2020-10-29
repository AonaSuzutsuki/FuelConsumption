using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using FuelConsumption2.Extensions;
using FuelConsumption2.Models.Csv;
using FuelConsumption2.Views;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace FuelConsumption2.Models
{
    public class MasterDetailItemModel : BindableBase
    {
        public string Title { get; set; }

        public bool IsInitialized { get; set; } = true;

        public Func<double> BaseOdoFunc { get; set; }


        private string totalMileageText = "0 km";
        public string TotalMileageText
        {
            get => totalMileageText;
            set => SetProperty(ref totalMileageText, value);
        }

        private string averageFuelConsumptionText = "0 km/L";
        public string AverageFuelConsumptionText
        {
            get => averageFuelConsumptionText;
            set => SetProperty(ref averageFuelConsumptionText, value);
        }



        //private bool addBtIsEnabled;
        //public bool AddBtIsEnabled
        //{
        //    get => addBtIsEnabled;
        //    set => SetProperty(ref addBtIsEnabled, value);
        //}

        private double totalMileage;
        public double TotalMileage
        {
            get => totalMileage;
            set
            {
                totalMileage = value;
                TotalMileageText = $"{value:F0} km";
            }
        }

        private double averageFuelConsumption;
        public double AverageFuelConsumption
        {
            get => averageFuelConsumption;
            set
            {
                averageFuelConsumption = value;
                AverageFuelConsumptionText = $"{value:F2} km/L";
            }
        }

        private ObservableCollection<FuelConsumptionInfo> fuelConsumptionItems = new ObservableCollection<FuelConsumptionInfo>();
        public ObservableCollection<FuelConsumptionInfo> FuelConsumptionItems
        {
            get => fuelConsumptionItems;
            set => SetProperty(ref fuelConsumptionItems, value);
        }


        public void AddFuelConsumption()
        {
            if (IsInitialized)
                return;

            NavigationClass.PushModal(new AddFuelConsumptionPage(new AddFuelConsumptionPageModel(FuelConsumptionItems)
            {
                BaseOdo = BaseOdoFunc(),
                ItemAddAction = (item) =>
                {
                    FuelConsumptionItems.Add(item);
                    Sort();
                    UpdateMillageAverage();
                },
                SaveAction = Save
            }));
        }

        public void UpdateMillageAverage()
        {
            TotalMileage = FuelConsumptionItems.Count > 0 ? FuelConsumptionItems.First().Odo : .0;

            var trip = .0d;
            var litter = .0d;
            foreach (var elem in FuelConsumptionItems)
            {
                trip += elem.Trip;
                litter += elem.Litter;
            }

            if (litter > .0d)
                AverageFuelConsumption = trip / litter;
        }

        public void Sort()
        {
            var list = new List<FuelConsumptionInfo>(FuelConsumptionItems.OrderByDescending(info => info.Odo));
            FuelConsumptionItems = new ObservableCollection<FuelConsumptionInfo>(list);
        }

        public void Edit(FuelConsumptionInfo fuelConsumptionInfo)
        {
            NavigationClass.PushModal(new AddFuelConsumptionPage(new AddFuelConsumptionPageModel(FuelConsumptionItems)
            {
                EditMode = true,
                EditFuelConsumptionInfo = fuelConsumptionInfo,

                PricePerLitter = fuelConsumptionInfo.PricePerLitter,
                Litter = fuelConsumptionInfo.Litter,
                Odo = fuelConsumptionInfo.Odo,
                Date = fuelConsumptionInfo.Date,
                Memo = fuelConsumptionInfo.Memo,
                FuelTypeSelectedItem = fuelConsumptionInfo.FuelType,

                BaseOdo = BaseOdoFunc(),
                ChangedItemAction = () =>
                {
                    Sort();
                    UpdateMillageAverage();
                },
                SaveAction = Save
            }));
        }

        public void Delete(FuelConsumptionInfo fuelConsumptionInfo)
        {
            if (FuelConsumptionItems.Contains(fuelConsumptionInfo))
                FuelConsumptionItems.Remove(fuelConsumptionInfo);
            Save();
        }

        public void OpenDetailPage(FuelConsumptionInfo fuelConsumptionInfo)
        {
            NavigationClass.Push(new FuelConsumptionDetailPage(new FuelConsumptionDetailPageModel(fuelConsumptionInfo)
            {
                ShowEditAction = () => Edit(fuelConsumptionInfo)
            }));
        }

        public void Load()
        {
            var title = $"{PathConverter.MakeValidFileName(Title)}.json";
            var filename = title.ResolveDocumentPath();
            if (string.IsNullOrEmpty(Title) || !File.Exists(filename))
                return;
            var json = File.ReadAllText(filename);
            var masterDetailMenuItems = JsonConvert.DeserializeObject<FuelConsumptionInfo[]>(json);
            FuelConsumptionItems.AddRange(masterDetailMenuItems.OrderByDescending(info => info.Odo));

            // var csvLoader = new CsvLoader("Data/fuel.csv")
            // {
            //    BaseOdo = BaseOdoFunc()
            // };
            // FuelConsumptionItems = new ObservableCollection<FuelConsumptionInfo>(csvLoader.GetSortedFuelConsumptionInfos());

            UpdateMillageAverage();

            //var list = new List<FuelConsumptionInfo>();
            //for (int i = 0; i < 500; i++)
            //{
            //    var info = new FuelConsumptionInfo
            //    {
            //        Date = DateTime.Now,
            //        Litter = 2,
            //        FuelType = "ハイオク",
            //        Odo = i * 100,
            //        Trip = 100,
            //        PricePerLitter = 148,
            //    };
            //    list.Add(info);
            //}
            //list.Reverse();
            //FuelConsumptionItems = new ObservableCollection<FuelConsumptionInfo>(list);
        }

        public void Save()
        {
            var title = $"{PathConverter.MakeValidFileName(Title)}.json";
            var filename = title.ResolveDocumentPath();
            var json = JsonConvert.SerializeObject(FuelConsumptionItems);
            File.WriteAllText(filename, json);
        }
    }
}
