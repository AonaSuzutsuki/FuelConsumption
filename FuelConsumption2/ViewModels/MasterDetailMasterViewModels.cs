using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FuelConsumption2.Models;
using FuelConsumption2.Views;
using Prism.Mvvm;
using Reactive.Bindings;
using Xamarin.Forms;

namespace FuelConsumption2.ViewModels
{
    public class MasterDetailMasterViewModel : BindableBase
    {
        public ObservableCollection<MasterDetailMenuItem> MenuItems { get; set; }

        public MasterDetailMasterViewModel(Action<Page> action, Action closeModal)
        {
            this.navigateAction = action;
            this.closeModal = closeModal;

            MenuItems = new ObservableCollection<MasterDetailMenuItem>(new[]
            {
                    new MasterDetailMenuItem { Id = 0, Title = "Page 1", TargetType = typeof(MasterDetailDetail) },
                    new MasterDetailMenuItem { Id = 1, Title = "Page 2", TargetType = typeof(MasterDetailDetail) },
                    new MasterDetailMenuItem { Id = 2, Title = "Page 3", TargetType = typeof(MasterDetailDetail) },
                    new MasterDetailMenuItem { Id = 3, Title = "Page 4", TargetType = typeof(MasterDetailDetail) },
                    new MasterDetailMenuItem { Id = 4, Title = "Page 5", TargetType = typeof(MasterDetailDetail) }
            });

            MenuItemAddBtClicked = new Command(MenuItemAddBt_Clicked);
        }

        Action<Page> navigateAction;
        Action closeModal;

        public ICommand MenuItemAddBtClicked { get; set; }

        public void MenuItemAddBt_Clicked()
        {
            navigateAction(new AddVehiclePage((item) => MenuItems.Add(item), closeModal));
        }

        public void MenuItemEditBt_Clicked(MasterDetailMenuItem item)
        {
            Console.WriteLine(item);
            var model = new AddVehiclePageModel()
            {
                EditMode = true,
                EditItem = item,
                VehicleName = item.Title
            };

            navigateAction(new AddVehiclePage((_item) => MenuItems.Add(_item), closeModal, model));
        }
        public void MenuItemDeleteBt_Clicked(MasterDetailMenuItem item)
        {
            if (item == null)
                return;

            MenuItems.Remove(item);
        }
    }
}
