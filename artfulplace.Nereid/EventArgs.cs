using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Nereid
{
    public class ButtonEventArgs : EventArgs
    {
        public ButtonEventArgs(string id, string tag, object context)
        {
            Id = id;
            Tag = tag;
            Context = context;
        }

        public object Context { get; private set; }
        public string Id { get; private set; }
        public string Tag { get; private set; }

    }
}
