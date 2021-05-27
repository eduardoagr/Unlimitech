using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace test.ViewModel {
    public class ViewModelBase : INotifyPropertyChanged {

        #region Notify Property Changed Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
