using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelConsumption2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            MasterPage.PushModalPage = (Page page) => Navigation.PushModalAsync(page);
            MasterPage.DetailMasterPage = ChangeMasterPage;
            MasterPage.CloseModalPage = () => Navigation.PopModalAsync();
        }

        private void ChangeMasterPage(Page page)
        {
            Detail = page;
            IsPresented = false;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            ChangeMasterPage(new NavigationPage(page));

            MasterPage.ListView.SelectedItem = null;
        }
    }
}
