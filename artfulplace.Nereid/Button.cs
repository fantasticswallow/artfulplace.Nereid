using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using Office = Microsoft.Office.Core;

namespace artfulplace.Nereid
{
    public class Button : GroupItemBase2, Definitions.IGroupChild
    {
        public string GetRibbonXml()
        {
            var param = CreateXmlAttributes();
            param.Add("onAction", "NereidButton_Click");
            param.Add("getSize", "NereidButton_GetSize");
            return XmlUtility.CreateXml("button", param);
        }

        // getImage、getImageMso、getShowImage、getShowLabel、getSize

        internal void OnClick(RibbonEventArgs e)
        {
            Click?.Invoke(this, e);
        }

        public Office.RibbonControlSize GetSize()
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
            DependencyProperty.Register("Size", typeof(Definitions.RibbonEnum.RibbonSize), typeof(Button), new PropertyMetadata(Definitions.RibbonEnum.RibbonSize.Regular));

        

        public delegate void ButtonClickEventHandler(object sender, RibbonEventArgs e);
        public event ButtonClickEventHandler Click;

        public bool HasCollection()
        {
            return false;
        }
    }
}
