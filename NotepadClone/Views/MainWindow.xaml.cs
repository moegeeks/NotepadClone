using System.Windows.Input;
using Microsoft.UI.Xaml;
using NotepadClone.Commands;
using NotepadClone.ViewModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NotepadClone
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public static MainWindow Handle { get; private set; }
        private DocumentViewModel DocumentViewModel { get; } = new();

        public MainWindow()
        {
            this.InitializeComponent();
            Handle = this;
        }
    }
}
