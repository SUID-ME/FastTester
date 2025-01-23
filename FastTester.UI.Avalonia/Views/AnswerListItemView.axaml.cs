using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FastTester.UI.Avalonia.ViewModels;

namespace FastTester.UI.Avalonia.Views;

public partial class AnswerListItemView : UserControl
{
    public AnswerListItemView()
    {
        InitializeComponent();
        _vm = new AnserItemVM();
        DataContext = _vm;
    }

    private AnserItemVM _vm;
}