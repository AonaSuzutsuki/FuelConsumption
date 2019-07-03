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

        public Action<Page> DetailMasterPage;
        public Action<Page> PushModalPage;
        public Action CloseModalPage;

        public MasterDetailMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailMasterViewModel(PushModal, CloseModal);
            ListView = MenuItemsListView;
        }

        public void PushModal(Page page) => PushModalPage(new NavigationPage(page));

        public void CloseModal() => CloseModalPage();
    }
}
