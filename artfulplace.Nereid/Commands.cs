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
    public class Commands : DependencyObject, Definitions.IRibbonStricts
    {
        public string GetRibbonXml()
        {
            // Commands is not returned xml, because command.onAction can't define.
            return "";
        }

        public List<Command> UiChild
        {
            get { return (List<Command>)GetValue(UiChildProperty); }
            set { SetValue(UiChildProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UiChild.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UiChildProperty =
            DependencyProperty.Register("UiChild", typeof(List<Command>), typeof(Commands), new PropertyMetadata(new List<Command>()));

        public bool HasCollection()
        {
            return true;
        }

        public object DataContext
        {
            get { return (object)GetValue(DataContextProperty); }
            set { SetValue(DataContextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataContext.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.Register("DataContext", typeof(object), typeof(Command), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, (d, e) => ((Commands)d).DataContext = e.NewValue));


    }

    public class Command : DependencyObject, Definitions.IRibbonItem
    {


        public string IdMso 
        {
            get { return (string)GetValue(IdMsoProperty); }
            set { SetValue(IdMsoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for .  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdMsoProperty =
            DependencyProperty.Register("IdMso", typeof(string), typeof(Command), new PropertyMetadata(""));

        public string GetRibbonXml()
        {
            var param = new Dictionary<string,string>();
            param.Add("idMso", IdMso);
            param.Add("onAction", "NereidCommand_Action");
            param.Add("getEnabled", "NereidCommand_GetEnabled");
            return XmlUtility.CreateXml("command", param);
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
            DependencyProperty.Register("Enabled", typeof(bool), typeof(Command), new PropertyMetadata(true, (d, e) => DependencyPropertyChanged(d, e, "Enabled")));

        public bool HasCollection()
        {
            return false;
        }
        public object DataContext
        {
            get { return (object)GetValue(DataContextProperty); }
            set { SetValue(DataContextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataContext.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.Register("DataContext", typeof(object), typeof(Command), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, (d, e) => ((Command)d).DataContext = e.NewValue));

        #region INotifyNereidPropertyChanged
        internal protected void NotifyChanged()
        {
            PropertyChanged?.Invoke(IdMso);
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
