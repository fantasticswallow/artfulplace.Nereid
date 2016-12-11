using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace artfulplace.Nereid
{
    [ContentProperty("UiChild")]
    public class DropDown : GroupItemBase4, Definitions.IGroupChild
    {
        public DropDown()
        {
            SetValue(UiChildPropertyKey, new List<Item>());
        }

        // onAction
        //Shared with comboBox: getItemCount, getItemID, getItemImage, getItemLabel, getItemScreentip, getItemSupertip, showItemImage
        //Shared with editBox: sizeString
        //getSelectedItemID
        //getSelectedItemIndex
        //showItemLabel
        public string GetRibbonXml()
        {
            var param = CreateXmlAttributes();
            // param.Add("getImageMso", "NereidDropDown_GetImageMso");
            param.Add("onAction", "NereidDropDown_Changed");
            if (!string.IsNullOrEmpty(SizeString))
            {
                param.Add("sizeString", SizeString);
            }
            var val = ShowItemImage ? "1" : "0";
            param.Add("showItemImage", val);
            val = ShowItemLabel ? "1" : "0";
            param.Add("showItemLabel", val);
            var selectInfo = GetSelectionData();
            param.Add(selectInfo.Item1, selectInfo.Item2);
            if (ItemsSource != null)
            {
                // getItemCount, getItemID, getItemImage, getItemLabel, getItemScreentip, getItemSupertip
                param.Add("getItemCount", "NereidDropDown_GetItemCount");
                param.Add("getItemID", "NereidDropDown_GetItemID");
                // param.Add("getItemImage", "NereidDropDown_GetItemImage");
                param.Add("getItemLabel", "NereidDropDown_GetItemLabel");
                param.Add("getItemScreentip", "NereidDropDown_GetItemScreentip");
                param.Add("getItemSupertip", "NereidDropDown_GetItemSupertip");

                return XmlUtility.CreateXml("dropDown", param);
            }
            else
            {
                var head = XmlUtility.CreateHeadXml("dropDown", param);
                var foot = XmlUtility.CreateFootXml("dropDown");
                return head + string.Concat(UiChild.Select(x => x.GetRibbonXml()).ToArray()) + foot;
            }
        }

        public bool HasCollection()
        {
            return true;
        }

        #region editBox
        public string SizeString
        {
            get { return (string)GetValue(SizeStringProperty); }
            set { SetValue(SizeStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SizeString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeStringProperty =
            DependencyProperty.Register("SizeString", typeof(string), typeof(DropDown), new PropertyMetadata(""));
        #endregion

        #region comboBox 
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
            DependencyProperty.Register("ItemIdMember", typeof(string), typeof(DropDown), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "ItemIdMember")));

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
            DependencyProperty.Register("ItemLabelMember", typeof(string), typeof(DropDown), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "ItemLabelMember")));

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
            DependencyProperty.Register("ItemScreentipMember", typeof(string), typeof(DropDown), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "ItemScreentipMember")));

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
            DependencyProperty.Register("ItemSupertipMember", typeof(string), typeof(DropDown), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "ItemSupertipMember")));


        public bool ShowItemImage
        {
            get { return (bool)GetValue(ShowItemImageProperty); }
            set { SetValue(ShowItemImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowItemImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowItemImageProperty =
            DependencyProperty.Register("ShowItemImage", typeof(bool), typeof(DropDown), new PropertyMetadata(true));

        private List<object> itemElements { get; } = new List<object>();

        public System.Collections.IEnumerable ItemsSource
        {
            get { return (System.Collections.IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(System.Collections.IEnumerable), typeof(DropDown), new PropertyMetadata(null, (d, e) =>
            {
                if (d != null)
                {
                    var cmb = ((DropDown)d);
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
            private set { SetValue(UiChildPropertyKey, value); }
        }

        // Using a DependencyProperty as the backing store for UiChild.  This enables animation, styling, binding, etc...
        private static readonly DependencyPropertyKey UiChildPropertyKey =
            DependencyProperty.RegisterReadOnly("UiChild", typeof(List<Item>), typeof(DropDown), new PropertyMetadata(new List<Item>()));

        public static readonly DependencyProperty UiChildProperty = UiChildPropertyKey.DependencyProperty;
        #endregion

        internal void OnSelectionChanged(RibbonSelectionChangedEventArgs e)
        {
            this.SelectedId = e.SelectedId;
            this.SelectedIndex = e.SelectedIndex;
            SelectionChanged?.Invoke(this, e);
        }

        public delegate void DropDownSelectionChangedEventHandler(object sender, RibbonSelectionChangedEventArgs e);

        public event DropDownSelectionChangedEventHandler SelectionChanged;

        public bool ShowItemLabel
        {
            get { return (bool)GetValue(ShowItemLabelProperty); }
            set { SetValue(ShowItemLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowItemLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowItemLabelProperty =
            DependencyProperty.Register("ShowItemLabel", typeof(bool), typeof(DropDown), new PropertyMetadata(true));



        internal int GetSelectedIndex()
        {
            if (SelectedIndex >= itemElements.Count)
            {
                SelectedIndex = itemElements.Count - 1; 
            }
            if (SelectedIndex < 0)
            {
                SelectedIndex = 0;
            }
            return SelectedIndex;
        }

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(DropDown), new PropertyMetadata(0, (d, e) => DependencyPropertyChanged(d, e, "SelectedIndex")));

        internal string GetSelectedId()
        {
            return SelectedId;
        }


        public string SelectedId
        {
            get { return (string)GetValue(SelectedIdProperty); }
            set { SetValue(SelectedIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIdProperty =
            DependencyProperty.Register("SelectedId", typeof(string), typeof(DropDown), new PropertyMetadata(null, (d, e) => DependencyPropertyChanged(d, e, "SelectedId")));

        public enum SelectMode
        {
            None,
            Index,
            Id
        }

        public SelectMode SelectionMode
        {
            get { return (SelectMode)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectionMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectionModeProperty =
            DependencyProperty.Register("SelectionMode", typeof(SelectMode), typeof(DropDown), new PropertyMetadata(SelectMode.None));

        // getSelectedItemID, getSelectedItemIndex
        
        private Tuple<string, string> GetSelectionData()
        {
            // param.Add("getItemSupertip", "NereidComboBox_GetItemSupertip");

            switch (SelectionMode)
            {
                case SelectMode.Id:
                    return Tuple.Create("getSelectedItemID", "NereidDropDown_GetSelectedItemId");
                case SelectMode.Index:
                    return Tuple.Create("getSelectedItemIndex", "NereidDropDown_GetSelectedItemIndex");
                default:

                    if (SelectedId != null || BindingOperations.IsDataBound(this, SelectedIdProperty))
                    {
                        return Tuple.Create("getSelectedItemID", "NereidDropDown_GetSelectedItemId");
                    }
                    return Tuple.Create("getSelectedItemIndex", "NereidDropDown_GetSelectedItemIndex");
            }
        }

    }
}
