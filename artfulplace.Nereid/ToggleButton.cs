using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Office = Microsoft.Office.Core;

namespace artfulplace.Nereid
{
    public class ToggleButton : GroupItemBase3, Definitions.IButtonBase
    {
        public string GetRibbonXml()
        {
            var param = CreateXmlAttributes();
            param.Add("onAction", "NereidToggleButton_Click");
            param.Add("getSize", "NereidToggleButton_GetSize");
            param.Add("getPressed", "NereidToggleButton_GetPressed");
            return XmlUtility.CreateXml("toggleButton", param);
        }

        public bool HasCollection()
        {
            return false;
        }

        //  getPressed, getSize, onAction

        internal bool GetPressed()
        {
            return IsChecked;
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(ToggleButton), new PropertyMetadata(false, (d, e) => DependencyPropertyChanged(d, e, "IsChecked")));


        internal void OnClick(RibbonCheckedEventArgs e)
        {
            Click?.Invoke(this, e);
        }

        internal Office.RibbonControlSize GetSize()
        {
            return Size == Definitions.RibbonEnum.RibbonSize.Regular ? Office.RibbonControlSize.RibbonControlSizeRegular : Office.RibbonControlSize.RibbonControlSizeLarge;
        }

        public Definitions.RibbonEnum.RibbonSize Size
        {
            get { return (Definitions.RibbonEnum.RibbonSize)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(Definitions.RibbonEnum.RibbonSize), typeof(ToggleButton), new PropertyMetadata(Definitions.RibbonEnum.RibbonSize.Regular));



        public delegate void ToggleButtonClickEventHandler(object sender, RibbonCheckedEventArgs e);
        public event ToggleButtonClickEventHandler Click;
    }
}
