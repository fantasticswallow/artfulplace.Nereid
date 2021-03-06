﻿using artfulplace.Nereid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace NereidXmlTest
{
    /// <summary>
    /// NereidTest.xaml の相互作用ロジック
    /// </summary>
    public partial class NereidTest : artfulplace.Nereid.CustomUI
    {
        public NereidTest()
        {
            InitializeComponent();
            this.DataContext = Tuple.Create("hjkl", "xyz");
        }

        private void Button_Click(object arg1, RibbonEventArgs arg2)
        {
            Debug.WriteLine("aaa");
        }

        private void Button_Click_1(object arg1, RibbonEventArgs arg2)
        {
            Debug.WriteLine("bbb");
        }

        private void Button_Click_2(object arg1, RibbonEventArgs arg2)
        {
            Debug.WriteLine("cccc");
        }
    }
}
