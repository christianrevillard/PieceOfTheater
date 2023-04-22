using PieceofTheater.Lib.DependencyInjection;
using PieceofTheater.Lib.Model;
using PieceOfTheater.Lib.MVVM;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

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
    }

    internal class CharactersViewModel : BaseViewModel, ICharactersViewModel
    {
        IPlayModel _model;
 
        public CharactersViewModel(IPlayModel playModel, IMediator mediator):base(mediator)
        {
           _model = playModel;
           
       }

        private int CountWord(string text) 
        {
            int wordCount = 0, index = 0;

            while (index < text.Length && !char.IsLetterOrDigit(text[index]))
                index++;

            while (index < text.Length)
            {
                while (index < text.Length && char.IsLetterOrDigit(text[index]))
                    index++;

                wordCount++;

                while (index < text.Length && !char.IsLetterOrDigit(text[index]))
                    index++;
            }

            return wordCount;
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
                    WordCount = group.Sum(line => CountWord(line.Line.Text)),
                    CharacterRole = _model.Acts.Select(act =>
                    {
                        var characterAct = new Act() { 
                            Title = act.Title,
                            Label = act.Label,
                            Key = act.Key
                        };
                        characterAct.Elements.AddRange(act.Elements.Select(scene =>
                        {
                            var characterScene = new Scene() { 
                                Title = scene.Title,
                                Label = scene.Label,
                                Key = scene.Key
                            };
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

            TotalWordCount = Characters.Sum(c => c.WordCount);
            TotalLinesCount = Characters.Sum(c => c.LineCount);
            TotalSceneCount = Characters.Sum(c => c.SceneCount);
            UpdateTotalTime();
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

        private int _totalWordCount;
        public int TotalWordCount { get { return _totalWordCount; } set { Set(ref _totalWordCount, value); } }

        private int _totalLinesCount;
        public int TotalLinesCount { get { return _totalLinesCount; } set { Set(ref _totalLinesCount, value); } }

        private int _totalSceneCount;
        public int TotalSceneCount { get { return _totalSceneCount; } set { Set(ref _totalSceneCount, value); } }

        private string _totalTime ;
        public string TotalTime { get { return _totalTime; } set { Set(ref _totalTime, value); } }

        private int _wordsPerMinute = 150;
        public int WordsPerMinute { get { return _wordsPerMinute; } set { Set(ref _wordsPerMinute, value); UpdateTotalTime(); } }

        private void UpdateTotalTime()
        {
            if (WordsPerMinute <= 0)
                return;

            int totalSeconds = TotalWordCount*60/WordsPerMinute;
            int hours = totalSeconds/3600;
            int minutes = (totalSeconds%3600) / 60;
            int seconds= (totalSeconds%60);

            StringBuilder time= new StringBuilder();
            if (hours > 0) 
            {
                time.Append($"{hours} heure{(hours > 1 ? "s" : "")} ");
            }
            if (minutes > 0)
            {
                time.Append($"{minutes} minute{(minutes > 1 ? "s" : "")} ");
            }
            if (seconds > 0)
            {
                time.Append($"{seconds} seconde{(seconds> 1 ? "s" : "")} ");
            }

            TotalTime = time.ToString();
        }
    }
}
