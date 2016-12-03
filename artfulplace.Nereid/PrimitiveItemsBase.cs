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
    public abstract class PrimitiveItemsBase : DependencyObject, INotifyNereidPropertyChanged
    {
        internal PrimitiveItemsBase()
        {
        }

        internal protected virtual Dictionary<string, string> CreateXmlAttributes()
        {
            var dic = new Dictionary<string, string>();
            var id = GetId();
            dic.Add(id.Item1, id.Item2);
            dic.Add("getVisible", "NereidControl_GetVisible");
            dic.Add("getLabel", "NereidControl_GetLabel");
            dic.Add("getKeytip", "NereidControl_GetKeytip");

            return dic;
        }

        // AG_ControlAttributes
        // AG_IDattributes

        #region enabled


        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Enabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.Register("Enabled", typeof(bool), typeof(PrimitiveItemsBase), new PropertyMetadata(true));



        #endregion

        #region idAttributes
        internal protected Tuple<string, string> GetId()
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

        public string GetKeytip()
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
            DependencyProperty.Register("Keytip", typeof(string), typeof(PrimitiveItemsBase), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "Keytip")));


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
            DependencyProperty.Register("Label", typeof(string), typeof(PrimitiveItemsBase), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "Label")));

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
            DependencyProperty.Register("Visible", typeof(bool), typeof(PrimitiveItemsBase), new PropertyMetadata(true, (d, e) => DependencyPropertyChanged(d, e, "Visible")));



        #region INotifyNereidPropertyChanged
        protected void notifyChanged()
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
            obj.notifyChanged();
        }
        #endregion

    }
}
