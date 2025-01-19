using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using FastTester.UI.Avalonia.Pages;

namespace FastTester.UI.Avalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        _pageController = new PageController(MainPresenter);
    }

    private PageController _pageController;
}
