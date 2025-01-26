using FastTester.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTester.UI.Avalonia.ViewModels
{
    public class TestContentVM : ViewModelBase
    {
        public TestContent Item
        {
            get { return _testContent; }
            set
            {
                _testContent = value;
                OnPropertyChanged();
            }
        }

        public string TestName
        {
            get { return _testContent.TestName; }
            set
            {
                _testContent.TestName = value;
            }
        }

        private TestContent _testContent = new TestContent();
    }
}
