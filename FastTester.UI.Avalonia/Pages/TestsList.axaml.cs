using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace FastTester.UI.Avalonia.Pages;

public partial class TestsList : PageAbstract
{
    public TestsList()
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