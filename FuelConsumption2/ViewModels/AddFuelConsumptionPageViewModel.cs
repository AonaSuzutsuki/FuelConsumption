using System;
using System.Windows.Input;
using FuelConsumption2.Views;
using Xamarin.Forms;

namespace FuelConsumption2.ViewModels
{
    public class AddFuelConsumptionPageViewModel
    {
        public AddFuelConsumptionPageViewModel()
        {

            CloseBtClicked = new Command(CloseBt_Clicked);
        }

        public ICommand CloseBtClicked { get; set; }

        public void CloseBt_Clicked()
        {
            NavigationClass.CloseModal();
        }
    }
}
