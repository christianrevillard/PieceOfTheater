using PieceofTheater.Lib.Model;
using PieceOfTheater.Lib.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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


    public class ActTable { 
        public string Title { get; set; }
        public List<ColumnElement> Scenes { get; set; }
        public List<CharacterScenes> Characters { get; set; }
    }

    internal class TableViewModel : BaseViewModel, ITableViewModel
    {
        int _singleWidth=60;
        int _minActWidth = 150;
        int _firstCoolumnWidth=100;

        IPlayModel _model;
        public TableViewModel(IPlayModel playModel, IMediator mediator) : base(mediator)
        {
            _model = playModel;
        }

        public override void OnAppearing()
        {
            _model.Acts.ForEach(act =>
            {
                var characters = act.Elements.SelectMany(s => s.Elements
                .Where(line=>line.Character != "")
                .Select(line => line.Character)).Distinct()
                .OrderBy(c=>c)
                .ToList();

                List<ColumnElement> scenes = new List<ColumnElement>();
                List<CharacterScenes> characterScenes = new List<CharacterScenes>();

                foreach (var character in characters)
                {
                    characterScenes.Add(new CharacterScenes { CharacterName = character, Scenes = new List<ColumnElement>() });
                }

                scenes.Add(new ColumnElement { Width = _firstCoolumnWidth, Text = "" });
                foreach (var characterScene in characterScenes)
                {
                    characterScene.Scenes.Add(new ColumnElement { Width = _firstCoolumnWidth, Text = characterScene.CharacterName });
                }

                
                int sceneWidth = Math.Max(act.Elements.Count() * _singleWidth, _minActWidth)/ act.Elements.Count();
                act.Elements.ForEach(scene =>
                {
                    if (scene.Elements.All(line=>string.IsNullOrEmpty(line.Character)))
                        return;

                    scenes.Add(new ColumnElement { Text = scene.IsDefined ? $"{scene.Label} {scene.Key}" : "", Width = sceneWidth });

                    foreach (var characterScene in characterScenes)
                    {
                        bool isInScene = scene.Elements.Any(line=>line.Character == characterScene.CharacterName);
                        characterScene.Scenes.Add(new ColumnElement { Width = sceneWidth, Text = isInScene ? "X" : "" });
                    }
                });

                Acts.Add(new ActTable() { 
                    Title = string.IsNullOrEmpty(act.Title)?"":$"{act.Label} {act.Key}: {act.Title}", 
                    Scenes = scenes,
                    Characters = characterScenes
                });

                Acts = Acts.ToList();
            });
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            Acts.Clear();
        }

        private List<ActTable> _acts = new List<ActTable>();
        public List<ActTable> Acts { get { return _acts; } set { Set(ref _acts, value); } }
    }
}
