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
    public class AddFuelConsumptionPageViewModel : BindableBase
    {
        public AddFuelConsumptionPageViewModel(AddFuelConsumptionPageModel model)
        {
            this.model = model;

            PricePerLitter = model.ToReactivePropertyAsSynchronized(m => m.PricePerLitter);
            Litter = model.ToReactivePropertyAsSynchronized(m => m.Litter);
            Odo = model.ToReactivePropertyAsSynchronized(m => m.Odo);
            Date = model.ToReactivePropertyAsSynchronized(m => m.Date);

            ActionButtonText = ReactiveProperty.FromObject(model, m => m.ActionButtonText);
            FuelType = model.FuelTypes.ToReadOnlyReactiveCollection();
            FuelTypeSelectedItem = ReactiveProperty.FromObject(model, m => m.FuelTypeSelectedItem);

            CloseBtClicked = new Command(CloseBt_Clicked);
            AddBtClicked = new Command(AddBt_Clicked);
        }

        private AddFuelConsumptionPageModel model;

        public ReactiveProperty<double> PricePerLitter { get; set; }
        public ReactiveProperty<double> Litter { get; set; }
        public ReactiveProperty<double> Odo { get; set; }
        public ReactiveProperty<DateTime> Date { get; set; }
        public ReactiveProperty<string> MemoText { get; set; }

        public ReactiveProperty<string> ActionButtonText { get; set; }
        public ReadOnlyReactiveCollection<string> FuelType { get; set; }
        public ReactiveProperty<string> FuelTypeSelectedItem { get; set; }

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
