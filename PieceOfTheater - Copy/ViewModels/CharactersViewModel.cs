using PieceOfTheater.Model;
using System.Linq;
using System.Text;

namespace PieceOfTheater.ViewModels
{
    public interface ICharactersViewModel
    {
    }


    internal class CharactersViewModel : BaseViewModel, ICharactersViewModel
    {
        IPlayModel _model;
        public CharactersViewModel(IPlayModel playModel)
        {
            _model = playModel;

            _model.TextParsed += (source, e) =>
            {
                var parsed = _model.Acts.SelectMany(a => a.Elements.SelectMany(s => s.Elements.Select(line => new { Scene = s, Line = line })).Select(line => 
                    new
                    {
                        Character = line.Line.Character,
                        Line = line.Line,
                        Scene = line.Scene,
                        Act = a
                    }));

                StringBuilder output = new StringBuilder();

                foreach (var group in parsed.GroupBy(p => p.Character)) 
                {
                    output.Append(group.Key);
                    output.Append(": ");
                    output.Append(System.Environment.NewLine);
                    output.Append($"{group.Count()} répliques dans {group.Select(a=>a.Scene).Distinct().Count()} scènes");
                    output.Append(System.Environment.NewLine);
                    output.Append(System.Environment.NewLine);
                }

                Output = output.ToString();
            };

        }

        private string _output = "";
        public string Output { get { return _output; } set { Set(ref _output, value); } }

    }
}
