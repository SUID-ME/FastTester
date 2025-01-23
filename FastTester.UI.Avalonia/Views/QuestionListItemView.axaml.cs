using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FastTester.Logic.Models;
using FastTester.UI.Avalonia.ViewModels;

namespace FastTester.UI.Avalonia.Views;

public partial class QuestionListItemView : UserControl
{
    public QuestionListItemView()
    {
        InitializeComponent();
        _vm = new QuestionItemVM();
        DataContext = _vm;
    }

    private QuestionItemVM _vm;
}