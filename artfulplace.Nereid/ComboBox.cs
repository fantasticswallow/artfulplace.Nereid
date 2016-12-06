using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace artfulplace.Nereid
{
    [ContentProperty("UiChild")]
    public class ComboBox : GroupItemBase, Definitions.IGroupChild
    {
        //  getImage, getImageMso, getShowImage, getShowLabel,
        // getText, maxLength, onChange, sizeString


        public string GetRibbonXml()
        {
            var param = CreateXmlAttributes();
            // param.Add("getImageMso", "NereidComboBox_GetImageMso");
            param.Add("getShowImage", "NereidComboBox_GetShowImage");
            param.Add("getShowLabel", "NereidComboBox_GetShowLabel");
            param.Add("onChange", "NereidComboBox_Changed");
            param.Add("getText", "NereidComboBox_GetText");
            if (MaxString > 0)
            {
                param.Add("maxString", MaxString.ToString());
            }
            if (!string.IsNullOrEmpty(SizeString))
            {
                param.Add("sizeString", SizeString);
            }
            if (ShowItemImage)
            {
                param.Add("showItemImage", "1");
            }
            if (ItemsSource != null)
            {
                // getItemCount, getItemID, getItemImage, getItemLabel, getItemScreentip, getItemSupertip
                param.Add("getItemCount", "NereidComboBox_GetItemCount");
                param.Add("getItemID", "NereidComboBox_GetItemID");
                // param.Add("getItemImage", "NereidComboBox_GetItemImage");
                param.Add("getItemLabel", "NereidComboBox_GetItemLabel");
                param.Add("getItemScreentip", "NereidComboBox_GetItemScreentip");
                param.Add("getItemSupertip", "NereidComboBox_GetItemSupertip");

                return XmlUtility.CreateXml("comboBox", param);
            }
            else
            {
                var head = XmlUtility.CreateHeadXml("comboBox", param);
                var foot = XmlUtility.CreateFootXml("comboBox");
                return head + string.Concat(UiChild.Select(x => x.GetRibbonXml()).ToArray()) + foot;
            }
        }

        #region GroupItemBase3 Copy
        internal string GetImageMso()
        {
            return ImageMso;
        }

        public string ImageMso
        {
            get { return (string)GetValue(ImageMsoProperty); }
            set { SetValue(ImageMsoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageMso.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageMsoProperty =
            DependencyProperty.Register("ImageMso", typeof(string), typeof(ComboBox), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "ImageMso")));


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
            DependencyProperty.Register("IsShowImage", typeof(bool), typeof(ComboBox), new PropertyMetadata(false, (d, e) => DependencyPropertyChanged(d, e, "IsShowImage")));


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
            DependencyProperty.Register("IsShowLabel", typeof(bool), typeof(ComboBox), new PropertyMetadata(true, (d, e) => DependencyPropertyChanged(d, e, "IsShowLabel")));
        #endregion

        #region EditBox Attributes
        public string SizeString
        {
            get { return (string)GetValue(SizeStringProperty); }
            set { SetValue(SizeStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SizeString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeStringProperty =
            DependencyProperty.Register("SizeString", typeof(string), typeof(ComboBox), new PropertyMetadata(""));

        public int MaxString
        {
            get { return (int)GetValue(MaxStringProperty); }
            set { SetValue(MaxStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxStringProperty =
            DependencyProperty.Register("MaxString", typeof(int), typeof(ComboBox), new PropertyMetadata(-1));

        internal string GetText()
        {
            return Text;
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ComboBox), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "Text")));

        internal void OnTextChanged(RibbonTextChangedEventArgs e)
        {
            this.Text = e.Text;
            TextChanged?.Invoke(this, e);
        }

        public delegate void ComboBoxTextChangedEventHandler(object sender, RibbonTextChangedEventArgs e);

        public event ComboBoxTextChangedEventHandler TextChanged;
        #endregion

        internal int GetItemCount()
        {
            if (ItemsSource != null)
            {
                return itemElements.Count;
            }
            return UiChild.Count;
        }

        // getItemCount, getItemID, getItemImage, getItemLabel, getItemScreentip, getItemSupertip, showItemImage

        internal string GetItemId(int index)
        {
            if (string.IsNullOrEmpty(ItemIdMember))
            {
                return "";
            }
            var item = itemElements[index];
            var prop = item.GetType().GetProperty(ItemIdMember);
            if (prop != null)
            {
                return prop.GetValue(item).ToString();
            }
            return "";
        }

        public string ItemIdMember
        {
            get { return (string)GetValue(ItemIdMemberProperty); }
            set { SetValue(ItemIdMemberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemIdMember.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemIdMemberProperty =
            DependencyProperty.Register("ItemIdMember", typeof(string), typeof(ComboBox), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "ItemIdMember")));

        internal string GetItemLabel(int index)
        {
            if (string.IsNullOrEmpty(ItemLabelMember))
            {
                return itemElements[index].ToString();
            }
            var item = itemElements[index];
            var prop = item.GetType().GetProperty(ItemLabelMember);
            if (prop != null)
            {
                return prop.GetValue(item).ToString();
            }
            return "";
        }

        public string ItemLabelMember
        {
            get { return (string)GetValue(ItemLabelMemberProperty); }
            set { SetValue(ItemLabelMemberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemLabelMember.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemLabelMemberProperty =
            DependencyProperty.Register("ItemLabelMember", typeof(string), typeof(ComboBox), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "ItemLabelMember")));

        // getItemScreentip, getItemSupertip, showItemImage

        internal string GetItemScreentip(int index)
        {
            if (string.IsNullOrEmpty(ItemScreentipMember))
            {
                return "";
            }
            var item = itemElements[index];
            var prop = item.GetType().GetProperty(ItemScreentipMember);
            if (prop != null)
            {
                return prop.GetValue(item).ToString();
            }
            return "";
        }

        public string ItemScreentipMember
        {
            get { return (string)GetValue(ItemScreentipMemberProperty); }
            set { SetValue(ItemScreentipMemberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemScreentipMember.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemScreentipMemberProperty =
            DependencyProperty.Register("ItemScreentipMember", typeof(string), typeof(ComboBox), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "ItemScreentipMember")));

        internal string GetItemSupertip(int index)
        {
            if (string.IsNullOrEmpty(ItemSupertipMember))
            {
                return "";
            }
            var item = itemElements[index];
            var prop = item.GetType().GetProperty(ItemSupertipMember);
            if (prop != null)
            {
                return prop.GetValue(item).ToString();
            }
            return "";
        }

        public string ItemSupertipMember
        {
            get { return (string)GetValue(ItemSupertipMemberProperty); }
            set { SetValue(ItemSupertipMemberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemSupertipMember.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSupertipMemberProperty =
            DependencyProperty.Register("ItemSupertipMember", typeof(string), typeof(ComboBox), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "ItemSupertipMember")));

        
        public bool ShowItemImage
        {
            get { return (bool)GetValue(ShowItemImageProperty); }
            set { SetValue(ShowItemImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowItemImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowItemImageProperty =
            DependencyProperty.Register("ShowItemImage", typeof(bool), typeof(ComboBox), new PropertyMetadata(true));
        

        public bool HasCollection()
        {
            return true;
        }


        private List<object> itemElements { get; } = new List<object>();

        public System.Collections.IEnumerable ItemsSource
        {
            get { return (System.Collections.IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(System.Collections.IEnumerable), typeof(ComboBox), new PropertyMetadata(null, (d, e) =>
            {
                if (d != null)
                {
                    var cmb = ((ComboBox)d);
                    if (e.OldValue != null && e.OldValue.GetType().GetInterface("INotifyCollectionChanged") != null)
                    {
                        var col = (INotifyCollectionChanged)e.NewValue;
                        col.CollectionChanged -= cmb.ItemsSource_CollectionChanged;
                    }
                    cmb.ItemsSource = (System.Collections.IEnumerable)e.NewValue;
                    if (e.NewValue != null)
                    {
                        if (e.NewValue.GetType().GetInterface("INotifyCollectionChanged") != null)
                        {
                            var col = (INotifyCollectionChanged)e.NewValue;
                            col.CollectionChanged += cmb.ItemsSource_CollectionChanged;
                        }
                        cmb.itemElements.Clear();
                        foreach (var x in (System.Collections.IEnumerable)e.NewValue)
                        {
                            cmb.itemElements.Add(x);
                        }
                    }
                }
            }));

        private void ItemsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            itemElements.Clear();
            foreach (var x in ItemsSource)
            {
                itemElements.Add(x);
            }
            NotifyChanged();
        }

        public List<Item> UiChild
        {
            get { return (List<Item>)GetValue(UiChildProperty); }
            set { SetValue(UiChildProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UiChild.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UiChildProperty =
            DependencyProperty.Register("UiChild", typeof(List<Item>), typeof(ComboBox), new PropertyMetadata(new List<Item>()));

    }
}
