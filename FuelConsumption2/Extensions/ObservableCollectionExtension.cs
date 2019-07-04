using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FuelConsumption2.Extensions
{
    public static class ObservableCollectionExtension
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> enumerable)
        {
            foreach (var elem in enumerable)
                collection.Add(elem);
        }
    }
}
