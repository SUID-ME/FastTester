using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using FastTester.Logic;
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

        public PageController(TesterLogic logic, ContentPresenter presenter, Page startPage = Page.MainMenu)
        {
            _presenter = presenter;
            _testerLogic = logic;
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
            newPage.SetLogic(_testerLogic);
            
            _presenter.Content = newPage;
        }

        private ContentPresenter _presenter;
        private TesterLogic _testerLogic;
    }
}
