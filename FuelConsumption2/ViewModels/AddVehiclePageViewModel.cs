using System;
using System.Windows.Input;
using FuelConsumption2.Models;
using FuelConsumption2.Views;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Xamarin.Forms;

namespace FuelConsumption2.ViewModels
{
    public class AddVehiclePageViewModel : BindableBase
    {
        public AddVehiclePageViewModel(AddVehiclePageModel model)
        {
            this.model = model;

            ActionButtonText = ReactiveProperty.FromObject(model, m => m.ActionButtonText);
            VehicleNameText = model.ToReactivePropertyAsSynchronized(m => m.VehicleName);

            CloseBtClicked = new Command(CloseBt_Clicked);
            AddBtClicked = new Command(AddBt_Clicked);
        }

        private AddVehiclePageModel model;

        public ReactiveProperty<string> ActionButtonText { get; set; }
        public ReactiveProperty<string> VehicleNameText { get; set; }

        public ICommand CloseBtClicked { get; set; }
        public ICommand AddBtClicked { get; set; }


        public void CloseBt_Clicked()
        {
            NavigationClass.CloseModal();
        }

        public void AddBt_Clicked()
        {
            model.AddToMenuItems();
        }
    }
}
