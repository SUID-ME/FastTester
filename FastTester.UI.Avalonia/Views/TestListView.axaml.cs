using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FastTester.UI.Avalonia.Views.Pages;

namespace FastTester.UI.Avalonia.Views;

public partial class TestListView : PageAbstract
{
    public TestListView()
    {
        InitializeComponent();
    }

    public void Click_MainMenu(object sender, RoutedEventArgs args)
    {
        _pageController?.SwitchPage(PageController.Page.MainMenu);
    }

    public void Click_AddTest(object sender, RoutedEventArgs args)
    {
        _pageController?.SwitchPage(PageController.Page.TestEditorNew);
    }
}