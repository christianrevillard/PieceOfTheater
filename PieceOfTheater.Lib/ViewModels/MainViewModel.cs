using PieceofTheater.Lib.Model;
using System;
using System.Windows.Input;

namespace PieceofTheater.Lib.ViewModels
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

        private bool _playTextVisibility = true;
        public bool PlayTextVisibility { get { return _playTextVisibility; } set { Set(ref _playTextVisibility, value); } }

        private bool _actsAndScenesVisibility = false;
        public bool ActsAndScenesVisibility { get { return _actsAndScenesVisibility; } set { Set(ref _actsAndScenesVisibility, value); } }

        private bool _charactersVisibility = false;
        public bool CharactersVisibility { get { return _charactersVisibility; } set { Set(ref _charactersVisibility, value); } }

        private bool _scenesVisibility = false;
        public bool ScenesVisibility { get { return _scenesVisibility; } set { Set(ref _scenesVisibility, value); } }

        private bool _tableVisibility = false;
        public bool TableVisibility { get { return _tableVisibility; } set { Set(ref _tableVisibility, value); } }

        private void CloseAll() {
            PlayTextVisibility = false;
            ActsAndScenesVisibility = false;
            CharactersVisibility = false;
            ScenesVisibility = false;
            TableVisibility = false;
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
                        PlayTextVisibility = true;
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
                        ActsAndScenesVisibility = true;
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
                        CharactersVisibility = true;
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
                        ScenesVisibility = true;
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
                        TableVisibility = true;
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
}