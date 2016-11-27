using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using Office = Microsoft.Office.Core;

namespace artfulplace.Nereid
{
    [ComVisible(true)]
    public class RibbonExtensibility : Office.IRibbonExtensibility
    {
        public RibbonExtensibility(CustomUI ui)
        {
            customUI = ui.GetRibbonXml();
        }

        private string customUI { get; set; }
        private Office.IRibbonUI ribbon { get; set; }

        public string GetCustomUI(string RibbonID)
        {
            var dec = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
            return dec + customUI;
            // return Resource1.String1;
        }

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
            
        }
    }
}
