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
    public class CustomUI : DependencyObject, Definitions.IRibbonItem
    {


        // public event Action<object, EventArgs> Loaded;

        public Definitions.IRibbonStricts UiChild
        {
            get { return (Definitions.IRibbonStricts)GetValue(UiChildProperty); }
            set { SetValue(UiChildProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UiChild.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UiChildProperty =
            DependencyProperty.Register("UiChild", typeof(Definitions.IRibbonStricts), typeof(CustomUI), new PropertyMetadata(null));

        public string GetRibbonXml()
        {
            var head = "<customUI xmlns=\"http://schemas.microsoft.com/office/2006/01/customui\" onLoad=\"Ribbon_Load\">\n";
            var foot = "</customUI>";
            return head + UiChild.GetRibbonXml() + foot;
        }

        public bool HasCollection()
        {
            return false;
        }
    }
}
