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
    public class Tab : TabItemBase, Definitions.IRibbonItem
    {
        public Tab()
        {
            SetValue(UiChildPropertyKey, new List<Group>());
        }

        public string GetRibbonXml()
        {
            var param = new Dictionary<string, object>();
            var id = GetId();
            param.Add(id.Item1, id.Item2);
            var head = XmlUtility.CreateHeadXml("tab",param);
            var foot = XmlUtility.CreateFootXml("tab");
            return head + string.Concat(UiChild.Select(x => x.GetRibbonXml()).ToArray()) + foot;
        }

        public bool HasCollection()
        {
            return true;
        }

        public List<Group> UiChild
        {
            get { return (List<Group>)GetValue(UiChildProperty); }
            private set { SetValue(UiChildPropertyKey, value); }
        }

        public static readonly DependencyProperty UiChildProperty = UiChildPropertyKey.DependencyProperty;

        // Using a DependencyProperty as the backing store for UiChild.  This enables animation, styling, binding, etc...
        private static readonly DependencyPropertyKey UiChildPropertyKey =
            DependencyProperty.RegisterReadOnly("UiChild", typeof(List<Group>), typeof(Tab), new PropertyMetadata(new List<Group>()));
    }




    [ContentProperty("UiChild")]
    public class Tabs : DependencyObject, Definitions.IRibbonChild
    {
        public Tabs()
        {
            SetValue(UiChildPropertyKey, new List<Tab>());
        }

        public string GetRibbonXml()
        {
            var head = XmlUtility.CreateHeadXml("tabs");
            var foot = XmlUtility.CreateFootXml("tabs");
            return head + string.Concat(UiChild.Select(x => x.GetRibbonXml()).ToArray()) + foot;
        }

        public bool HasCollection()
        {
            return true;
        }


        public List<Tab> UiChild
        {
            get { return (List<Tab>)GetValue(UiChildProperty); }
            private set { SetValue(UiChildPropertyKey, value); }
        }

        // Using a DependencyProperty as the backing store for UiChild.  This enables animation, styling, binding, etc...
        private static readonly DependencyPropertyKey UiChildPropertyKey =
            DependencyProperty.RegisterReadOnly("UiChild", typeof(List<Tab>), typeof(Tabs), new PropertyMetadata(new List<Tab>()));

        public static readonly DependencyProperty UiChildProperty = UiChildPropertyKey.DependencyProperty;
    }
}
