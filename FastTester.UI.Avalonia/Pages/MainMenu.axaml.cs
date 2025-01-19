using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace FastTester.UI.Avalonia.Pages;

public partial class MainMenu : PageAbstract
{
    public MainMenu()
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