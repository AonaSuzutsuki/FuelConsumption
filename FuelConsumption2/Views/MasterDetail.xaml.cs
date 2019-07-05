using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FuelConsumption2.Models;

namespace FuelConsumption2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();

            NavigationClass.PushModalPage = NavigationModal;
            NavigationClass.PushPage = NavigationPush;
            NavigationClass.NavigateDetail = ChangeMasterNavigationPage;
            NavigationClass.CloseModalPage = () => Navigation.PopModalAsync();
        }

        public void Load()
        {
            MasterPage.Load();
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
    }
}
