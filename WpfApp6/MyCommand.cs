using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp6
{
    public class MyCommand : ICommand
    {
        public Action<string> Function { get; set; }


        public bool CanExecute(object parameter)
        {
            return Function != null;
        }

        public void Execute(object parameter)
        {
            if (Function != null)
            {
                var str = parameter as string;
                Function(str);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
