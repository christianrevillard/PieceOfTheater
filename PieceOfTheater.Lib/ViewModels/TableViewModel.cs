using PieceofTheater.Lib.Model;
using PieceOfTheater.Lib.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PieceofTheater.Lib.ViewModels
{
    public interface ITableViewModel
    {
    }

    public class ColumnElement 
    {
        public string Text { get; set; }
        public int Width { get; set; }
    }

    public class CharacterScenes
    {
        public string CharacterName { get; set; }
        public List<ColumnElement> Scenes { get; set; }
    }

    internal class TableViewModel : BaseViewModel, ITableViewModel
    {
        int _singleWidth=30;
        int _minActWidth = 100;
        int _firstCoolumnWidth=100;

        IPlayModel _model;
        public TableViewModel(IPlayModel playModel, IMediator mediator) : base(mediator)
        {
            _model = playModel;
        }

        public override void OnAppearing()
        {

            var characters = _model.Acts.SelectMany(a => a.Elements.SelectMany(s => s.Elements.Select(line => line.Character))).Distinct().ToList();

            List<ColumnElement> acts = new List<ColumnElement>();
            List<ColumnElement> scenes = new List<ColumnElement>();
            List<CharacterScenes> characterScenes = new List<CharacterScenes>();

            foreach (var character in characters) 
            {
                characterScenes.Add(new CharacterScenes { CharacterName = character, Scenes = new List<ColumnElement>() });
            }

            acts.Add(new ColumnElement { Width = _firstCoolumnWidth, Text = "" });
            scenes.Add(new ColumnElement { Width = _firstCoolumnWidth, Text = "" });
            foreach (var characterScene in characterScenes)
            {
                characterScene.Scenes.Add(new ColumnElement{ Width=_firstCoolumnWidth, Text=characterScene.CharacterName});
            }

            _model.Acts.ForEach(act =>
            {
                int actWidth = Math.Max(act.Elements.Count()*_singleWidth, _minActWidth);
                int sceneWidth = actWidth/ act.Elements.Count();
                acts.Add(new ColumnElement{Text = act.Title, Width= actWidth });
                act.Elements.ForEach(scene =>
                {
                    scenes.Add(new ColumnElement{Text = scene.Title, Width= sceneWidth});

                    foreach (var characterScene in characterScenes)
                    {
                        bool isInScene = scene.Elements.Any(line=>line.Character == characterScene.CharacterName);
                        characterScene.Scenes.Add(new ColumnElement { Width = sceneWidth, Text = isInScene?"X":"" });
                    }
                });
            });

            Acts = acts;
            Scenes = scenes;
            Characters = characterScenes;
        }

        private List<ColumnElement> _acts = new List<ColumnElement>();
        public List<ColumnElement> Acts { get { return _acts; } set { Set(ref _acts, value); } }

        private List<ColumnElement> _scenes= new List<ColumnElement>();
        public List<ColumnElement> Scenes { get { return _scenes; } set { Set(ref _scenes, value); } }

        private List<CharacterScenes> _characters = new List<CharacterScenes>();
        public List<CharacterScenes> Characters { get { return _characters; } set { Set(ref _characters, value); } } 

    }
}
