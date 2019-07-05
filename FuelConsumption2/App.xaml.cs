using System;
using FuelConsumption2.Models;
using FuelConsumption2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelConsumption2
{
    public partial class App : Application
    {
        private readonly MasterDetail _masterDetail;

        public App()
        {
            InitializeComponent();

            _masterDetail = new Views.MasterDetail
            {
                Detail = new MasterDetailItemView(new MasterDetailMenuItem())
            };
            MainPage = _masterDetail;
        }

        protected override void OnStart()
        {
            _masterDetail.Load();
        }

        protected override void OnSleep()
        {
            _masterDetail.Save();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
