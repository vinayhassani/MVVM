using System;
using System.Windows.Input;

namespace MVVMDemo.Command
{
    public class RelayCommand : ICommand
    {
        Action<object> executeActon;
        Func<object, bool> canExecute;
        bool canExecuteCache;

        public RelayCommand(Action<object> executeActon,Func<object, bool> canExecute,bool canExecuteCache)
        {
            this.canExecute = canExecute;
            this.executeActon = executeActon;
            canExecuteCache = canExecuteCache;
        }
       
        public bool CanExecute(object parameter)
        {
           if(canExecute == null)
            {
                return true;
            }
           else
            {
                return canExecute(parameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
              }
            remove
            {
               
                CommandManager.RequerySuggested += value;
            }
        }

        public void Execute(object parameter)
        {
            executeActon(parameter);
        }
    }
}
