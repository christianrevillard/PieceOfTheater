using PieceofTheater.Lib.Model;
using System.Windows.Input;
using PieceOfTheater.Lib.MVVM;

namespace PieceofTheater.Lib.ViewModels
{
  
    public interface IMainViewModel
    {
    }

    internal class MainViewModel : BaseViewModel, IMainViewModel
    {
        IPlayModel _model;
        IMediator _mediator;
        public MainViewModel(IPlayModel playModel, IMediator mediator) : base(mediator)
        {
            _model = playModel;
            _mediator = mediator;
            _mediator.Publish("Appearing", typeof(IPlayTextViewModel));
        }
        private void CloseAll() {
            _mediator.Publish("Disappearing");
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
                        _mediator.Publish("Appearing", typeof(IPlayTextViewModel));
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
                        _mediator.Publish("Appearing", typeof(IActsAndScenesViewModel));
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
                        _mediator.Publish("Appearing", typeof(ICharactersViewModel));
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
                        _mediator.Publish("Appearing", typeof(IScenesViewModel));
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
                        _mediator.Publish("Appearing", typeof(ITableViewModel));
                    });
            }
        }
    }
}