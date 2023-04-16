using PieceOfTheater.Model;
using System.Linq;
using System.Text;

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
                StringBuilder output = new StringBuilder();

                output.Append($"Actes: {_model.Acts.Count}\r\n" +
$"Scenes: {_model.Acts.SelectMany(a => a.Elements).Count()}\r\n" +
$"Personnages: {string.Join("; ", _model.Acts.SelectMany(a => a.Elements.SelectMany(s => s.Elements).Select(line => line.Character)).Distinct())}\r\n" +
$"");
                output.Append(System.Environment.NewLine);
                output.Append(System.Environment.NewLine);


                _model.Acts.ForEach(a =>
                {
                    output.Append($"Acte: {a.Title}");
                    output.Append(System.Environment.NewLine);
                    a.Elements.ForEach(s =>
                    {
                        output.Append($"Scene: {s.Title}");
                        output.Append(System.Environment.NewLine);
                    });
                    output.Append(System.Environment.NewLine);
                });

                Output = output.ToString();

            };
        }

        private string _output = "";
        public string Output { get { return _output; } set { Set(ref _output, value); } }

    }
}
