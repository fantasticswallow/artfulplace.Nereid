using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace artfulplace.Nereid
{
    public class Item : DataContextBase, Definitions.IRibbonItem
    {
        // id, image, imageMso, label, screentip, supertip
        // Item has static properties.

        public string GetRibbonXml()
        {
            var param = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(Id))
            {
                param.Add("id", Id);
            }
            if (!string.IsNullOrEmpty(Label))
            {
                param.Add("label", Label);
            }
            if (!string.IsNullOrEmpty(ImageMso))
            {
                param.Add("imageMso", ImageMso);
            }
            if (!string.IsNullOrEmpty(Screentip))
            {
                param.Add("screentip", Screentip);
            }
            if (!string.IsNullOrEmpty(Supertip))
            {
                param.Add("supertip", Supertip);
            }


            return XmlUtility.CreateXml("item", param);
            
        }

        public bool HasCollection()
        {
            return false;
        }

        public string Id
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(string), typeof(Item), new PropertyMetadata(""));



        public string ImageMso
        {
            get { return (string)GetValue(ImageMsoProperty); }
            set { SetValue(ImageMsoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageMso.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageMsoProperty =
            DependencyProperty.Register("ImageMso", typeof(string), typeof(Item), new PropertyMetadata(""));



        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(Item), new PropertyMetadata(""));



        public string Screentip
        {
            get { return (string)GetValue(ScreentipProperty); }
            set { SetValue(ScreentipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Screentip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScreentipProperty =
            DependencyProperty.Register("Screentip", typeof(string), typeof(Item), new PropertyMetadata(""));



        public string Supertip
        {
            get { return (string)GetValue(SupertipProperty); }
            set { SetValue(SupertipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Supertip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SupertipProperty =
            DependencyProperty.Register("Supertip", typeof(string), typeof(Item), new PropertyMetadata(""));

        
    }
}
