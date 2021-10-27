using Label_the_Paint.Core;
using Label_the_Paint.MVVM.Model;
using System.Windows.Input;

namespace Label_the_Paint.MVVM.ViewModel
{
    class MainWindowViewModel : ObservableObject
    {
        public Label Label { get; set; }
        public ICommand PrintLabel { get; set; }

        public MainWindowViewModel()
        {
            Label = new Label();

            PrintLabel = new RelayCommand(ExecutePrintLabel, CanExecutePrintLabel);
        }

        public bool CanExecutePrintLabel(object parameter)
        {
            return true;
        }

        public void ExecutePrintLabel(object parameter)
        {
            //TO DO - Run window with a print preview

        }
    }
}
