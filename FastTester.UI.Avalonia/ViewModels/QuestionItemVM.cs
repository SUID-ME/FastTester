using FastTester.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTester.UI.Avalonia.ViewModels
{
    public class QuestionItemVM : ViewModelBase
    {
        public QuestionItem Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        private QuestionItem _item = new QuestionItem();
    }
}
