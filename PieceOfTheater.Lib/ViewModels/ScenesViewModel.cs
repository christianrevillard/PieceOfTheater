using PieceofTheater.Lib.Model;
using PieceOfTheater.Lib.MVVM;
using System.Linq;

namespace PieceofTheater.Lib.ViewModels
{
    public interface IScenesViewModel
    {
    }


    internal class ScenesViewModel : BaseViewModel, IScenesViewModel
    {
        IPlayModel _model;
        public ScenesViewModel(IPlayModel playModel, IMediator mediator) : base(mediator)
        {
            _model = playModel;
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            Output = $"Actes: {_model.Acts.Count}\r\n" +
    $"Scenes: {_model.Acts.SelectMany(a => a.Elements).Count()}\r\n" +
    $"Personnages: {string.Join("; ", _model.Acts.SelectMany(a => a.Elements.SelectMany(s => s.Elements).Select(line => line.Character)).Distinct())}\r\n" +
    $"";
        }

        private string _output = "";
        public string Output { get { return _output; } set { Set(ref _output, value); } }

    }
}
