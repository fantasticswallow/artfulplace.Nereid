using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace artfulplace.Nereid
{
    [ContentProperty("UiChild")]
    public class Ribbon : DataContextBase, Definitions.IRibbonStricts
    {
        public string GetRibbonXml()
        {
            var param = new Dictionary<string, object>();
            if (StartFromScratch)
            {
                param.Add("startFromScratch", StartFromScratch);
            }
            var head = XmlUtility.CreateHeadXml("ribbon", param);
            var foot = XmlUtility.CreateFootXml("ribbon");
            return head + UiChild.GetRibbonXml() +  foot;
        }

        public bool HasCollection()
        {
            return false;
        }

        public Definitions.IRibbonChild UiChild
        {
            get { return (Definitions.IRibbonChild)GetValue(UiChildProperty); }
            set { SetValue(UiChildProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UiChild.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UiChildProperty =
            DependencyProperty.Register("UiChild", typeof(Definitions.IRibbonChild), typeof(Ribbon), new PropertyMetadata(null));

        public bool StartFromScratch
        {
            get { return (bool)GetValue(StartFromScratchProperty); }
            set { SetValue(StartFromScratchProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartFromScratch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartFromScratchProperty =
            DependencyProperty.Register("StartFromScratch", typeof(bool), typeof(Ribbon), new PropertyMetadata(false));



    }
}
