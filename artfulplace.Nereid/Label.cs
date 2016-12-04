using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace artfulplace.Nereid
{
    public class LabelControl : PrimitiveItemsBase, Definitions.IGroupChild
    {

        // getEnabled, getLabel, getScreentip, getShowLabel, getSupertip, getVisible, positions
        public string GetRibbonXml()
        {
            var param = CreateXmlAttributes();
            param.Add("getEnabled", "NereidLabel_GetEnabled");
            param.Add("getScreentip", "NereidLabel_GetScreentip");
            param.Add("getSupertip", "NereidLabel_GetSupertip");
            param.Add("getVisible", "NereidLabel_GetVisible");
            param.Add("getLabel", "NereidLabel_GetLabel");
            param.Add("getShowLabel", "NereidLabel_GetShowLabel");
            return XmlUtility.CreateXml("labelControl", param);
        }

        public bool HasCollection()
        {
            return false;
        }

        public bool GetEnabled()
        {
            return Enabled;
        }

        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Enabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.Register("Enabled", typeof(bool), typeof(LabelControl), new PropertyMetadata(true, (d, e) => DependencyPropertyChanged(d, e, "Enabled")));

        public string GetScreentip()
        {
            return Screentip;
        }

        public string Screentip
        {
            get { return (string)GetValue(ScreentipProperty); }
            set { SetValue(ScreentipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Screentip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScreentipProperty =
            DependencyProperty.Register("Screentip", typeof(string), typeof(LabelControl), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "Screentip")));

        public string GetSupertip()
        {
            return Supertip;
        }

        public string Supertip
        {
            get { return (string)GetValue(SupertipProperty); }
            set { SetValue(SupertipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Supertip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SupertipProperty =
            DependencyProperty.Register("Supertip", typeof(string), typeof(LabelControl), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "Supertip")));

        public string GetLabel()
        {
            return Label;
        }

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(LabelControl), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "Label")));

        public bool GetVisible()
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
            DependencyProperty.Register("Visible", typeof(bool), typeof(LabelControl), new PropertyMetadata(true, (d, e) => DependencyPropertyChanged(d, e, "Visible")));


        public bool GetShowLabel()
        {
            return IsShowLabel;
        }

        public bool IsShowLabel
        {
            get { return (bool)GetValue(IsShowLabelProperty); }
            set { SetValue(IsShowLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsShowLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsShowLabelProperty =
            DependencyProperty.Register("IsShowLabel", typeof(bool), typeof(LabelControl), new PropertyMetadata(false, (d, e) => DependencyPropertyChanged(d, e, "IsShowLabel")));

    }
}
