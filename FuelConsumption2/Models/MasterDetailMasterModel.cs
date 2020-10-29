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
    [JsonObject]
    public class VehicleTable
    {
        [JsonProperty]
        public MasterDetailMenuItem SelectedItem { get; set; }
        [JsonProperty]
        public ICollection<MasterDetailMenuItem> MenuItems { get; set; }
    }

    public class MasterDetailMasterModel : BindableBase
    {
        public ObservableCollection<MasterDetailMenuItem> MenuItems { get; set; } = new ObservableCollection<MasterDetailMenuItem>();

        public Action<MasterDetailMenuItem> ChangeSelectedItem { get; set; }

        public void MenuItemAdd()
        {
            NavigationClass.PushModal(new AddVehiclePage((item) => MenuItems.Add(item), Save));
        }

        public void MenuItemEdit(MasterDetailMenuItem item)
        {
            var model = new AddVehiclePageModel
            {
                EditMode = true,
                EditItem = item,
                VehicleName = item.Title,
                BaseOdo = item.BaseOdo
            };

            NavigationClass.PushModal(new AddVehiclePage((_item) => MenuItems.Add(_item), Save, model));
        }
        public void MenuItemDelete(MasterDetailMenuItem item)
        {
            if (item == null)
                return;
            MenuItems.Remove(item);

            var title = $"{PathConverter.MakeValidFileName(item.Title)}.json";
            var filename = title.ResolveDocumentPath();
            if (File.Exists(filename))
                File.Delete(filename);

            //if (MenuItems.Count <= 0)
            //    NavigationClass.PushDetail(new MasterDetailItemView(new MasterDetailMenuItem()));

            this.Save(null);
        }

        public void Load()
        {
            var savedPath = Constants.VehiclesSavedPath;
            if (!File.Exists(savedPath))
            {
                ChangeSelectedItem(new MasterDetailMenuItem());
                return;
            }

            var json = File.ReadAllText(savedPath);
            try
            {
                var table = JsonConvert.DeserializeObject<VehicleTable>(json);
                MenuItems.AddRange(table.MenuItems);
                if (MenuItems.Count < 1)
                    ChangeSelectedItem(new MasterDetailMenuItem());
                foreach (var item in table.MenuItems)
                {
                    if (item.Title == table.SelectedItem.Title)
                        ChangeSelectedItem(item);
                }
            }
            catch (JsonSerializationException) { }
        }

        public void Save(MasterDetailMenuItem item)
        {
            var savedPath = Constants.VehiclesSavedPath;
            var table = new VehicleTable
            {
                SelectedItem = item,
                MenuItems = MenuItems,
            };
            var json = JsonConvert.SerializeObject(table);
            File.WriteAllText(savedPath, json);
        }
    }
}
