using Avalonia.Controls;
using Avalonia.Interactivity;
using FastTester.UI.Avalonia.Views.Pages;
using System;

namespace FastTester.UI.Avalonia.Views;

public partial class MainView : PageAbstract
{
    public MainView()
    {
        InitializeComponent();
    }

    public void Click_TestListView(object sender, RoutedEventArgs args)
    {
        if (_pageController == null)
        {
            return;
        }

        _pageController.SwitchPage(PageController.Page.TestList);
    }

    public void Click_WorkOnMistakes(object sender, RoutedEventArgs args)
    {

    }

    public void Click_Exit(object sender, RoutedEventArgs args)
    {
        Environment.Exit(0);
    }
}
