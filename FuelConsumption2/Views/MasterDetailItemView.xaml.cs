using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelConsumption2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelConsumption2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailItemView : ContentPage
    {
        private readonly MasterDetailItemViewModel _viewModel;

        public MasterDetailItemView()
        {
            InitializeComponent();

            _viewModel = new MasterDetailItemViewModel();
            BindingContext = _viewModel;
        }

        private void OnDelete(object sender, EventArgs e)
        {

        }

        private void OnEdit(object sender, EventArgs e)
        {

        }
    }
}
