using System;
using System.Windows.Input;

namespace Label_the_Paint.Core
{
    class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExectute;
        
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExectute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExectute == null || _canExectute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
