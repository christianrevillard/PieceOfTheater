using Microsoft.Extensions.DependencyInjection;
using PieceofTheater.ViewModels;
using System.Windows.Controls;
using PieceofTheater.DependencyInjection;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PieceofTheater.Views
{
    public sealed partial class PlayText : UserControl
    {
        public PlayText()
        {
            this.InitializeComponent();
            var container = ApplicationServiceProvider.Instance;// ((App)App.Current).;
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(IPlayTextViewModel));
        }
    }
}
