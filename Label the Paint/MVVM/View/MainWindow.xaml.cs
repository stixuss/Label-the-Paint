using Label_the_Paint.MVVM.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Label_the_Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel _mvm = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _mvm;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
