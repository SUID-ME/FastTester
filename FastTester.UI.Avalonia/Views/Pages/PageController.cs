using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using FastTester.UI.Avalonia.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTester.UI.Avalonia.Views.Pages
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
                        newPage = new MainView();
                        break;
                    }
                case Page.TestList:
                    {
                        newPage = new TestListView();
                        break;
                    }
                case Page.TestEditorNew:
                    {
                        newPage = new TestEditorView();
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
