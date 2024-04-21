using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NotepadClone.ViewModel;

namespace NotepadClone.Commands
{
    public class Command : ICommand
    {
        protected readonly DocumentViewModel m_vm;

        public Command(DocumentViewModel vm)
        {
            // このクラスが直接初期化された場合、例外を投げる
            if ((this.GetType() == typeof(Command)))
                throw new Exception($"{nameof(Command)} cannot be instantiated directly.");

            if (vm is null) 
                throw new ArgumentNullException(nameof(vm));

            m_vm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) { return true; }

        public virtual void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
