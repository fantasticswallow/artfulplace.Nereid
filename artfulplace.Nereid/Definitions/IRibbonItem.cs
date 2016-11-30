using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Nereid.Definitions
{
    public interface IRibbonItem
    {
        string GetRibbonXml();
        /// <summary>
        /// object has any elements to UiChild property.
        /// </summary>
        /// <returns></returns>
        bool HasCollection();
    }
}
