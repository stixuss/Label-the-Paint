using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Label_the_Paint.Core
{
    public class ObservableObject : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
