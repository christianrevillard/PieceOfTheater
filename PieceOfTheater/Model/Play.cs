using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PieceOfTheater.Model
{
    public interface IPlayModel {
        string Title { get; }
        List<Character> Characters { get; }
        List<Act> Acts { get; }
        void Parse(string text);
    }

    public class Play :IPlayModel
    {
        public string Title { get; set; }
        public List<Character> Characters { get; } = new List<Character>();
        public List<Act> Acts { get; } = new List<Act>();


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

                Act newAct = new Act();
                Scene newScene = new Scene();
                if (newAct.ParseTitle(textLine))
                {
                    Acts.Add(newAct);
                }
                else if (newScene.ParseTitle(textLine))
                {
                    if (!Acts.Any())
                        Acts.Add(newAct);
                    Acts.Last().Elements.Add(newScene);
                }
                else
                {
                    if (!Acts.Any())
                        Acts.Add(newAct);
                    if (!Acts.Last().Elements.Any())
                        Acts.Last().Elements.Add(newScene);
                    // handle adding lines directly to Act (Prologue..., act with one unnamed scene)
                    Acts.Last().Elements.Last().Elements.Add(new Line(lineRegex, textLine));
                }

            }

            // parse line by line
            // ActeTitle?
            // SceneTitle? or no scene...
            // CharacterLine
            // Didascalie

        }
    }
}
