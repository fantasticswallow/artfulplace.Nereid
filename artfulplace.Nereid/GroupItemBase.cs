using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace artfulplace.Nereid
{
    /// <summary>
    /// Ribbon Item Base to checkBox
    /// </summary>
    public abstract class GroupItemBase : TabItemBase
    {
        // getDescription、getEnabled、getScreentip、getSupertip、

        protected internal override Dictionary<string, string> CreateXmlAttributes()
        {
            var dic = base.CreateXmlAttributes();
            dic.Add("getEnabled", "NereidControl_GetEnabled");
            dic.Add("getScreentip", "NereidControl_GetScreentip");
            dic.Add("getSupertip", "NereidControl_GetSupertip");
            return dic;
        }

        internal bool GetEnabled()
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
            DependencyProperty.Register("Enabled", typeof(bool), typeof(GroupItemBase), new PropertyMetadata(true, (d, e) => DependencyPropertyChanged(d, e, "Enabled")));

        internal string GetScreentip()
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
            DependencyProperty.Register("Screentip", typeof(string), typeof(GroupItemBase), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "Screentip")));

        internal string GetSupertip()
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
            DependencyProperty.Register("Supertip", typeof(string), typeof(GroupItemBase), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "Supertip")));
        

    }

    public abstract class GroupItemBase2 : GroupItemBase
    {
        protected internal override Dictionary<string, string> CreateXmlAttributes()
        {
            var dic = base.CreateXmlAttributes();
            dic.Add("getDescription", "NereidControl_GetDescription");
            return dic;
        }

        internal string GetDescription()
        {
            return Description;
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(GroupItemBase2), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "Description")));

    }

    /// <summary>
    /// Ribbon item base for button, editBox, etc...
    /// </summary>
    public abstract class GroupItemBase3 : GroupItemBase2
    {
        protected internal override Dictionary<string, string> CreateXmlAttributes()
        {
            var dic = base.CreateXmlAttributes();
            // dic.Add("getImageMso", "NereidControl_GetImageMso");
            dic.Add("getShowImage", "NereidControl_GetShowImage");
            dic.Add("getShowLabel", "NereidControl_GetShowLabel");
            // dic.Add("getImage", "NereidControl_GetImage");
            return dic;
        }

        //internal string GetImageMso()
        //{
        //    return ImageMso;
        //}

        //public string ImageMso
        //{
        //    get { return (string)GetValue(ImageMsoProperty); }
        //    set { SetValue(ImageMsoProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ImageMso.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ImageMsoProperty =
        //    DependencyProperty.Register("ImageMso", typeof(string), typeof(GroupItemBase3), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "ImageMso")));


        internal bool GetShowImage()
        {
            return IsShowImage;
        }

        public bool IsShowImage
        {
            get { return (bool)GetValue(IsShowImageProperty); }
            set { SetValue(IsShowImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsShowImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsShowImageProperty =
            DependencyProperty.Register("IsShowImage", typeof(bool), typeof(GroupItemBase3), new PropertyMetadata(false, (d, e) => DependencyPropertyChanged(d, e, "IsShowImage")));


        internal bool GetShowLabel()
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
            DependencyProperty.Register("IsShowLabel", typeof(bool), typeof(GroupItemBase3), new PropertyMetadata(true, (d, e) => DependencyPropertyChanged(d, e, "IsShowLabel")));

    }

    /// <summary>
    /// Ribbon item base for comboBox, dropDown
    /// </summary>
    public abstract class GroupItemBase4 : GroupItemBase
    {
        protected internal override Dictionary<string, string> CreateXmlAttributes()
        {
            var dic = base.CreateXmlAttributes();
            // dic.Add("getImageMso", "NereidControl_GetImageMso");
            dic.Add("getShowImage", "NereidControl2_GetShowImage");
            dic.Add("getShowLabel", "NereidControl2_GetShowLabel");
            // dic.Add("getImage", "NereidControl_GetImage");
            return dic;
        }

        //internal string GetImageMso()
        //{
        //    return ImageMso;
        //}

        //public string ImageMso
        //{
        //    get { return (string)GetValue(ImageMsoProperty); }
        //    set { SetValue(ImageMsoProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ImageMso.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ImageMsoProperty =
        //    DependencyProperty.Register("ImageMso", typeof(string), typeof(GroupItemBase3), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "ImageMso")));


        internal bool GetShowImage()
        {
            return IsShowImage;
        }

        public bool IsShowImage
        {
            get { return (bool)GetValue(IsShowImageProperty); }
            set { SetValue(IsShowImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsShowImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsShowImageProperty =
            DependencyProperty.Register("IsShowImage", typeof(bool), typeof(GroupItemBase4), new PropertyMetadata(false, (d, e) => DependencyPropertyChanged(d, e, "IsShowImage")));


        internal bool GetShowLabel()
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
            DependencyProperty.Register("IsShowLabel", typeof(bool), typeof(GroupItemBase4), new PropertyMetadata(true, (d, e) => DependencyPropertyChanged(d, e, "IsShowLabel")));

    }
}
