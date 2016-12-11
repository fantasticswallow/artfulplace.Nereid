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
    public class Group : PrimitiveItemsBase, Definitions.IRibbonItem
    {

        public Group()
        {
            SetValue(UiChildPropertyKey, new List<Definitions.IGroupChild>());

        }
        public string GetRibbonXml()
        {
            var param = new Dictionary<string, object>();
            param.Add("id", Id);
            param.Add("label", Label);
            var head = XmlUtility.CreateHeadXml("group", param);
            var foot = XmlUtility.CreateFootXml("group");
            if (UiChild.Any(x => x is DialogBoxLauncher))
            {
                // DialogBoxLauncher element must be final in group.

                var dBoxLauncher = UiChild.First(x => x is DialogBoxLauncher);
                return head + string.Concat(UiChild.Where(x => !(x is DialogBoxLauncher)).Select(x => x.GetRibbonXml()).ToArray()) + dBoxLauncher.GetRibbonXml() + foot;
            }
            else
            {
                return head + string.Concat(UiChild.Select(x => x.GetRibbonXml()).ToArray()) + foot;
            }
            
        }

        public List<Definitions.IGroupChild> UiChild
        {
            get { return (List<Definitions.IGroupChild>)GetValue(UiChildProperty); }
            private set { SetValue(UiChildPropertyKey, value); }
        }

        public bool HasCollection()
        {
            return true;
        }

        private static readonly DependencyPropertyKey UiChildPropertyKey =
            DependencyProperty.RegisterReadOnly("UiChild", typeof(List<Definitions.IGroupChild>), typeof(Group), new PropertyMetadata(new List<Definitions.IGroupChild>()));

        // Using a DependencyProperty as the backing store for UiChild.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UiChildProperty =
            UiChildPropertyKey.DependencyProperty;

        

       

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(Group), new PropertyMetadata(""));



    }
}
