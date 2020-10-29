using System;
using System.Windows.Input;
using FuelConsumption2.Models;
using FuelConsumption2.Views;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Xamarin.Forms;

namespace FuelConsumption2.ViewModels
{
    public class FuelConsumptionDetailPageViewModel
    {
        public FuelConsumptionDetailPageViewModel(FuelConsumptionDetailPageModel model)
        {
            _model = model;

            PricePerLitter = model.ObserveProperty(m => m.PricePerLitter).ToReactiveProperty();
            Litter = model.ObserveProperty(m => m.Litter).ToReactiveProperty();
            Odo = model.ObserveProperty(m => m.Odo).ToReactiveProperty();
            Trip = model.ObserveProperty(m => m.Trip).ToReactiveProperty();
            Date = model.ObserveProperty(m => m.Date).ToReactiveProperty();

            FuelType = model.ObserveProperty(m => m.FuelType).ToReactiveProperty();

            CloseBtClicked = new Command(CloseBt_Clicked);
            EditButtonClicked = new Command(EditButton_Clicked);
        }

        private readonly FuelConsumptionDetailPageModel _model;

        public ReactiveProperty<string> PricePerLitter { get; set; }
        public ReactiveProperty<string> Litter { get; set; }
        public ReactiveProperty<string> Odo { get; set; }
        public ReactiveProperty<string> Trip { get; set; }
        public ReactiveProperty<string> Date { get; set; }
        public ReactiveProperty<string> MemoText { get; set; }

        public ReactiveProperty<string> ActionButtonText { get; set; }
        public ReactiveProperty<string> FuelType { get; set; }
        public ReactiveProperty<string> FuelTypeSelectedItem { get; set; }

        public ICommand CloseBtClicked { get; set; }
        public ICommand EditButtonClicked { get; set; }

        public void CloseBt_Clicked()
        {
            NavigationClass.CloseModal();
        }

        public void EditButton_Clicked()
        {
            _model.ShowEdit();
        }
    }
}
