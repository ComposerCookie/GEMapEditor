using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMapEditor
{
    class CustomProperty<T>
    {
        T Value { get; set; }

        public CustomProperty(T value)
        {
            Value = value;
        }
    }
}
