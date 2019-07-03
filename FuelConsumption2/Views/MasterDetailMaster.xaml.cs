using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FuelConsumption2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelConsumption2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailMaster : ContentPage
    {
        public ListView ListView;

        private List<MasterDetailMenuItem> _detailMenuItems;
        public List<MasterDetailMenuItem> DetailMenuItems => _detailMenuItems ?? (_detailMenuItems = vm.MenuItems.ToList());

        public Action<Page> DetailMasterPage;
        public Action<Page> PushModalPage;
        public Action CloseModalPage;

        private MasterDetailMasterViewModel vm;

        public MasterDetailMaster()
        {
            InitializeComponent();

            vm = new MasterDetailMasterViewModel(PushModal, CloseModal);
            BindingContext = vm;
            ListView = MenuItemsListView;
        }

        public void Load()
        {
            vm.Load();
        }

        public void PushModal(Page page) => PushModalPage(new NavigationPage(page));

        public void CloseModal() => CloseModalPage();

        private void OnEdit(object sender, EventArgs e)
        {
            var model = (MenuItem)sender;
            vm.MenuItemEditBt_Clicked((MasterDetailMenuItem)model.CommandParameter);
        }
        private void OnDelete(object sender, EventArgs e)
        {
            var model = (MenuItem)sender;
            vm.MenuItemDeleteBt_Clicked((MasterDetailMenuItem)model.CommandParameter);
        }
    }
}
