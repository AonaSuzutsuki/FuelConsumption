using System;
using FuelConsumption2.Views;
using Prism.Mvvm;

namespace FuelConsumption2.Models
{
    public class AddVehiclePageModel : BindableBase
    {

        private string vehicleName;
        public string VehicleName
        {
            get => vehicleName;
            set => SetProperty(ref vehicleName, value);
        }

        public Action<MasterDetailMenuItem> ItemAddAction { get; set; }
        public Action CloseModal { get; set; }

        public void AddToMenuItems()
        {
            ItemAddAction(new MasterDetailMenuItem
            {
                Title = VehicleName,
                TargetType = typeof(MasterDetailDetail)
            });
            CloseModal();
        }
    }
}
