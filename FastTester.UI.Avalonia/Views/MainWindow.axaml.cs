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
        _logic = new TesterLogic();
        _pageController = new PageController(_logic, MainPresenter);
    }

    private PageController _pageController;
    private TesterLogic _logic;
}
