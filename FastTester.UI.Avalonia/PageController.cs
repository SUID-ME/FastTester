using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using FastTester.UI.Avalonia.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTester.UI.Avalonia
{
    public class PageController
    {
        public enum Page
        {
            MainMenu,
            TestList,
            TestEditorNew
        }

        public PageController(ContentPresenter presenter, Page startPage = Page.MainMenu)
        {
            _presenter = presenter;
            SwitchPage(startPage);
        }

        public void SwitchPage(Page page)
        {
            PageAbstract newPage = null;
            switch (page)
            {
                case Page.MainMenu:
                    {
                        newPage = new MainMenu();
                        break;
                    }
                case Page.TestList:
                    {
                        newPage = new TestsList();
                        break;
                    }
                case Page.TestEditorNew:
                    {
                        newPage = new TestEditor();
                        break;
                    }
            }

            if (newPage == null)
            {
                return;
            }
            newPage.Controller = this;
            _presenter.Content = newPage;
        }

        private ContentPresenter _presenter;
    }
}
