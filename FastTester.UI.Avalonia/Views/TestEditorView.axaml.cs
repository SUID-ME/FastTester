using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using FastTester.Logic.Models;
using FastTester.UI.Avalonia.ViewModels;
using FastTester.UI.Avalonia.Views.Pages;
using System.IO;

namespace FastTester.UI.Avalonia.Views;

public partial class TestEditorView : PageAbstract
{
    public TestEditorView()
    {
        InitializeComponent();
        Button_SaveTest.IsEnabled = false;
        _vm = new TestContentVM();
        DataContext = _vm;
    }

    public void Click_Back(object sender, RoutedEventArgs args)
    {
        _pageController?.SwitchPage(PageController.Page.TestList);
    }
    
    public void Click_SaveTest(object sender, RoutedEventArgs args)
    {
        if (_vm.Item.QuestionItems == null || _vm.Item.QuestionItems.Count == 0)
        {
            return;
        }

        _testerLogic.AddTest(_vm.Item);
        _testerLogic.SaveTests();
    }

    public void Click_Debug(object sender, RoutedEventArgs args)
    {

    }

    public async void Click_FileLoad(object sender, RoutedEventArgs args)
    {
        // Get top level from the current control. Alternatively, you can use Window reference instead.
        var topLevel = TopLevel.GetTopLevel(this);

        // Start async operation to open the dialog.
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open Text File",
            AllowMultiple = false
        });

        if (files.Count >= 1)
        {
            // Open reading stream from the first file.
            await using var stream = await files[0].OpenReadAsync();
            using var streamReader = new StreamReader(stream);
            // Reads all the content of file as a text.
            var fileContent = await streamReader.ReadToEndAsync();
            if (_testerLogic == null)
            {
                return;
            }

            _testerLogic.Parser.OnParseComplete += _fillListBox;
            _ = _testerLogic.TestParse(fileContent);
        }
    }

    private void _fillListBox(TestContent content)
    {
        Dispatcher.UIThread.Post(() =>
        {
            _fillListBoxUIThread(content);
        });
    }

    private void _fillListBoxUIThread(TestContent content)
    {
        if (content == null)
        {
            return;
        }

        content.TestName = _vm.Item.TestName;
        _vm.Item = content;
        ListBox_QuestionsList.Items.Clear();
        foreach (var item in _vm.Item.QuestionItems)
        {
            QuestionListItemView questionView = new QuestionListItemView();
            questionView.SetItem(item);
            ListBox_QuestionsList.Items.Add(questionView);
        }
    }

    private void _checkIsTestSaveAvalable()
    {
        if (_vm.Item.QuestionItems != null && _vm.Item.QuestionItems.Count > 0)
        {
            Button_SaveTest.IsEnabled = true;
        } else
        {
            Button_SaveTest.IsEnabled = false;
        }
    }

    //private TestContent _currentTest = new TestContent();
    private TestContentVM _vm;
}