using PieceOfTheater.Model;
using System.Linq;

namespace PieceOfTheater.ViewModels
{
    public interface IActsAndScenesViewModel
    {
    }


    internal class ActsAndScenesViewModel : BaseViewModel, IActsAndScenesViewModel
    {
        IPlayModel _model;

        public ActsAndScenesViewModel(IPlayModel playModel)
        {
            _model = playModel;

            _model.TextParsed += (source, e) =>
            {

                Output = $"Actes: {_model.Acts.Count}\r\n" +
        $"Scenes: {_model.Acts.SelectMany(a => a.Elements).Count()}\r\n" +
        $"Personnages: {string.Join("; ", _model.Acts.SelectMany(a => a.Elements.SelectMany(s => s.Elements).Select(line => line.Character)).Distinct())}\r\n" +
        $"";
            };
        }

        private string _output = "";
        public string Output { get { return _output; } set { Set(ref _output, value); } }

    }
}
