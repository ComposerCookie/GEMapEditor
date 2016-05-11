using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMapEditor
{
    interface Propertiable<T>
    {
        List<CustomProperty<T>> CustomProperties { get; set; }

        void AddProperty(T type, T value);
        void RemoveProperty(int index);
        void EditProperty(int index, T value);
        CustomProperty<T> GetProperty(int index);
    }
}
