using PieceofTheater.Lib.Model;
using PieceOfTheater.Lib.MVVM;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PieceofTheater.Lib.ViewModels
{
    public interface IActsAndScenesViewModel
    {
    }

    internal class ActsAndScenesViewModel : BaseViewModel, IActsAndScenesViewModel
    {
        IPlayModel _model;

        public ActsAndScenesViewModel(IPlayModel playModel, IMediator mediator) : base(mediator)
        {
            _model = playModel;
        }

        private List<Act> _acts = new List<Act>();
        public List<Act> Acts { get { return _acts; } set { Set(ref _acts, value);  } }

        private List<string> _pureComments = new List<string>();
        public List<string> PureComments { get { return _pureComments; } set { Set(ref _pureComments, value); } }

        public override void OnAppearing()
        {
            base.OnAppearing();

            Acts = _model.Acts;
            PureComments = _model
                .Acts
                .SelectMany(act => act
                    .Elements
                    .SelectMany(scene => scene
                        .Elements.Where(line => line.Character == "" && line.Text=="").Select(line=>line.Comment)))
                .ToList();
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            Acts = null;
            PureComments = null;
        }
    }
}
