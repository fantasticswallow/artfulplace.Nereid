using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                ItemsDictionary.Add(id.Item2, pItem);
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
        private Office.IRibbonUI ribbon { get; set; }

        #region event handler
        public void NereidButton_Click(Office.IRibbonControl arg)
        {
            var args = new RibbonEventArgs(arg.Id, arg.Tag, (object)arg.Context);
            var button = (Button)RibbonItems.First(x => x is Button && ((Button)x).Id == args.Id);
            button.OnClick(args);
        }

        public void NereidCheckBox_Click(Office.IRibbonControl arg, bool isPressed)
        {
            var args = new RibbonCheckedEventArgs(arg.Id, arg.Tag, (object)arg.Context, isPressed);
            var checkBox= (CheckBox)ItemsDictionary[arg.Id];
            checkBox.OnClick(args);
        }

        public void NereidEditBox_Changed(Office.IRibbonControl arg, string text)
        {
            var args = new RibbonTextChangedEventArgs(arg.Id, arg.Tag, (object)arg.Context, text);
            var editBox = (EditBox)ItemsDictionary[arg.Id];
            editBox.OnTextChanged(args);
        }

        public void NereidToggleButton_Click(Office.IRibbonControl arg, bool isPressed)
        {
            var args = new RibbonCheckedEventArgs(arg.Id, arg.Tag, (object)arg.Context, isPressed);
            var checkBox = (ToggleButton)ItemsDictionary[arg.Id];
            checkBox.OnClick(args);
        }
        #endregion

        #region TabItemBase callback

        // getKeytip、getLabel, getVisible
        public string NereidControl_GetLabel(Office.IRibbonControl arg)
        {
            return ((TabItemBase)ItemsDictionary[arg.Id]).GetLabel();
        }

        public bool NereidControl_GetVisible(Office.IRibbonControl arg)
        {
            return ((TabItemBase)ItemsDictionary[arg.Id]).GetVisible();
        }

        public string NereidControl_GetKeytip(Office.IRibbonControl arg)
        {
            return ((TabItemBase)ItemsDictionary[arg.Id]).GetKeytip();
        }
        #endregion

        #region GroupItemBase callback
        // getDescription、getEnabled、getImage、getImageMso、、getScreentip、getShowImage、getShowLabel、getSupertip

        public string NereidControl_GetDescription(Office.IRibbonControl arg)
        {
            return ((GroupItemBase)ItemsDictionary[arg.Id]).GetDescription();
        }

        public bool NereidControl_GetEnabled(Office.IRibbonControl arg)
        {
            return ((GroupItemBase)ItemsDictionary[arg.Id]).GetEnabled();
        }

        public string NereidControl_GetImageMso(Office.IRibbonControl arg)
        {
            return ((GroupItemBase2)ItemsDictionary[arg.Id]).GetImageMso();
        }

        public string NereidControl_GetScreentip(Office.IRibbonControl arg)
        {
            return ((GroupItemBase)ItemsDictionary[arg.Id]).GetScreentip();
        }

        public string NereidControl_GetSupertip(Office.IRibbonControl arg)
        {
            return ((GroupItemBase)ItemsDictionary[arg.Id]).GetSupertip();
        }

        public bool NereidControl_GetShowImage(Office.IRibbonControl arg)
        {
            return ((GroupItemBase2)ItemsDictionary[arg.Id]).GetShowImage();
        }

        public bool NereidControl_GetShowLabel(Office.IRibbonControl arg)
        {
            return ((GroupItemBase2)ItemsDictionary[arg.Id]).GetShowLabel();
        }
        #endregion

        #region button
        public Office.RibbonControlSize NereidButton_GetSize(Office.IRibbonControl arg)
        {
            return ((Button)ItemsDictionary[arg.Id]).GetSize();
        }
        #endregion

        #region checkBox
        public bool NereidCheckBox_GetPressed(Office.IRibbonControl arg)
        {
            return ((CheckBox)ItemsDictionary[arg.Id]).GetPressed();
        }
        #endregion

        #region editBox
        public string NereidEditBox_GetText(Office.IRibbonControl arg)
        {
            return ((EditBox)ItemsDictionary[arg.Id]).GetText();
        }

        #endregion

        #region labelControl
        public string NereidLabel_GetLabel(Office.IRibbonControl arg)
        {
            return ((LabelControl)ItemsDictionary[arg.Id]).GetLabel();
        }

        public bool NereidLabel_GetVisible(Office.IRibbonControl arg)
        {
            return ((LabelControl)ItemsDictionary[arg.Id]).GetVisible();
        }

        public bool NereidLabel_GetEnabled(Office.IRibbonControl arg)
        {
            return ((LabelControl)ItemsDictionary[arg.Id]).GetEnabled();
        }

        public string NereidLabel_GetScreentip(Office.IRibbonControl arg)
        {
            return ((LabelControl)ItemsDictionary[arg.Id]).GetScreentip();
        }

        public string NereidLabel_GetSupertip(Office.IRibbonControl arg)
        {
            return ((LabelControl)ItemsDictionary[arg.Id]).GetSupertip();
        }

        public bool NereidLabel_GetShowLabel(Office.IRibbonControl arg)
        {
            return ((LabelControl)ItemsDictionary[arg.Id]).GetShowLabel();
        }
        #endregion

        #region ToggleButton
        public bool NereidToggleButton_GetPressed(Office.IRibbonControl arg)
        {
            return ((ToggleButton)ItemsDictionary[arg.Id]).GetPressed();
        }

        public Office.RibbonControlSize NereidToggleButton_GetSize(Office.IRibbonControl arg)
        {
            return ((ToggleButton)ItemsDictionary[arg.Id]).GetSize();
        }
        #endregion

    }


}
