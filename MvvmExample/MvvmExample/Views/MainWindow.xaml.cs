using System.Windows;
using MvvmExample.ViewModels;

namespace MvvmExample.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel(Dispatcher);
        }
    }
}
