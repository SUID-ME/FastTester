using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using System.Diagnostics;
using System.IO;

namespace FastTester.UI.Avalonia.Pages;

public partial class TestEditor : PageAbstract
{
    public TestEditor()
    {
        InitializeComponent();
    }

    public void Click_Back(object sender, RoutedEventArgs args)
    {
        _pageController.SwitchPage(PageController.Page.TestList);
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
            Debug.Write(fileContent);
        }
    }
}