using PieceofTheater.Lib.Model;
using PieceOfTheater.Lib.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PieceofTheater.Lib.ViewModels
{
    public interface IScenesViewModel
    {
    }

    public class SelectedCharacter
    {
        public string CharacterName { get; set; }

        private bool _isSelected; 
        public bool IsSelected { get { return _isSelected; } set {_isSelected = value; if (OnSelected != null) { OnSelected(); } } }

        public Action OnSelected { get; set; }
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

            Characters = _model.Acts.SelectMany(a => a.Elements.SelectMany(s => s.Elements.Select(line => new { Scene = s, Line = line })).Select(line => line.Line.Character))
                .Distinct()
                .Select(characterName => new SelectedCharacter() { 
                    CharacterName = characterName, 
                    IsSelected = false,
                    OnSelected = UpdatePlayableScenes 
                })
                .ToList();
        }

        private string _output = "";
        public string Output { get { return _output; } set { Set(ref _output, value); } }


        private List<SelectedCharacter> _characters = new List<SelectedCharacter>() ;
        public List<SelectedCharacter>  Characters { get { return _characters; } set { Set(ref _characters, value); } }

        private ICommand _invertSelection;

        public ICommand InvertSelection
        {
            get
            {
                return _invertSelection ?? (_invertSelection = new RelayCommand(
                    obj => { return true; },
                    obj =>
                    {
                        Characters = Characters.Select(character => new SelectedCharacter() { 
                            CharacterName = character.CharacterName,
                            IsSelected = !character.IsSelected,
                            OnSelected = character.OnSelected
                        }).ToList();
                        UpdatePlayableScenes();
                    }));
            }
        }

        private List<Act> _playableScenes = new List<Act>() ;
        public List<Act> PlayableScenes{ get { return _playableScenes; } set { Set(ref _playableScenes, value); } }

        private List<Act> _unplayableScenes = new List<Act>() ;
        public List<Act> UnplayableScenes { get { return _unplayableScenes; } set { Set(ref _unplayableScenes, value); } }

        void UpdatePlayableScenes()
        {
            PlayableScenes = _model.Acts.Select(act =>
            {
                var playableAct = new Act() { Title = act.Title };
                playableAct.Elements.AddRange(act.Elements.Where(scene => scene.Elements.All(line => Characters.Any(c => c.IsSelected && c.CharacterName == line.Character))));
                return playableAct;
            }).Where(act => act.Elements.Any()).ToList();

            UnplayableScenes = _model.Acts.Select(act =>
            {
                var unplayableAct = new Act() { Title = act.Title };
                unplayableAct.Elements.AddRange(
                    act.Elements.Select(scene =>
                    {
                        var unplayableScene = new Scene() { Title = scene.Title };

                        List<string> missingCharacters = new List<string>();

                        foreach (var character in scene.Elements.Select(line => line.Character).Distinct()) 
                        {
                            if (!Characters.Any(c => c.IsSelected && c.CharacterName == character)) 
                            {
                                missingCharacters.Add(character);
                            }
                        }

                        if (!missingCharacters.Any())
                            return unplayableScene;

                        unplayableScene.Elements.Add(new Line() {Text = $"Il manque {String.Join(",", missingCharacters.Distinct())}" });
                        return unplayableScene;
                    }).Where(scene => scene.Elements.Any()).ToList()


                    );
                return unplayableAct;
            }).Where(act => act.Elements.Any()).ToList();

        }
    }
}
