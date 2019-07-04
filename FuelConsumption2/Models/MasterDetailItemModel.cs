using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using FuelConsumption2.Extensions;
using FuelConsumption2.Views;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace FuelConsumption2.Models
{
    public class MasterDetailItemModel : BindableBase
    {
        public string Title { get; set; }

        public double BaseOdo { get; set; }

        public ObservableCollection<FuelConsumptionInfo> FuelConsumptionItems { get; } = new ObservableCollection<FuelConsumptionInfo>();


        public void AddFuelConsumption()
        {
            NavigationClass.PushModal(new AddFuelConsumptionPage(new AddFuelConsumptionPageModel(FuelConsumptionItems)
            {
                BaseOdo = BaseOdo,
                ItemAddAction = (item) =>
                {
                    FuelConsumptionItems.Add(item);
                    Sort();
                },
                SaveAction = Save
            }));
        }

        public void Sort()
        {
            var list = new List<FuelConsumptionInfo>(FuelConsumptionItems);
            FuelConsumptionItems.Clear();
            FuelConsumptionItems.AddRange(list.OrderByDescending(info => info.Odo));
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

                BaseOdo = BaseOdo,
                ItemAddAction = (item) =>
                {
                    FuelConsumptionItems.Add(item);
                    Sort();
                },
                ChangedItemAction = Sort,
                SaveAction = Save
            }));
        }

        public void Delete(FuelConsumptionInfo fuelConsumptionInfo)
        {
            if (FuelConsumptionItems.Contains(fuelConsumptionInfo))
                FuelConsumptionItems.Remove(fuelConsumptionInfo);
            Save();
        }

        public void Load()
        {
            var title = $"{MakeValidFileName(Title)}.json";
            var filename = title.ResolveDocumentPath();
            if (string.IsNullOrEmpty(Title) || !File.Exists(filename))
                return;
            var json = File.ReadAllText(filename);
            var masterDetailMenuItems = JsonConvert.DeserializeObject<FuelConsumptionInfo[]>(json);
            FuelConsumptionItems.AddRange(masterDetailMenuItems.OrderByDescending(info => info.Odo));
        }

        public void Save()
        {
            var title = $"{MakeValidFileName(Title)}.json";
            var filename = title.ResolveDocumentPath();
            var json = JsonConvert.SerializeObject(FuelConsumptionItems);
            File.WriteAllText(filename, json);
        }

        private static string MakeValidFileName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;
            var invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            var invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }
    }
}
