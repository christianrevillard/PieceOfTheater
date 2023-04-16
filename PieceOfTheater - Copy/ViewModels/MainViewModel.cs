using PieceOfTheater.Model;
using System;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace PieceOfTheater.ViewModels
{
    public interface IMainViewModel
    {
    }

    internal class MainViewModel : BaseViewModel, IMainViewModel
    {
        IPlayModel _model;
        public MainViewModel(IPlayModel playModel) 
        {
            _model = playModel;
        }

        private Visibility _playTextVisibility = Visibility.Visible;
        public Visibility PlayTextVisibility { get { return _playTextVisibility; } set { Set(ref _playTextVisibility, value); } }

        private Visibility _actsAndScenesVisibility = Visibility.Collapsed;
        public Visibility ActsAndScenesVisibility { get { return _actsAndScenesVisibility; } set { Set(ref _actsAndScenesVisibility, value); } }

        private Visibility _charactersVisibility = Visibility.Collapsed;
        public Visibility CharactersVisibility { get { return _charactersVisibility; } set { Set(ref _charactersVisibility, value); } }

        private Visibility _scenesVisibility = Visibility.Collapsed;
        public Visibility ScenesVisibility { get { return _scenesVisibility; } set { Set(ref _scenesVisibility, value); } }

        private Visibility _tableVisibility = Visibility.Collapsed;
        public Visibility TableVisibility { get { return _tableVisibility; } set { Set(ref _tableVisibility, value); } }

        private void CloseAll() {
            PlayTextVisibility = Visibility.Collapsed;
            ActsAndScenesVisibility = Visibility.Collapsed;
            CharactersVisibility = Visibility.Collapsed;
            ScenesVisibility = Visibility.Collapsed;
            TableVisibility = Visibility.Collapsed;
        }

        public ICommand OpenPlayText
        {
            get
            {
                return new RelayCommand(
                    obj => { return true; },
                    obj =>
                    {
                        CloseAll();
                        PlayTextVisibility = Visibility.Visible;
                    });
            }
        }

        public ICommand OpenActAndScenes
        {
            get
            {
                return new RelayCommand(
                    obj => { return true; },
                    obj =>
                    {
                        CloseAll();
                        ActsAndScenesVisibility = Visibility.Visible;
                    });
            }
        }

        public ICommand OpenCharacters
        {
            get
            {
                return new RelayCommand(
                    obj => { return true; },
                    obj =>
                    {
                        CloseAll();
                        CharactersVisibility = Visibility.Visible;
                    });
            }
        }

        public ICommand OpenScenes
        {
            get
            {
                return new RelayCommand(
                    obj => { return true; },
                    obj =>
                    {
                        CloseAll();
                        ScenesVisibility = Visibility.Visible;
                    });
            }
        }

        public ICommand OpenTable
        {
            get
            {
                return new RelayCommand(
                    obj => { return true; },
                    obj =>
                    {
                        CloseAll();
                        TableVisibility = Visibility.Visible;
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