using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FuelConsumption2.Extensions;
using FuelConsumption2.Models;
using FuelConsumption2.Views;
using Newtonsoft.Json;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Xamarin.Forms;

namespace FuelConsumption2.ViewModels
{
    public class MasterDetailItemViewModel : BindableBase
    {

        public MasterDetailItemViewModel(MasterDetailItemModel model)
        {
            _model = model;

            TotalMileage = model.ObserveProperty(m => m.TotalMileageText).ToReactiveProperty();
            AverageFuelConsumption = model.ObserveProperty(m => m.AverageFuelConsumptionText).ToReactiveProperty();
            FuelConsumptionItems = model.ToReactivePropertyAsSynchronized(m => m.FuelConsumptionItems); //ReactiveProperty.FromObject(model, m => m.FuelConsumptionItems);
            AddFuelConsumptionBtClicked = new Command(AddFuelConsumptionBt_Clicked);
        }

        private readonly MasterDetailItemModel _model;

        public ReactiveProperty<string> TotalMileage { get; set; }
        public ReactiveProperty<string> AverageFuelConsumption { get; set; }
        public ReactiveProperty<ObservableCollection<FuelConsumptionInfo>> FuelConsumptionItems { get; set; }

        public ICommand AddFuelConsumptionBtClicked { get; set; }

        public void AddFuelConsumptionBt_Clicked()
        {
            _model.AddFuelConsumption();
        }

        public void Load()
        {
            _model.Load();
        }

        public void MenuItemEditBt_Clicked(FuelConsumptionInfo fuelConsumptionInfo)
        {
            _model.Edit(fuelConsumptionInfo);
        }
        public void MenuItemDeleteBt_Clicked(FuelConsumptionInfo fuelConsumptionInfo)
        {
            _model.Delete(fuelConsumptionInfo);
        }
    }
}
