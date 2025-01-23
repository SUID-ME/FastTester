using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using FastTester.UI.Avalonia.Views.Pages;
using FastTester.Logic;

namespace FastTester.UI.Avalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        _pageController = new PageController(MainPresenter);
        _logic = new TesterLogic();
    }

    private PageController _pageController;
    private TesterLogic _logic;
}
