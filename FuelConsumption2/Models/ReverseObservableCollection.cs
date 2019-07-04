using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FuelConsumption2.Models
{
    public class ReverseObservableCollection<T> : ObservableCollection<T>
    {
        public new void Add(T value)
        {

        }
    }
}
