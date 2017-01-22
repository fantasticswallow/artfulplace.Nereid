using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Nereid
{
    public class Menu : GroupItemBase3, Definitions.IRibbonItem
    {
        public string GetRibbonXml()
        {
            throw new NotImplementedException();
        }

        public bool HasCollection()
        {
            
            return true;

        }

        // getImage, getImageMso,  getSize,
        // image, imageMso, size, tag
        // itemSize

        

    }
}
