using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace artfulplace.Nereid
{
    [ContentProperty("UiChild")]
    public class ContextualTabs : DataContextBase, Definitions.IRibbonItem
    {
        public string GetRibbonXml()
        {
            if (UiChild == null)
            {
                return "";
            }
            var head = XmlUtility.CreateHeadXml("contextualTabs");
            var foot = XmlUtility.CreateFootXml("contextualTabs");
            return head + UiChild.GetRibbonXml() + foot;
        }

        public bool HasCollection()
        {
            return false;
        }

        public TabSet UiChild
        {
            get { return (TabSet)GetValue(UiChildProperty); }
            set { SetValue(UiChildProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UiChild.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UiChildProperty =
            DependencyProperty.Register("UiChild", typeof(TabSet), typeof(ContextualTabs), new PropertyMetadata(null));

    }

    [ContentProperty("UiChild")]
    public class TabSet : DataContextBase, Definitions.IRibbonItem
    {
        public string GetRibbonXml()
        {
            var param = new Dictionary<string, string>();
            param.Add("idMso", IdMso);
            param.Add("getVisible", "NereidTabSet_GetVisible");
            if (UiChild == null)
            {
                return "";
            }
            var head = XmlUtility.CreateHeadXml("tabSet");
            var foot = XmlUtility.CreateFootXml("tabSet");
            return head + UiChild.GetRibbonXml() + foot;
        }

        public bool HasCollection()
        {
            return false;
        }



        public string IdMso
        {
            get { return (string)GetValue(IdMsoProperty); }
            set { SetValue(IdMsoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IdMso.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdMsoProperty =
            DependencyProperty.Register("IdMso", typeof(string), typeof(TabSet), new PropertyMetadata(""));



        public Tab UiChild
        {
            get { return (Tab)GetValue(UiChildProperty); }
            set { SetValue(UiChildProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UiChild.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UiChildProperty =
            DependencyProperty.Register("UiChild", typeof(Tab), typeof(TabSet), new PropertyMetadata(null));

        internal bool GetVisible()
        {
            return Visible;
        }

        public bool Visible
        {
            get { return (bool)GetValue(VisibleProperty); }
            set { SetValue(VisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Visible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibleProperty =
            DependencyProperty.Register("Visible", typeof(bool), typeof(TabSet), new PropertyMetadata(true, (d, e) => DependencyPropertyChanged(d, e, "Visible")));

        #region INotifyNereidPropertyChanged
        internal protected void NotifyChanged()
        {
            var id = IdMso;
            PropertyChanged?.Invoke(id);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public event Action<string> PropertyChanged;

        internal static void DependencyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e, string propertyName)
        {
            var obj = (TabSet)d;
            d.GetType().GetProperty(propertyName).SetValue(d, e.NewValue);
            obj.NotifyChanged();
        }
        #endregion
    }
}
