
using PieceofTheater.Lib.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PieceofTheater.Lib.Model
{
    public interface IPlayModel {
        string Title { get; }
        List<Act> Acts { get; }
        string SelectedCharacterName { get; }
        void Parse(string text);
    }

    public class Play :IPlayModel
    {
        public string Title { get; set; }
        public List<Character> Characters { get; } = new List<Character>();
        public List<Act> Acts { get; } = new List<Act>();
        public string SelectedCharacterName { get; set; }


        public void Parse(string text) 
        {
            Acts.Clear();

            var textLines = text.Split('\n','\r').ToList();

            foreach (var textLine in textLines)             
            {
                if (string.IsNullOrWhiteSpace(textLine))
                    continue;

                // move to the classes...
                var lineRegex = @"^([^:+(]*) *(\(.+\))? *: *([^ ].*)$";

                Act newAct = new Act() {};
                Scene newScene = new Scene() {};
                if (newAct.ParseTitle(textLine))
                {
                    Acts.Add(newAct);
                }
                else if (newScene.ParseTitle(textLine))
                {
                    if (!Acts.Any())
                    {
                        Acts.Add(newAct);
                    }
                    Acts.Last().Elements.Add(newScene);
                }
                else
                {
                    if (!Acts.Any())
                    {
                        Acts.Add(newAct);
                    }
                    if (!Acts.Last().Elements.Any())
                    {
                        Acts.Last().Elements.Add(newScene);
                    }
                    Acts.Last().Elements.Last().Elements.Add(new Line(lineRegex, textLine));
                }
            }
        }
    }
}
