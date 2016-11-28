using System.Windows;
using Lineyschikov.WpfAssignment.Desktop.ViewModels;

namespace Lineyschikov.WpfAssignment.Desktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowView
    {
        public MainWindow(IMainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

    }
}
