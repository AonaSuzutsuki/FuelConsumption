using System;
using Xamarin.Forms;

namespace FuelConsumption2.Views
{
    public static class NavigationClass
    {
        public static Action<Page> NavigateDetail { private get; set; }
        public static Action<Page> PushModalPage { private get; set; }
        public static Action CloseModalPage { private get; set; }

        public static void PushDetail(Page page) => NavigateDetail?.Invoke(page);
        public static void PushModal(Page page) => PushModalPage?.Invoke(page);
        public static void CloseModal() => CloseModalPage?.Invoke();
    }
}
