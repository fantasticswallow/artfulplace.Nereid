using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows;

namespace artfulplace.Nereid
{
    [ContentProperty("UiChild")]
    public class DialogBoxLauncher : DependencyObject, Definitions.IGroupChild
    {
        public string GetRibbonXml()
        {
            if (UiChild == null)
            {
                return "";
            }
            var head = XmlUtility.CreateHeadXml("dialogBoxLauncher");
            var foot = XmlUtility.CreateFootXml("dialogBoxLauncher");
            return head + UiChild.GetRibbonXml() + foot;
        }

        public bool HasCollection()
        {
            return false;
        }



        public Button UiChild
        {
            get { return (Button)GetValue(UiChildProperty); }
            set { SetValue(UiChildProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UiChild.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UiChildProperty =
            DependencyProperty.Register("UiChild", typeof(Button), typeof(DialogBoxLauncher), new PropertyMetadata(null));
        
    }
}
