using Microsoft.Extensions.DependencyInjection;
using PieceofTheater.Lib.DependencyInjection;
using PieceofTheater.Lib.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PieceOfTheater.Uwp.Views
{
    public sealed partial class Table : UserControl
    {
        public Table()
        {
            this.InitializeComponent();
            var container = ApplicationServiceProvider.Instance;
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(ITableViewModel));
        }
    }
}
