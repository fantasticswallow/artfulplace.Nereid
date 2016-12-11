using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Nereid
{
    public class RibbonEventArgs : EventArgs
    {
        internal RibbonEventArgs(string id, string tag, object context)
        {
            Id = id;
            Tag = tag;
            Context = context;
        }

        public object Context { get; private set; }
        public string Id { get; private set; }
        public string Tag { get; private set; }

    }

    public class RibbonCheckedEventArgs : EventArgs
    {
        internal RibbonCheckedEventArgs(string id, string tag, object context, bool isChecked)
        {
            Id = id;
            Tag = tag;
            Context = context;
            IsChecked = isChecked;
        }

        public object Context { get; private set; }
        public string Id { get; private set; }
        public string Tag { get; private set; }
        public bool IsChecked { get; private set; }

    }

    public class RibbonTextChangedEventArgs : EventArgs
    {
        internal RibbonTextChangedEventArgs(string id, string tag, object context, string text)
        {
            Id = id;
            Tag = tag;
            Context = context;
            Text = text;
        }

        public object Context { get; private set; }
        public string Id { get; private set; }
        public string Tag { get; private set; }
        public string Text { get; private set; }

    }

    public class RibbonSelectionChangedEventArgs : EventArgs
    {
        internal RibbonSelectionChangedEventArgs(string id, string tag, object context, string selectedId, int index)
        {
            Id = id;
            Tag = tag;
            Context = context;
            SelectedId = selectedId;
            SelectedIndex = index;
        }

        public object Context { get; private set; }
        public string Id { get; private set; }
        public string Tag { get; private set; }
        public string SelectedId { get; private set; }
        public int SelectedIndex { get; private set; }

    }
}
