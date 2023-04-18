using Microsoft.Extensions.DependencyInjection;
using PieceofTheater.Lib.DependencyInjection;
using PieceofTheater.Lib.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PieceOfTheater.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage :  Windows.UI.Xaml.Controls.Page
    {
        //MainPage.xaml.cs 
        public MainPage()
        {
            this.InitializeComponent();
            var container = ApplicationServiceProvider.Instance;
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(IMainViewModel));
        }
    }
}
