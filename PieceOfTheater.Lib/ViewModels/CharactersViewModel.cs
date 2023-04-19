using PieceofTheater.Lib.DependencyInjection;
using PieceofTheater.Lib.Model;
using PieceOfTheater.Lib.MVVM;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PieceofTheater.Lib.ViewModels
{
    public class CharacterDetails
    {
        public string CharacterName { get; set; }
        public List<Act> CharacterRole { get; set; }
        public int SceneCount { get; set; }
        public int LineCount { get; set; }
        public int WordCount { get; set; }
    }

    public interface ICharactersViewModel
    {
        List<CharacterDetails> Characters { get; }
        CharacterDetails SelectedCharacter { get; }
        ICommand SelectCharacter { get; }
//        void SelectCharacter(string characterName);
    }

    internal class CharactersViewModel : BaseViewModel, ICharactersViewModel
    {
        IPlayModel _model;
 
        public CharactersViewModel(IPlayModel playModel, IMediator mediator):base(mediator)
        {
           _model = playModel;

            //_model.TextParsed += (source, e) =>
            //{
            //    var parsed = _model.Acts.SelectMany(a => a.Elements.SelectMany(s => s.Elements.Select(line => new { Scene = s, Line = line })).Select(line => 
            //        new
            //        {
            //            Character = line.Line.Character,
            //            Line = line.Line,
            //            Scene = line.Scene,
            //            Act = a
            //        }));

            //    StringBuilder output = new StringBuilder();

            //    foreach (var group in parsed.GroupBy(p => p.Character)) 
            //    {
            //        output.Append(group.Key);
            //        output.Append(": ");
            //        output.Append(System.Environment.NewLine);
            //        output.Append($"{group.Count()} répliques dans {group.Select(a=>a.Scene).Distinct().Count()} scènes");
            //        output.Append(System.Environment.NewLine);
            //        output.Append(System.Environment.NewLine);
            //    }

            //    Output = output.ToString();
            //};        
       }

        public override void OnAppearing()
        {
            base.OnAppearing();

            List<CharacterDetails> characters = new List<CharacterDetails>();

            var parsed = _model.Acts.SelectMany(a => a.Elements.SelectMany(s => s.Elements.Select(line => new { Scene = s, Line = line })).Select(line =>
                        new
                        {
                            Character = line.Line.Character,
                            Line = line.Line,
                            Scene = line.Scene,
                            Act = a
                        }));

            foreach (var group in parsed.GroupBy(p => p.Character))
            {
                characters.Add(new CharacterDetails()
                {
                    CharacterName = group.Key,
                    SceneCount = group.Select(a => a.Scene).Distinct().Count(),
                    LineCount = group.Count(),
                    WordCount = group.Sum(line => line.Line.Text.Split(' ').Count()),
                    CharacterRole = _model.Acts.Select(act =>
                    {
                        var characterAct = new Act() { Title = act.Title };
                        characterAct.Elements.AddRange(act.Elements.Select(scene =>
                        {
                            var characterScene = new Scene() { Title = scene.Title };
                            characterScene.Elements.AddRange(
                                scene.Elements
                                .Where(line => line.Character == group.Key)
                                .Select(line => new Line() { Character = line.Character, Text = line.Text, Comment = line.Comment }));
                            return characterScene;
                        }).Where(scene => scene.Elements.Any()).ToList());
                        return characterAct;
                    }).Where(act => act.Elements.Any()).ToList()
                });
            }

            Characters = characters;
        }

        private List<CharacterDetails> _characters = new List<CharacterDetails>();
        public List<CharacterDetails> Characters { get { return _characters; } set { Set(ref _characters, value); } }
        private CharacterDetails _selectedCharacter;
        public CharacterDetails SelectedCharacter { get { return _selectedCharacter; } private set { Set(ref _selectedCharacter, value); } }
        private ICommand _selectCharacter;

        public ICommand SelectCharacter
        {
            get
            {
                return _selectCharacter ?? (_selectCharacter = new RelayCommand(
                    obj => { return true; },
                    obj =>
                    {
                        SelectedCharacter = Characters.FirstOrDefault(c => c.CharacterName == (string)obj);
                    }));
            }
        }
    }

}
