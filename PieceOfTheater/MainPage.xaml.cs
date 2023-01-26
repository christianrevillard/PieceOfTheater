using Microsoft.Extensions.DependencyInjection;
using PieceOfTheater.Model;
using PieceOfTheater.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PieceOfTheater
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
            var container = ((App)App.Current).Container;
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(IMainViewModel));
        }
    }
}
