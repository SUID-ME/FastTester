using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using FastTester.Logic.Models;
using FastTester.UI.Avalonia.Views.Pages;
using System.IO;

namespace FastTester.UI.Avalonia.Views;

public partial class TestEditorView : PageAbstract
{
    public TestEditorView()
    {
        InitializeComponent();
    }

    public void Click_Back(object sender, RoutedEventArgs args)
    {
        _pageController?.SwitchPage(PageController.Page.TestList);
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
        ListBox_QuestionsList.Items.Clear();
        foreach (var item in content.QuestionItems)
        {
            QuestionListItemView questionView = new QuestionListItemView();
            questionView.SetItem(item);
            ListBox_QuestionsList.Items.Add(questionView);
        }
    }
}