using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using FuelConsumption2.Models;
using FuelConsumption2.Views;
using Prism.Mvvm;
using Xamarin.Forms;

namespace FuelConsumption2.ViewModels
{
    public class MasterDetailItemViewModel : BindableBase
    {

        public MasterDetailItemViewModel()
        {

            AddFuelConsumptionBtClicked = new Command(AddFuelConsumptionBt_Clicked);
        }

        public ObservableCollection<FuelConsumptionInfo> FuelConsumptionItems { get; set; }

        public ICommand AddFuelConsumptionBtClicked { get; set; }

        public void AddFuelConsumptionBt_Clicked()
        {
            NavigationClass.PushModal(new AddFuelConsumptionPage());
        }
    }
}
