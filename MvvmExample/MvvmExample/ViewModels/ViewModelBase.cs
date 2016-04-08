using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace MvvmExample.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private readonly Dispatcher _uiDispatcher;

        protected ViewModelBase(Dispatcher uiDispatcher)
        {
            _uiDispatcher = uiDispatcher;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged == null)
            {
                return;
            }

            _uiDispatcher.Invoke(() => propertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName)));
        }
    }
}
