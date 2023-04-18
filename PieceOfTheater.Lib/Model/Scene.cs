using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceofTheater.Lib.Model
{
    public class Scene : Subdivision<Line>
    {
        public override bool ParseTitle(string line)
        {
           // var sceneRegex = @"^((?:SC.{1,2}NE)|(?:))(?: *)(-?[0-9A-Z]+\.)(?: *)(.*)$";

            if (Parse("^(SC.{1,2}NE)(?: *)(-?[0-9A-Z]+\\.)(?: *)(.*)$", line))
                return true;

            if (Parse("^()(-?[0-9A-Z]+\\.)(?: *)(.*)$", line))
                return true;

            return false;
        }
    }
}
