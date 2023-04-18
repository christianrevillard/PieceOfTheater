using Microsoft.Extensions.DependencyInjection;
using PieceofTheater.ViewModels;
using PieceofTheater.DependencyInjection;
using System.Windows.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PieceofTheater.Views
{
    public sealed partial class Characters : UserControl
    {
        public Characters()
        {
            this.InitializeComponent();
            var container = ApplicationServiceProvider.Instance;// ((App)App.Current).;
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(ICharactersViewModel));
        }
    }
}
