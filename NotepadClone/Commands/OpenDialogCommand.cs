using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using NotepadClone.ViewModel;
using WinRT.Interop;

namespace NotepadClone.Commands
{
    public class OpenDialogCommand : Command
    {
        public OpenDialogCommand(DocumentViewModel vm) : base(vm)
        {
        }

        public override async void Execute(object parameter)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker()
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary,
            };
            picker.FileTypeFilter.Add(".txt");

            InitializeWithWindow.Initialize(picker, Controls.WindowEx.Handle);

            var file = await picker.PickSingleFileAsync();
            if (file is null) return;
            m_vm.Text = File.ReadAllText(file.Path);
            m_vm.Title = file.Name;
        }
    }
}
