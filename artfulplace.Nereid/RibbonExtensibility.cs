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
            var t = item.GetType();
            if (t.GetInterface("INotifyNereidPropertyChanged") != null)
            {
                ((INotifyNereidPropertyChanged)item).PropertyChanged += NereidControls_PropertyChanged;
            }
            if (t.GetProperty("IdMso") != null)
            {
                var pItem = (PrimitiveItemsBase)item;
                var id = pItem.GetId();
                ItemsDictionary.Add(id.Item2,pItem);
            }

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
                var prop = item.GetType().GetProperty("UiChild");
 
                if (prop != null)
                {
                    AddRibbonItem((Definitions.IRibbonItem)prop.GetValue(item));
                }
            }
        }

        private void NereidControls_PropertyChanged(string id)
        {
            this.ribbon.InvalidateControl(id);
        }

        private List<Definitions.IRibbonItem> RibbonItems { get; set; } = new List<Definitions.IRibbonItem>();
        private Dictionary<string, PrimitiveItemsBase> ItemsDictionary { get; } = new Dictionary<string, PrimitiveItemsBase>();


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
            var args = new RibbonEventArgs(arg.Id, arg.Tag, (object)arg.Context);
            var button = (Button)RibbonItems.First(x => x is Button && ((Button)x).Id == args.Id);
            button.OnClick(args);
        }

        public string NereidControl_GetLabel(Office.IRibbonControl arg)
        {
            return ItemsDictionary[arg.Id].GetLabel();
        }

        public bool NereidControl_GetVisible(Office.IRibbonControl arg)
        {
            return ItemsDictionary[arg.Id].GetVisible();
        }

        public string NereidControl_GetKeytip(Office.IRibbonControl arg)
        {
            return ItemsDictionary[arg.Id].GetKeytip();
        }
    }


}
