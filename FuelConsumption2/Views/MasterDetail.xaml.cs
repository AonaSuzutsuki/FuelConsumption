using System;
using System.Linq;
using System.Collections.Generic;
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
            NavigationClass.PushModalPage = NavigationModal;
            NavigationClass.PushPage = NavigationPush;
            NavigationClass.NavigateDetail = ChangeMasterNavigationPage;
            NavigationClass.CloseModalPage = () => Navigation.PopModalAsync();
        }

        public void Load()
        {
            MasterPage.Load();

            var first = MasterPage.DetailMenuItems.Count > 0 ? MasterPage.DetailMenuItems.First() : null;
			if (first != null)
				ItemSelected(first);
			else
				ChangeMasterNavigationPage(new MasterDetailItemView(new MasterDetailMenuItem()));

		}

        public void Save()
        {

        }

        private void NavigationModal(Page page)
        {
            page.BackgroundColor = Color.Black;
            var nav = new NavigationPage(page)
            {
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.White
            };
            Detail.Navigation.PushModalAsync(nav);
        }

        private void NavigationPush(Page page)
        {
            page.BackgroundColor = Color.Black;
            Detail.Navigation.PushAsync(page);
        }

        private void ChangeMasterPage(Page page)
        {
            BackgroundColor = Color.Black;
            Detail = page;
            IsPresented = false;
        }

        private void ChangeMasterNavigationPage(Page page)
        {
            page.BackgroundColor = Color.Black;
            var nav = new NavigationPage(page)
            {
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.White
            };
            ChangeMasterPage(nav);
        }

        private void ChangeMasterPage(NavigationPage page)
        {
            page.BarBackgroundColor = Color.Black;
            page.BarTextColor = Color.White;
            ChangeMasterPage((Page)page);
        }

        private void ItemSelected(MasterDetailMenuItem item)
        {
            var page = (Page) Activator.CreateInstance(item.TargetType, item);
            //page.Title = item.Title;

            ChangeMasterNavigationPage(page);

            MasterPage.ListView.SelectedItem = null;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is MasterDetailMenuItem item))
                return;

            ItemSelected(item);
        }
    }
}
