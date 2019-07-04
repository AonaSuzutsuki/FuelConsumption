using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace FuelConsumption2.Views
{
    public class MasterDetailMenuItem : BindableBase
    {
        public int Id { get; set; }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public double BaseOdo { get; set; }

        public Type TargetType { get; } = typeof(MasterDetailItemView);
    }
}
