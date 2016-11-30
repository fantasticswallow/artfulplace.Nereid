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
            customUI = ui;
            AddRibbonItem(customUI);
        }

        private void AddRibbonItem(Definitions.IRibbonItem item)
        {
            RibbonItems.Add(item);

            if (item.HasCollection())
            {
                var items = (IEnumerable<Definitions.IRibbonItem>)item.GetType().GetProperty("UiChild").GetValue(item);
                foreach (var it in items)
                {
                    AddRibbonItem(it);
                }
            }
            else
            {
                Definitions.IRibbonItem it2 = null; 
                try
                {
                    it2 = (Definitions.IRibbonItem)item.GetType().GetProperty("UiChild").GetValue(item);
                }
                catch (Exception)
                {
                }
                if (it2 != null)
                {
                    AddRibbonItem(it2);
                }
                
            }
        }

        private List<Definitions.IRibbonItem> RibbonItems { get; set; } = new List<Definitions.IRibbonItem>();

        private CustomUI customUI { get; set; }
        private Office.IRibbonUI ribbon { get; set; }

        public string GetCustomUI(string RibbonID)
        {
            var dec = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
            return dec + customUI.GetRibbonXml();
            // return Resource1.String1;
        }

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        public void NereidButton_Click(Office.IRibbonControl arg)
        {
            var args = new ButtonEventArgs(arg.Id, arg.Tag, (object)arg.Context);
            var button = (Button)RibbonItems.First(x => x is Button && ((Button)x).Id == args.Id);
            button.OnClick(args);

        }
    }


}
