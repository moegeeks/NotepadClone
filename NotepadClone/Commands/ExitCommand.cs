using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotepadClone.ViewModel;

namespace NotepadClone.Commands
{
    public class ExitCommand : Command
    {
        public ExitCommand(DocumentViewModel vm) : base(vm)
        {
        }
        public override void Execute(object parameter)
        {

        }
    }
}
