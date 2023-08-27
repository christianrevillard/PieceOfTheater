namespace PieceofTheater.Lib.Model
{
    public class Scene : Subdivision<Line>
    {
        public override bool ParseTitle(string line)
        {
           // var sceneRegex = @"^((?:SC.{1,2}NE)|(?:))(?: *)(-?[0-9A-Z]+\.)(?: *)(.*)$";

            if (Parse("^(SC.{1,2}NE)(?: *)(-?[0-9A-Z]+)(?: *[ :.] *)(.*)$", line))
                return true;

            if (Parse("^()(-?[0-9A-Z]{1,2})(?:[.] *)(.*)$", line))
                return true;

            return false;
        }
    }
}
