using System;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using NotepadClone.Commands;
using NotepadClone.Controls;
using NotepadClone.ViewModel;
using Windows.UI.Core.Preview;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NotepadClone
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : WindowEx
    {
        private DocumentViewModel DocumentViewModel { get; } = new();

        public MainWindow()
        {
            this.InitializeComponent();
            this.Closing += MainWindow_Closing;
        }

        private async void MainWindow_Closing(object sender, WindowClosingEventArgs e)
        {
            ContentDialog dialog = new()
            {
                Title = "NotepadClone",
                Content = $"Do you want to save changes to {DocumentViewModel.Title}?",
                XamlRoot = this.Content.XamlRoot,
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "No",
                CloseButtonText = "Cancel",
                IsPrimaryButtonEnabled = true,
                DefaultButton = ContentDialogButton.Primary,
            };
            var dialogResult = await dialog.ShowAsync();
            switch (dialogResult)
            {
                // Yes
                case ContentDialogResult.Primary:
                    e.TryCancel();
                    break;
                // No
                case ContentDialogResult.Secondary:
                    e.TryCancel();
                    break;
                // Cancel
                default:
                    break;
            }

        }
    }
}
