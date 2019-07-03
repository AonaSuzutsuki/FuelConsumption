using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FuelConsumption2.Views
{
    public partial class AddVehiclePage : ContentPage
    {
        public AddVehiclePage(Action<MasterDetailMenuItem> itemAddAction, Action closeModal)
        {
            InitializeComponent();

            var model = new Models.AddVehiclePageModel
            {
                ItemAddAction = itemAddAction,
                CloseModal = closeModal
            };
            var vm = new ViewModels.AddVehiclePageViewModel(model);
            BindingContext = vm;
        }
    }
}
