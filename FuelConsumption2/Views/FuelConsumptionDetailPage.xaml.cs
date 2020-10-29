﻿using System;
using System.Collections.Generic;
using FuelConsumption2.Models;
using FuelConsumption2.ViewModels;
using Xamarin.Forms;

namespace FuelConsumption2.Views
{
    public partial class FuelConsumptionDetailPage : ContentPage
    {
        public FuelConsumptionDetailPage(FuelConsumptionDetailPageModel model)
        {
            InitializeComponent();

            var viewModel = new FuelConsumptionDetailPageViewModel(model);
            BindingContext = viewModel;
        }
    }
}
