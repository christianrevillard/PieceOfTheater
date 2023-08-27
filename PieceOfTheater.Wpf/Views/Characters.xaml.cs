using Microsoft.Extensions.DependencyInjection;
using PieceofTheater.Lib.ViewModels;
using PieceofTheater.Lib.DependencyInjection;
using System.Windows.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PieceOfTheater.Wpf.Views
{
    public sealed partial class Characters : Grid
    {
        public Characters()
        {
            this.InitializeComponent();
            var container = ApplicationServiceProvider.Instance;// ((App)App.Current).;
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(ICharactersViewModel));
        }
    }
}
