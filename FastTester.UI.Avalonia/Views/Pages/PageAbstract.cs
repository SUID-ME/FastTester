using Avalonia.Controls;
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

        protected PageController? _pageController;
    }
}
