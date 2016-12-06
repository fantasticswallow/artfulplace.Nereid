using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace artfulplace.Nereid
{
    public class CheckBox : GroupItemBase2, Definitions.IGroupChild
    {
        public string GetRibbonXml()
        {
            var param = CreateXmlAttributes();
            param.Add("onAction", "NereidCheckBox_Click");
            param.Add("getPressed", "NereidCheckBox_GetPressed");
            return XmlUtility.CreateXml("checkBox", param);
        }

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
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(CheckBox), new PropertyMetadata(false, (d, e) => DependencyPropertyChanged(d, e, "IsChecked")));

        internal void OnClick(RibbonCheckedEventArgs e)
        {
            CheckChanged?.Invoke(this, e);
        }

        public delegate void RibbonCheckChangedEventHandler(object sender, RibbonCheckedEventArgs e);

        public event RibbonCheckChangedEventHandler CheckChanged;
        
        public bool HasCollection()
        {
            return false;
        }
    }
}
