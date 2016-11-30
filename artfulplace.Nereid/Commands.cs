using System;
using System.Collections.Generic;
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
            DependencyProperty.Register("IdMso", typeof(string), typeof(Command), new PropertyMetadata(0));

        public string GetRibbonXml()
        {
            throw new NotImplementedException();
        }

        public bool HasCollection()
        {
            return false;
        }
    }
}
