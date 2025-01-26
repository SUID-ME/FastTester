using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FastTester.Logic.Models;
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

    public void SetItem(AnswerItem item)
    {
        _vm.Item = item;
    }

    private AnserItemVM _vm;
}