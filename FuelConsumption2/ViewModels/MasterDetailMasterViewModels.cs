﻿using System;
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
using Xamarin.Forms;

namespace FuelConsumption2.ViewModels
{
    public class MasterDetailMasterViewModel : BindableBase
    {
        public MasterDetailMasterViewModel(Action<Page> pushDetail, Action<Page> navigateModal, Action closeModal)
        {
            _navigateModal = navigateModal;
            _closeModal = closeModal;
            _pushDetail = pushDetail;

            //MenuItems = new ObservableCollection<MasterDetailMenuItem>(new[]
            //{
            //        new MasterDetailMenuItem { Id = 0, Title = "Page 1", TargetType = typeof(MasterDetailItemView) },
            //        new MasterDetailMenuItem { Id = 1, Title = "Page 2", TargetType = typeof(MasterDetailItemView) },
            //        new MasterDetailMenuItem { Id = 2, Title = "Page 3", TargetType = typeof(MasterDetailItemView) },
            //        new MasterDetailMenuItem { Id = 3, Title = "Page 4", TargetType = typeof(MasterDetailItemView) },
            //        new MasterDetailMenuItem { Id = 4, Title = "Page 5", TargetType = typeof(MasterDetailItemView) }
            //});
            MenuItems = new ObservableCollection<MasterDetailMenuItem>();

            MenuItemAddBtClicked = new Command(MenuItemAddBt_Clicked);
        }

        #region Fields

        private readonly Action<Page> _pushDetail;
        private readonly Action<Page> _navigateModal;
        private readonly Action _closeModal;
        #endregion

        #region Properties
        public ObservableCollection<MasterDetailMenuItem> MenuItems { get; set; }
        #endregion

        #region Event Properties
        public ICommand MenuItemAddBtClicked { get; set; }
        #endregion

        #region Event Methods
        public void MenuItemAddBt_Clicked()
        {
            _navigateModal(new AddVehiclePage((item) => MenuItems.Add(item), _closeModal, Save));
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

            _navigateModal(new AddVehiclePage((_item) => MenuItems.Add(_item), _closeModal, Save, model));
        }
        public void MenuItemDeleteBt_Clicked(MasterDetailMenuItem item)
        {
            if (item == null)
                return;
            MenuItems.Remove(item);

            if (MenuItems.Count <= 0)
                _pushDetail(new MasterDetailItemView());

            this.Save();
        }
        #endregion

        #region Methods

        public void Load()
        {
            var savedPath = Constants.VehiclesSavedPath;
            if (!File.Exists(savedPath))
                return;
            var json = File.ReadAllText(savedPath);
            var masterDetailMenuItems = JsonConvert.DeserializeObject<MasterDetailMenuItem[]>(json);
            MenuItems.AddRange(masterDetailMenuItems);
        }

        public void Save()
        {
            var savedPath = Constants.VehiclesSavedPath;
            var json = JsonConvert.SerializeObject(MenuItems);
            File.WriteAllText(savedPath, json);
        }
        #endregion
    }
}
