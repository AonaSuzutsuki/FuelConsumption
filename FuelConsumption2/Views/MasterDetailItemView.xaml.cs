using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelConsumption2.Models;
using FuelConsumption2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelConsumption2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailItemView : ContentPage
    {
        private readonly MasterDetailItemViewModel _viewModel;

        public MasterDetailItemView(MasterDetailMenuItem masterDetailMenuItem)
        {
            InitializeComponent();

            Title = masterDetailMenuItem.Title;
            var model = new MasterDetailItemModel
            {
                Title = masterDetailMenuItem.Title,
                BaseOdoFunc = () => masterDetailMenuItem.BaseOdo
            };
            _viewModel = new MasterDetailItemViewModel(model);
            _viewModel.Load();
            BindingContext = _viewModel;
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var model = (MenuItem)sender;
            _viewModel.MenuItemDeleteBt_Clicked((FuelConsumptionInfo)model.CommandParameter);
        }

        private void OnEdit(object sender, EventArgs e)
        {
            var model = (MenuItem)sender;
            _viewModel.MenuItemEditBt_Clicked((FuelConsumptionInfo)model.CommandParameter);
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is FuelConsumptionInfo item))
                return;

            NavigationClass.Push(new FuelConsumptionDetailPage());
            ((ListView)sender).SelectedItem = null;
        }
    }
}
