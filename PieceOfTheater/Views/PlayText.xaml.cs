using Microsoft.Extensions.DependencyInjection;
using PieceOfTheater.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PieceOfTheater.Views
{
    public sealed partial class PlayText : UserControl
    {
        public PlayText()
        {
            this.InitializeComponent();
            var container = ((App)App.Current).Container;
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(IPlayTextViewModel));
        }
    }
}
