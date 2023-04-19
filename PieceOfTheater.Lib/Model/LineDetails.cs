using System;
using System.Collections.Generic;
using System.Text;

namespace PieceOfTheater.Lib.Model
{
    public class LineDetails
    {
        public int ActIndex { get; set; }
        public int SetIndex { get; set; }
        public string CharacterName{ get; set; }
        public string Text { get; set; }
        public int WordCount { get; set; }
    }
}
