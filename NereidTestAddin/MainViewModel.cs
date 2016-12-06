using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NereidTestAddin
{
    public class MainViewModel : BindableBase
    {
        private MainViewModel()
        {
        }

        public static MainViewModel Instance { get; } = new MainViewModel();

        private string _testButton1Label = "";
        public string TestButton1Label
        {
            get { return _testButton1Label; }
            set
            {
                _testButton1Label = value;
                notifyChanged();
            }
        }

        public ObservableCollection<string> ComboBoxItems { get; } = new ObservableCollection<string>();

        private string _editBoxText = "";
        public string EditBoxText
        {
            get { return _editBoxText; }
            set
            {
                _editBoxText = value;
                notifyChanged();
            }
        }

    }

    public abstract class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// 呼び出し元のProperty名が変更されたことを通知します
        /// </summary>
        /// <param name="name"></param>
        protected void notifyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

        /// <summary>
        /// 指定したプロパティ名のプロパティが変更されたことを通知します
        /// </summary>
        /// <param name="name"></param>
        protected void notifyChanged2(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
