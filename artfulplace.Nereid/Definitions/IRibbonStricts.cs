using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Nereid.Definitions
{
    /// <summary>
    /// Strict to use children for CustomUi.
    /// </summary>
    public interface IRibbonStricts : IRibbonItem
    {
    }

    /// <summary>
    /// Strict to use children for Ribbon
    /// </summary>
    public interface IRibbonChild : IRibbonItem { }
    public interface IGroupChild : IRibbonItem { }

    public interface IButtonBase : IGroupChild { }
    public interface IDropDownChid { }

    public interface IMenuChild : IRibbonItem { }
}
