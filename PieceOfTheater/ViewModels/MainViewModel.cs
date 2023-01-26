using PieceOfTheater.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace PieceOfTheater.ViewModels
{
    public interface IMainViewModel
    {
        string Output { get; }

        ICommand Process { get; }
    }


    internal class MainViewModel : BaseViewModel, IMainViewModel
    {
        IPlayModel _model;
        public MainViewModel(IPlayModel playModel) 
        {
            _model = playModel;
        }

        private string _input = @"I. L'arc-en-ciel

1. Le vert
Rico: c'est tout vert
Gai: Ben oui
Rico: c'est rigolo 'ben oui'
Gai: Ben oui

2. Le rouge
Rico: tiens, voilà berek.
Gai: ben oui.
berek: bon j'ai trouvé quatre solutions possibles à la jaune
Rico: prout.On rouge, là.

II.Acteurs et Actrices

1. la triche
Zab: j'ai refait le classement, berek est dernier
Rico: c'est pas bien
Gai: Ben non
berek (dépité): y'a de la triche, je m'en vais

2. début de la fin
Rico: tiens, plus de berek
Gai (gai): ben non.
Zab: bon je vais me coucher

3. fin de la fin
Rico (fatigué): tiens, plus de zab
Gai (expressif): ben non.";
        public string Input { get { return _input; } set { Set(ref _input, value); } }

        private string _output = "";
        public string Output { get { return _output; } set { Set(ref _output, value); } }


        public ICommand Process { get
            {
                return new RelayCommand(
                    obj => { return true; },
                    obj =>
                {
                    _model.Parse(Input);

                    Output = $"Actes: {_model.Acts.Count}\r\n" +
                        $"Scenes: {_model.Acts.SelectMany(a => a.Elements).Count()}\r\n" +
                        $"Personnages: {string.Join("; ", _model.Acts.SelectMany(a => a.Elements.SelectMany(s => s.Elements).Select(line => line.Character)).Distinct())}\r\n" +
                        $"";
                });
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged; 
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
    //private void Button_Click(object sender, RoutedEventArgs e)
    //{
    //    var play = new Play();
    //    play.Parse(Input.Text);

    //    Ouput.Text =
    //        $"Actes: {play.Acts.Count}\r\n" +
    //        $"Scenes: {play.Acts.SelectMany(a => a.Elements).Count()}\r\n" +
    //        $"Personnages: {string.Join("; ", play.Acts.SelectMany(a => a.Elements.SelectMany(s => s.Elements).Select(line => line.Character)).Distinct())}\r\n" +
    //        $"";
    //}

}