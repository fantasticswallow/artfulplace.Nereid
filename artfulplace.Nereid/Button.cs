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
    public class Button : PrimitiveItemsBase, Definitions.IGroupChild
    {
        public string GetRibbonXml()
        {
            var param = CreateXmlAttributes();
            param.Add("onAction", "NereidButton_Click");
            return XmlUtility.CreateXml("button", param);
        }

        internal void OnClick(RibbonEventArgs e)
        {
            Click?.Invoke(this, e);
        }


        public delegate void ButtonClickEventHandler(object sender, RibbonEventArgs e);
        public event ButtonClickEventHandler Click;

        public bool HasCollection()
        {
            return false;
        }
    }
}
