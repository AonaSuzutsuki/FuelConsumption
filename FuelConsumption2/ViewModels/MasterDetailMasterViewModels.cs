using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FuelConsumption2.Extensions;
using FuelConsumption2.Models;
using FuelConsumption2.Views;
using Newtonsoft.Json;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Xamarin.Forms;

namespace FuelConsumption2.ViewModels
{
    public class MasterDetailMasterViewModel : BindableBase
    {
        public MasterDetailMasterViewModel(MasterDetailMasterModel model)
        {
            _model = model;

            MenuItems = model.MenuItems.ToReadOnlyReactiveCollection();

            MenuItemAddBtClicked = new Command(MenuItemAddBt_Clicked);
        }

        #region Fields
        private readonly MasterDetailMasterModel _model;
        #endregion

        #region Properties
        public ReadOnlyCollection<MasterDetailMenuItem> MenuItems { get; set; }
        #endregion

        #region Event Properties
        public ICommand MenuItemAddBtClicked { get; set; }
        #endregion

        #region Event Methods
        public void MenuItemAddBt_Clicked()
        {
            _model.MenuItemAdd();
        }

        public void MenuItemEditBt_Clicked(MasterDetailMenuItem item)
        {
            _model.MenuItemEdit(item);
        }
        public void MenuItemDeleteBt_Clicked(MasterDetailMenuItem item)
        {
            _model.MenuItemDelete(item);
        }
        #endregion

        #region Methods

        public void Load()
        {
            _model.Load();
        }

        public void Save(MasterDetailMenuItem item)
        {
            _model.Save(item);
        }
        #endregion
    }
}
