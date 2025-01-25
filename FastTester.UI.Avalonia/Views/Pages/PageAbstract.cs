using Avalonia.Controls;
using FastTester.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTester.UI.Avalonia.Views.Pages
{
    public abstract class PageAbstract : UserControl
    {
        public PageController Controller { set { _pageController = value; } }
        public void SetLogic(TesterLogic logic)
        {
            _testerLogic = logic;
        }

        protected PageController? _pageController;
        protected TesterLogic _testerLogic;
    }
}
