using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Nereid
{
    public class RibbonEventArgs : EventArgs
    {
        public RibbonEventArgs(string id, string tag, object context)
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
        public RibbonCheckedEventArgs(string id, string tag, object context, bool isChecked)
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
        public RibbonTextChangedEventArgs(string id, string tag, object context, string text)
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
}
