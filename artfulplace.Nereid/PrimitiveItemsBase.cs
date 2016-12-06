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
    public abstract class IdAttributesBase : DependencyObject
    {
        #region idAttributes
        internal Tuple<string, string> GetId()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return Tuple.Create("id", Id);
            }
            else if (!string.IsNullOrEmpty(IdMso))
            {
                return Tuple.Create("idMso", IdMso);
            }
            else if (!string.IsNullOrEmpty(IdQ))
            {
                return Tuple.Create("idQ", IdQ);
            }
            throw new InvalidOperationException("Must set id to Id, IdMso or IdQ property.");
        }


        public string IdMso
        {
            get { return (string)GetValue(IdMsoProperty); }
            set { SetValue(IdMsoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IdMso.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdMsoProperty =
            DependencyProperty.Register("IdMso", typeof(string), typeof(PrimitiveItemsBase), new PropertyMetadata(""));

        /// <summary>
        /// Control Id.
        /// </summary>
        public string Id
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(string), typeof(PrimitiveItemsBase), new PropertyMetadata(""));

        /// <summary>
        /// Control Id with Namespace. Other addins reference to Control setted IdQ.
        /// </summary>
        public string IdQ
        {
            get { return (string)GetValue(IdQProperty); }
            set { SetValue(IdQProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IdQ.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdQProperty =
            DependencyProperty.Register("IdQ", typeof(string), typeof(PrimitiveItemsBase), new PropertyMetadata(""));
        #endregion
    }

    /// <summary>
    /// Ribbon Item base, has IdAttributes and PositionAttributes.
    /// </summary>
    public abstract class PrimitiveItemsBase : IdAttributesBase, INotifyNereidPropertyChanged
    {
        internal PrimitiveItemsBase()
        {
        }

        internal protected virtual Dictionary<string, string> CreateXmlAttributes()
        {
            var dic = new Dictionary<string, string>();
            var id = GetId();
            dic.Add(id.Item1, id.Item2);
            var pos = GetPosition();
            if (pos.Item1 != "")
            {
                dic.Add(pos.Item1, pos.Item2);
            }
            return dic;
        }

        // AG_ControlAttributes
        // AG_IDattributes

        #region positions
        // insertAfterMso、insertAfterQ、insertBeforeMso、insertBeforeQ
        
        public string InsertBeforeMso
        {
            get { return (string)GetValue(InsertBeforeMsoProperty); }
            set { SetValue(InsertBeforeMsoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InsertBeforeMso.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InsertBeforeMsoProperty =
            DependencyProperty.Register("InsertBeforeMso", typeof(string), typeof(PrimitiveItemsBase), new PropertyMetadata(""));
        
        public string InsertBeforeQ
        {
            get { return (string)GetValue(InsertBeforeQProperty); }
            set { SetValue(InsertBeforeQProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InsertBeforeQ.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InsertBeforeQProperty =
            DependencyProperty.Register("InsertBeforeQ", typeof(string), typeof(PrimitiveItemsBase), new PropertyMetadata(""));
        
        public string InsertAfterMso
        {
            get { return (string)GetValue(InsertAfterMsoProperty); }
            set { SetValue(InsertAfterMsoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InsertAfterMso.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InsertAfterMsoProperty =
            DependencyProperty.Register("InsertAfterMso", typeof(string), typeof(PrimitiveItemsBase), new PropertyMetadata(""));
        
        public string InsertAfterQ
        {
            get { return (string)GetValue(InsertAfterQProperty); }
            set { SetValue(InsertAfterQProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InsertAfterQ.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InsertAfterQProperty =
            DependencyProperty.Register("InsertAfterQ", typeof(string), typeof(PrimitiveItemsBase), new PropertyMetadata(""));

        internal Tuple<string, string> GetPosition()
        {
            if (!string.IsNullOrEmpty(InsertBeforeMso))
            {
                return Tuple.Create("insertBeforeMso", InsertBeforeMso);
            }
            else if (!string.IsNullOrEmpty(InsertBeforeQ))
            {
                return Tuple.Create("insertBeforeQ", InsertBeforeQ);
            }
            else if (!string.IsNullOrEmpty(InsertAfterMso))
            {
                return Tuple.Create("insertAfterMso", InsertAfterMso);
            }
            else if (!string.IsNullOrEmpty(InsertAfterQ))
            {
                return Tuple.Create("insertAfterQ", InsertAfterQ);
            }
            return Tuple.Create("", "");
        }

        #endregion
        
        

        #region INotifyNereidPropertyChanged
        internal protected void NotifyChanged()
        {
            var id = GetId();
            PropertyChanged?.Invoke(id.Item2);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public event Action<string> PropertyChanged;

        internal static void DependencyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e, string propertyName)
        {
            var obj = (PrimitiveItemsBase)d;
            d.GetType().GetProperty(propertyName).SetValue(d, e.NewValue);
            obj.NotifyChanged();
        }
        #endregion

    }

    public abstract class TabItemBase : PrimitiveItemsBase
    {

        protected internal override Dictionary<string, string> CreateXmlAttributes()
        {
            var dic = base.CreateXmlAttributes();
            dic.Add("getVisible", "NereidControl_GetVisible");
            dic.Add("getLabel", "NereidControl_GetLabel");
            dic.Add("getKeytip", "NereidControl_GetKeytip");
            return dic;
        }
        internal string GetKeytip()
        {
            return Keytip;
        }

        public string Keytip
        {
            get { return (string)GetValue(KeytipProperty); }
            set { SetValue(KeytipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Keytip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeytipProperty =
            DependencyProperty.Register("Keytip", typeof(string), typeof(TabItemBase), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "Keytip")));


        internal string GetLabel()
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
            DependencyProperty.Register("Label", typeof(string), typeof(TabItemBase), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "Label")));

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
            DependencyProperty.Register("Visible", typeof(bool), typeof(TabItemBase), new PropertyMetadata(true, (d, e) => DependencyPropertyChanged(d, e, "Visible")));


    }
}
