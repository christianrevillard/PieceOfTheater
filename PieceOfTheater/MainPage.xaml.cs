using PieceOfTheater.Model;
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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var play = new Play();
            play.Parse(Input.Text);

            Ouput.Text =
                $"Actes: {play.Acts.Count}\r\n" +
                $"Scenes: {play.Acts.SelectMany(a=>a.Elements).Count()}\r\n" +
                $"Personnages: {string.Join("; ",play.Acts.SelectMany(a => a.Elements.SelectMany(s=>s.Elements).Select(line=>line.Character)).Distinct())}\r\n" +
                $"";
        }
    }
}
