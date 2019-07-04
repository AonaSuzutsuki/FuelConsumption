using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using FuelConsumption2.Models;
using Prism.Mvvm;

namespace FuelConsumption2.ViewModels
{
    public class MasterDetailItemViewModel : BindableBase
    {

        public MasterDetailItemViewModel()
        {

        }

        public ObservableCollection<FuelConsumptionInfo> FuelConsumptionItems { get; set; }
    }
}
