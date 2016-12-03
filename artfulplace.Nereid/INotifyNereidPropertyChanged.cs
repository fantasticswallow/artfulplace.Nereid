using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Nereid
{
    internal interface INotifyNereidPropertyChanged
    {
        event Action<string> PropertyChanged;

    }
}
