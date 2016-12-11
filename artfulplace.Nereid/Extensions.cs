using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace artfulplace.Nereid
{
    public static class Extensions
    {
        public static IEnumerable<System.Windows.Data.Binding> GetBindingAll(this DependencyObject target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            LocalValueEnumerator localValueEnumerator = target.GetLocalValueEnumerator();
            var list = new List<System.Windows.Data.Binding>();
            while (localValueEnumerator.MoveNext())
            {
                LocalValueEntry current = localValueEnumerator.Current;
                if (System.Windows.Data.BindingOperations.IsDataBound(target, current.Property))
                {
                    list.Add(System.Windows.Data.BindingOperations.GetBinding(target, current.Property));
                }
            }
            return list;
        }


        public static void SetDataContext(this Definitions.IRibbonItem item, object val)
        {
            item.DataContext = val;
            if (item is DependencyObject)
            {
                var target = (DependencyObject)item;
                LocalValueEnumerator localValueEnumerator = target.GetLocalValueEnumerator();
                while (localValueEnumerator.MoveNext())
                {
                    LocalValueEntry current = localValueEnumerator.Current;
                    if (System.Windows.Data.BindingOperations.IsDataBound(target, current.Property))
                    {
                        var bind = System.Windows.Data.BindingOperations.GetBinding(target, current.Property);
                        if (bind.Source == null)
                        {
                            System.Windows.Data.BindingOperations.GetBindingExpression(target, current.Property).UpdateTarget();
                        }
                    }
                }

                if (item.HasCollection())
                {
                    var items = (IEnumerable<Definitions.IRibbonItem>)item.GetType().GetProperty("UiChild").GetValue(item);
                    foreach (var it in items)
                    {
                        SetDataContext(it,val);
                    }
                }
                else
                {
                    var prop = item.GetType().GetProperty("UiChild");

                    if (prop != null)
                    {
                        SetDataContext((Definitions.IRibbonItem)prop.GetValue(item),val);
                    }
                }
            }
            
        }
    }
}
