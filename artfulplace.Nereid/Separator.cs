using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace artfulplace.Nereid
{
    public class Separator : DataContextBase, Definitions.IGroupChild
    {
        public string GetRibbonXml()
        {
            var dic = new Dictionary<string, string>();
            var id = GetId();
            dic.Add(id.Item1, id.Item2);
            var pos = GetPosition();
            if (pos.Item1 != "")
            {
                dic.Add(pos.Item1, pos.Item2);
            }
            dic.Add("getVisible", "NereidSeparator_GetVisible");
            return XmlUtility.CreateXml("separator", dic);

        }

        public bool HasCollection()
        {
            return false;
        }

        internal Tuple<string, string> GetId()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return Tuple.Create("id", Id);
            }
            else if (!string.IsNullOrEmpty(IdQ))
            {
                return Tuple.Create("idQ", IdQ);
            }
            throw new InvalidOperationException("Must set id to Id or IdQ property.");
        }

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
            DependencyProperty.Register("Id", typeof(string), typeof(Separator), new PropertyMetadata(""));

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
            DependencyProperty.Register("IdQ", typeof(string), typeof(Separator), new PropertyMetadata(""));

        #region positions
        // insertAfterMso、insertAfterQ、insertBeforeMso、insertBeforeQ

        public string InsertBeforeMso
        {
            get { return (string)GetValue(InsertBeforeMsoProperty); }
            set { SetValue(InsertBeforeMsoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InsertBeforeMso.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InsertBeforeMsoProperty =
            DependencyProperty.Register("InsertBeforeMso", typeof(string), typeof(Separator), new PropertyMetadata(""));

        public string InsertBeforeQ
        {
            get { return (string)GetValue(InsertBeforeQProperty); }
            set { SetValue(InsertBeforeQProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InsertBeforeQ.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InsertBeforeQProperty =
            DependencyProperty.Register("InsertBeforeQ", typeof(string), typeof(Separator), new PropertyMetadata(""));

        public string InsertAfterMso
        {
            get { return (string)GetValue(InsertAfterMsoProperty); }
            set { SetValue(InsertAfterMsoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InsertAfterMso.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InsertAfterMsoProperty =
            DependencyProperty.Register("InsertAfterMso", typeof(string), typeof(Separator), new PropertyMetadata(""));

        public string InsertAfterQ
        {
            get { return (string)GetValue(InsertAfterQProperty); }
            set { SetValue(InsertAfterQProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InsertAfterQ.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InsertAfterQProperty =
            DependencyProperty.Register("InsertAfterQ", typeof(string), typeof(Separator), new PropertyMetadata(""));

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
            DependencyProperty.Register("Visible", typeof(bool), typeof(Separator), new PropertyMetadata(true, (d, e) => DependencyPropertyChanged(d, e, "Visible")));

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
}
