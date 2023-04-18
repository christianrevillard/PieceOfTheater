using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PieceofTheater.Lib.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value) || string.IsNullOrEmpty(propertyName))
            {
                return false;
            }
            storage = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}