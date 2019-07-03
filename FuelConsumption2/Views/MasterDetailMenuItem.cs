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

        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public Type TargetType { get; set; }
    }
}
