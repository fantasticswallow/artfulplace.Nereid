using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace artfulplace.Nereid
{
    public class EditBox : GroupItemBase2, Definitions.IGroupChild
    {
        // getImage, getImageMso, getShowImage, getShowLabel, image, imageMso, showImage, showLabel
        public string GetRibbonXml()
        {
            var param = CreateXmlAttributes();
            param.Add("onChange", "NereidEditBox_Changed");
            param.Add("getText", "NereidEditBox_GetText");
            if (MaxString > 0)
            {
                param.Add("maxString", MaxString.ToString());
            }
            if (!string.IsNullOrEmpty(SizeString))
            {
                param.Add("sizeString", SizeString);
            }
            return XmlUtility.CreateXml("editBox", param);
        }


        #region EditBox Attributes
        public string SizeString
        {
            get { return (string)GetValue(SizeStringProperty); }
            set { SetValue(SizeStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SizeString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeStringProperty =
            DependencyProperty.Register("SizeString", typeof(string), typeof(EditBox), new PropertyMetadata(""));
        
        public int MaxString
        {
            get { return (int)GetValue(MaxStringProperty); }
            set { SetValue(MaxStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxStringProperty =
            DependencyProperty.Register("MaxString", typeof(int), typeof(EditBox), new PropertyMetadata(-1));

        internal string GetText()
        {
            return Text;
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(EditBox), new PropertyMetadata("", (d, e) => DependencyPropertyChanged(d, e, "Text")));

        internal void OnTextChanged(RibbonTextChangedEventArgs e)
        {
            this.Text = e.Text;
            TextChanged?.Invoke(this, e);
        }

        public delegate void EditBoxTextChangedEventHandler(object sender, RibbonTextChangedEventArgs e);

        public event EditBoxTextChangedEventHandler TextChanged;
        #endregion

        public bool HasCollection()
        {
            return false;
        }
    }
}
