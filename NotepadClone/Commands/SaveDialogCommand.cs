using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NotepadClone.ViewModel;
using WinRT.Interop;

namespace NotepadClone.Commands
{
    public class SaveDialogCommand : Command
    {
        public SaveDialogCommand(DocumentViewModel vm) : base(vm)
        {
        }

        public override async void Execute(object parameter)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker()
            {
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary,
                SuggestedFileName = "New document",
            };
            picker.FileTypeChoices.Add("Plain text", new List<string>() { ".txt", ".text" });

            InitializeWithWindow.Initialize(picker, WindowNative.GetWindowHandle(MainWindow.Handle));

            var file = await picker.PickSaveFileAsync();
            if (file is null) return;
            File.WriteAllText(file.Path, m_vm.Text);
            m_vm.Title = file.Name;
        }
    }
}
