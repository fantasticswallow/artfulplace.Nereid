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
    public class Group : DependencyObject, Definitions.IRibbonItem
    {
        public string GetRibbonXml()
        {
            var param = new Dictionary<string, object>();
            param.Add("id", Id);
            param.Add("label", Label);
            var head = XmlUtility.CreateHeadXml("group", param);
            var foot = XmlUtility.CreateFootXml("group");
            return head + string.Concat(UiChild.Select(x => x.GetRibbonXml()).ToArray()) + foot;
        }

        public List<Definitions.IGroupChild> UiChild
        {
            get { return (List<Definitions.IGroupChild>)GetValue(UiChildProperty); }
            set { SetValue(UiChildProperty, value); }
        }

        public bool HasCollection()
        {
            return true;
        }

        // Using a DependencyProperty as the backing store for UiChild.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UiChildProperty =
            DependencyProperty.Register("UiChild", typeof(List<Definitions.IGroupChild>), typeof(Group), new PropertyMetadata(new List<Definitions.IGroupChild>()));



        public string Id
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(string), typeof(Group), new PropertyMetadata(""));



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
