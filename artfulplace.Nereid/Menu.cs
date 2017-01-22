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
    [ContentProperty("UiChild")]
    public class Menu : GroupItemBase3, Definitions.IRibbonItem
    {
        public Menu()
        {
            SetValue(UiChildPropertyKey, new List<Definitions.IMenuChild>());
        }

        public string GetRibbonXml()
        {
            var param = CreateXmlAttributes();
            // param.Add("getImageMso", "NereidDropDown_GetImageMso");
            
            var val = ItemSize == Definitions.RibbonEnum.RibbonSize.Regular ? "Normal" : "Large";
            param.Add("itemSize", val);
            param.Add("getSize", "NereidMenu_GetSize");


            var head = XmlUtility.CreateHeadXml("menu", param);
            var foot = XmlUtility.CreateFootXml("menu");
            return head + string.Concat(UiChild.Select(x => x.GetRibbonXml()).ToArray()) + foot;
        }
            

        public bool HasCollection()
        {
            return true;
            
        }

        // getImage, getImageMso,  getSize,
        // image, imageMso, size, tag
        // itemSize

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
            DependencyProperty.Register("Size", typeof(Definitions.RibbonEnum.RibbonSize), typeof(Menu), new PropertyMetadata(Definitions.RibbonEnum.RibbonSize.Regular));



        public Definitions.RibbonEnum.RibbonSize ItemSize
        {
            get { return (Definitions.RibbonEnum.RibbonSize)GetValue(ItemSizeProperty); }
            set { SetValue(ItemSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSizeProperty =
            DependencyProperty.Register("ItemSize", typeof(Definitions.RibbonEnum.RibbonSize), typeof(Menu), new PropertyMetadata(Definitions.RibbonEnum.RibbonSize.Regular));


        public List<Definitions.IMenuChild> UiChild
        {
            get { return (List<Definitions.IMenuChild>)GetValue(UiChildProperty); }
            private set { SetValue(UiChildPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey UiChildPropertyKey =
            DependencyProperty.RegisterReadOnly("UiChild", typeof(List<Definitions.IMenuChild>), typeof(Menu), new PropertyMetadata(new List<Definitions.IMenuChild>()));

        public static readonly DependencyProperty UiChildProperty = UiChildPropertyKey.DependencyProperty;



    }
}
