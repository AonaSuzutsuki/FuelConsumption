using System;
using System.Collections.Generic;
using FuelConsumption2.ViewModels;
using Xamarin.Forms;

namespace FuelConsumption2.Views
{
    public partial class AddFuelConsumptionPage : ContentPage
    {
        public AddFuelConsumptionPage()
        {
            InitializeComponent();

            var viewModel = new AddFuelConsumptionPageViewModel();
            BindingContext = viewModel;
        }
    }
}
