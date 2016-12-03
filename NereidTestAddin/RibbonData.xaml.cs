using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using artfulplace.Nereid;
using System.Diagnostics;

namespace NereidTestAddin
{
    /// <summary>
    /// RibbonData.xaml の相互作用ロジック
    /// </summary>

    public partial class RibbonData : CustomUI
    {
        public RibbonData()
        {
            InitializeComponent();
        }

        private void Button_Click(object arg1, RibbonEventArgs arg2)
        {
            Debug.WriteLine("aaa");
        }

        private void Button_Click_1(object arg1, RibbonEventArgs arg2)
        {
            MainViewModel.Instance.TestButton1Label = "bcbc";
        }

        private void Button_Click_2(object arg1, RibbonEventArgs arg2)
        {
            Debug.WriteLine("cccc");
        }
    }
}
