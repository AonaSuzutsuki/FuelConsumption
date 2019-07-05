using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FuelConsumption2.Models;
using FuelConsumption2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelConsumption2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailMaster : ContentPage
    {
        public ListView ListView;

        private readonly MasterDetailMasterViewModel _viewModel;

        public MasterDetailMaster()
        {
            InitializeComponent();

            var model = new MasterDetailMasterModel
            {
                ChangeSelectedItem = ItemSelected
            };
            _viewModel = new MasterDetailMasterViewModel(model);
            BindingContext = _viewModel;
            ListView = MenuItemsListView;
            ListView.ItemSelected += ListView_ItemSelected;
        }

        public void Load()
        {
            _viewModel.Load();
        }

        public void Save(MasterDetailMenuItem item)
        {
            _viewModel.Save(item);
        }

        private void OnEdit(object sender, EventArgs e)
        {
            var model = (MenuItem)sender;
            _viewModel.MenuItemEditBt_Clicked((MasterDetailMenuItem)model.CommandParameter);
        }
        private void OnDelete(object sender, EventArgs e)
        {
            var model = (MenuItem)sender;
            _viewModel.MenuItemDeleteBt_Clicked((MasterDetailMenuItem)model.CommandParameter);
        }


        private void ItemSelected(MasterDetailMenuItem item)
        {
            var page = (Page)Activator.CreateInstance(item.TargetType, item);
            //page.Title = item.Title;

            NavigationClass.PushDetail(page);

            Save(item);

            ListView.SelectedItem = null;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is MasterDetailMenuItem item))
                return;

            ItemSelected(item);
        }
    }
}
