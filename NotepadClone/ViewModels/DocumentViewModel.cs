using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NotepadClone.Commands;
using NotepadClone.Model;

namespace NotepadClone.ViewModel
{
    public class DocumentViewModel : INotifyPropertyChanged
    {
        private Document _document;

        public readonly ICommand OpenDialogCommand;
        public readonly ICommand SaveDialogCommand;

        public DocumentViewModel()
        {
            _document = new();

            OpenDialogCommand = new OpenDialogCommand(this);
            SaveDialogCommand = new SaveDialogCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new(propertyName));
        }

        internal string Title
        {
            get { return _document.Title; }
            set
            {
                if (_document.Title == value) return;

                _document.Title = value;
                NotifyPropertyChanged();
            }
        }

        internal string Text
        {
            get { return _document.Text; }
            set
            {
                if (_document.Text == value) return;

                _document.Text = value;
                NotifyPropertyChanged();
            }
        }
    }
}
