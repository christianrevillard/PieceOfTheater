using Microsoft.Extensions.DependencyInjection;
using PieceofTheater.Lib.ViewModels;
using System.Windows.Controls;
using PieceofTheater.Lib.DependencyInjection;


// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PieceOfTheater.Wpf.Views
{
    public sealed partial class ActsAndScenes : Grid
    {
        public ActsAndScenes()
        {
            this.InitializeComponent();
            var container = ApplicationServiceProvider.Instance;// ((App)App.Current).;
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(IActsAndScenesViewModel));
        }
    }
}
