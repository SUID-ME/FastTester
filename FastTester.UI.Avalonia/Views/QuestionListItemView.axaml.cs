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

    public void SetItem(QuestionItem item)
    {
        StackPanel_AnswerList.Children.Clear();
        _vm.Item = item;
        foreach (var answer in item.Answers)
        {
            AnswerListItemView answerView = new AnswerListItemView();
            answerView.SetItem(answer);
            StackPanel_AnswerList.Children.Add(answerView);
        }
    }

    private QuestionItemVM _vm;
}