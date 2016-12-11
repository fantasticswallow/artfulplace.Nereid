using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Nereid
{
    public class Binding : System.Windows.Data.Binding
    {
        public Binding()
            : base()
        {
            if (Source == null && RelativeSource == null && string.IsNullOrEmpty(ElementName))
            {
                this.RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.Self);
                if (this.Path == null)
                {
                    this.Path = new System.Windows.PropertyPath("DataContext");
                }
                else
                {
                    this.Path = new System.Windows.PropertyPath("DataContext." + this.Path.Path);
                }
                
                
            }
        }

        public Binding(string path)
            :base(path)
        {
            if (Source == null && RelativeSource == null && string.IsNullOrEmpty(ElementName))
            {
                this.RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.Self);
                if (this.Path == null)
                {
                    this.Path = new System.Windows.PropertyPath("DataContext");
                }
                else
                {
                    this.Path = new System.Windows.PropertyPath("DataContext." + this.Path.Path);
                }
            }
        }

    }
}
