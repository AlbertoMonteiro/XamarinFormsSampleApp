using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProposalAppXamarin.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            params string[] otherProps)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName, otherProps);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "", params string[] otherProps)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            foreach (var otherProp in otherProps)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(otherProp));
        }
        #endregion
    }
}