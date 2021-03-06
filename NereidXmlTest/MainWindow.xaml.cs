﻿using System;
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
using System.Xml.Linq;

namespace NereidXmlTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var obj = new NereidTest();
            var ext = new artfulplace.Nereid.RibbonExtensibility(obj);
            textBox.DataContext = ext.GetCustomUI("");
            // var binds = BindingOperations.GetSourceUpdatingBindings(textBox);
            var localEnumerator = textBox.GetLocalValueEnumerator();
            var bind = BindingOperations.GetBinding(textBox, TextBox.TextProperty);

        }
    }
}
