using System;
using System.Collections.Generic;
using FuelConsumption2.Models;
using Xamarin.Forms;

namespace FuelConsumption2.Views
{
    public partial class AddVehiclePage : ContentPage
    {
        public AddVehiclePage(Action<MasterDetailMenuItem> itemAddAction, Action<MasterDetailMenuItem> saveAction, AddVehiclePageModel model = null)
        {
            InitializeComponent();

            if (model == null)
                model = new AddVehiclePageModel();
            model.ItemAddAction = itemAddAction;
            model.SaveAction = saveAction;

            var vm = new ViewModels.AddVehiclePageViewModel(model);
            BindingContext = vm;
        }
    }
}
