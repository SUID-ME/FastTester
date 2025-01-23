using FastTester.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTester.UI.Avalonia.ViewModels
{
    public class AnserItemVM : ViewModelBase
    {
        public AnswerItem Item
        {
            get { return _item; }
            set { _item = value;
                OnPropertyChanged();
            }
        }

        public AnswerItem _item = new AnswerItem();
    }
}
