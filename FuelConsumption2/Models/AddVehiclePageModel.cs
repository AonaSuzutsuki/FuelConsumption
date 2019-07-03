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

        public MasterDetailMenuItem EditItem { get; set; }
        public Action<MasterDetailMenuItem> ItemAddAction { get; set; }
        public Action CloseModal { get; set; }
        public Action SaveAction { get; set; }

        public void AddToMenuItems()
        {
            if (EditMode)
            {
                if (EditItem != null)
                {
                    EditItem.Title = VehicleName;
                }
            }
            else
            {
                ItemAddAction(new MasterDetailMenuItem
                {
                    Title = VehicleName,
                    TargetType = typeof(MasterDetailDetail)
                });
            }

            SaveAction();
            CloseModal();
        }
    }
}
