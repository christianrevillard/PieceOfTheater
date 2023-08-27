using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using PieceofTheater.Lib.DependencyInjection;
using PieceofTheater.Lib.ViewModels;

namespace PieceofTheater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var container = ApplicationServiceProvider.Instance;// ((App)App.Current).;
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(IMainViewModel));
        }
    }
}
